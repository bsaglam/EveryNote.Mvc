

namespace EveryNote.Entities.ErrorManager
{
    public enum ErrorMessageCode
    {
        UserIsAlreadyExist=101,
        EmailOrPasswordWrong=102,
        AccountIsNotActive=103,
        EmailIsAlreadyExist=104,
        ActivateIdDoesNotExist=105,
        UserNotFound = 106,
        SomethingIsWrong = 107,
        UpdateIsFailed = 108,
        DeleteIsFailed = 109
    }
}
