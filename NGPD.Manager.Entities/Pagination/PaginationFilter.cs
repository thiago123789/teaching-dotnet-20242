using NGPD.Manager.CrossCutting.Extensions;
using NGPD.Manager.CrossCutting.Wrapper;

namespace NGPD.Manager.Entities.Pagination;

public class PaginationFilter
{
    private string _sort;
    public int PageSize { get; set; }
    public int PageNumber{ get; set; }
    public string Sort {
        get => _sort;
        set => ValidateValue(value);
    }

    private void ValidateValue(object value)
    {
        var stringEnum = value?.ToString()?.ToUpper();
        if (!string.IsNullOrEmpty(stringEnum))
        {
            OrderTypeEnum convertedValue;
            bool tried = Enum.TryParse(stringEnum, out convertedValue);
            if (tried)
            {
                _sort = convertedValue.GetEnumDescription();
            }
            else
            {
                throw new ManagerException("Parametro de ordenação inválido, deve ser ASC ou DESC");
            }
        }
        else
        {
            _sort = "";
        }
            
    }


}