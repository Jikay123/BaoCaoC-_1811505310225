using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1.Model
{
    public class ModelEmployee
    {
        private int _EmployeeId;
        private string _Name;
        private string _Address;
        private string _Department;
        private bool _Gender;
        private int _EmployeeType;

        public int EmployeeType
        {
            get { return _EmployeeType; }
            set { _EmployeeType = value; }
        }


        public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public ModelEmployee(int pId, string pName, string pAddress, string pDepartment, bool pGender, int pEmployeeType)
        {
            this.EmployeeId = pId;
            this.Name = pName;
            this.Address = pAddress;
            this.Department = pDepartment;
            this.Gender = pGender;
            this.EmployeeType = pEmployeeType;
        }

    }
}
