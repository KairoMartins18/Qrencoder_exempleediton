Imports QRCoder
Imports QRCoder.PayloadGenerator
Public Class Form1
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rowCount As Integer = 3
        Dim colCount As Integer = 5
        ' Add columns to DataGridView
        For i As Integer = 0 To colCount - 1
            Dim ColImage As New DataGridViewImageColumn
            ColImage.Name = "ColImg" + i.ToString
            ColImage.HeaderText = "Your Image" + i.ToString
            DataGridView1.Columns.Add(ColImage)
        Next
        ' Add rows to DataGridView
        For i As Integer = 0 To rowCount - 1
            DataGridView1.Rows.Add()
        Next
        ' Assign values to DataGridView
        For i As Integer = 0 To colCount - 1
            For j As Integer = 0 To rowCount - 1
                Dim Img As New DataGridViewImageCell
                Img.Value = PictureBox1.BackgroundImage
                DataGridView1(i, j) = Img
            Next
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim printDialog As PrintDialog = New PrintDialog()
        printDialog.Document = PrintDocument1
        If printDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode("Hello world", QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20)
        PictureBox1.BackgroundImage = qrCodeImage
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim rowIndex As Integer = DataGridView1.CurrentCell.RowIndex
        Dim bm As Bitmap = CType(DataGridView1.Rows(rowIndex).Cells(0).Value, Bitmap)
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub
End Class
