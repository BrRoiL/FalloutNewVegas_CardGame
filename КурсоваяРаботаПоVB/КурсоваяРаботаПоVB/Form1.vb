Public Class Form1
    'Public MainMenuSelectAudio As New WMPLib.WindowsMediaPlayer()
    'Public MainMenuClickAudio As New WMPLib.WindowsMediaPlayer()
    'Public MainMenuAudio As New WMPLib.WindowsMediaPlayer()
    Dim FontSize As Integer
    Dim UpDateButton As Boolean
    Dim ScreenCoefficient As Double
    Dim OldSizeForm As Size

    'Загрузка данных при загрузке программы
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String
        path = Application.StartupPath
        'MainMenuClickAudio.currentMedia = MainMenuClickAudio.newMedia(path & "\Audio\Main_Menu\Menu_Click.wav")
        'MainMenuSelectAudio.currentMedia = MainMenuSelectAudio.newMedia(path & "\Audio\Main_Menu\Menu_Select.wav")
        'MainMenuAudio.currentMedia = MainMenuAudio.newMedia(path & "\Audio\Main_Menu\Main Theme - Fallout_ New Vegas.wav")

        'MainMenuClickAudio.controls.stop()
        ''MainMenuSelectAudio.controls.stop()
        'MainMenuAudio.controls.play()

        If (My.Settings.SaveActive = True) Then
            Button1.Visible = True
        End If
    End Sub

    'Продожить игру
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button0.Click
        Button1.FlatAppearance.BorderSize = 0
        Button1.Visible = False
        Form2.LoadGameBoolean = True
        Me.Hide()
        Form2.Show()
        AudioClick()
    End Sub

    'Действие при наведении указателя
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter, Button0.MouseEnter
        Button1.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave, Button0.MouseLeave
        Button1.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Новая игра
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.FlatAppearance.BorderSize = 0
        Form2.LoadGameBoolean = False
        My.Settings.SaveActive = False
        AudioClick()
        'MainMenuAudio.controls.stop()
        Me.Hide()
        Form2.Show()
    End Sub

    'Действие при наведении указателя
    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Загрузить игру
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.FlatAppearance.BorderSize = 0
        If (My.Settings.SaveActive = True) Then
            Form2.LoadGameBoolean = True
            Me.Hide()
            Form2.Show()
            'MainMenuAudio.controls.stop()
        End If
        AudioClick()
    End Sub

    'Действие при наведении указателя
    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Правила игры
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.FlatAppearance.BorderSize = 0
        If (Button4.Enabled = True And Button1.Enabled = False) Then
            Exit Sub
        End If
        AudioClick()
        Label1.Visible = True
        Button7.Visible = True
        For i = 1 To 6
            If (Controls("Button" & i) IsNot Button4) Then
                Controls("Button" & i).Enabled = False
            End If
        Next
    End Sub

    'Действие при наведении указателя
    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        If (Button4.Enabled = True And Button1.Enabled = False) Then
            Exit Sub
        End If
        Button4.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Команда разработки
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.FlatAppearance.BorderSize = 0
        If (Button5.Enabled = True And Button1.Enabled = False) Then
            Exit Sub
        End If
        AudioClick()
        Label4.Visible = True
        Button7.Visible = True
        Label4.Location = New Point(447, 625)
        For i = 1 To 6
            If (Controls("Button" & i) IsNot Button5) Then
                Controls("Button" & i).Enabled = False
            End If
        Next
        Timer1.Start()
    End Sub

    'Действие при наведении указателя
    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        If (Button5.Enabled = True And Button1.Enabled = False) Then
            Exit Sub
        End If
        Button5.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Выход
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.FlatAppearance.BorderSize = 0
        AudioClick()
        Me.Close()
    End Sub

    'Действие при наведении указателя
    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Вкючение звуков
    Sub AudioEffect()
        'MainMenuSelectAudio.controls.play()
    End Sub

    'Назад
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button7.FlatAppearance.BorderSize = 0
        AudioClick()
        Button7.Visible = False
        If (Button5.Enabled = True And Button1.Enabled = False) Then
            Label4.Visible = False
            Label4.Location = New Point(447, 625)
            For i = 1 To 6
                Controls("Button" & i).Enabled = True
            Next
        ElseIf (Button4.Enabled = True And Button1.Enabled = False) Then
            Label1.Visible = False
            For i = 1 To 6
                Controls("Button" & i).Enabled = True
            Next
        End If
    End Sub

    'Действие при наведении указателя
    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter
        Button7.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        AudioEffect()
    End Sub

    'Действие при откланении указателя
    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Button7.FlatAppearance.BorderSize = 0
        'MainMenuSelectAudio.controls.stop()
    End Sub

    'Информация о разработчиках
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Label4.Location.Y > 0 - Label4.Size.Height) Then
            Label4.Location = New Point(Label4.Location.X, Label4.Location.Y - 1)
        Else
            For i = 1 To 6
                If (Controls("Button" & i) IsNot Button5) Then
                    Controls("Button" & i).Enabled = True
                End If
            Next
            Label4.Visible = False
            Timer1.Stop()
        End If
    End Sub

    'Вкючение звуков
    Sub AudioClick()
        'MainMenuClickAudio.controls.play()
    End Sub
End Class