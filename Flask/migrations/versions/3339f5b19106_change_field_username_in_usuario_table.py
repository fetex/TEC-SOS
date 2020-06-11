"""change field username in Usuario Table

Revision ID: 3339f5b19106
Revises: 2e2b236a58a7
Create Date: 2020-06-01 10:15:00.990294

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '3339f5b19106'
down_revision = '2e2b236a58a7'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_index('username', table_name='Usuario')
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_index('username', 'Usuario', ['username'], unique=True)
    # ### end Alembic commands ###
