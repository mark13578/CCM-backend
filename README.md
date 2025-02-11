<pre><code>

- ProxmoxManagementSystem.sln
  ├── WebAPI                   # 負責處理 HTTP 請求、身份驗證、授權
  │   └── Controllers
  ├── Core                     # 定義核心邏輯、接口（Interfaces）
  ├── Services                 # 業務邏輯層，負責 Proxmox API、VNC 管理
  │   └── ProxmoxService
  │   └── VNCService
  ├── Repository               # 資料存取層，與 DB 溝通
  ├── Models                   # 定義資料模型（DTOs, ViewModels, Entities）
  ├── Common                   # 共用元件（Utility, Helper, Exception Handling）
  ├── Infrastructure           # 系統基礎建設，例如日誌服務、API Client 等
  ├── LogService               # 獨立的日誌記錄模組，方便集中管理與擴展
  └── Tests                    # 單元測試與整合測試
</code></pre>

| 日期 | 項目 | 說明 |
| ---- | ---- | ---- |
| 2/12 | 新增命名 | 1. 新增名為CloudCoreManager的專案，並採用多層次架構下去撰寫，以利後續完整開發，串接大量不同的API。 |
| 2/12 | 新增功能API | 1. 新增Login/Register。<br>2. 新增JWT。<br>3. [規劃中]新增appid、appkey、appsecret。<br>4. 目前完成註冊API測試。 |

