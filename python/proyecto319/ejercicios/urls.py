from django.urls import path

from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('fibo', views.fibov, name='fibo'),
    path('primo', views.primov, name='primo'),
    path('fibo2', views.fibov2, name='fibo2'),
    path('calculadora', views.calculadorav, name='calculadora'),
    path('matrices', views.calc_matv, name='matrices'),
    path('resfibo', views.resfibo, name='resfibo'),
    path('resfibo2', views.resfibo2, name='resfibo2'),
    path('resprimo', views.resprimo, name='resprimo'),
    path('rescalcu', views.rescalcu, name='rescalcu'),
    path('resmat', views.resmat, name='resmat'),
]