using BTGPactual.App.Model.Base;
using SQLite;

namespace BTGPactual.App.Model
{
    public class Cliente : BaseModel
    {
        private int id;
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id 
        { 
            get { return id; } 
            set 
            { 
                id = value; 
                OnPropertyChanged("Id");
            }
        }
        private string name;
        [Column("name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string lastName;
        [Column("last_name")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private int age;
        [Column("age")]
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        private string address;
        [Column("address")]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
    }
}
