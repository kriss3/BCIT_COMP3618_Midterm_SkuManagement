namespace OrpSkuViewer.Service
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Interface to support opening and closing new XAML form with detials on Selected SKU;
    /// </summary>
    public interface IDialogService
    {
        void CloseDetailDialog();
        void ShowDetailDialog();
    }
}
