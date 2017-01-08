using UnityEngine;
using System.Collections;

public class DrError {

    public enum ErrorType
    {
        DR_NO_ERROR = 0,
        DR_ERR_SHORT_BUF_FOR_WRITE = -1,
        DR_ERR_SHORT_BUF_FOR_READ = -2,
        DR_ERR_STR_LEN_TOO_BIG = -3,
        DR_ERR_STR_LEN_TOO_SMALL = -4,
        DR_ERR_ARG_POINTER_IS_NULL = -5,
        DR_ERR_ARRAY_OUT_OF_BOUND = -6,
    }

    private static readonly string[] errorTab =
    {
        /* 0 */"no error",
        /* 1 */"no enough space in buffer for write",
        /* 2 */"no enough data in buffer for read",
        /* 3 */"string length surpass defined size",
        /* 4 */"string length smaller than minus size",
        /* 5 */"value of pointer-type argument is NULL",
        /* 6 */"array size out of bound",
    };


    public static string GetErrorMsg(ErrorType error)
    {
        int errorIdx = -1 * (int)error;
        if (errorIdx < 0 || errorIdx >= errorTab.Length)
        {
            return "unkown error";
        }
        else
        {
            return errorTab[errorIdx];
        }
    }
}
