using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HomeCheckList.DbContexts;
using HomeCheckList.Models;
using HomeCheckList.Services;
using HomeCheckList.Services.Creators;
using HomeCheckList.Stores;
using HomeCheckList.ViewModels;
using HomeCheckList.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;
using System.Reflection;

namespace HomeCheckList
{
    public class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=checklist.db";
        private readonly HomeCheckListDbContextFactory _homeCheckListDbContextFactory;
        private readonly NavigationStore _navigationStore;
        private readonly INavigationServices _navigationServices;
        private readonly DbHelper _dbHelper;

        public override void Initialize()
        {
            
            AvaloniaXamlLoader.Load(this);
        }

        public App()
        {
            _homeCheckListDbContextFactory = new HomeCheckListDbContextFactory(CONNECTION_STRING);
            IRoomsProvider roomsProvider = new DatabaseRoomProviders(_homeCheckListDbContextFactory);
            IRoomCreator roomCreator = new DatabaseRoomCreator(_homeCheckListDbContextFactory);

            IRoomItemsProvider itemProvider = new DatabaseRoomItemsProvider(_homeCheckListDbContextFactory);
            IRoomItemCreator roomItemCreator = new DatabaseItemCreator(_homeCheckListDbContextFactory);

             _dbHelper = new DbHelper(roomsProvider, roomCreator, itemProvider, roomItemCreator);
            _navigationStore = new NavigationStore();
        }
        public override void OnFrameworkInitializationCompleted()
        {
            //Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
            //Locator.CurrentMutable.Register<IViewFor<AddItemViewModel>>(() => new AddItem());
            //Locator.CurrentMutable.Register<IViewFor<RoomItemsViewModel>>(() => new RoomItem());
            //Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());


            // DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            
            

            //using (CheckListContext dbContext = _homeCheckListDbContextFactory.CreateDbContext())
            //{
            //    dbContext.Database.Migrate();
            //}



            _navigationStore.CurrentViewModel = CreateRoomItemsViewModel();
           // _navigationStore.CurrentViewModel = CreateMainWindowViewModel()
            //_navigationStore.CurrentViewModel = new RoomItemsViewModel(_navigationStore);


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                

                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(_dbHelper, _navigationStore),
                    
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private RoomItemsViewModel CreateRoomItemsViewModel()
        {
            return new RoomItemsViewModel(_dbHelper, _navigationStore);

        }

        //private MainWindowViewModel CreateMainWindowViewModel()
        //{
        //    return new RoomItemsViewModel(_dbHelper, _navigationStore);
        //    MainWindowViewModel.Load
        //    return MainWindowViewModel(_dbHelper, new NavigationServices(_navigationStore, RoomItemsViewModel));
        //}

        //private RoomItemsViewModel CreateRoomItemsViewModel()
        //{

        //}


    }
}
