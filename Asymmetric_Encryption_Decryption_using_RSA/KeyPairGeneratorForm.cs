using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Asymmertic_Encryption_Decryption
{
	public class KeyPairGeneratorForm: System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button generateKeysButton;
		private System.ComponentModel.Container components = null;

		public KeyPairGeneratorForm()
		{ InitializeComponent(); }
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{ 
				if( components != null )
				{ components.Dispose(); }
			}
			base.Dispose( disposing );
		}
		
		private void InitializeComponent()
		{
            this.generateKeysButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateKeysButton
            // 
            this.generateKeysButton.BackColor = System.Drawing.SystemColors.Control;
            this.generateKeysButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.generateKeysButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateKeysButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.generateKeysButton.Location = new System.Drawing.Point(61, 32);
            this.generateKeysButton.Name = "generateKeysButton";
            this.generateKeysButton.Size = new System.Drawing.Size(68, 43);
            this.generateKeysButton.TabIndex = 0;
            this.generateKeysButton.Text = "Generate Keys";
            this.generateKeysButton.UseVisualStyleBackColor = false;
            this.generateKeysButton.Click += new System.EventHandler(this.generateKeysButton_Click);
            // 
            // KeyPairGeneratorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(196, 87);
            this.Controls.Add(this.generateKeysButton);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyPairGeneratorForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Keys";
            this.Load += new System.EventHandler(this.KeyPairGeneratorForm_Load);
            this.ResumeLayout(false);

		}

		private void generateKeysButton_Click( object sender, System.EventArgs e )
		{
			//Asymmertic_Encription_Decription.MainForm.SetBitStrength( Convert.ToInt32( numericUpDown.Value ) );
			this.DialogResult = DialogResult.OK;
			this.Dispose( true );
		}

		private void KeyPairGeneratorForm_Load( object sender, EventArgs e )
		{ Asymmertic_Encryption_Decryption.MainForm.SetBitStrength( 1024 ); }		
	}
}