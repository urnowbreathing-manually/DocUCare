Module DataStore
    'Hardcoded list of all existing personel in the hospital.
    Public personnelDB(,) As String = {
                                        {"wionquintela", "adminPass", "0001-A", "Admin"},
                                        {"jestineaquino", "abc123", "0001-D", "Doctor"},
                                        {"andreizantua", "def456", "0002-D", "Doctor"},
                                        {"kaelrivera", "staffPass", "0001-S", "Staff"}
                                    }

    'Stores the ID of the current user for reference
    Public currentUser() As String = {"", "", "", ""}
End Module
