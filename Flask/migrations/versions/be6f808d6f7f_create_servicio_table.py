"""Create Servicio Table

Revision ID: be6f808d6f7f
Revises: a6728f6bee6d
Create Date: 2020-05-16 23:53:24.247139

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'be6f808d6f7f'
down_revision = 'a6728f6bee6d'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_table('Servicio',
    sa.Column('servicio_id', sa.Integer(), nullable=False),
    sa.Column('descripcion', sa.String(length=255), nullable=False),
    sa.Column('fecha', sa.Date(), nullable=False),
    sa.Column('estadoServicio_id', sa.Integer(), nullable=True),
    sa.Column('cliente_id', sa.Integer(), nullable=True),
    sa.Column('tecnico_id', sa.Integer(), nullable=True),
    sa.ForeignKeyConstraint(['cliente_id'], ['Cliente.cliente_id'], ),
    sa.ForeignKeyConstraint(['estadoServicio_id'], ['Estado_Servicio.estadoServicio_id'], ),
    sa.ForeignKeyConstraint(['tecnico_id'], ['Tecnico.tecnico_id'], ),
    sa.PrimaryKeyConstraint('servicio_id')
    )
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_table('Servicio')
    # ### end Alembic commands ###