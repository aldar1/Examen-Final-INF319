from django.shortcuts import render
from django.http import HttpResponse
from .forms import *
from array import *

#funciones
#fibo
def func_fibo(n):
    a = 0
    b = 1
    res = "0"
    for i in range(n):
        res += ", "
        aux = a
        a = b
        b = aux+a
        res += str(a)
    return res

#Primo
def func_primo(n):
    a = 2
    res =""
    while n!=0:
        b=0
        for i in range(1,a):
            if(a%i==0):
                b=b+1
        if(b==1):
            n=n-1
            res += ",  "
            res += str(a)
        a=a+1
    return res

#fibo 4 termios    
def func_fibo2(n):
    a = 0
    b = 0
    c = 1
    d = 1
    res ="0,  0,  1,  1"
    if(n==1):
        return "0"
    else:
        if(n==2):
            return "0,  0"
        else:
            if(n==3):
                return "0,  0,  1"
            else:
                if(n==4):
                    return "0,  0,  1,  1"
                else:
                    n=n-3
                    for i in range(1,n):
                        f=a+b+c+d
                        a=b
                        b=c
                        c=d
                        d=f
                        res =res+ ",  "
                        res =res+ str(f)
                    return res

#calculadora
def suma(x,y): return x + y
def resta(x,y): return x - y
def mult(x,y): return x * y
def div(x,y): return x / y

def func_calcu(a,b,func):
    res = func(a,b)
    return str(res)

def inter(a,b,op):
    if (op == 'suma'):
        return func_calcu(a,b,suma)
    elif (op == 'resta'):
        return func_calcu(a,b,resta)
    elif (op == 'mult'):
        return func_calcu(a,b,mult)
    elif (op == 'div'):
        return func_calcu(a,b,div)
    else:
        return "Operacion no reconocida"

#matrices
def sumat(m1, m2):
    res = [[0,0],[0,0]]
    cad = ""
    for i in range(2):
        for j in range(2):
            res[i][j] = m1[i][j] + m2[i][j]
            cad += str(res[i][j]) + " "
        cad+="<br>"
    return cad

def resmatri(m1, m2):
    res = [[0,0],[0,0]]
    cad = ""
    for i in range(2):
        for j in range(2):
            res[i][j] = m1[i][j] - m2[i][j]
            cad += str(res[i][j]) + " "
        cad+="<br>"
    return cad

def mulmat(m1, m2):
    res = [[0,0],[0,0]]
    cad = ""
    for i in range(2):
        for j in range(2):
            for k in range(2):
                res[i][j] += m1[i][k] * m2[k][j]
            cad += str(res[i][j]) + " "
        cad+="<br>"
    return cad


def interm(a,b,op):
    if (op == 'suma'):
        return func_mat(a,b,sumat)
    elif (op == 'resta'):
        return func_mat(a,b,resmatri)
    elif (op == 'multi'):
        return func_mat(a,b,mulmat)
    else:
        return "Operacion no reconocida"

def func_mat(a,b,func):
    return func(a,b)







#vistas

def index(request):
    return render(request, "form_index.html")

def fibov(request):
    form = fibo()
    return render(request, "form_fibo.html", {"form":form})

def primov(request):
    form = primo()
    return render(request, "form_primo.html", {"form":form})

def fibov2(request):
    form = fibo2()
    return render(request, "form_fibo2.html", {"form":form})


def calculadorav(request):
    form = calculadora()
    return render(request, "form_calcu.html", {"form":form})

def calc_matv(request):
    form = calc_mat()
    return render(request, "form_matrices.html", {"form":form})


def resfibo(request):
    resp = "<h2>Resultados</h2>"
    x = request.GET['n_fibo']
    resp += func_fibo(int(x))
    return HttpResponse(resp)

def resprimo(request):
    resp = "<h2>Resultados</h2>"
    x = request.GET['n_primo']
    resp += func_primo(int(x))
    return HttpResponse(resp)

def resfibo2(request):
    resp = "<h2>Resultados</h2>"
    x = request.GET['n_fibo2']
    resp += func_fibo2(int(x))
    return HttpResponse(resp)


def rescalcu(request):
    resp = "<h2>Resultados</h2>"
    a = int(request.GET['a'])
    b = int(request.GET['b'])
    op = request.GET['op_c']
    resp += inter(a,b,op)
    return HttpResponse(resp)

def resmat(request):
    resp = "<h2>Resultados</h2>"
    mat1 = [[0,0],[0,0]]
    mat2 = [[0,0],[0,0]]
    mat1[0][0] = int(request.GET['mat100'])
    mat1[0][1] = int(request.GET['mat101'])
    mat1[1][0] = int(request.GET['mat110'])
    mat1[1][1] = int(request.GET['mat111'])
    mat2[0][0] = int(request.GET['mat200'])
    mat2[0][1] = int(request.GET['mat201'])
    mat2[1][0] = int(request.GET['mat210'])
    mat2[1][1] = int(request.GET['mat211'])
    op = request.GET['op_m']
    resp += interm(mat1, mat2, op)
    return HttpResponse(resp)


#falta separar

