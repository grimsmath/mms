using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMS.Models
{
	[Table("State")]
	public class State : BaseModel
	{
        #region Members

        public string StateCode { get; set; }
        public string Name { get; set; } 
        
        #endregion

        #region Constructors

        public State()
        {

        } 

        #endregion
	}
}