using Telerik.WinControls.UI.Localization;

public class CustomGridLocalizationProvider : RadGridLocalizationProvider
{
    public override string GetLocalizedString(string id)
    {
        switch (id)
        {
            case RadGridStringId.AddNewRowString:
                return "برای افزودن سطر جدید کلیک کنید"; // متن دلخواه شما
            default:
                return base.GetLocalizedString(id);
        }
    }
}
