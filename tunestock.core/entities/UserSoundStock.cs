using System.ComponentModel.DataAnnotations.Schema;

namespace tunestock.core.entities;

[Table("UserSoundStock")]
public class UserSoundStock {

    public UserSoundStock() {
        
    }

    public UserSoundStock(UserSoundStock userStock) {
        UserID_FK = userStock.UserID_FK;
        SoundID_FK = userStock.SoundID_FK;
    }

    public int UserID_FK { get; set; }
    
    public int SoundID_FK { get; set; }
    
    

}