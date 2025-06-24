using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs;

public class ActionResultDto<T>
{
    [Required]
    public T Data { get; set; }

    [Required] 
    [DefaultValue("")] 
    public string Message { get; set; } = string.Empty;
        

    public ActionResultDto()
    {
            
    }

    public ActionResultDto(T data, string message)
    {
        Data = data;
        Message = message;
    }
}