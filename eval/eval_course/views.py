"""views"""

from typing import Iterable

from django.forms import ModelForm, Select, formset_factory
from django.http import HttpRequest, HttpResponse
from django.shortcuts import redirect, render

from .models import Answer, Participant, Question


class _AnswerForm(ModelForm):  # type: ignore
    class Meta:
        model = Answer
        fields = ("choice", "comment")
        widgets = {
            "choice": Select(attrs={"required": True}),
        }


def eval_view(request: HttpRequest) -> HttpResponse:
    """Eval"""
    questions = Question.objects.all()
    answer_form_set = formset_factory(_AnswerForm, extra=questions.count())

    def assign_questions(forms: Iterable[_AnswerForm]) -> None:
        for i, form in enumerate(forms):
            form.instance.question = questions[i]

    if request.method == "POST":
        formset = answer_form_set(data=request.POST)
        assign_questions(formset)
        if formset.is_valid():
            participant = Participant.objects.create()
            for form in formset:
                form.instance.participant = participant
                form.instance.save()
            return redirect("thanks")

    formset = answer_form_set()
    assign_questions(formset)

    return render(request, "eval_course/eval.html", {"forms": formset})


def thanks_view(request: HttpRequest) -> HttpResponse:
    """thanks"""

    return render(request, "eval_course/thanks.html")
