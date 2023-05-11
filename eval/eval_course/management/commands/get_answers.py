"""get answers"""

from typing import Any

from django.core.management.base import BaseCommand

from ...models import Answer, Participant


class Command(BaseCommand):
    """Get answers"""

    help = "get answers"

    def handle(self, *args: Any, **options: Any) -> None:
        """handler"""

        participants = Participant.objects.all()
        for participant in participants:
            answers = Answer.objects.filter(participant=participant)
            for answer in answers:
                msg = f"{participant.id}, {answer.question.text}, {answer.choice}, {answer.comment}"
                print(msg)
