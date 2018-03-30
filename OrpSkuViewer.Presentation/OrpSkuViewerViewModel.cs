using OrpSkuRepository.Interface;
using OrpSkuViewer.SharedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrpSkuViewer.Presentation
{
    public class OrpSkuViewerViewModel : INotifyPropertyChanged
    {
        protected ISkuRepository _currentRepo;
        private IEnumerable<OrpSku> _allSku;
        private OrpSku _selectedSku;
        
        public IEnumerable<OrpSku> AllSku
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

        public OrpSkuViewerViewModel(ISkuRepository repository)
        {
            _currentRepo = repository;
            loadData();

        }

        private void loadData()
        {
            AllSku = _currentRepo.GetAllSku();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void raisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands

        private RefreshCommand _refreshOrpSkuCommand = new RefreshCommand();
        public RefreshCommand RefreshOrpSkuCommand
        {
            get
            {
                if (_refreshOrpSkuCommand.ViewModel == null)
                    _refreshOrpSkuCommand.ViewModel = this;
                return _refreshOrpSkuCommand;
            }
        }

        public class RefreshCommand : ICommand
        {
            public OrpSkuViewerViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ViewModel._allSku = ViewModel._currentRepo.GetAllSku();
            }
        }

        private ClearCommand _clearAllSkuCommand = new ClearCommand();
        public ClearCommand ClearPeopleCommand
        {
            get
            {
                if (_clearAllSkuCommand.ViewModel == null)
                    _clearAllSkuCommand.ViewModel = this;
                return _clearAllSkuCommand;
            }
        }

        public class ClearCommand : ICommand
        {
            public OrpSkuViewerViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ViewModel._allSku = new List<OrpSku>();
            }
        }

        #endregion Commands
    }
}