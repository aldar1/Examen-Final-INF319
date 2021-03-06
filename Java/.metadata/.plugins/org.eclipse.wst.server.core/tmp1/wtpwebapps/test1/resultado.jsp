<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Resultado</title>
</head>
<%@ page import="java.util.*" %>

<%!

public interface Callable {
    public int suma(int a, int b);
    public int resta(int a, int b);
    public int multi(int a, int b);
    public int divi(int a, int b);
    public int[][] sumamat(int[][] a, int[][] b);
    public int[][] restamat(int[][] a, int[][] b);
    public int[][] multimat(int[][] a, int[][] b);
}
    
public class Calcu implements Callable {
    public int suma(int a, int b) {
    	return a+b;
    }
    public int resta(int a, int b) {
    	return a-b;
    }
    public int multi(int a, int b) {
    	return a*b;
    }
    public int divi(int a, int b) {
    	return a/b;
    }
    public int[][] sumamat(int[][] mat1, int[][] mat2)
    {
        int[][] res = new int[2][2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                res[i][j] = mat1[i][j] + mat2[i][j];
            }
        }
        return res;
    }
    public int[][] restamat(int[][] mat1, int[][] mat2)
    {
        int[][] res = new int[2][2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                res[i][j] = mat1[i][j] - mat2[i][j];
            }
        }
        return res;
    }
    
    public int[][] multimat(int[][] mat1, int[][] mat2)
    {
        int[][] res = new int[2][2];
        int n = 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                res[i][j] = 0;
                for (int k = 0; k < n; k++)
                {
                    res[i][j] += mat1[i][k] * mat2[k][j];
                }
            }
        }
        return res;
    }
}

public static int invoke(Callable callable, int a, int b, String op){
	if (op.equals("suma")) return callable.suma(a,b);
	else if (op.equals("resta")) return callable.resta(a,b);
	else if (op.equals("multi")) return callable.multi(a,b);
	return callable.divi(a,b);
}

public static int[][] mat(Callable callable, int[][] a, int[][] b, String op){
	if (op.equals("suma")) return callable.sumamat(a,b);
	else if (op.equals("resta")) return callable.restamat(a,b);
	return callable.multimat(a,b);
}
%>
<body>
<h1>Resultados</h1>
</body>
<%
if(request.getParameter("n_prim") != null){
	out.print("<h2>Primos</h2>");
	int lim,p1=1;
	lim = Integer.parseInt(request.getParameter("n_prim")); 
	while(lim!=0){
		int p2 = 0;
		for(int i=1;i<=p1;i++){
			if(p1%i==0){
				p2++;
			}
		}
		if(p2==2){
			lim--;
			out.print(p1+", ");
		}
		p1++;
	}
}
%>


<% 
if(request.getParameter("n_fib") != null){
	out.print("<h2>Fibonacci 4 terminos</h2>");
	int n = Integer.parseInt(request.getParameter("n_fib"));
	int a = 0;
	int b = 0;
	int c = 1;
	int d = 1;
	int f;
	if(n==1){
		out.print("0" + ", ");
	}
	else{
		if(n==2){
			out.print("0,  0"+ ", ");
		}
		else{
			if(n==3){
				out.print("0,  0,  1" + ", ");
			}
			else{
				if(n==4){
					out.print("0,  0,  1,  1" + ", ");
				}
				else{
					out.print("0,  0,  1,  1" + ", ");
					n = n-4;
					for(int i=1;i<=n;i++){
						f = a+b+c+d;
						a=b;
						b=c;
						c=d;
						d=f;
						out.print(f + ", ");
					}
				}
			}
		}
	}
}

if(request.getParameter("n_fibo") != null){
	out.print("<h2>Fibonacci 2 Terminos</h2>");
	int a, b, lim, aux;
    lim = Integer.parseInt(request.getParameter("n_fibo"));
    a = 0;
    b = 1;
    out.print("0, ");
    for (int i = 2; i <= lim; i++)
    {
        aux = a;
        a = b;
        b = aux + a;
        out.print(a + ", ");
        if (i % 10 == 0 && i != 0) out.print("<br>");
    }
}

//calculadora
else if(request.getParameter("a_calcu") != null && request.getParameter("b_calcu") != null && request.getParameter("op_calcu") != null){
	out.print("<h2>Calculadora</h2>");
	String op = request.getParameter("op_calcu");
	int a = Integer.parseInt(request.getParameter("a_calcu"));
    int b = Integer.parseInt(request.getParameter("b_calcu"));
    if(op.equals("suma") || op.equals("resta") || op.equals("multi") || op.equals("divi")){
    	out.print(op+"<br>");
    	Callable cmd = new Calcu();
        int res = invoke(cmd, a, b, op);
    	out.print(res);
    }
    else out.print("Operacion no reconocida");
}

//calculadora de matrices
else if(request.getParameter("mat100") != null && request.getParameter("mat101") != null && request.getParameter("mat110") != null &&
	request.getParameter("mat111") != null && request.getParameter("mat200") != null && request.getParameter("mat201") != null &&
	request.getParameter("mat210") != null && request.getParameter("mat211") != null && request.getParameter("op_matrices") != null){
	out.print("<h2>Calculadora de matrices</h2>");
	String op = request.getParameter("op_matrices");
	out.print(op+"<br>");
	int a = Integer.parseInt(request.getParameter("mat100"));
	int b = Integer.parseInt(request.getParameter("mat101"));
	int c = Integer.parseInt(request.getParameter("mat110"));
	int d = Integer.parseInt(request.getParameter("mat111"));
	int a1 = Integer.parseInt(request.getParameter("mat200"));
	int b1 = Integer.parseInt(request.getParameter("mat201"));
	int c1 = Integer.parseInt(request.getParameter("mat210"));
	int d1 = Integer.parseInt(request.getParameter("mat211"));

	int[][] m1 = {{a,b},{c,d}};
	int[][] m2 = {{a1,b1},{c1,d1}};
    if(op.equals("suma") || op.equals("resta") || op.equals("multi")){
    	Callable cmd = new Calcu();
        int[][] res = mat(cmd, m1, m2, op);
        for(int i=0; i<2; i++){
        	for(int j=0; j<2; j++){
        		out.print(res[i][j]+" ");
        	}
        	out.print("<br>");
        }
    }
    else out.print("Operacion no reconocida");
}



%>
</body>
</html>