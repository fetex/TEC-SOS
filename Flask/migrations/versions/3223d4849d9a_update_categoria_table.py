"""Update Categoria Table

Revision ID: 3223d4849d9a
Revises: 45e1bdfdc17e
Create Date: 2020-05-30 12:04:08.307899

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '3223d4849d9a'
down_revision = '45e1bdfdc17e'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_unique_constraint(None, 'Categoria', ['categoria'])
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_constraint(None, 'Categoria', type_='unique')
    # ### end Alembic commands ###