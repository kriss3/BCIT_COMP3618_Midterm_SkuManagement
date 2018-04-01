using OrpSkuViewer.View;
using System.Windows;

namespace OrpSkuViewer.Service
{
    public class DialogService : IDialogService
    {
        private Window _orpSkuViewerDetailView = null;

        public DialogService()
        {
            
        }

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
