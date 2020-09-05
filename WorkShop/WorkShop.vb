Public Class WorkShop
    Enum CatrgoryType
        AppDev
        Database
        Networking
        SysAdmin
    End Enum
    Public Shared CategoryNames() As String = {"Application Development",
                                               "Database", "Networking",
                                               "SystemAdminstration"}
    Public Property Title As String
    Public Property Days As Integer
    Public Property Cost As Decimal
    Public Property Category As CatrgoryType
    Public Overrides Function ToString() As String
        Return $"{Title },days={Days },category={Category},cost={Cost.ToString("c")}"

    End Function
End Class
