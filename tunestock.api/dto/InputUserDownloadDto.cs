//Importamos la entidad correspondiente

using tunestock.core.entities;

namespace tunestock.api.dto;

public class InputUserDownloadDto
{
    public InputUserDownloadDto()
    {
    }

    public InputUserDownloadDto(UserDownload userDownload)
    {
        SoundID_FK = userDownload.SoundID_FK;
        UserID_FK = userDownload.UserID_FK;
        DownloadedDate = userDownload.DownloadedDate;
    }

    public int SoundID_FK { get; set; }

    public int UserID_FK { get; set; }

    public DateTime DownloadedDate { get; set; }
}