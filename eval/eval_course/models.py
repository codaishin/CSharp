"""models"""
from django.db import models


class Participant(models.Model):
    """Participant"""


class Question(models.Model):
    """Question"""

    text = models.TextField()


class Answer(models.Model):
    """Answer"""

    class Choice(models.IntegerChoices):
        """choices"""

        FULLY_DISAGREE = 1, "stimme überhauptnicht zu"
        DISAGREE = 2, "stimme nicht zu"
        AGREE = 3, "stimme zu"
        FULL_AGREE = 4, "stimme voll zu"

    participant = models.ForeignKey(to=Participant, on_delete=models.CASCADE)
    question = models.ForeignKey(to=Question, on_delete=models.CASCADE)
    choice = models.IntegerField(choices=Choice.choices, verbose_name="Auswahl")
    comment = models.TextField(
        null=True,
        blank=True,
        default=None,
        verbose_name="Kommentar",
    )
