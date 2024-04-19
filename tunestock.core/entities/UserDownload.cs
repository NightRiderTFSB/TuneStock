//Importamos el decorador para establecer la tabla SQL objetivo
using System.ComponentModel.DataAnnotations.Schema;

//Nombre del paquete al que pertenece la clase
namespace tunestock.core.entities;

[Table("UserDownloads")] //Apuntamos a la tabla correspondiente
public class UserDownload {

    public UserDownload(){

    }

    public UserDownload(UserDownload userDownload){
        ID = userDownload.ID;
        SoundID_FK =userDownload.SoundID_FK;
        DownloadedDate = userDownload.DownloadedDate;
    }
    
    public int ID { get; set; }

    public int SoundID_FK { get; set; }
    
    public int UserID_FK { get; set; }

    public DateTime DownloadedDate { get; set; }

}