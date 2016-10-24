using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Chamber
{
    public delegate void RefreshGasType();

    public class GasType
    {
        private int     id          = 0;
        private string  name        = "New gas type";
        private string  description = "";
        private double  factor      = 0;  //okresleneie factora dla danego gazu podpietego do danej przeplywki. Przeplywki
                                          //sa skalibrowane na jeden gaz i podpiecie innego wymusza ustawienie factora dla poprawnych przeliczen przeplywu

        private static RefreshGasType refreshObject = null;
        //--------------------------------------------------------------------------------------------------------------
        public int ID
        {
            get { return id; }
        }
        //--------------------------------------------------------------------------------------------------------------
        public string Name
        {
            set
            {
                name = value;
                if (refreshObject != null)
                    refreshObject();
            }
            get { return name; }
        }
        //--------------------------------------------------------------------------------------------------------------
        public string Description
        {
            set { description = value; }
            get { return description; }
        }
        //--------------------------------------------------------------------------------------------------------------
        public double Factor
        {
            set { factor = value; }
            get { return factor; }

        }
        //--------------------------------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            bool aRes = false;
            if (obj != null && obj is GasType)
            {
                GasType gasType = (GasType)obj;
                if (gasType.ID == id && gasType.Name == name && gasType.Description == description && gasType.Factor == factor)
                    aRes = true;
            }
            return aRes;
        }
        //--------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return name;
        }
        //--------------------------------------------------------------------------------------------------------------
        public static void SetDelegateToRefreshInfo(RefreshGasType aRefresh)
        {
            refreshObject = aRefresh;
        }
        //--------------------------------------------------------------------------------------------------------------

    }
    //--------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------
    public class GasTypes
    {
  
        private List<GasType> items = new List<GasType>();

        private static RefreshGasType refreshObject = null;
        //--------------------------------------------------------------------------------------------------------------
        public List<GasType> Items
        {
            get { return items; }
        }

        //--------------------------------------------------------------------------------------------------------------
        public void Add(GasType gasType)
        {
            items.Add(gasType);
            if (refreshObject != null)
                refreshObject();
        }
        //--------------------------------------------------------------------------------------------------------------
        public void Remove(GasType gasType)
        {
            items.Remove(gasType);
            if (refreshObject != null)
                refreshObject();

        }
        //--------------------------------------------------------------------------------------------------------------
        public static void AddToRefreshList(RefreshGasType aRefresh)
        {
            refreshObject += aRefresh;
            GasType.SetDelegateToRefreshInfo(refreshObject);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public bool Contains(GasType aGasType)
        {
            bool aRes = false;

            foreach(GasType gasType in items)
            {
                if (gasType.Name == aGasType.Name)
                    aRes = true;
            }

            return aRes;
        }
    }
}
