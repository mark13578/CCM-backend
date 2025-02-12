using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class IpController : ControllerBase
{
    [HttpGet("get-client-info")]
    public IActionResult GetClientInfo()
    {
        var clientIp = GetClientIpAddress(HttpContext);
        var country = GetCountryFromIp(clientIp);

        return Ok(new { IP = clientIp, Country = country });
    }

    private string GetClientIpAddress(HttpContext context)
    {
        string ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

        if (string.IsNullOrEmpty(ip))
        {
            ip = context.Connection.RemoteIpAddress?.ToString();
        }
        else
        {
            // X-Forwarded-For 可能包含多個 IP，取第一個
            ip = ip.Split(',').First().Trim();
        }

        return ip;
    }

    private string GetCountryFromIp(string ip)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync($"http://ip-api.com/json/{ip}").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                return data?.country ?? "Unknown";
            }
        }
        return "Unknown";

    }
}
