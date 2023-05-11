"""Urls"""

from django.urls import path

from .views import eval_view, thanks_view

urlpatterns = [
    path("form/", eval_view, name="eval"),
    path("thanks/", thanks_view, name="thanks"),
]
