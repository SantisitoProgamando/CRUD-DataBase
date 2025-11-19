namespace CRUD_DB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvClientes = new DataGridView();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            dgvPrevClientes = new DataGridView();
            btnEliminarSeleccionando = new Button();
            btnEliminarClientePrevio = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrevClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.Location = new Point(359, 122);
            dgvClientes.Name = "dgvClientes";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(712, 340);
            dgvClientes.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(30, 96);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 52);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar cliente";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(596, 468);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(167, 64);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar cliente por ID";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(761, 43);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(201, 73);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar cliente seleccionado";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(97, 337);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(137, 58);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar en DB";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 23);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // dgvPrevClientes
            // 
            dgvPrevClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrevClientes.Location = new Point(30, 154);
            dgvPrevClientes.Name = "dgvPrevClientes";
            dgvPrevClientes.RowHeadersWidth = 51;
            dgvPrevClientes.Size = new Size(297, 177);
            dgvPrevClientes.TabIndex = 6;
            // 
            // btnEliminarSeleccionando
            // 
            btnEliminarSeleccionando.Location = new Point(497, 43);
            btnEliminarSeleccionando.Name = "btnEliminarSeleccionando";
            btnEliminarSeleccionando.Size = new Size(230, 73);
            btnEliminarSeleccionando.TabIndex = 7;
            btnEliminarSeleccionando.Text = "Eliminar cliente seleccionando";
            btnEliminarSeleccionando.UseVisualStyleBackColor = true;
            btnEliminarSeleccionando.Click += btnEliminarSeleccionando_Click;
            // 
            // btnEliminarClientePrevio
            // 
            btnEliminarClientePrevio.Location = new Point(150, 96);
            btnEliminarClientePrevio.Name = "btnEliminarClientePrevio";
            btnEliminarClientePrevio.Size = new Size(110, 52);
            btnEliminarClientePrevio.TabIndex = 8;
            btnEliminarClientePrevio.Text = "Eliminar Cliente";
            btnEliminarClientePrevio.UseVisualStyleBackColor = true;
            btnEliminarClientePrevio.Click += btnEliminarClientePrevio_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 562);
            Controls.Add(btnEliminarClientePrevio);
            Controls.Add(btnEliminarSeleccionando);
            Controls.Add(dgvPrevClientes);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvClientes);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrevClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private Label label1;
        private DataGridView dgvPrevClientes;
        private Button btnEliminarSeleccionando;
        private Button btnEliminarClientePrevio;
    }
}
