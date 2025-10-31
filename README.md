# LocalizationHelper for Unity

Easy async access to localized strings with callbacks — no need to handle `AsyncOperationHandle` manually.

---

## 🔧 Features
- Fetch localized strings by table and key  
- Simple callback-based API  
- Support for single keys and string arrays  

---

## 💡 Example
```csharp
LocalizationHelper.EasyLocalize("UI_Texts", "PlayButton", value =>
{
    playButton.text = value;
});

LocalizationHelper.EasyLocalizeArray("UI_Texts", new[] { "Yes", "No", "Cancel" }, results =>
{
    yes.text = results[0];
    no.text = results[1];
    cancel.text = results[2];
});
