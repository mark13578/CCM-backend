# CloudCore Manager - 新一代虛擬機管理平台

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
| 2/12 | 新增功能權限角色 | 1. 新增SysMenu、SysRole、SysPermission、SysUserRole、SysRolePermission。<br>2. 新增邏輯：<br>- 確保程式有效，首先建立空的角色<br>- 權限操作可以增加的前提為：有選單資料，讀取其UUID，才能新增下面的操作。<br>- 空角色建立後，才能繼續往下針對該角色授予相關權限。<br>- 使用者可以增加多個角色，存入SysUserRole表中。<br>3. SysMenu為多層選單，可以將子階層存入parent_uuid作為上一層之連結。<br>4. 更新使用者群組權限。<br>- 個別使用者：預設直接指派空的UUID，作為個人用戶組。<br>- 企業使用者：會於匯入CSV 檔案時，客戶只需上傳姓名、帳號、密碼，並於寫入時orgid自動加入該組織UUID，以作為該企業之識別。<br>5. [規劃中]各企業組織底下根據使用者用戶組，授予不同API權限。 |


