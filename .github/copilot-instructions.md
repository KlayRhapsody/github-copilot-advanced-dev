

## 產生 /Models 目錄下的類別時，應遵守以下規定
* 類別所定義的屬性必須都加上合適的 DataAnnotations 屬性，例如：`[Required]`、`[StringLength(50)]`、`[Range(0, 100)]` 等。
* 產生 DTO 的類別時，類別名稱要以 Dto 結尾，例如：`UserDto`。


## 產生 /Controllers 目錄下的類別時，應遵守以下規定
* Action 方法的參數應該使用 DTO 類別，而不是直接使用 Entity 類別。
* Action 方法的回傳值應該使用 DTO 類別，而不是直接使用 Entity 類別。
* Action 的 Annotations 必須明確定義 Name
    - 例如：[HttpGet(Name = "GetWeatherForecast")]
    - 例如：[HttpPost(Name = "PostWeatherForecast")]
    - 例如：[HttpDelete("{date}", Name = "DeleteWeatherForecast")]
