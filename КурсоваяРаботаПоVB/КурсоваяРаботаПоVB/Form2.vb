Imports System.Media
Public Class Form2
    'Public GameCapsAddAudio As New WMPLib.WindowsMediaPlayer()
    'Public GameOverAudio As New WMPLib.WindowsMediaPlayer()
    'Public GameWinAudio As New WMPLib.WindowsMediaPlayer()
    'Public GameSong As New WMPLib.WindowsMediaPlayer()

    Public FalloutNewVegas_CardGame As SaveOptions

    Dim ButtonNotActive(0 To 72) As Boolean
    Dim ButtonSelect(0 To 72) As Boolean
    Dim ButtonTag(0 To 72) As String
    Dim ColodaAll(0 To 72) As Image
    Dim min, sec As Integer
    Dim buttonObj As Button
    Dim CardName(0 To 72) As String
    Dim Coloda = {
                    My.Resources.Ч_6, My.Resources.Ч_7, My.Resources.Ч_8, My.Resources.Ч_9, My.Resources.Ч_10, My.Resources.Ч_В, My.Resources.Ч_Д, My.Resources.Ч_К, My.Resources.Ч_Т,
                    My.Resources.В_6, My.Resources.В_7, My.Resources.В_8, My.Resources.В_9, My.Resources.В_10, My.Resources.В_В, My.Resources.В_Д, My.Resources.В_К, My.Resources.В_Т,
                    My.Resources.К_6, My.Resources.К_7, My.Resources.К_8, My.Resources.К_9, My.Resources.К_10, My.Resources.К_В, My.Resources.К_Д, My.Resources.К_К, My.Resources.К_Т,
                    My.Resources.Б_6, My.Resources.Б_7, My.Resources.Б_8, My.Resources.Б_9, My.Resources.Б_10, My.Resources.Б_В, My.Resources.Б_Д, My.Resources.Б_К, My.Resources.Б_Т
                  }
    Dim ColodaString = {
                    "Ч_6", "Ч_7", "Ч_8", "Ч_9", "Ч_10", "Ч_В", "Ч_Д", "Ч_К", "Ч_Т",
                    "В_6", "В_7", "В_8", "В_9", "В_10", "В_В", "В_Д", "В_К", "В_Т",
                    "К_6", "К_7", "К_8", "К_9", "К_10", "К_В", "К_Д", "К_К", "К_Т",
                    "Б_6", "Б_7", "Б_8", "Б_9", "Б_10", "Б_В", "Б_Д", "Б_К", "Б_Т"
                  }
    Dim ColodaColums() As Integer = {
                    1, 2, 3, 4, 5, 6, 7, 8,
                    16, 15, 14, 13, 12, 11, 10, 9,
                    17, 18, 19, 20, 21, 22, 23, 24,
                    0, 30, 29, 28, 27, 26, 25, 0,
                    0, 31, 32, 33, 34, 35, 36, 0,
                    0, 0, 40, 39, 38, 37, 0, 0,
                    0, 0, 41, 42, 43, 44, 0, 0
                  }

    Dim LastCard As Integer = 71
    Dim Counter As Integer
    Dim TriggerOnAction As Boolean
    Dim Pause As Boolean
    Public LoadGameBoolean As Boolean
    Dim ExclusionToColodaAll(0 To 72) As String

    'Загрузка данных при загрузке программы
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String
        Dim rand As New Random()
        Dim Num As Integer()
        path = Application.StartupPath
        'GameCapsAddAudio.currentMedia = GameCapsAddAudio.newMedia(path & "\Audio\Game\fallout_shelter_caps.wav")
        'GameOverAudio.currentMedia = GameOverAudio.newMedia(path & "\Audio\Game\fallout_3_death.wav")
        'GameWinAudio.currentMedia = GameWinAudio.newMedia(path & "\Audio\Game\fallout_4_end_song.wav")
        'GameSong.currentMedia = GameSong.newMedia(path & "\Audio\Game\The Ink Spots - I Don't Want to Set the World on Fire (Fallout New Vegas OST).mp3")
        'GameCapsAddAudio.controls.stop()
        'GameOverAudio.controls.stop()
        'GameWinAudio.controls.stop()
        'GameSong.controls.play()

        If (LoadGameBoolean = False) Then
            Num = Enumerable.Range(0, 36).OrderBy(Function(n) rand.Next).Take(36).ToArray()
            For i = 1 To 36
                ColodaAll(i) = Coloda(Num(i - 1))
                CardName(i) = ColodaString(Num(i - 1))
            Next
            Num = Enumerable.Range(0, 36).OrderBy(Function(n) rand.Next).Take(36).ToArray()
            For i = 37 To 72
                ColodaAll(i) = Coloda(Num(i - 36 - 1))
                CardName(i) = ColodaString(Num(i - 36 - 1))
            Next
            For i = 1 To 44
                Me.Controls("Button" & i).BackgroundImage = ColodaAll(i)
                Me.Controls("Button" & i).Tag = CardName(i)
            Next
            For i = 69 To 71
                Me.Controls("Button" & i).Tag = CardName(i)
            Next
            Button_Activete()
            min = 5
            sec = 0
            Timer1.Start()
        Else
            LoadGame()
        End If
    End Sub

    'Отключение взаимодействия
    Private Sub Button_Activete()
        For i = 1 To 16
            ButtonNotActive(i) = True
        Next
        For i = 18 To 23
            ButtonNotActive(i) = True
        Next
        For i = 25 To 30
            ButtonNotActive(i) = True
        Next
        For i = 32 To 35
            ButtonNotActive(i) = True
        Next
        For i = 37 To 40
            ButtonNotActive(i) = True
        Next
        For i = 69 To 70
            ButtonNotActive(i) = True
        Next
        ButtonNotActive(72) = True
    End Sub

    'Таймер обратного отсчёта
    Private Sub Timer1_Tick() Handles Timer1.Tick
        sec = sec - 1
        If (sec < 0) Then
            sec = 59
            min = min - 1
        End If
        Label5.Text = min & " : " & sec
        If (min = 0 And sec = 0) Then
            Timer1.Stop()
            GameOver()
        End If
    End Sub

    'Проверка нажатия на карту
    Private Sub Button_MouseClick(sender As Object, e As EventArgs) Handles Button1.MouseClick, Button2.MouseClick, Button3.MouseClick, Button4.MouseClick, Button5.MouseClick,
         Button6.MouseClick, Button7.MouseClick, Button8.MouseClick, Button9.MouseClick, Button10.MouseClick, Button11.MouseClick, Button12.MouseClick, Button13.MouseClick, Button14.MouseClick, Button15.MouseClick,
          Button16.MouseClick, Button17.MouseClick, Button18.MouseClick, Button19.MouseClick, Button20.MouseClick, Button21.MouseClick, Button22.MouseClick, Button23.MouseClick, Button24.MouseClick, Button25.MouseClick,
           Button26.MouseClick, Button27.MouseClick, Button28.MouseClick, Button29.MouseClick, Button30.MouseClick, Button31.MouseClick, Button32.MouseClick, Button33.MouseClick, Button34.MouseClick, Button35.MouseClick,
            Button36.MouseClick, Button37.MouseClick, Button38.MouseClick, Button39.MouseClick, Button40.MouseClick, Button41.MouseClick, Button42.MouseClick, Button43.MouseClick, Button44.MouseClick,
             Button69.MouseClick, Button70.MouseClick, Button71.MouseClick

        buttonObj = sender
        If (Button71.Visible = True And Button70.Visible = True And Button69.Visible = True) Then
            ButtonNotActive(71) = False
            ButtonNotActive(70) = True
            ButtonNotActive(69) = True
        ElseIf (Button71.Visible = False And Button70.Visible = True And Button69.Visible = True) Then
            ButtonNotActive(71) = True
            ButtonNotActive(70) = False
            ButtonNotActive(69) = True
        ElseIf (Button71.Visible = False And Button70.Visible = False And Button69.Visible = True) Then
            ButtonNotActive(71) = True
            ButtonNotActive(70) = True
            ButtonNotActive(69) = False
        End If
        If (ButtonNotActive(Mid(buttonObj.Name, 7)) = False) Then
            If (buttonObj.FlatAppearance.BorderSize = 1) Then
                buttonObj.FlatAppearance.BorderSize = 0
                ButtonSelect(Mid(buttonObj.Name, 7)) = False
            Else
                buttonObj.FlatAppearance.BorderSize = 1
                ButtonSelect(Mid(buttonObj.Name, 7)) = True
            End If
        End If
    End Sub

    'Сброс карт
    Private Sub Button73_Click(sender As Object, e As EventArgs) Handles Button73.Click
        Dim stricke, exp, cof, ButtonSelectCheck, OldSum, num As Integer
        Dim ObjName As String
        Dim ButtonTrigger, GameOverCheck As Boolean

        OldSum = Label3.Text
        ObjName = ""
        ButtonSelectCheck = 0
        stricke = 1
        exp = 25
        cof = 1
        For i = 1 To 72
            If (ButtonSelect(i) = True) Then
                ButtonSelectCheck += 1
                If (Mid(Me.Controls("Button" & i).Tag, 2) = Mid(ObjName, 2)) Then
                    cof += 1
                    exp += 25
                ElseIf (ButtonSelectCheck = 1) Then
                    exp = 25
                ElseIf (ButtonSelectCheck > 1 And Mid(Me.Controls("Button" & i).Tag, 2) <> Mid(ObjName, 2)) Then
                    exp -= 25
                    cof -= 1
                    If (cof < 1) Then
                        cof = 1
                    End If
                    ButtonSelectCheck = 0
                End If
                For j = 55 To 8 Step -1
                    If (ColodaColums(j) = Mid(Me.Controls("Button" & i).Name, 7)) Then
                        ButtonNotActive(ColodaColums(j - 8)) = False
                        ColodaColums(j) = "0"
                    End If
                Next
                Me.Controls("Button" & i).Visible = False
                ButtonSelect(i) = False
                ButtonTrigger = True
                ObjName = Me.Controls("Button" & i).Tag
            End If
        Next
        If (ButtonTrigger = True) Then
            Label3.Text = Int(Label3.Text) + ((exp * cof))
            ButtonTrigger = False
            If (OldSum <> Label3.Text) Then
                'GameCapsAddAudio.controls.stop()
                'GameCapsAddAudio.controls.play()
            End If
            If (TriggerOnAction = True) Then
                For i = 71 To 69 Step -1
                    If (Me.Controls("Button" & i).Visible = False) Then
                        If (i = 71) Then
                            ExclusionToColodaAll(Counter) = Me.Controls("Button" & i).Tag
                            CardName(LastCard) = ""
                            ColodaAll(LastCard) = Nothing
                        ElseIf (i = 70) Then
                            ExclusionToColodaAll(Counter) = Me.Controls("Button" & i).Tag
                            CardName(LastCard - 1) = ""
                            ColodaAll(LastCard - 1) = Nothing
                        ElseIf (i = 69) Then
                            ExclusionToColodaAll(Counter) = Me.Controls("Button" & i).Tag
                            CardName(LastCard - 2) = ""
                            ColodaAll(LastCard - 2) = Nothing
                        End If
                        Counter += 1
                    End If
                Next
            End If
            num = 0
            For i = 72 To 45 Step -1
                If (CardName(i) <> "") Then
                    num += 1
                End If
            Next
            If (Button72.Visible = False) Then
                num = 0
                Button72.Visible = True
                Button72.BackgroundImage = My.Resources.Шапка
                Button72.FlatAppearance.BorderSize = 0
                Button72.Enabled = False
            End If
            Label1.Text = "X" & num
            If (Label1.Text = "X1") Then
                Button72.BackgroundImage = ColodaAll(72)
                Button72.Tag = CardName(72)
            End If
        End If
        For i = 1 To 44
            If (Me.Controls("Button" & i).Visible = False) Then
                GameOverCheck = True
            Else
                GameOverCheck = False
                Exit For
            End If
        Next
        If (GameOverCheck = True) Then
            GameWin()
        End If
    End Sub

    'Перетасовка дополнительных карт
    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click
        Dim button As Button
        Dim num As Integer

        For i = 69 To 71
            ButtonSelect(i) = False
        Next
        If (LastCard <= 47) Then
            LastCard = 71
        ElseIf (TriggerOnAction = True) Then
            LastCard -= 3
        End If
        For i = 71 To 69 Step -1
            button = Me.Controls("Button" & i)
            button.Visible = True
            button.FlatAppearance.BorderSize = 0
            If (i = 71) Then
                num = LastCard
            ElseIf (i = 70) Then
                num = LastCard - 1
            ElseIf (i = 69) Then
                num = LastCard - 2
            End If
            button.BackgroundImage = ColodaAll(num)
            button.Tag = CardName(num)
            If (button.BackgroundImage Is Nothing) Then
                button.Visible = False
            End If
            For j = 0 To 27
                If (ExclusionToColodaAll(j) = button.Tag) Then
                    CardName(num) = ""
                    ColodaAll(num) = Nothing
                    While CardName(num) Is Nothing
                        num -= 1
                        If (num <= 44) Then
                            Exit For
                        End If
                    End While
                    If (i = 71) Then
                        button.BackgroundImage = ColodaAll(num)
                        button.Tag = CardName(num)
                    ElseIf (i = 70) Then
                        button.BackgroundImage = ColodaAll(num)
                        button.Tag = CardName(num)
                    ElseIf (i = 69) Then
                        button.BackgroundImage = ColodaAll(num)
                        button.Tag = CardName(num)
                    End If
                End If
            Next
        Next
        TriggerOnAction = True
        If (Button72.Tag = CardName(72)) Then
            If (Button72.FlatAppearance.BorderSize = 1) Then
                Button72.FlatAppearance.BorderSize = 0
                ButtonSelect(Mid(Button72.Name, 7)) = False
            Else
                Button72.FlatAppearance.BorderSize = 1
                ButtonSelect(Mid(Button72.Name, 7)) = True
            End If
            TriggerOnAction = False
        End If
    End Sub

    'Проигрыш
    Sub GameOver()
        Dim button As Button
        For i = 1 To 44
            button = Me.Controls("Button" & i)
            button.Enabled = False
            button.FlatAppearance.BorderSize = 0
        Next
        For i = 69 To 73
            button = Me.Controls("Button" & i)
            button.Enabled = False
            button.FlatAppearance.BorderSize = 0
        Next
        Label6.Visible = True
        Label6.Text = "Ты проиграл!"
        Label3.Text = "0"
        Button73.Visible = False
        Button74.Enabled = False
        Button75.Enabled = False
        'GameSong.controls.stop()
        'GameOverAudio.controls.play()
    End Sub

    'Победа
    Sub GameWin()
        Dim button As Button
        Timer1.Stop()
        For i = 1 To 44
            button = Me.Controls("Button" & i)
            button.Enabled = False
            button.FlatAppearance.BorderSize = 0
        Next
        For i = 69 To 73
            button = Me.Controls("Button" & i)
            button.Enabled = False
            button.FlatAppearance.BorderSize = 0
        Next
        Label6.Visible = True
        Label6.Text = "Ты победил!"
        Button73.Visible = False
        Button74.Enabled = False
        Button75.Enabled = False
        'GameSong.controls.stop()
        'GameWinAudio.controls.play()
    End Sub

    'Загрузка
    Sub LoadGame()
        Dim TextMas(0 To 72) As String
        Dim text As String
        Dim num2 As Integer = 1
        Label3.Text = My.Settings.Coin
        LastCard = My.Settings.LastCard
        Counter = My.Settings.Counter
        min = My.Settings.min
        sec = My.Settings.sec
        text = ""
        For i = 0 To Len(My.Settings.ActiveCard) - 1
            If (My.Settings.ActiveCard(i) <> ";") Then
                text = text + My.Settings.ActiveCard(i)
            Else
                TextMas(num2) = text
                num2 += 1
                text = ""
                If (num2 = 45) Then
                    num2 = 69
                End If
            End If
        Next
        For i = 1 To 44
            Me.Controls("Button" & i).Visible = TextMas(i)
        Next
        For i = 69 To 72
            Me.Controls("Button" & i).Visible = TextMas(i)
        Next
        For i = 1 To 72
            TextMas(i) = Nothing
        Next
        text = ""
        num2 = 1
        For i = 0 To Len(My.Settings.CardName) - 1
            If (My.Settings.CardName(i) <> ";") Then
                text = text + My.Settings.CardName(i)
            Else
                TextMas(num2) = text
                num2 += 1
                text = ""
            End If
        Next
        For i = 1 To 72
            CardName(i) = TextMas(i)
        Next
        For i = 1 To 72
            For j = 0 To 35
                If (CardName(i) = ColodaString(j)) Then
                    ColodaAll(i) = Coloda(j)
                End If
            Next
        Next
        For i = 1 To 44
            Me.Controls("Button" & i).Tag = TextMas(i)
            Me.Controls("Button" & i).BackgroundImage = ColodaAll(i)
        Next
        For i = 69 To 71
            Me.Controls("Button" & i).Tag = TextMas(i)
            Me.Controls("Button" & i).BackgroundImage = ColodaAll(i)
        Next
        For i = 1 To 72
            TextMas(i) = Nothing
        Next
        text = ""
        num2 = 1
        For i = 0 To Len(My.Settings.ButtonNotActive) - 1
            If (My.Settings.ButtonNotActive(i) <> ";") Then
                text = text + My.Settings.ButtonNotActive(i)
            Else
                TextMas(num2) = text
                num2 += 1
                text = ""
            End If
        Next
        For i = 1 To 72
            ButtonNotActive(i) = TextMas(i)
        Next
        For i = 1 To 72
            TextMas(i) = Nothing
        Next
        text = ""
        num2 = 1
        For i = 0 To Len(My.Settings.ExclusionToColodaAll) - 1
            If (My.Settings.ExclusionToColodaAll(i) <> ";") Then
                text = text + My.Settings.ExclusionToColodaAll(i)
            Else
                TextMas(num2) = text
                num2 += 1
                text = ""
            End If
        Next
        For i = 0 To 27
            ExclusionToColodaAll(i) = TextMas(i)
        Next
        For i = 1 To 72
            TextMas(i) = Nothing
        Next
        Timer1.Start()
    End Sub

    'Изменение очков
    Private Sub Label6_TextChanged(sender As Object, e As EventArgs) Handles Label6.TextChanged
        Label6.Location = New Point(Me.Size.Width / 2, Label6.Location.Y)
        Label6.Location = New Point(Label6.Location.X - (Label6.Size.Width / 2), Label6.Location.Y)
    End Sub

    'Вызов паузы
    Private Sub ButtonPause_Click(sender As Object, e As EventArgs) Handles ButtonPause.Click
        PauseGame()
    End Sub
    'Действие при наведении указателя
    Private Sub ButtonPause_MouseEnter(sender As Object, e As EventArgs) Handles ButtonPause.MouseEnter
        ButtonPause.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
    End Sub

    'Действие при откланении указателя
    Private Sub ButtonPause_MouseLeave(sender As Object, e As EventArgs) Handles ButtonPause.MouseLeave
        ButtonPause.FlatAppearance.BorderSize = 0
    End Sub

    'Пауза
    Sub PauseGame()
        Dim button As Button
        If (Pause = False) Then
            Pause = True
            Timer1.Stop()
            'GameSong.controls.pause()
            For i = 1 To 44
                button = Me.Controls("Button" & i)
                button.Enabled = False
                button.FlatAppearance.BorderSize = 0
            Next
            For i = 69 To 73
                button = Me.Controls("Button" & i)
                button.Enabled = False
                button.FlatAppearance.BorderSize = 0
            Next
            Label6.Visible = True
            Label6.Text = "Пауза"
            Button74.Visible = True
            Button75.Visible = True
            Button76.Visible = True
        Else
            Pause = False
            Timer1.Start()
            'GameSong.controls.play()
            For i = 1 To 44
                button = Me.Controls("Button" & i)
                button.Enabled = True
                button.FlatAppearance.BorderSize = 0
            Next
            For i = 69 To 73
                button = Me.Controls("Button" & i)
                button.Enabled = True
                button.FlatAppearance.BorderSize = 0
            Next
            Label6.Visible = False
            Button74.Visible = False
            Button75.Visible = False
            Button76.Visible = False
        End If
    End Sub

    'Созранить
    Private Sub Button74_Click(sender As Object, e As EventArgs) Handles Button74.Click
        Dim Text As String
        Button74.FlatAppearance.BorderSize = 0
        'Form1.MainMenuClickAudio.controls.play()
        My.Settings.Coin = Label3.Text
        My.Settings.min = min
        My.Settings.sec = sec
        My.Settings.LastCard = LastCard
        My.Settings.Counter = Counter
        Text = ""
        For i = 1 To 44
            Text = Text + Convert.ToString(Convert.ToInt32(Me.Controls("Button" & i).Visible)) + ";"
        Next
        For i = 69 To 72
            Text = Text + Convert.ToString(Convert.ToInt32(Me.Controls("Button" & i).Visible)) + ";"
        Next
        My.Settings.ActiveCard = Text
        Text = ""
        For i = 1 To 44
            Text = Text + Me.Controls("Button" & i).Tag + ";"
        Next
        For i = 45 To 68
            Text = Text + CardName(i) + ";"
        Next
        For i = 69 To 72
            Text = Text + Me.Controls("Button" & i).Tag + ";"
        Next
        My.Settings.CardName = Text
        Text = ""
        For i = 1 To 72
            Text = Text + Convert.ToString(Convert.ToInt32(ButtonNotActive(i))) + ";"
        Next
        My.Settings.ButtonNotActive = Text
        Text = ""
        For i = 0 To 27
            Text = Text + ExclusionToColodaAll(i) + ";"
        Next
        My.Settings.ExclusionToColodaAll = Text
        My.Settings.SaveActive = True
        My.Settings.Save()
    End Sub

    'Действие при наведении указателя
    Private Sub Button74_MouseEnter(sender As Object, e As EventArgs) Handles Button74.MouseEnter
        Button74.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        'Form1.MainMenuSelectAudio.controls.play()
    End Sub

    'Действие при откланении указателя
    Private Sub Button74_MouseLeave(sender As Object, e As EventArgs) Handles Button74.MouseLeave
        Button74.FlatAppearance.BorderSize = 0
        'Form1.MainMenuSelectAudio.controls.stop()
    End Sub

    'Загрузить
    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click
        Button75.FlatAppearance.BorderSize = 0
        'Form1.MainMenuClickAudio.controls.play()
        LoadGame()
        PauseGame()
    End Sub

    'Действие при наведении указателя
    Private Sub Button75_MouseEnter(sender As Object, e As EventArgs) Handles Button75.MouseEnter
        Button75.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        'Form1.MainMenuSelectAudio.controls.play()
    End Sub

    'Действие при откланении указателя
    Private Sub Button75_MouseLeave(sender As Object, e As EventArgs) Handles Button75.MouseLeave
        Button75.FlatAppearance.BorderSize = 0
        'Form1.MainMenuSelectAudio.controls.stop()
    End Sub

    'Выход
    Private Sub Button76_Click(sender As Object, e As EventArgs) Handles Button76.Click
        Button76.FlatAppearance.BorderSize = 0
        'Form1.MainMenuClickAudio.controls.play()
        'GameOverAudio.controls.stop()
        'GameWinAudio.controls.stop()
        Me.Close()
        Form1.Show()
    End Sub

    'Действие при наведении указателя
    Private Sub Button76_MouseEnter(sender As Object, e As EventArgs) Handles Button76.MouseEnter
        Button76.FlatAppearance.BorderSize = 1
        System.Threading.Thread.Sleep(30)
        'Form1.MainMenuSelectAudio.controls.play()
    End Sub

    'Действие при откланении указателя
    Private Sub Button76_MouseLeave(sender As Object, e As EventArgs) Handles Button76.MouseLeave
        Button76.FlatAppearance.BorderSize = 0
        'Form1.MainMenuSelectAudio.controls.stop()
    End Sub
End Class