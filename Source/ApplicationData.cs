using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source
{
    /**
     * Klasa zawiera zbiorcze informacje powiazane z aplikacja:
     * - lista userow
     * - aktualnie zalogowany user
     */
    public delegate void RefreshUsers();    //okreslenie funkcji ktora mozna podpiac jako wskaznik i bedzie wywolywana podczas odswiezania userow

    public class ApplicationData
    {
        private DB  dataBase = null;                ///< wskaznika na referencje bazy danych
        List<User>  users    = new List<User>();    ///< list dostepnych userow ktorzy moga sie logowanac do aplikacji

        private static User userNone   = new User(Types.UserPrivilige.None, "","none"); //Utworzenie usera o braku uprawnien. Jest on wykorzystywany jako user ktory zostal wylogowany
        public  static User loggedUser = userNone;// new User(Types.UserPrivilige.None, ""); ///< Aktulnie zalogowany user

        private static RefreshUsers refreshObject = null; //delegate ktroy jest wywolywany gdy zmieniam konfiguracje userow

        //-------------------------------------------------------------------------------------
        //Zwroc list userow
        public List<User> Users
        {
            get { return users; }
        }
        //-------------------------------------------------------------------------------------
        //Podaj aktualnie zalogowanwgo usera
        public static User LoggedUser
        {
            get { return loggedUser; }
        }
        //--------------------------------------------------------------------------------------------------------------
        public DB DataBase
        {
            set { dataBase = value; }
        }
        //--------------------------------------------------------------------------------------------------------------
        //Konstruktor aplikacji ustawia odrazu wymagane referencje
        public ApplicationData()
        {
            //For teest
            User user = new User(Types.UserPrivilige.Administrator, "admin","admin");
            AddUser(user);
            user = new User(Types.UserPrivilige.Operator, "operator","operator");
            AddUser(user);
            user = new User(Types.UserPrivilige.Service, "service","service");
            AddUser(user);
            user = new User(Types.UserPrivilige.Technican, "technican","technics");
            AddUser(user);
        }   
        //-------------------------------------------------------------------------------------
        //Funkcja wykonuje operacje zwiazane z operacja logowania usera do aplikacji. Jezeli operacja sie powiedzie to ustaw aktualnego usera jako ten zalogwany
        public bool LoginUser(User user, string psw)
        {
            bool aRes = false;

            if (user != null && user.Password == psw)
            {
                loggedUser = user;
                aRes = true;
            }

            return aRes;
        }
        //-------------------------------------------------------------------------------------
        //WYkonaie operacji wylogowania usera. Ustawienia aktualnego usera jako None
        public void LogoutUser()
        {
            loggedUser = userNone;
        }
        //-------------------------------------------------------------------------------------
        //Dodaj usera do listy wszystkich userow
        public void AddUser(User user)
        {
            if (users != null)
            {
                users.Add(user);
                if (refreshObject != null)
                    refreshObject();
            }
        }
        //--------------------------------------------------------------------------------------------------------------
        //Usun danego usera
        public void RemoveUser(User user)
        {
            users.Remove(user);
            if (refreshObject != null)
                refreshObject();
        }
        //--------------------------------------------------------------------------------------------------------------
        //Wykonanie akcji modyfikacji usera. Powiadom moich subskryptentow ze cos sie zmienilo
        public void ModifyUser(User user)
        {
            if (refreshObject != null)
                refreshObject();
        }
        //--------------------------------------------------------------------------------------------------------------
        //Dodanie do listy subskrypcji danej funkcji
        public static void AddToRefreshUsersList(RefreshUsers aRefresh)
        {
            refreshObject += aRefresh;
        }
        //-------------------------------------------------------------------------------------

    }
}
