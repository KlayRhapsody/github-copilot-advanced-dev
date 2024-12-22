# 開發計畫

## 概述
這個開發計畫旨在建立一個簡單的活動管理系統，用於管理各種活動的資訊，包括活動名稱、展覽日期、售票開始日期、結束日期、描述和場次等。系統將提供 API 端點，讓使用者可以查看、新增、編輯和刪除活動，以及管理活動內的場次。

你只要幫我撰寫 Web API 就好

### 1. 設定專案環境

* 建立一個新的 ASP.NET Core 9 Web API 專案
* 設定專案的基本結構，包括 Controllers、Models 和 Services 資料夾

### 2. 建立 Models

* 建立 `Activity` 類別，包含以下屬性：
  * `Id` (int)
  * `Name` (string)
  * `ExhibitionDate` (DateTime)
  * `SaleStartDate` (DateTime)
  * `EndDate` (DateTime)
  * `Description` (string)
  * `Sessions` (List<Session>)

* 建立 `Session` 類別，包含以下屬性：
  * `Id` (int)
  * `Date` (DateTime)
  * `Location` (string)

### 3. 建立 Controllers

* 建立 `ActivitiesController` 類別，包含以下 API 端點：
  * `GET /activities` - 查看所有活動，支援分頁
  * `GET /activities/{id}` - 查看單一活動的詳細資訊
  * `POST /activities` - 新增活動
  * `PUT /activities/{id}` - 編輯活動
  * `DELETE /activities/{id}` - 刪除活動
  * `DELETE /activities/{id}/sessions/{sessionId}` - 刪除活動內的場次

### 4. 建立 Services

* 建立 `ActivityService` 類別，包含以下方法：
  * `GetAllActivities` - 取得所有活動
  * `GetActivityById` - 依據 ID 取得單一活動
  * `CreateActivity` - 新增活動
  * `UpdateActivity` - 編輯活動
  * `DeleteActivity` - 刪除活動
  * `DeleteSession` - 刪除活動內的場次

### 5. 設定資料儲存

* 使用 `static` 變數在記憶體中儲存活動資料
* 在 `ActivityService` 中管理這些資料

### 6. 實作 API 端點

* 在 `ActivitiesController` 中呼叫 `ActivityService` 的方法來實作各個 API 端點

### 7. 測試

* 使用 Postman 或其他 API 測試工具來測試各個 API 端點
* 確認所有功能正常運作，包括新增、編輯、刪除和查看活動

### 8. 文件

* 撰寫 API 文件，說明各個端點的使用方法和參數
* 提供範例請求和回應

### 9. 部署

* 部署到本地開發環境進行測試
* 確認所有功能在部署後正常運作

### 10. 維護

* 根據使用者反饋進行功能調整和修正
* 定期更新和優化程式碼