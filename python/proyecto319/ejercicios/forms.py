from django import forms

class fibo(forms.Form):
    n_fibo = forms.IntegerField(label="n")

class primo(forms.Form):
    n_primo = forms.IntegerField(label="n")

class fibo2(forms.Form):
    n_fibo2 = forms.IntegerField(label="n")


class calculadora(forms.Form):
    a = forms.IntegerField(label="a")
    b = forms.IntegerField(label="b")
    op_c = forms.CharField(label="operacion(suma, resta, mult o div):")

class calc_mat(forms.Form):
    mat100 = forms.IntegerField(label="matriz 1[0,0]:")
    mat101 = forms.IntegerField(label="matriz 1[0,1]:")
    mat110 = forms.IntegerField(label="matriz 1[1,0]:")
    mat111 = forms.IntegerField(label="matriz 1[1,1]:")
    mat200 = forms.IntegerField(label="matriz 2[0,0]:")
    mat201 = forms.IntegerField(label="matriz 2[0,1]:")
    mat210 = forms.IntegerField(label="matriz 2[1,0]:")
    mat211 = forms.IntegerField(label="matriz 2[1,1]:")
    op_m = forms.CharField(label="operacion(suma, resta o multi):")
