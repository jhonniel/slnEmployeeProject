' Name: Employee Payroll Project w/ Tax Computation - First Exam Lab
' Purpose: Computes employee’s salary
' Programmer: <Jhonniel Ygay> on <Sep 18,2020>
Option Explicit On
Option Infer Off
Option Strict On




Public Class frmMain
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtEmployeeName.Text = ""
        txtHourlySalary.Text = "0.00"
        txtMonday1.Text = "0.00"
        txtTuesday1.Text = "0.00"
        txtWednesday1.Text = "0.00"
        txtThursday1.Text = "0.00"
        txtFriday1.Text = "0.00"
        txtSaturday1.Text = "0.00"
        txtSunday1.Text = "0.00"
        txtMonday2.Text = "0.00"
        txtTuesday2.Text = "0.00"
        txtWednesday2.Text = "0.00"
        txtThursday2.Text = "0.00"
        txtFriday2.Text = "0.00"
        txtSaturday2.Text = "0.00"
        txtSunday2.Text = "0.00"

        txtRegularHours.Text = "0.00"
        txtRegularAmount.Text = "0.00"
        txtOvertimeHours.Text = "0.00"
        txtOvertimeAmount.Text = "0.00"
        txtGrossPay.Text = "0.00"
        txtHoldingTax.Text = "0.00"
        txtNetPay.Text = "0.00"

        txtEmployeeName.Focus()
    End Sub

    Private Sub txtEmployeeName_Click(sender As Object, e As EventArgs) Handles txtEmployeeName.Click
        txtEmployeeName.SelectAll()
    End Sub
    Private Sub txtHourlySalary_Click(sender As Object, e As EventArgs) Handles txtHourlySalary.Click
        txtHourlySalary.SelectAll()
    End Sub
    Private Sub txtMonday1_Click(sender As Object, e As EventArgs) Handles txtMonday1.Click
        txtMonday1.SelectAll()
    End Sub
    Private Sub txtTuesday1_Click(sender As Object, e As EventArgs) Handles txtTuesday1.Click
        txtTuesday1.SelectAll()
    End Sub
    Private Sub txtWednesday1_Click(sender As Object, e As EventArgs) Handles txtWednesday1.Click
        txtWednesday1.SelectAll()
    End Sub
    Private Sub txtThursday1_Click(sender As Object, e As EventArgs) Handles txtThursday1.Click
        txtThursday1.SelectAll()
    End Sub
    Private Sub txtFriday1_Click(sender As Object, e As EventArgs) Handles txtFriday1.Click
        txtFriday1.SelectAll()
    End Sub
    Private Sub txtSaturday1_Click(sender As Object, e As EventArgs) Handles txtSaturday1.Click
        txtSaturday1.SelectAll()
    End Sub
    Private Sub txtSunday1_Click(sender As Object, e As EventArgs) Handles txtSunday1.Click
        txtSunday1.SelectAll()
    End Sub

    Private Sub txtMonday2_Click(sender As Object, e As EventArgs) Handles txtMonday2.Click
        txtMonday2.SelectAll()
    End Sub
    Private Sub txtTuesday2_Click(sender As Object, e As EventArgs) Handles txtTuesday2.Click
        txtTuesday2.SelectAll()
    End Sub
    Private Sub txtWednesday2_Click(sender As Object, e As EventArgs) Handles txtWednesday2.Click
        txtWednesday2.SelectAll()
    End Sub
    Private Sub txtThursday2_Click(sender As Object, e As EventArgs) Handles txtThursday2.Click
        txtThursday2.SelectAll()
    End Sub
    Private Sub txtFriday2_Click(sender As Object, e As EventArgs) Handles txtFriday2.Click
        txtFriday2.SelectAll()
    End Sub
    Private Sub txtSaturday2_Click(sender As Object, e As EventArgs) Handles txtSaturday2.Click
        txtSaturday2.SelectAll()
    End Sub
    Private Sub txtSunday2_Click(sender As Object, e As EventArgs) Handles txtSunday2.Click
        txtSunday2.SelectAll()
    End Sub





    Private Sub Days(monday1 As Double, monday2 As Double, tuesday1 As Double, tuesday2 As Double, wednesday1 As Double, wednesday2 As Double,
                      thursday1 As Double, thursday2 As Double, friday1 As Double, friday2 As Double, saturday1 As Double, saturday2 As Double,
                      sunday1 As Double, sunday2 As Double)

        Dim WorkDays() As Double = {monday1, monday2, tuesday1, tuesday2, wednesday1, wednesday2, thursday1, thursday2, friday1, friday2, saturday1, saturday2}
        Dim ovtDays() As Double = {sunday1, sunday2}
        Dim regHours As Double, regularAmount As Double, OvertimeHours As Double, OvertimeHours1 As Double, OvertimeHours2 As Double,
            ovtsunday As Double, ovtSalary As Double, ovtsunday1 As Double, ovtsunday2 As Double, overtimeAmount As Double,
            GrossPay As Double = 0, HoldingTax As Double, Totalearnings As Double
        Dim rawtax1, rawtax2 As Double

        For Each time As Double In WorkDays
            regHours += time
            For ovtTime As Double = 0 To time Step 1
                If ovtTime >= 9 Then
                    OvertimeHours += 1
                    regHours -= 1
                End If
            Next ovtTime
        Next time

        For Each time As Double In ovtDays
            OvertimeHours1 += time
            OvertimeHours2 += time
            For ovtTime As Double = 0 To time Step 1
                If ovtTime >= 9 Then
                    ovtsunday += 1
                    OvertimeHours2 -= 1
                End If
            Next ovtTime
        Next time


        Dim hourlySalary As Double


        hourlySalary = CDbl(Me.txtHourlySalary.Text)


        ovtSalary = (hourlySalary * OvertimeHours) * 1.25
        ovtsunday1 = (hourlySalary * OvertimeHours2) * 1.3
        ovtsunday2 = (hourlySalary * ovtsunday) * 1.69
        overtimeAmount = ovtSalary + ovtsunday1 + ovtsunday2
        regularAmount = hourlySalary * regHours
        GrossPay = overtimeAmount + regularAmount

        If GrossPay < 10417 Then
            HoldingTax = 0
        ElseIf GrossPay >= 10417 And GrossPay < 16667 Then
            rawtax1 = 10417 * 0.2
            rawtax2 = rawtax1 * 0.2
            HoldingTax = rawtax2
        ElseIf GrossPay >= 16667 And GrossPay < 33333 Then
            rawtax1 = 16667 * 0.25
            rawtax2 = rawtax1 * 0.25
            HoldingTax = rawtax2 + 1250
        ElseIf GrossPay >= 33333 And GrossPay < 83333 Then
            rawtax1 = 33333 * 0.3
            rawtax2 = rawtax1 * 0.3
            HoldingTax = rawtax2 + 5416.67
        ElseIf GrossPay >= 83333 And GrossPay < 333333 Then
            rawtax1 = 83333 * 0.32
            rawtax2 = rawtax1 * 0.32
            HoldingTax = rawtax2 + 20416.67
        ElseIf GrossPay >= 333333 Then
            rawtax1 = 333333 * 0.35
            rawtax2 = rawtax1 * 0.35
            HoldingTax = rawtax2 + 100416
        End If

        Totalearnings = GrossPay - HoldingTax
        Dim ovtTimehourse As Double
        ovtTimehourse = OvertimeHours + OvertimeHours1

        Me.txtRegularHours.Text = regHours.ToString("F")
        Me.txtOvertimeHours.Text = ovtTimehourse.ToString("F")
        Me.txtRegularAmount.Text = regularAmount.ToString("C")
        Me.txtOvertimeAmount.Text = overtimeAmount.ToString("C")
        Me.txtGrossPay.Text = GrossPay.ToString("C")
        Me.txtGrossPay.Text = HoldingTax.ToString("C")
        Me.txtNetPay.Text = Totalearnings.ToString("C")

    End Sub
    Private Sub btnProcessIt_Click(sender As Object, e As EventArgs) Handles btnProcessIt.Click
        Days(CDbl(Me.txtMonday1.Text), CDbl(Me.txtTuesday1.Text), CDbl(Me.txtWednesday1.Text), CDbl(Me.txtThursday1.Text),
    CDbl(Me.txtFriday1.Text), CDbl(Me.txtSaturday1.Text), CDbl(Me.txtSunday1.Text), CDbl(Me.txtMonday2.Text),
    CDbl(Me.txtTuesday2.Text), CDbl(Me.txtWednesday2.Text), CDbl(Me.txtThursday2.Text), CDbl(Me.txtFriday2.Text),
    CDbl(Me.txtSaturday2.Text), CDbl(Me.txtSunday2.Text))

    End Sub
End Class
