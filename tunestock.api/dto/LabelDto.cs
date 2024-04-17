using tunestock.core.entities;

namespace tunestock.api.dto;

public class LabelDto : DtoBase{
    
    public string? Labelname { get; set; }
    public string? Description {get; set;}

    public LabelDto(){
        
    }

    public LabelDto(Label label){
        ID = label.ID;
        Labelname = label.Labelname;
        Description = label.Description;
    }

}