using OrpSkuRepository.Interface;
using OrpSkuViewer.Service;
using OrpSkuViewer.SharedObjects;
using OrpSkuViewer.View.Extensions;
using OrpSkuViewer.View.Messages;
using OrpSkuViewer.View.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using OrpSkuViewer.View.Scheduler;

namespace OrpSkuViewer.ViewModel
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Main viewModel for the initial Window with a List of OrpSkus;
    /// This viewModel support Edit and Clear methods;
    /// This viewModel also is passing information of SelectedSku into the OrpSkuViewerDetailView;
    /// </summary>
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
        public ICommand LoadCommand { get; set; }
        public ICommand NewSkuCommand { get; set; }

        public OrpSkuViewerViewModel(ISkuRepository repository, IDialogService dialogService)
        {
            _currentRepo = repository;
            _dialogService = dialogService;
            loadData();
            loadCommands();
            Messenger.Default.Register<UpdateListMessage>(this, onUpdateListMessageReceived);
            Config.Run(this);
        }

        #region Private Methods
        //Uses Extension method as GetAllSku() returns IEnumerable collection;
        private void loadData()
        {
            AllSku = _currentRepo.GetAllSku().ToObservableCollection();
        }

        private void loadCommands()
        {
            EditCommand = new CustomCommand(editOrpSku, canEditOrpSku);
            ClearCommand = new CustomCommand(clearAll, canClearAll);
            LoadCommand = new CustomCommand(loadData, canLoadData);
            NewSkuCommand = new CustomCommand(createNewSku, canCreateNewSku);
        }

        private void onUpdateListMessageReceived(UpdateListMessage obj)
        {
            loadData();
            _dialogService.CloseDetailDialog();
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void raisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands

        private void loadData(object obj)
        {
            AllSku = this._currentRepo.GetAllSku().ToObservableCollection();
        }

        private bool canLoadData(object obj)
        {
            if(AllSku.Count == 0)
                return true;
            return false;
        }

        private void clearAll(object obj)
        {
            AllSku = new ObservableCollection<OrpSku>();
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

        private void createNewSku(object obj)
        {
            //create new OrpSku
            Messenger.Default.Send<OrpSku>(new OrpSku());
            _dialogService.ShowDetailDialog();
        }
        private bool canCreateNewSku(object obj)
        {
            if (SelectedSku != null)
                return true;
            return false;
        }
        #endregion Commands
    }
}