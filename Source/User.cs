using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;
namespace HPT1000.Source
{
    public class User
    {
        private string              name;
        private string              surname;
        private string              login;
        private string              password ;
        private Types.UserPrivilige privilige               = Types.UserPrivilige.Operator;
        private bool                allowChangeAccount      = false;                        //falga okresla czy user moze zmienic parametry konta (password)
        private bool                termAccount             = true;                         //flaga okresla czy kotno jest aktywne NA DANY OKRES
        private DateTime            dateTimeEnableAccount   = DateTime.MinValue;            //data okresla do kiedy konto ma być aktywne

        //---------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------
        public Types.UserPrivilige Privilige
        {
            set { privilige = value; }
            get { return privilige;  }
        }
        //---------------------------------------------------------------------------------------------------------------------
        public User(Types.UserPrivilige aPrivilige,string psw)
        {
            privilige = aPrivilige;
            password  = psw;
        }
        //---------------------------------------------------------------------------------------------------------------------
        public string Password
        {
            set { password = value; }
            get { return password; }
        }
        //---------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            string name = privilige.ToString();
            return name;
        }
        //---------------------------------------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            bool aRes = false;

            if (obj is User)
            {
                User user = (User)obj;

                if (user != null && user.Privilige == privilige && user.Password == password)
                    aRes = true;

            }
            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------
        public User Copy()
        {
            return (User)this.MemberwiseClone();
        }
        //---------------------------------------------------------------------------------------------------------------------

    }
}
