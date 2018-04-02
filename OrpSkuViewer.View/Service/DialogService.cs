using OrpSkuViewer.View;
using System.Windows;

namespace OrpSkuViewer.Service
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Class to help handling opening and closing new form. New form will be passed details of SelectedSKU;
    /// </summary>
    public class DialogService : IDialogService
    {
        private Window _orpSkuViewerDetailView = null;
        
        public void CloseDetailDialog()
        {
            if (_orpSkuViewerDetailView != null)
                _orpSkuViewerDetailView.Close();
        }

        public void ShowDetailDialog()
        {
            _orpSkuViewerDetailView = new OrpSkuDetailView();
            _orpSkuViewerDetailView.ShowDialog();
        }
    }
}
