using OrpSkuRepository.Interface;
using OrpSkuViewer.Service;
using OrpSkuViewer.SharedObjects;
using OrpSkuViewer.View.Extensions;
using OrpSkuViewer.View.Messages;
using OrpSkuViewer.View.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace OrpSkuViewer.ViewModel
{
    public class OrpSkuViewerViewModel : INotifyPropertyChanged
    {
        protected ISkuRepository _currentRepo;
        private ObservableCollection<OrpSku> _allSku;
        private OrpSku _selectedSku;
        private IDialogService _dialogService = null;

        public ObservableCollection<OrpSku> AllSku
        {
            get { return _allSku; }
            set
            {
                if (_allSku == value)
                    return;
                _allSku = value;
                raisePropertyChanged("AllSku");
            }
        }
        public OrpSku SelectedSku
        {
            get { return _selectedSku; }
            set
            {
                _selectedSku = value;
                raisePropertyChanged("SelectedSku");
            }
        }
        public ICommand EditCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public OrpSkuViewerViewModel(ISkuRepository repository, IDialogService dialogService)
        {
            _currentRepo = repository;
            _dialogService = dialogService;
            loadData();
            loadCommands();
            Messenger.Default.Register<UpdateListMessage>(this, onUpdateListMessageReceived);

        }

        private void loadData()
        {
            AllSku = _currentRepo.GetAllSku().ToObservableCollection();
        }

        private void loadCommands()
        {
            EditCommand = new CustomCommand(editOrpSku, canEditOrpSku);
            ClearCommand = new CustomCommand(clearAll, canClearAll);
            RefreshCommand = new CustomCommand(refreshAll, canRefreshAll);
        }

        private void onUpdateListMessageReceived(UpdateListMessage obj)
        {
            loadData();
            _dialogService.CloseDetailDialog();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void raisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands

        private void refreshAll(object obj)
        {
            _allSku = this._currentRepo.GetAllSku().ToObservableCollection();
        }

        private bool canRefreshAll(object obj)
        {
            return true;
        }

        private void clearAll(object obj)
        {
            this._allSku = new ObservableCollection<OrpSku>();
        }

        private bool canClearAll(object obj)
        {
            return true;
        }

        private void editOrpSku(object obj)
        {
            Messenger.Default.Send<OrpSku>(_selectedSku);
            _dialogService.ShowDetailDialog();
        }

        private bool canEditOrpSku(object obj)
        {
            if (SelectedSku != null)
                return true;
            return false;
        }

        #endregion Commands
    }
}