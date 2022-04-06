Imports System
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())

        Dim html = "test <b> fat cat </b> test"
        Dim table_html1 As String =
        "<table><tr><th>one</th><th>two</th><th>three</th></tr><tr><td>Row1, column 1</td><td>Row1, column 2</td><td>Row1, column 3</td></tr><tr><td>Row2, column 1</td><td>Row2, column 2</td><td>Row2, column 3</td></tr></table>"
        Dim table_html2 As String =
        "<table><tr><th>Name:</th><td>John Doe</td></tr><tr><th>Email:</th><td>john.doe@example.com</td></tr><tr><th>Phone:</th><td>123-45-678</td></tr></table>"

        Dim table_html3 As String = "<table><tr><th>Name</th><th>Email</th><th>Phone</th></tr><tr><td>John Doe</td><td>john.doe@example.com</td><td>123-45-678</td></tr></table>"

        Console.WriteLine(HTML_to_BankId(table_html3))

    End Sub


    Function HTML_to_BankId(input As String) As String

        Dim s = input


        'THEAMATIC BREAK
        s = s.Replace("<hr>", "---")
        s = s.Replace("</hr>", "")

        'HEADINGS
        s = s.Replace("<h1>", ("#"))
        s = s.Replace("<h2>", ("##"))
        s = s.Replace("<h3>", ("###"))
        s = s.Replace("</h1>", (""))
        s = s.Replace("</h2>", (""))
        s = s.Replace("</h2>", (""))

        'STRONG EMPHASIS
        s = s.Replace("<b>", "*")
        s = s.Replace("</b>", "*")

        s = s.Replace("<strong>", "*")
        s = s.Replace("</strong>", "*")

        s = s.Replace("* ", "*")
        s = s.Replace(" *", "*")

        'LISTS
        s = s.Replace("<ol>", "")
        s = s.Replace("</ol>", "")
        s = s.Replace("<ul>", "")
        s = s.Replace("</ul>", "")
        s = s.Replace("<li>", "+ ")
        s = s.Replace("</li>", "")

        'TABLE
        s = Table(s)

        Return s
    End Function


    Dim table_html As String =
        "<table>
            <tr>
                <th>one</th>
                <th>two</th>
                <th>three</th>
            </tr>
            <tr>
                <td>Row1, column 1</td>
                <td>Row1, column 2</td>
                <td>Row1, column 3</td>
            </tr>
            <tr>
                <td>Row2, column 1</td>
                <td>Row2, column 2</td>
                <td>Row2, column 3</td>
            </tr>
        </table>"
    Function Table(s As String) As String

        Dim th As Integer = 0
        th = Regex.Matches(s, "<th>").Count
        Dim delimiter As String = "|"

        For i = 1 To th
            delimiter = delimiter + "|-"
        Next

        ' Dim regX = New Regex(Regex.Escape("</th>"))
        ' Dim str = regX.Replace(s, delimiter, 1)

        Dim index = s.IndexOf("</tr>")
        s = s.Insert(index, delimiter)



        s = s.Replace("<table>", "")
        s = s.Replace("</table>", "")

        s = s.Replace("<th>", "|")
        s = s.Replace("</th>", "")

        s = s.Replace("<td>", "|")
        s = s.Replace("</td>", "")

        s = s.Replace("<tr>", "")
        s = s.Replace("</tr>", "|")

        Return s

    End Function


End Module
