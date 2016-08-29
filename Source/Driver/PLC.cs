using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Driver
{
    public abstract class PLC
    {
        abstract public int Connect();
        
        abstract public int SetDevice(string aAddr, int aState);
        abstract public int GetDevice(string aAddr, out int aState);
    
        abstract public int WriteWords(string aAddr, int aSize, int[] aData);
        abstract public int ReadWords(string aAddr, int aSize, int[] aData);

        abstract public void SetAddrIP(string aAddrIP);

        abstract public int WriteRealData(string aAddr, float aValue);
        abstract public int ReadRealData(string aAddr , out float aValue);
    }
}
