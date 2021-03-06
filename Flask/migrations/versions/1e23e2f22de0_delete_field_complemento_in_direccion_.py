"""delete field complemento in Direccion Table

Revision ID: 1e23e2f22de0
Revises: 74f94c0b82b7
Create Date: 2020-05-31 22:13:13.103140

"""
from alembic import op
import sqlalchemy as sa
from sqlalchemy.dialects import mysql

# revision identifiers, used by Alembic.
revision = '1e23e2f22de0'
down_revision = '74f94c0b82b7'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_column('Direccion', 'complemento')
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('Direccion', sa.Column('complemento', mysql.VARCHAR(length=50), nullable=True))
    # ### end Alembic commands ###
