"""unique field estado in EstadoServicio Table

Revision ID: 2e2b236a58a7
Revises: 7f22e915646b
Create Date: 2020-05-31 23:02:43.547407

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '2e2b236a58a7'
down_revision = '7f22e915646b'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_unique_constraint(None, 'Estado_Servicio', ['estado'])
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_constraint(None, 'Estado_Servicio', type_='unique')
    # ### end Alembic commands ###
