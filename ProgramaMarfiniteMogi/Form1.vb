﻿

' rem teste de programa do claudio

Imports System.Data.SqlClient
Imports System.Linq
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Xml
Imports System.Globalization
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System
Imports System.Math
Imports Microsoft.Win32
Imports System.Net





Public Class Form1

    Dim variavelClique As String
    Dim variavelImpressao As String
    Dim nomeArquivoXML As String
    Dim arquivo As New OpenFileDialog
    Dim FlagProdPesquisa As String = "0"
    Dim NumeroNotaPedidoCompra As String
    Dim i As Integer
    Dim flag As String
    Dim flag1 As String
    Dim FlagProdutos As String
    Dim connection As SqlConnection
    Dim command As SqlCommand
    Dim connection2 As SqlConnection
    Dim command2 As SqlCommand
    Dim travado As Boolean
    Dim nivel As Integer
    Public logado As Boolean
    Dim produto_cadastrado As Boolean
    Dim cadastro_transportadoras As Boolean
    Dim hora_final As String
    Dim somatotal As Double
    Dim habilitarProvisório As String
    Dim fernando As String
    Dim z As Integer
    Dim ReabrirVendaBalcao As String
    Dim AcertarPreco As Boolean
    Dim PrecoAtacado As Boolean
    Dim FlagNotaentrada As String
    Dim ContLinhaRelEst As Integer

    ' dados sobre o combobox da tela de relatório de despesas
    Dim IdentificacaoCombobox As Integer

    ' dados da matriz
    Dim Clientes(1000) As String
    Dim telefone(1000) As String
    Dim email(1000) As String
    Dim contato(1000) As String

    Dim ii As Integer

    Private Sub ClienteBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ClienteBindingSource.EndEdit()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSetFinal.VendasBalcaoTotal' table. You can move, or remove it, as needed.
        Me.VendasBalcaoTotalTableAdapter.Fill(Me.DataSetFinal.VendasBalcaoTotal)
        'TODO: This line of code loads data into the 'DataSetFinal.VendasBalcaoPedidos' table. You can move, or remove it, as needed.
        Me.VendasBalcaoPedidosTableAdapter.Fill(Me.DataSetFinal.VendasBalcaoPedidos)
        'TODO: This line of code loads data into the 'DataSetFinal.VendasBalcaoResultado' table. You can move, or remove it, as needed.
        Me.VendasBalcaoResultadoTableAdapter.Fill(Me.DataSetFinal.VendasBalcaoResultado)
        'TODO: This line of code loads data into the 'DataSetFinal.RamoCliente' table. You can move, or remove it, as needed.
        Me.RamoClienteTableAdapter.Fill(Me.DataSetFinal.RamoCliente)
        'TODO: This line of code loads data into the 'DataSetFinal.EnderecoEletronico' table. You can move, or remove it, as needed.
        Me.EnderecoEletronicoTableAdapter.Fill(Me.DataSetFinal.EnderecoEletronico)
        'TODO: This line of code loads data into the 'DataSetFinal.ApelidoErrado' table. You can move, or remove it, as needed.
        Me.ApelidoErradoTableAdapter.Fill(Me.DataSetFinal.ApelidoErrado)
        'TODO: This line of code loads data into the 'DataSetFinal.VendasMlb' table. You can move, or remove it, as needed.
        Me.VendasMlbTableAdapter.Fill(Me.DataSetFinal.VendasMlb)
        'TODO: This line of code loads data into the 'DataSetFinal.teste' table. You can move, or remove it, as needed.
        Me.TesteTableAdapter.Fill(Me.DataSetFinal.teste)
        'TODO: This line of code loads data into the 'DataSetFinal.PedidoCompra' table. You can move, or remove it, as needed.
        Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)
        'TODO: This line of code loads data into the 'DataSetFinal.NotasEntrada' table. You can move, or remove it, as needed.
        Me.NotasEntradaTableAdapter.Fill(Me.DataSetFinal.NotasEntrada)
        'TODO: This line of code loads data into the 'DataSetFinal.NomeContasFuncionarios' table. You can move, or remove it, as needed.
        Me.NomeContasFuncionariosTableAdapter.Fill(Me.DataSetFinal.NomeContasFuncionarios)
        'TODO: This line of code loads data into the 'DataSetFinal.NomeContaOutra' table. You can move, or remove it, as needed.
        Me.NomeContaOutraTableAdapter.Fill(Me.DataSetFinal.NomeContaOutra)
        'TODO: This line of code loads data into the 'DataSetFinal.NomeContaImposto' table. You can move, or remove it, as needed.
        Me.NomeContaImpostoTableAdapter.Fill(Me.DataSetFinal.NomeContaImposto)
        'TODO: This line of code loads data into the 'DataSetFinal.NomeConta_aluguel_Banco' table. You can move, or remove it, as needed.
        Me.NomeConta_aluguel_BancoTableAdapter.Fill(Me.DataSetFinal.NomeConta_aluguel_Banco)
        'TODO: This line of code loads data into the 'DataSetFinal.ContasTransportes' table. You can move, or remove it, as needed.
        Me.ContasTransportesTableAdapter.Fill(Me.DataSetFinal.ContasTransportes)
        'TODO: This line of code loads data into the 'DataSetFinal.NOmeContaExtras' table. You can move, or remove it, as needed.
        Me.NOmeContaExtrasTableAdapter.Fill(Me.DataSetFinal.NOmeContaExtras)
        'TODO: This line of code loads data into the 'DataSetFinal.ListaContasArquivo' table. You can move, or remove it, as needed.
        Me.ListaContasArquivoTableAdapter.Fill(Me.DataSetFinal.ListaContasArquivo)
        'TODO: This line of code loads data into the 'DataSetFinal.NomeContas' table. You can move, or remove it, as needed.
        Me.NomeContasTableAdapter.Fill(Me.DataSetFinal.NomeContas)
        'TODO: This line of code loads data into the 'DataSetFinal.linguas' table. You can move, or remove it, as needed.
        Me.LinguasTableAdapter.Fill(Me.DataSetFinal.linguas)
        'TODO: This line of code loads data into the 'DataSetFinal.EmailErroCliente' table. You can move, or remove it, as needed.
        Me.EmailErroClienteTableAdapter.Fill(Me.DataSetFinal.EmailErroCliente)
        'TODO: This line of code loads data into the 'DataSetFinal.orcamento2' table. You can move, or remove it, as needed.
        Me.Orcamento2TableAdapter.Fill(Me.DataSetFinal.orcamento2)
        'TODO: This line of code loads data into the 'DataSetFinal.TabelaCFOP' table. You can move, or remove it, as needed.
        Me.TabelaCFOPTableAdapter.Fill(Me.DataSetFinal.TabelaCFOP)
        'TODO: This line of code loads data into the 'DataSetFinal.orcamento2' table. You can move, or remove it, as needed.
        Me.Orcamento2TableAdapter.Fill(Me.DataSetFinal.orcamento2)
        'TODO: This line of code loads data into the 'DataSetFinal.ItemOrcamento' table. You can move, or remove it, as needed.
        Me.ItemOrcamentoTableAdapter.Fill(Me.DataSetFinal.ItemOrcamento)
        'TODO: This line of code loads data into the 'DataSetFinal.orcamento' table. You can move, or remove it, as needed.
        'Me.OrcamentoTableAdapter.Fill(Me.DataSetFinal.orcamento)
        'TODO: This line of code loads data into the 'DataSetFinal.ItemNfeEmitida' table. You can move, or remove it, as needed.
        Me.ItemNfeEmitidaTableAdapter.Fill(Me.DataSetFinal.ItemNfeEmitida)
        'TODO: This line of code loads data into the 'DataSetFinal.balcao' table. You can move, or remove it, as needed.
        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)
        'TODO: This line of code loads data into the 'DataSetFinal.NFE_Emitidas' table. You can move, or remove it, as needed.
        Me.NFE_EmitidasTableAdapter.Fill(Me.DataSetFinal.NFE_Emitidas)
        'TODO: This line of code loads data into the 'DataSetFinal.ItemPedidos' table. You can move, or remove it, as needed.
        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
        'TODO: This line of code loads data into the 'DataSetFinal.PedidoNFE' table. You can move, or remove it, as needed.
        Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)
        'TODO: This line of code loads data into the 'DataSetFinal.cadastrodoNCM' table. You can move, or remove it, as needed.
        Me.CadastrodoNCMTableAdapter.Fill(Me.DataSetFinal.cadastrodoNCM)
        'TODO: This line of code loads data into the 'DataSetFinal.pedidoMarfinite' table. You can move, or remove it, as needed.
        Me.PedidoMarfiniteTableAdapter.Fill(Me.DataSetFinal.pedidoMarfinite)
        'TODO: This line of code loads data into the 'TesteDataSet1.produtos' table. You can move, or remove it, as needed.
        Me.ProdutosTableAdapter1.Fill(Me.DataSetFinal.produtos)
        'TODO: This line of code loads data into the 'DataSetFinal.transportadoras' table. You can move, or remove it, as needed.
        Me.TransportadorasTableAdapter1.Fill(Me.DataSetFinal.transportadoras)
        'TODO: This line of code loads data into the 'TesteDataSet.transportadoras' table. You can move, or remove it, as needed.
        Me.TransportadorasTableAdapter.Fill(Me.DataSetFinal.transportadoras)

        'deixa a coluna da emissão de NFE em outra cor
        ' qtdeaserentregadaNFE_item.DefaultCellStyle.BackColor = Color.Aquamarine

        logado = True
        nivel = 1

        If logado = False Then
            Me.Visible = False
        End If


        'TODO: This line of code loads data into the 'DataSetFinal.capitalgirofornecedor' table. You can move, or remove it, as needed.
        Me.CapitalgirofornecedorTableAdapter.Fill(Me.DataSetFinal.capitalgirofornecedor)

        '------------------------------------------------------------------------------
        'esses próximos comandos são somente para qdo ligamos o programa na tela form produtos
        ' TELA PRODUTOS INICIO
        limpar_inicioFormProd()
        verificarNivelAcesso()
        flag = ""
        btn_calcPrecos.Enabled = False
        DesistirOperaçãoToolStripMenuItem2.Visible = False
        menu_confirmarprod.Visible = False

       
        'TODO: This line of code loads data into the 'DataSetFinal.corProd' table. You can move, or remove it, as needed.
        Me.CorProdTableAdapter.Fill(Me.DataSetFinal.corProd)
        'TODO: This line of code loads data into the 'DataSetFinal.fornecedor' table. You can move, or remove it, as needed.
        Me.FornecedorTableAdapter.Fill(Me.DataSetFinal.fornecedor)
        'TODO: This line of code loads data into the 'DataSetFinal.linhasprod' table. You can move, or remove it, as needed.
        Me.LinhasprodTableAdapter.Fill(Me.DataSetFinal.linhasprod)
        'TODO: This line of code loads data into the 'DataSetFinal.produtos' table. You can move, or remove it, as needed.
        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
        'TODO: This line of code loads data into the 'DataSetFinal.nfefornecedor' table. You can move, or remove it, as needed.
        Me.NfefornecedorTableAdapter.Fill(Me.DataSetFinal.nfefornecedor)
        'TODO: This line of code loads data into the 'DataSetFinal.estados' table. You can move, or remove it, as needed.
        Me.EstadosTableAdapter.Fill(Me.DataSetFinal.estados)
        'TODO: This line of code loads data into the 'DataSetFinal.vendedor' table. You can move, or remove it, as needed.
        Me.VendedorTableAdapter.Fill(Me.DataSetFinal.vendedor)
        'TODO: This line of code loads data into the 'DataSetFinal.cliente' table. You can move, or remove it, as needed.
        Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)

    End Sub
    
    Public Sub verificarNivelAcesso()

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select * from autorizacao where id_autorizacao = @id_autorizacao "
        command.Parameters.Add("@id_autorizacao", SqlDbType.VarChar, 50).Value = "1"

        connection.Open()

        Dim lrd As SqlDataReader = command.ExecuteReader()

        While lrd.Read
            fernando = lrd("codigo_autorizado")
        End While

        connection.Close()


    End Sub


    Private Sub TabControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseClick

        'Atualiza a form transportadora quando o tabcontrol 1 é clicado
        If TabControl1.SelectedTab.ToString = "TabPage: {Transportadoras}" Then

            btn_procuraCEpTrans.Enabled = False
            DesistirOperaçãoToolStripMenuItem.Visible = False
            deshabilitarmenuTrans()
            travarCamposTrans()

        End If
        ' AO CLICAR A ABA DAS VENDAS BALCÃO
        If TabControl1.SelectedTab.ToString = "TabPage: {Vendas Balcão}" Then

            ComboBox2.Text = ""
            TextBox1.Clear()
            RadioButton25.Checked = True

            'trabalhando com os radiobutton
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            RadioButton6.Checked = False
            Button84.Enabled = False


            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
            RadioButton5.Enabled = False
            RadioButton6.Enabled = False
          


            Button12.Enabled = False
            Button11.Enabled = False
            tbcotrl_pdv.TabPages.Remove(tbpg_produtosPDV)
            BalcaoBindingSource.Filter = String.Format("nomevendedor_balcao LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Relatórios}" Then
            ' Código de acesso
            Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
            Dim date1 As New Date()
            date1 = Date.Now
            Dim ci As CultureInfo = CultureInfo.InvariantCulture
            '    Dim datacodigo2 = date1.ToString("dd.MM.yyyy.hh.mm", ci)
            Dim datacodigo2 = date1.ToString("dd.MM.yyyy.hh", ci)
            datacodigo2 = datacodigo2.Replace(".", "")


            ' Acertando dados na tela de Despesas na aba Relatório
            'pegando o primeiro dia do mês
            Dim ano As Integer = Today.Year
            Dim mes As Integer = Today.Month
            Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
            Dim ultimoDia As DateTime = New DateTime(ano, mes + 1, 1).AddDays(-1)
            DateTimePicker32.Text = primeiroDia
            DateTimePicker33.Text = UltimoDia


            Button59.Enabled = True
            Button63.Enabled = False
            Button64.Enabled = False
            TextBox202.Enabled = False
            TextBox185.Enabled = False
            TextBox203.Enabled = False
            TextBox204.Enabled = False
            DateTimePicker35.Enabled = False
            DateTimePicker35.Value = New DateTime(ano - 1, mes, 1).AddDays(-3)
            TextBox212.Enabled = False
            Button68.Enabled = False
            Button71.Enabled = False

            ' bloquear os combos
            ComboBox6.Enabled = False
            ComboBox11.Enabled = False
            ComboBox20.Enabled = False
            ComboBox21.Enabled = False
            ComboBox22.Enabled = False
            ComboBox23.Enabled = False



            If codigoEntrada <> datacodigo2 Then
                MessageBox.Show("Código inválido")
                TabControl1.SelectedIndex = 0
                Exit Sub
            End If

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Mala direta}" Then

            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox174.Enabled = False
            TextBox180.Enabled = False
            ApagarToolStripMenuItem2.Enabled = False
            DateTimePicker1.Text = Date.Now

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Pedidos}" Then
            ItemPedidosBindingSource.Filter = String.Format("codprod_item LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")
            ConfirmarPedidoToolStripMenuItem.Enabled = False
            btn_conifmardadospedNFE.Enabled = False
            btn_deletaritempedidosnfe.Enabled = False
            btn_enviarEMail.Enabled = False
            Dataemissao_pedDateTimePicker.Text = Date.Now
            travacamposformpedidosNFE()
            TabControlpedidos_nfe.TabPages.Remove(tabpageProdutos_nfe)
            TabControlpedidos_nfe.TabPages.Remove(TabPageClientes_nfe)
            TabControlpedidos_nfe.TabPages.Remove(TabPageTransportadora_nfe)
            ComboBox16.Enabled = False
            RadioButton9.Enabled = False
            RadioButton7.Enabled = False
            Button49.Visible = False
            Button51.Enabled = False
            Button52.Enabled = True
            Button58.Enabled = False
            Button61.Enabled = False

            ItemPedidosDataGridView.Columns(17).DefaultCellStyle.Format = "MM/dd/yyyy"

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Cadastrar Pasta NFe}" Then

           
            ' pedir o código
            Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
            If codigoEntrada <> fernando Then
                MessageBox.Show("Código inválido")
                TabControl1.SelectedIndex = 0
                Exit Sub
            End If
            ' buscar a data
            DateTimePicker39.Text = Date.Now
            DateTimePicker40.Text = Date.Now
            ' acetar a data que se fará a busca
            Dim ano As Integer = Today.Year
            Dim mes As Integer = Today.Month
            Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
            DateTimePicker20.Text = primeiroDia
            Select Case mes
                Case 1
                    Label403.Text = "Janeiro"
                Case 2
                    Label403.Text = "Fevereiro"
                Case 3
                    Label403.Text = "Março"
                Case 4
                    Label403.Text = "Abril"
                Case 5
                    Label403.Text = "Maio"
                Case 6
                    Label403.Text = "Junho"
                Case 7
                    Label403.Text = "Julho"
                Case 8
                    Label403.Text = "Agosto"
                Case 9
                    Label403.Text = "Setembro"
                Case 10
                    Label403.Text = "Outubro"
                Case 11
                    Label403.Text = "Novembro"
                Case 12
                    Label403.Text = "Dezembro"
            End Select
            ' buscar tabela do mês

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim sql2 As String = "SELECT * FROM VendasMlb WHERE DataPedido_VendasMlb >= convert (datetime, '" & DateTimePicker20.Text & "' ,103)"
            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()
            Try
                connection.Open()
                dataadapter.Fill(ds, "VendasMlb")
                connection.Close()
                VendasMlbDataGridView.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Estatisticas}" Then

            NotasEntradaBindingSource.Filter = String.Format("FornecedorEntrada LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")
            TextBox27.Enabled = False
            Button67.Enabled = False

            Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
            If codigoEntrada <> fernando Then
                MessageBox.Show("Código inválido")
                TabControl1.SelectedIndex = 0
                Exit Sub
            End If


        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Pedido Compra}" Then

            PedidoCompraBindingSource.Filter = String.Format("Codigo_PedidoCompraString LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")
            Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
            If codigoEntrada <> fernando Then
                MessageBox.Show("Código inválido")
                TabControl1.SelectedIndex = 0
                Exit Sub
            End If
            TabControl2.TabPages.Remove(Tab_fornecedor)
            RadioButton13.Checked = True
            Button86.Enabled = False
            ComboBox26.Enabled = True

        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Back Up}" Then
            Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
            If codigoEntrada <> fernando Then
                MessageBox.Show("Código inválido")
                TabControl1.SelectedIndex = 0
                Exit Sub
            End If
        End If
        'atualiza o form clientes quando é chamado no tabcontrol1
        If TabControl1.SelectedTab.ToString = "TabPage: {Clientes}" Then

            Id_clienteTextBox.Enabled = False
            btn_buscarcepcliente.Enabled = False
            DesistirOperaçãoToolStripMenuItem1.Visible = False
            ConfirmarToolStripMenuItem.Visible = False
            btn_ValidarCNPJ.Enabled = False
            habilitarmenuclientes()
            travarCampos()

            Dim v_SelectRow As Integer

            travarCampos()
            btn_buscarcepcliente.Enabled = False

            'busca relativa à pessoa físia e jurídica da tabela clientes coluna 2 somente quando ela é clicada 
            If ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "Fisica" Then

                pes_juridica.BackColor = Color.Silver
                pes_juridica.Checked = False
                pes_fisica.Checked = True
                pes_fisica.BackColor = Color.Gray

            End If

            If ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "Jurídica" Then

                pes_fisica.BackColor = Color.Silver
                pes_fisica.Checked = False
                pes_juridica.Checked = True
                pes_juridica.BackColor = Color.Gray

            End If


            'busca relativa `a busca do ISENTO  da tabela clientes coluna 19-------------------------

            If ClienteDataGridView5.Item(19, v_SelectRow).Value.ToString() = "sim" Then

                isento_nao.BackColor = Color.Silver
                isento_nao.Checked = False
                isento_sim.Checked = True
                isento_sim.BackColor = Color.Gray

            End If

            If ClienteDataGridView5.Item(19, v_SelectRow).Value.ToString() = "não" Then

                isento_sim.BackColor = Color.Silver
                isento_sim.Checked = False
                isento_nao.Checked = True
                isento_nao.BackColor = Color.Gray

            End If

            'busca relativa `a busca do vender ou não do cliente da tabela clientes coluna 16 -------------------------

            If ClienteDataGridView5.Item(16, v_SelectRow).Value.ToString() = "vender" Then

                naovender_cliente.BackColor = Color.Silver
                naovender_cliente.Checked = False
                vender_cliente.Checked = True
                vender_cliente.BackColor = Color.Gray

            End If

            If ClienteDataGridView5.Item(16, v_SelectRow).Value.ToString() = "não vender" Then

                vender_cliente.BackColor = Color.Silver
                vender_cliente.Checked = False
                naovender_cliente.Checked = True
                naovender_cliente.BackColor = Color.Gray

            End If

        End If

       

    End Sub



    'Função apagar txt_box do formulário clientes
    Public Sub ClearTextBox()

        Id_clienteTextBox.Clear()
        Nome_clienteTextBox.Clear()
        Nfantasia_clienteTextBox.Clear()
        msktxtbox_rgcliente.Clear()
        msk_cpfcliente.Clear()
        msktxt_cnpjcliente.Clear()
        msk_insestadualcliente.Clear()
        Email_clienteTextBox.Clear()
        Cep_clienteMaskedTextBox.Clear()
        Endereco_clienteTextBox.Clear()
        Numerorua_clienteTextBox.Clear()
        Bairro_clienteTextBox.Clear()
        Cidade_clienteTextBox.Clear()
        Estado_clienteComboBox.Text = ""
        Telefone_clienteTextBox.Clear()
        Obs_clienteTextBox.Clear()
        Credito_clienteTextBox.Clear()
        Totalcompra_clienteTextBox.Clear()
        Saldo_clienteTextBox1.Clear()
        CodIBGE_clienteTextBox.Clear()

    End Sub

    'Função Destravar txt_box do formulário clientes
    Public Sub destravarCampos()

        Nome_clienteTextBox.Enabled = True
        pes_fisica.Enabled = True
        pes_juridica.Enabled = True
        Nfantasia_clienteTextBox.Enabled = True
        isento_sim.Enabled = True
        isento_nao.Enabled = True
        msktxtbox_rgcliente.Enabled = True
        msk_cpfcliente.Enabled = True
        msktxt_cnpjcliente.Enabled = True
        msk_insestadualcliente.Enabled = True
        Email_clienteTextBox.Enabled = True
        Cep_clienteMaskedTextBox.Enabled = True
        Endereco_clienteTextBox.Enabled = True
        Numerorua_clienteTextBox.Enabled = True
        Bairro_clienteTextBox.Enabled = True
        Cidade_clienteTextBox.Enabled = True
        Estado_clienteComboBox.Enabled = True
        Telefone_clienteTextBox.Enabled = True
        Obs_clienteTextBox.Enabled = True
        vender_cliente.Enabled = True
        naovender_cliente.Enabled = True
        Credito_clienteTextBox.Enabled = True
        Totalcompra_clienteTextBox.Enabled = True
        Saldo_clienteTextBox1.Enabled = True
        btn_ValidarCNPJ.Enabled = True

    End Sub
    'Função Travar txt_box do formulário clientes
    Public Sub travarCampos()

        Nome_clienteTextBox.Enabled = False
        pes_fisica.Enabled = False
        pes_juridica.Enabled = False
        Nfantasia_clienteTextBox.Enabled = False
        isento_sim.Enabled = False
        isento_nao.Enabled = False
        msktxtbox_rgcliente.Enabled = False
        msk_cpfcliente.Enabled = False
        msktxt_cnpjcliente.Enabled = False
        msk_insestadualcliente.Enabled = False
        Email_clienteTextBox.Enabled = False
        Cep_clienteMaskedTextBox.Enabled = False
        Endereco_clienteTextBox.Enabled = False
        Numerorua_clienteTextBox.Enabled = False
        Bairro_clienteTextBox.Enabled = False
        Cidade_clienteTextBox.Enabled = False
        Estado_clienteComboBox.Enabled = False
        Telefone_clienteTextBox.Enabled = False
        Obs_clienteTextBox.Enabled = False
        vender_cliente.Enabled = False
        naovender_cliente.Enabled = False
        Credito_clienteTextBox.Enabled = False
        Totalcompra_clienteTextBox.Enabled = False
        Saldo_clienteTextBox1.Enabled = False
        btn_ValidarCNPJ.Enabled = False

    End Sub
    Private Sub habilitarmenuclientes()

        IncluirToolStripMenuItem1.Enabled = True
        AlterarToolStripMenuItem1.Enabled = True
        ApagarToolStripMenuItem1.Enabled = True
        ConsultarToolStripMenuItem1.Enabled = True
        ConfirmarToolStripMenuItem.Visible = False
        DesistirOperaçãoToolStripMenuItem1.Visible = False

    End Sub
    'função habilitar e desabilitar botões do formulário clientes quando o botão gravar é clicado 

    Private Sub habilitarbotoesgravar()

        tab_grid_clientes.Enabled = True

    End Sub


    'atualiza a tabela clientes e põem em ordem crescente pela coluna um de códigos interno
    Private Sub tab_form_clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_form_clientes.Selected

        Try
            If tab_form_clientes.SelectedIndex = 1 Then
                ' a próxima ordem coloca o datagrid de clientes na page tabela em ordem alfabética columns(1)
                ClienteDataGridView5.Sort(ClienteDataGridView5.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                ' dá um refresh na tabela clientes atualizando-a
                Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)
                destravarCampos()
            End If

            If tab_form_clientes.SelectedIndex = 0 Then
                travarCampos()
                slecionar_campoGrid_Cliente()

            End If

        Catch ex As Exception
            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())
        Finally

        End Try
    End Sub

    'faz o check dos radiogroup da pessoa jurídica ou física entre outros, quando chamamos o grid do cliente para o formulário - se não fizesse essa sub rotina quando mudamos do grid de clientes para a page formulário os radiogroup não ficam selecionados....

    Private Sub slecionar_campoGrid_Cliente() Handles ClienteDataGridView5.CellDoubleClick

        Dim v_SelectRow As Integer
        v_SelectRow = Me.ClienteDataGridView5.CurrentRow.Index
        'busca relativa à pessoa fícia e jurídica da tabela clientes
        If ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "Fisica" Or
            ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "f" Then
            pes_juridica.BackColor = Color.Silver
            pes_juridica.Checked = False
            pes_fisica.Checked = True
            pes_fisica.BackColor = Color.Gray

        End If

        If ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "Jurídica" Or
 ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "j" Or
            ClienteDataGridView5.Item(2, v_SelectRow).Value.ToString() = "" Then
            pes_fisica.BackColor = Color.Silver
            pes_fisica.Checked = False
            pes_juridica.Checked = True
            pes_juridica.BackColor = Color.Gray


        End If

        'busca relativa `a busca do ISENTO  da tabela clientes -------------------------

        If ClienteDataGridView5.Item(20, v_SelectRow).Value.ToString() = "sim" Then

            isento_nao.BackColor = Color.Silver
            isento_nao.Checked = False
            isento_sim.Checked = True
            isento_sim.BackColor = Color.Gray

        End If

        If ClienteDataGridView5.Item(20, v_SelectRow).Value.ToString() = "não" Or
 ClienteDataGridView5.Item(20, v_SelectRow).Value.ToString() = "" Then
            isento_sim.BackColor = Color.Silver
            isento_sim.Checked = False
            isento_nao.Checked = True
            isento_nao.BackColor = Color.Gray

        End If

        'busca relativa `a busca do vender ou não do cliente da tabela clientes -------------------------

        If ClienteDataGridView5.Item(16, v_SelectRow).Value.ToString() = "vender" Or
ClienteDataGridView5.Item(16, v_SelectRow).Value.ToString() = "" Then
            naovender_cliente.BackColor = Color.Silver
            naovender_cliente.Checked = False
            vender_cliente.Checked = True
            vender_cliente.BackColor = Color.Gray

        End If

        If ClienteDataGridView5.Item(16, v_SelectRow).Value.ToString() = "não vender" Then

            vender_cliente.BackColor = Color.Silver
            vender_cliente.Checked = False
            naovender_cliente.Checked = True
            naovender_cliente.BackColor = Color.Gray

        End If
        tab_form_clientes.SelectedIndex = 0


    End Sub

    'chama a subrotina de impressão
    Private Sub btnimprimir_cliente_Click(sender As Object, e As EventArgs)

    End Sub
    
    Private Sub pes_fisica_Click(sender As Object, e As EventArgs) Handles pes_fisica.Click
        pes_fisica.BackColor = Color.Gray
        pes_fisica.Checked = True
        pes_juridica.BackColor = Color.Silver
        pes_juridica.Checked = False
    End Sub
    'ao clicar realça e chaca o radio button 

    Private Sub pes_juridica_Click(sender As Object, e As EventArgs) Handles pes_juridica.Click
        pes_fisica.BackColor = Color.Silver
        pes_fisica.Checked = False
        pes_juridica.BackColor = Color.Gray
        pes_juridica.Checked = True
    End Sub
    'ao clicar realça e chaca o radio button 

    Private Sub isento_sim_Click(sender As Object, e As EventArgs) Handles isento_sim.Click
        isento_sim.BackColor = Color.Gray
        isento_sim.Checked = True
        isento_nao.BackColor = Color.Silver
        isento_nao.Checked = False
    End Sub
    'ao clicar realça e chaca o radio button 

    Private Sub isento_nao_Click(sender As Object, e As EventArgs) Handles isento_nao.Click
        isento_sim.BackColor = Color.Silver
        isento_sim.Checked = False
        isento_nao.BackColor = Color.Gray
        isento_nao.Checked = True
    End Sub
    'ao clicar realça e chaca o radio button 

    Private Sub vender_cliente_Click(sender As Object, e As EventArgs) Handles vender_cliente.Click
        vender_cliente.BackColor = Color.Gray
        vender_cliente.Checked = True
        naovender_cliente.BackColor = Color.Silver
        naovender_cliente.Checked = False
    End Sub
    'ao clicar realça e checa o radio button 

    Private Sub naovender_cliente_Click(sender As Object, e As EventArgs) Handles naovender_cliente.Click
        vender_cliente.BackColor = Color.Silver
        vender_cliente.Checked = False
        naovender_cliente.BackColor = Color.Gray
        naovender_cliente.Checked = True
    End Sub
    'rotina parbuscar o endereço na web service dos correios
    Private Sub buscar_cepcliente_Click(sender As Object, e As EventArgs) Handles btn_buscarcepcliente.Click

        Try
            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", Cep_clienteMaskedTextBox.Text)
            ds.ReadXml(xml)
            Endereco_clienteTextBox.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
            Bairro_clienteTextBox.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            Cidade_clienteTextBox.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            Estado_clienteComboBox.Text = ds.Tables(0).Rows(0)("uf").ToString()

            'rotina para ler o código do IBGE no arquivo copiado da receita
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

            command = connection.CreateCommand()
            command.CommandText = "select * from tab_municipios where nome = '" & Cidade_clienteTextBox.Text & "'"

            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            While lrd.Read

                CodIBGE_clienteTextBox.Text = lrd("id").ToString

            End While

            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Erro")
        Finally

        End Try

        If Endereco_clienteTextBox.Text = "" Then
            MessageBox.Show("nenhum CEP foi achado, verificar o nome da cidade")
            Cep_clienteMaskedTextBox.Clear()
        End If

        Numerorua_clienteTextBox.Text = ""

    End Sub

    'REM verifica  se uma pasta foi selecionada

    Private Sub xml_procuraNfe_Click(sender As Object, e As EventArgs) Handles xml_procuraNfe.Click

        Dim senha As String
        senha = InputBox("Coloque a senha")
        If senha <> fernando Then
            Exit Sub
        End If
     
        If txtXml.Text = "" Then
            MessageBox.Show("Por favor, selecione uma pasta")
        Else
            REM chama a sub
            cad_nfeExistente()

        End If


        Me.VendasMlbTableAdapter.Fill(Me.DataSetFinal.VendasMlb)

    End Sub
    'REM chama a funçao para carregar as notas XML
    Private Sub txtXml_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtXml.TextChanged
        carrega_xml()
    End Sub

    Sub carrega_xml()

        Dim myXMLfile As String = nomeArquivoXML
        Dim ds As New DataSet
        Dim dt As New DataTable

        If txtXml.Text = "" Then

        Else
            Try
                ds.ReadXml(myXMLfile)

                'grava_nfe()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If


    End Sub



    Public Sub cad_nfeExistente()

        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(txtXml.Text)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.xml", IO.SearchOption.AllDirectories)
        Dim fi As IO.FileInfo


        For Each fi In aryFi

            grava_nfeporPasta(fi.ToString, fi)

        Next

    End Sub

    REM grava as notas no arquivo nfefornecedor
    Public Sub grava_nfeporPasta(ByVal nomeXml As String, ByVal xml As Object)

        Dim xmlDoc As New XmlDocument
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ns As New XmlNamespaceManager(xmlDoc.NameTable)
        Dim NumeroNotaFull As String = ""

        Try
            xmlDoc.Load(xml.FullName)

            ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe")



            con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT NUmeroPedido2_VendasMlb from VendasMlb"
            Dim lrd As SqlDataReader = cmd.ExecuteReader()
            ' **********************************************************************************************


            If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns).InnerText = "18623408000266" Then
                NumeroNotaFull = "F" + xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns).InnerText
            Else
                NumeroNotaFull = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns).InnerText
            End If

          
            While lrd.Read()

                'REM verifica se cdigo existe banco do produto na nota para não gravar duas vezes
                If NumeroNotaFull = lrd("NUmeroPedido2_VendasMlb").ToString Then
                    '  MessageBox.Show("A Nota " & nomeXml & " já foi cadastrada!!!!")
                    Exit Sub
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("Error while retrieving records on table..." & ex.Message, "Load Records")
        Finally
            con.Close()
        End Try

        'faz o loop para pegar todas os produtos da nfe xml de entrada(fornecedor) e coloca em nosso banco de dados nfefornecedor
        Dim ctd_prod As Integer = 0
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Try

            nodeList = xmlDoc.SelectNodes("//nfe:infNFe/nfe:det", ns)
        Catch ex As Exception

            MessageBox.Show("Erro ao ler a nota")

            Exit Sub
        End Try

        'REM essa função conta quantos produtos tem na nota, contando os nós
        For Each node In nodeList
            ctd_prod = ctd_prod + 1
        Next

        'REM faz um loop de gravação e grava os outros dados repetidamente só variando os produtos
        'REM ele conta quantos produtos tem na nota e joga em a
        '************************************************************
        Dim CodigoAnterior As String = ""
        Dim NumeroNota(10000) As String
        '***********************************************************
        For a As Integer = 1 To ctd_prod

            'criar comando inserção na tabela nfeforncedor

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.Parameters.Clear()
            command.CommandText = "INSERT INTO VendasMlb (SerieNF_VendasMlb,CNPJEmitente_VendasMlb,VrTotal_vendasMlb,NUmeroPedido2_VendasMlb,DataPedido_VendasMlb,NomeContato_VendasMlb,CEP_VendasMlb,Municipio_VendasMlb,Estado_VendasMlb,Endereco_VendasMlb,NumeroRua_VendasMlb,Complemento_VendasMlb,Bairro_VendasMlb,Fone_VendasMlb,NomeProduto_VendasMlb,QuantidadeVendida_VendasMlb,VrUnitario_VendasMlb,CodigoMlb_VendasMlb) Values (@SerieNF_VendasMlb,@CNPJEmitente_VendasMlb,@VrTotal_vendasMlb,@NUmeroPedido2_VendasMlb,@DataPedido_VendasMlb,@NomeContato_VendasMlb,@CEP_VendasMlb,@Municipio_VendasMlb,@Estado_VendasMlb,@Endereco_VendasMlb,@NumeroRua_VendasMlb,@Complemento_VendasMlb,@Bairro_VendasMlb,@Fone_VendasMlb,@NomeProduto_VendasMlb,@QuantidadeVendida_VendasMlb,@VrUnitario_VendasMlb,@CodigoMlb_VendasMlb)"
            ' ---------------------------------------------------
            Dim NumeroNotaFinal As String = ""
            Dim Quantidade As Double = 0
            Dim Preco As Double = 0
            Dim TotalValor As Double = 0

            Try
                command.CommandType = CommandType.Text

                'REM gravar campos IDE
                'verificar se existe o nó numero da noda cNf[acredito ser o numero da nf]
                'If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns) Is Nothing Then
                '    command.Parameters.Add("@NUmeroPedido2_VendasMlb", SqlDbType.VarChar, 50).Value = " sem "
                'Else
                '    NumeroNota(a) = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns).InnerText
                '*************************************************************************************
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns) Is Nothing Then
                    command.Parameters.Add("@NUmeroPedido2_VendasMlb", SqlDbType.VarChar, 50).Value = " sem "
                Else
                    NumeroNota(a) = NumeroNotaFull

                    ' ************************************************************************************
                    If CodigoAnterior = NumeroNota(a) Then
                        NumeroNota(a) = NumeroNota(a) + "A"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "A") Then
                        NumeroNota(a) = NumeroNota(a) + "B"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "B") Then
                        NumeroNota(a) = NumeroNota(a) + "C"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "C") Then
                        NumeroNota(a) = NumeroNota(a) + "D"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "D") Then
                        NumeroNota(a) = NumeroNota(a) + "E"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "E") Then
                        NumeroNota(a) = NumeroNota(a) + "F"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "F") Then
                        NumeroNota(a) = NumeroNota(a) + "G"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "G") Then
                        NumeroNota(a) = NumeroNota(a) + "H"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "H") Then
                        NumeroNota(a) = NumeroNota(a) + "I"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "I") Then
                        NumeroNota(a) = NumeroNota(a) + "J"
                    End If

                    If CodigoAnterior = (NumeroNota(a) + "J") Then
                        NumeroNota(a) = NumeroNota(a) + "K"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "K") Then
                        NumeroNota(a) = NumeroNota(a) + "L"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "L") Then
                        NumeroNota(a) = NumeroNota(a) + "M"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "M") Then
                        NumeroNota(a) = NumeroNota(a) + "N"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "N") Then
                        NumeroNota(a) = NumeroNota(a) + "O"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "O") Then
                        NumeroNota(a) = NumeroNota(a) + "P"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "P") Then
                        NumeroNota(a) = NumeroNota(a) + "Q"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "Q") Then
                        NumeroNota(a) = NumeroNota(a) + "R"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "R") Then
                        NumeroNota(a) = NumeroNota(a) + "S"
                    End If
                    If CodigoAnterior = (NumeroNota(a) + "S") Then
                        NumeroNota(a) = NumeroNota(a) + "T"
                    End If
                    command.Parameters.Add("@NUmeroPedido2_VendasMlb", SqlDbType.VarChar, 50).Value = NumeroNota(a)

                End If
                ' verificar a SÉRIE da nota
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:serie", ns) Is Nothing Then
                    command.Parameters.Add("@SerieNF_VendasMlb", SqlDbType.VarChar, 50).Value = " sem "
                Else
                    command.Parameters.Add("@SerieNF_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:serie", ns).InnerText
                End If

                'verificar se existe o nó dataEmi
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns) Is Nothing Then
                    command.Parameters.Add("@DataPedido_VendasMlb", SqlDbType.VarChar, 50).Value = Date.Today
                Else
                    command.Parameters.Add("@DataPedido_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns).InnerText
                End If
                ' gravar CNPJ
                '----------------------------------------------
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns) Is Nothing Then
                    command.Parameters.Add("@CNPJEmitente_VendasMlb", SqlDbType.VarChar, 50).Value = Date.Today
                Else
                    command.Parameters.Add("@CNPJEmitente_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns).InnerText
                End If
                '----------------------------------------------
                'REM gravar dest
                'verificar se existe o nó nome cliente
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:xNome", ns) Is Nothing Then
                    command.Parameters.Add("@NomeContato_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@NomeContato_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:xNome", ns).InnerText
                End If

                ''verificar se existe o CEP
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:CEP", ns) Is Nothing Then
                    command.Parameters.Add("@CEP_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@CEP_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:CEP", ns).InnerText
                End If

                ''rem gravar municipio
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xMun", ns) Is Nothing Then
                    command.Parameters.Add("@Municipio_VendasMlb", SqlDbType.VarChar, 50).Value = "Sem  "
                Else
                    command.Parameters.Add("@Municipio_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xMun", ns).InnerText
                End If

                ''verifica se existe o nó do Estado
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:UF", ns) Is Nothing Then
                    command.Parameters.Add("@Estado_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@Estado_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:UF", ns).InnerText
                End If

                ''verifica se existe o nó o nome da rua
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xLgr", ns) Is Nothing Then
                    command.Parameters.Add("@Endereco_VendasMlb", SqlDbType.VarChar, 50).Value = "sem"
                Else
                    command.Parameters.Add("@Endereco_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xLgr", ns).InnerText
                End If

                'verifica se existe o numero da rua
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:nro", ns) Is Nothing Then
                    'REM gravar enderEmit
                    command.Parameters.Add("@NumeroRua_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@NumeroRua_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:nro", ns).InnerText
                End If

                ''verifica se existe o complemento de endereço
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xCpl", ns) Is Nothing Then
                    command.Parameters.Add("@Complemento_VendasMlb", SqlDbType.VarChar, 50).Value = "sem numero"
                Else
                    command.Parameters.Add("@Complemento_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xCpl", ns).InnerText
                End If

                ''verifica se existe o nó xCpl o complemento do endereço
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xBairro", ns) Is Nothing Then
                    command.Parameters.Add("@Bairro_VendasMlb", SqlDbType.VarChar, 50).Value = "sem complemento"
                Else
                    command.Parameters.Add("@Bairro_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:xBairro", ns).InnerText
                End If

                ''verifica se existe o nó xBairro o nome do bairro
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:fone", ns) Is Nothing Then
                    command.Parameters.Add("@Fone_VendasMlb", SqlDbType.VarChar, 50).Value = "sem bairro"
                Else
                    command.Parameters.Add("@Fone_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:enderDest/nfe:fone", ns).InnerText
                End If

                ' nome do produto
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:xProd", ns) Is Nothing Then
                    command.Parameters.Add("@NomeProduto_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@NomeProduto_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:xProd", ns).InnerText
                End If

                ' quantidade vendida
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:qCom", ns) Is Nothing Then
                    command.Parameters.Add("@QuantidadeVendida_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    Quantidade = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:qCom", ns).InnerText
                    command.Parameters.Add("@QuantidadeVendida_VendasMlb", SqlDbType.VarChar, 50).Value = Quantidade

                End If

                ' Valor Unitátio
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:vUnCom", ns) Is Nothing Then
                    command.Parameters.Add("@VrUnitario_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    Preco = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:vUnCom", ns).InnerText
                    command.Parameters.Add("@VrUnitario_VendasMlb", SqlDbType.VarChar, 50).Value = Preco

                End If

                ' codigo produto
                If xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:cProd", ns) Is Nothing Then
                    command.Parameters.Add("@CodigoMlb_VendasMlb", SqlDbType.VarChar, 50).Value = "sem "
                Else
                    command.Parameters.Add("@CodigoMlb_VendasMlb", SqlDbType.VarChar, 50).Value = xmlDoc.SelectSingleNode("//nfe:infNFe/nfe:det[@nItem=" & a & "]/nfe:prod/nfe:cProd", ns).InnerText
                End If
                'Rem ---------- fim da leitura da nota xml
                TotalValor = Quantidade * (Preco / 100000000)
                command.Parameters.Add("@VrTotal_vendasMlb", SqlDbType.Float).Value = TotalValor


            Catch ex As Exception

                MessageBox.Show(ex.ToString())

            Finally

            End Try

            ' a seguir comandos para gravar os ítens coletados do arquivo xml no arquivo nfefornecedor
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try
            CodigoAnterior = NumeroNota(a)
        Next

        Me.VendasMlbTableAdapter.Fill(Me.DataSetFinal.VendasMlb)

    End Sub

    'REM mostra a tela para escolher a pasta para pegar o arquivo xml .....
    Private Sub btn_seleciona_pasta_nota_Click(sender As Object, e As EventArgs) Handles btn_seleciona_pasta_nota.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

        ' Descriptive text displayed above the tree view control in the dialog box
        MyFolderBrowser.Description = "Selecione as pastas com as notas bugigangasMil"

        ' Sets the root folder where the browsing starts from
        'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments

        ' Do not show the button for new folder
        MyFolderBrowser.ShowNewFolderButton = False

        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            txtXml.Text = MyFolderBrowser.SelectedPath
        End If

    End Sub
    '   ROTINAS PARA O FORMULÁRIO DE PRODUTOS

    'Botão de gravar - grava os registros da tabela cliente, verifica pessoa jurídica e outra -
    Private Sub menu_incluirprod_Click(sender As Object, e As EventArgs) Handles menu_incluirprod.Click


        'funções ----------------------
        ClearTextBoxprod()
        zerando_camposFormProd()
        habilitarbotoesincluirprod()

        'extras ---------------------
        flag = "incluir"
        btn_calcPrecos.Enabled = True
        produto_cadastrado = False
        Cod_prodTextBox.Enabled = True
        menu_confirmarprod.Visible = False
        DesistirOperaçãoToolStripMenuItem2.Visible = True
        FlagProdPesquisa = "1"


        Codbarras_prodTextBox.Clear()

        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
        '  tira outra page de outra tabcontrol
        tabpage_produtos.TabPages.Remove(TabPage_gridProd)
        tabpage_produtos.TabPages.Remove(tbpg_listapreco)

        Cod_prodTextBox.Focus()


    End Sub

    'REM desabilitar text box para não entrarem com dados falsos
    Private Sub desabilitatextbox()

        Precovarejo_prodTextBox.Enabled = False
        Precoatacado_prodTextBox.Enabled = False
        Estoquemin_prodTextBox.Enabled = False
        Estaquemax_prodTextBox.Enabled = False
        Pedcolocados_prodTextBox.Enabled = False
        Pedencomendados_prodTextBox.Enabled = False
        Tempoentragafor_prodTextBox.Enabled = False
        Porcentagemfat_prodTextBox.Enabled = False
        Abc_prodComboBox.Enabled = False
        Situacao_prodComboBox.Enabled = False
       

    End Sub


    'função habilitar e desabilitar botões do formulário produtos quando o botão incluir é clicado

    Private Sub habilitarbotoesincluirprod()

        menu_incluirprod.Enabled = False
        menu_alterarprod.Enabled = False
        menu_apagarprod.Enabled = False
        menu_consultarprod.Enabled = False
        menu_confirmarprod.Visible = True

    End Sub


    'função habilitar e desabilitar botões do formulário produtos quando o botão alterar é clicado 

    Private Sub habilitarbotoesalterarprod()
        menu_incluirprod.Enabled = False
        menu_alterarprod.Enabled = False
        menu_apagarprod.Enabled = False
        menu_consultarprod.Enabled = False
        menu_confirmarprod.Visible = True
        DesistirOperaçãoToolStripMenuItem2.Visible = True

    End Sub

    'função habilitar e desabilitar botões do formulário produtos quando o botão apagar é clicado 

    Private Sub habilitarbotoesconfirmarprod()

        menu_incluirprod.Enabled = True
        menu_alterarprod.Enabled = True
        menu_apagarprod.Enabled = True
        menu_consultarprod.Enabled = True
        menu_confirmarprod.Visible = False

    End Sub
    ' FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM FORM PRODUTOS
    ' colocar todas as funções aqui de todos as sub que vc quiser que sejam iniciada quando o formulário PRODUTOS for mostrado -quando clicamos o page formulário, ele trava os campos do formulário -ele desabilita o botão gravar -

    Private Sub tabpage_produtos_Click(sender As Object, e As EventArgs) Handles tabpage_produtos.Click
        Label420.Text = EnderecoEletronicoDataGridView.Rows.Count()
        menu_confirmarprod.Visible = False
        travarCamposprod()
        btn_calcPrecos.Enabled = False
        Me.ProdutosBindingSource.MoveFirst()
    End Sub

    Public Sub limpar_inicioFormProd()

        travarCamposprod()
        menu_confirmarprod.Visible = False


    End Sub
    Private Sub DesistirOperaçãoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DesistirOperaçãoToolStripMenuItem2.Click
        restaurar_tab(TabControl1.SelectedTab.ToString)
        FlagProdPesquisa = "0"
        flag = ""
        DesistirOperaçãoToolStripMenuItem2.Visible = False
        menu_confirmarprod.Visible = False
        habilitarbotoesconfirmarprod()
        travarCamposprod()
        Cod_prodTextBox.Text = ""
        Button74.Enabled = True
        Button75.Enabled = True
        Button112.Enabled = False
        TextBox327.Enabled = False
        TextBox329.Enabled = False
        TextBox331.Enabled = False
        Button112.BackColor = Color.LightGray
        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)


    End Sub

    'Função apagar txt_box do formulário PRODUTOS
    Public Sub ClearTextBoxprod()

        Cod_prodTextBox.Clear()
        Cod_prodforTextBox.Clear()
        TextBox251.Clear()
        Nome_prodTextBox.Clear()
        Precoatacado_prodTextBox.Clear()
        Precovarejo_prodTextBox.Clear()
        Ipi_prodTextBox.Clear()
        Markup_prodTextBox.Clear()
        Custo_prodTextBox.Clear()
        Classificfiscal_prodTextBox.Clear()
        Tabelafiscal_prodTextBox.Clear()
        Peso_prodTextBox.Clear()
        Estaquemax_prodTextBox.Clear()
        Estoquemin_prodTextBox.Clear()
        TextBox253.Clear()
        '------------------------------
        TextBox327.Clear()
        TextBox328.Clear()
        TextBox329.Clear()
        TextBox330.Clear()
        TextBox331.Clear()
        TextBox332.Clear()

        '-----------------------------
        Pedcolocados_prodTextBox.Clear()
        Tempoentragafor_prodTextBox.Clear()
        Pedencomendados_prodTextBox.Clear()
        Porcentagemfat_prodTextBox.Clear()
        DescontoFabrica_prodTextBox.Clear()
        TextBox231.Clear()
        TextBox233.Clear()
        TextBox245.Clear()
        'TextBox234.Clear()
        TextBox233.Clear()

        'combobox
        Nome_linhaComboBox.Text = ""
        xNome_fornecedorComboBox.Text = ""
        Nome_corComboBox.Text = ""
        Abc_prodComboBox.Text = ""
        Situacao_prodComboBox.Text = ""

    End Sub

    'Função Destravar txt_box do formulário PRODUTOS
    Public Sub destravarCamposprod()

        Cod_prodTextBox.Enabled = True
        'Cod_prodforTextBox.Enabled = True
        TextBox251.Enabled = True
        Codbarras_prodTextBox.Enabled = True
        Nome_prodTextBox.Enabled = True
        Precoatacado_prodTextBox.Enabled = True
        Precovarejo_prodTextBox.Enabled = True
        Ipi_prodTextBox.Enabled = True
        Markup_prodTextBox.Enabled = True
        Custo_prodTextBox.Enabled = True
        Classificfiscal_prodTextBox.Enabled = True
        Tabelafiscal_prodTextBox.Enabled = True

        Peso_prodTextBox.Enabled = True
        Estaquemax_prodTextBox.Enabled = True
        Estoquemin_prodTextBox.Enabled = True
        TextBox253.Enabled = True
        '------------------------------
        TextBox327.Enabled = True
        TextBox329.Enabled = True
        TextBox331.Enabled = True
        '-------------------------------
        Pedcolocados_prodTextBox.Enabled = True
        Tempoentragafor_prodTextBox.Enabled = True
        Pedencomendados_prodTextBox.Enabled = True
        Porcentagemfat_prodTextBox.Enabled = True
        DescontoFabrica_prodTextBox.Enabled = True
        TextBox231.Enabled = True
        TextBox233.Enabled = True
        TextBox245.Enabled = True
        ' TextBox234.Enabled = True
        TextBox232.Enabled = True
        TextBox238.Enabled = True
        TextBox259.Enabled = True
        TextBox260.Enabled = True
        TextBox261.Enabled = True
        TextBox262.Enabled = True
        TextBox263.Enabled = True
        TextBox264.Enabled = True
        TextBox265.Enabled = True
        TextBox266.Enabled = True
        TextBox267.Enabled = True
        ComboBox32.Enabled = True
        ComboBox41.Enabled = True

        'combobox
        Nome_linhaComboBox.Enabled = True
        xNome_fornecedorComboBox.Enabled = True
        Nome_corComboBox.Enabled = True
        Abc_prodComboBox.Enabled = True
        Situacao_prodComboBox.Enabled = True

        'botões
        btn_calcPrecos.Enabled = True

    End Sub

    'Função Travar txt_box do formulário PRODUTOS
    Public Sub travarCamposprod()

        Cod_prodTextBox.Enabled = False
        Cod_prodforTextBox.Enabled = False
        TextBox251.Enabled = False
        Nome_prodTextBox.Enabled = False
        Precoatacado_prodTextBox.Enabled = False
        Precovarejo_prodTextBox.Enabled = False
        Ipi_prodTextBox.Enabled = False
        Markup_prodTextBox.Enabled = False
        Custo_prodTextBox.Enabled = False
        Classificfiscal_prodTextBox.Enabled = False
        Tabelafiscal_prodTextBox.Enabled = False
        Peso_prodTextBox.Enabled = False
        Estaquemax_prodTextBox.Enabled = False
        Estoquemin_prodTextBox.Enabled = False
        TextBox253.Enabled = False
        TextBox328.Enabled = False
        TextBox330.Enabled = False
        TextBox332.Enabled = False

        Pedcolocados_prodTextBox.Enabled = False
        Tempoentragafor_prodTextBox.Enabled = False
        Pedencomendados_prodTextBox.Enabled = False
        Porcentagemfat_prodTextBox.Enabled = False
        Codbarras_prodTextBox.Enabled = False
        DescontoFabrica_prodTextBox.Enabled = False
        TextBox230.Enabled = False
        TextBox231.Enabled = False
        TextBox233.Enabled = False
        TextBox245.Enabled = False
        'TextBox234.Enabled = False
        TextBox232.Enabled = False
        ' -----------------------------
        TextBox238.Enabled = False
        TextBox259.Enabled = False
        TextBox260.Enabled = False
        TextBox261.Enabled = False
        TextBox262.Enabled = False
        TextBox263.Enabled = False
        TextBox264.Enabled = False
        TextBox265.Enabled = False
        TextBox266.Enabled = False
        TextBox267.Enabled = False
        ComboBox32.Enabled = False
        ComboBox41.Enabled = False


        'combobox
        Nome_linhaComboBox.Enabled = False
        xNome_fornecedorComboBox.Enabled = False
        Nome_corComboBox.Enabled = False
        Abc_prodComboBox.Enabled = False
        Situacao_prodComboBox.Enabled = False

        'botões
        btn_calcPrecos.Enabled = False


    End Sub
    REM sub que confirma a gravação no arquivo de produtos
    Private Sub menu_confirmarprod_Click(sender As Object, e As EventArgs) Handles menu_confirmarprod.Click

        Cod_prodforTextBox.Focus()
        FlagProdPesquisa = "0"

        ' REM verifica se todos os campos importantes foram preenchidos e se o custo foi calculado antes de gravar
        If Markup_prodTextBox.Text = "0,00" Or
            Custo_prodTextBox.Text = "0,00" Or
            Nome_linhaComboBox.Text = "" Or
            xNome_fornecedorComboBox.Text = "" Or
            Nome_corComboBox.Text = "" Or
            Nome_prodTextBox.Text = "" Or
            Classificfiscal_prodTextBox.Text = "" Or
            Tabelafiscal_prodTextBox.Text = "" Or
            DescontoFabrica_prodTextBox.Text = "" Then

            MessageBox.Show("Os campos de cadastro não foram todos preenchidos")

            Exit Sub
            ' Peso_prodTextBox.Text = "0,00" Or
        End If
        '---------------------------------------------------------
        Dim connection5 As SqlConnection
        connection5 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command5 As SqlCommand
        command5 = connection5.CreateCommand()

        command5 = connection5.CreateCommand()
        command5.CommandText = "select * from ibpt_NCM where  codigo = '" & Classificfiscal_prodTextBox.Text & "'"

        connection5.Open()

        Dim lrd5 As SqlDataReader = command5.ExecuteReader()

        Try
            If lrd5.Read() = True Then
            Else
                MessageBox.Show("NCM declarado não existe")
                connection5.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        connection5.Close()
        '--------------------------------------------------------------------------------------------

        Dim reply As DialogResult = MessageBox.Show("Confirmar a inclusão/alteração?", "Atenção!!!", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)


        'REM se confirmar a alteração ele grava
        If reply = DialogResult.Yes And produto_cadastrado = False Then


            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

            Dim command As SqlCommand
            command = connection.CreateCommand()

            If flag = "incluir" Then
                command.CommandText = "INSERT INTO produtos (MaxConsumoEstoque_prod,EstoqueInicial_prod,DataEstoqueInicial_prod,ConsumoDaDataIncial_prod,DataAtualizacaoEstoque_prod,PrecoMarketPlace_prod,PrecoSite_prod,PrecoMercadoLivreFull_prod,MkMarketPlace_prod,MkMercadoLivreFull_prod,MkSite_prod,RaizSimNao_prod,Bugiganga_prod,CodComp1_prod,QtdeComp1_prod,CodComp2_prod,QtdeComp2_prod,CodComp3_prod,QtdeComp3_prod,CodComp4_prod,QtdeComp4_prod,CodComp5_prod,QtdeComp5_prod,EstoquePrateleira_prod,EmbalagemFabrica_prod,CodigoMlb_prod,cod_prod,cod_prodfor,fornecedor_prod,linha_prod,nome_prod,cor_prod,precovarejo_prod,precoatacado_prod,markup_prod,estoquemin_prod,estaquemax_prod,estoqueatual_prod,icms_prod,ipi_prod,peso_prod,custo_prod,pedcolocados_prod,pedencomendados_prod,abc_prod,tempoentragafor_prod,porcentagemfat_prod,classificfiscal_prod,tabelafiscal_prod,situacao_prod,foto_prod,codbarras_prod,DescontoFabrica_prod, Subtituicao_tributaria, Apelido_prod,MarkupNET_prod) Values (@MaxConsumoEstoque_prod,@EstoqueInicial_prod,@DataEstoqueInicial_prod,@ConsumoDaDataIncial_prod,@DataAtualizacaoEstoque_prod,@PrecoMarketPlace_prod,@PrecoSite_prod,@PrecoMercadoLivreFull_prod,@MkMarketPlace_prod,@MkMercadoLivreFull_prod,@MkSite_prod,@RaizSimNao_prod,@Bugiganga_prod,@CodComp1_prod,@QtdeComp1_prod,@CodComp2_prod,@QtdeComp2_prod,@CodComp3_prod,@QtdeComp3_prod,@CodComp4_prod,@QtdeComp4_prod,@CodComp5_prod,@QtdeComp5_prod,@EstoquePrateleira_prod,@EmbalagemFabrica_prod,@CodigoMlb_prod,@codprod,@codprodfor,@fornecedorprod,@linhaprod,@nomeprod,@corprod,@precovarejoprod,@precoatacadoprod,@markupprod,@estoqueminprod,@estaquemaxprod,@estoqueatualprod,@icmsprod,@ipi_prod,@pesoprod,@custoprod,@pedcolocadosprod,@pedencomendadosprod,@abcprod,@tempoentrgaforprod,@porcentagemfatprod,@classiffiscalprod,@tabelafiscalprod,@situacaoprod,@foto_prod,@codbarras_prod,@DescontoFabrica_prod, @Subtituicao_tributaria, @Apelido_prod, @MarkupNET_prod)"
            Else
                command.CommandText = "update produtos set PrecoMarketPlace_prod=@PrecoMarketPlace_prod,PrecoSite_prod=@PrecoSite_prod,PrecoMercadoLivreFull_prod=@PrecoMercadoLivreFull_prod,MkMarketPlace_prod=@MkMarketPlace_prod,MkSite_prod=@MkSite_prod,MkMercadoLivreFull_prod=@MkMercadoLivreFull_prod,RaizSimNao_prod=@RaizSimNao_prod,Bugiganga_prod=@Bugiganga_prod,CodComp1_prod=@CodComp1_prod,QtdeComp1_prod=@QtdeComp1_prod,CodComp2_prod=@CodComp2_prod,QtdeComp2_prod=@QtdeComp2_prod,CodComp3_prod=@CodComp3_prod,QtdeComp3_prod=@QtdeComp3_prod,CodComp4_prod=@CodComp4_prod,QtdeComp4_prod=@QtdeComp4_prod,CodComp5_prod=@CodComp5_prod,QtdeComp5_prod=@QtdeComp5_prod,EstoquePrateleira_prod=@EstoquePrateleira_prod,EmbalagemFabrica_prod=@EmbalagemFabrica_prod,CodigoMlb_prod=@CodigoMlb_prod, cod_prod=@codprod,cod_prodfor=@codprodfor,fornecedor_prod=@fornecedorprod,linha_prod=@linhaprod,nome_prod=@nomeprod,cor_prod=@corprod,precovarejo_prod=@precovarejoprod,precoatacado_prod=@precoatacadoprod,markup_prod=@markupprod,estoquemin_prod=@estoqueminprod,estaquemax_prod=@estaquemaxprod,estoqueatual_prod=@estoqueatualprod,icms_prod=@icmsprod,ipi_prod=@ipi_prod,peso_prod=@pesoprod,custo_prod=@custoprod,pedcolocados_prod=@pedcolocadosprod,pedencomendados_prod=@pedencomendadosprod,abc_prod=@abcprod,tempoentragafor_prod=@tempoentrgaforprod,porcentagemfat_prod=@porcentagemfatprod,classificfiscal_prod=@classiffiscalprod,tabelafiscal_prod=@tabelafiscalprod,situacao_prod=@situacaoprod,foto_prod=@foto_prod,codbarras_prod=@codbarras_prod,DescontoFabrica_prod=@DescontoFabrica_prod,Subtituicao_tributaria=@Subtituicao_tributaria,Apelido_prod=@Apelido_prod,MarkupNET_prod=@MarkupNET_prod  where cod_prod=@codprod "
            End If

            'REM calculando o preço varejo e atacado antes de salvar


            'aqui ele faz o cálculo
            If Ipi_prodTextBox.Text = "" Then
                Ipi_prodTextBox.Text = 0
            End If
            If TextBox231.Text = "" Then
                TextBox231.Text = 0
            End If
            If TextBox327.Text = "" Then
                TextBox327.Text = 0
            End If
            If TextBox329.Text = "" Then
                TextBox329.Text = 0
            End If
            If TextBox331.Text = "" Then
                TextBox331.Text = 0
            End If


            Precoatacado_prodTextBox.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox253.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            Precovarejo_prodTextBox.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (Markup_prodTextBox.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox328.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox327.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox330.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox329.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox332.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox331.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")

            command.CommandType = CommandType.Text
            command.Parameters.Add("@codprod", SqlDbType.VarChar, 50).Value = Cod_prodTextBox.Text
            command.Parameters.Add("@codprodfor", SqlDbType.VarChar, 50).Value = Cod_prodforTextBox.Text
            command.Parameters.Add("@Apelido_prod", SqlDbType.VarChar, 50).Value = TextBox251.Text

            command.Parameters.Add("@fornecedorprod", SqlDbType.VarChar, 50).Value = xNome_fornecedorComboBox.Text
            command.Parameters.Add("@linhaprod", SqlDbType.VarChar, 50).Value = Nome_linhaComboBox.Text
            command.Parameters.Add("@nomeprod", SqlDbType.VarChar, 50).Value = Nome_prodTextBox.Text
            command.Parameters.Add("@corprod", SqlDbType.VarChar, 50).Value = Nome_corComboBox.Text
            command.Parameters.Add("@codbarras_prod", SqlDbType.VarChar, 50).Value = Codbarras_prodTextBox.Text

            'Rem repassando variáveis varchar para float
            Dim precovarejo = Convert.ToDouble(Precovarejo_prodTextBox.Text)
            command.Parameters.Add("@precovarejoprod", SqlDbType.Float).Value = precovarejo
            Dim precoatacado = Convert.ToDouble(Precoatacado_prodTextBox.Text)
            command.Parameters.Add("@precoatacadoprod", SqlDbType.Float).Value = 0
            Dim markup = Convert.ToDouble(Markup_prodTextBox.Text)
            command.Parameters.Add("@markupprod", SqlDbType.Float).Value = markup
            command.Parameters.Add("@MarkupNET_prod", SqlDbType.Float).Value = TextBox253.Text
            '------------------------------------------------------------------------------------
            command.Parameters.Add("@MkMercadoLivreFull_prod", SqlDbType.Float).Value = TextBox327.Text
            command.Parameters.Add("@MkSite_prod", SqlDbType.Float).Value = TextBox329.Text
            command.Parameters.Add("@MkMarketPlace_prod", SqlDbType.Float).Value = TextBox331.Text

            command.Parameters.Add("@PrecoMercadoLivreFull_prod", SqlDbType.Float).Value = TextBox328.Text
            command.Parameters.Add("@PrecoSite_prod", SqlDbType.Float).Value = TextBox330.Text
            command.Parameters.Add("@PrecoMarketPlace_prod", SqlDbType.Float).Value = TextBox332.Text
            '------------------------------------------------------------------------------------
            Dim estoquemin = Convert.ToDouble(Estoquemin_prodTextBox.Text)
            command.Parameters.Add("@estoqueminprod", SqlDbType.Float).Value = estoquemin
            Dim estoquemax = Convert.ToDouble(Estaquemax_prodTextBox.Text)
            command.Parameters.Add("@estaquemaxprod", SqlDbType.Float).Value = estoquemax
            Dim estoqueatual = Convert.ToDouble(TextBox234.Text)
            command.Parameters.Add("@estoqueatualprod", SqlDbType.Float).Value = estoqueatual
            'Dim icmsprod = Convert.ToDouble(Icms_prodTextBox.Text)
            command.Parameters.Add("@icmsprod", SqlDbType.Float).Value = 0
            Dim ipiprod = Convert.ToDouble(Ipi_prodTextBox.Text)
            command.Parameters.Add("@ipi_prod", SqlDbType.Float).Value = ipiprod
            Dim pesoprod = Convert.ToDouble(Peso_prodTextBox.Text)
            command.Parameters.Add("@pesoprod", SqlDbType.Float).Value = pesoprod
            Dim custoprod = Convert.ToDouble(Custo_prodTextBox.Text)
            command.Parameters.Add("@custoprod", SqlDbType.Float).Value = custoprod
            Dim pedcolocados = Convert.ToDouble(Pedcolocados_prodTextBox.Text)
            command.Parameters.Add("@pedcolocadosprod", SqlDbType.Float).Value = pedcolocados
            Dim pedencomendados = Convert.ToDouble(Pedencomendados_prodTextBox.Text)
            command.Parameters.Add("@pedencomendadosprod", SqlDbType.Float).Value = pedencomendados
            command.Parameters.Add("@abcprod", SqlDbType.VarChar, 50).Value = Abc_prodComboBox.Text
            If Tempoentragafor_prodTextBox.Text = "" Then
                Tempoentragafor_prodTextBox.Text = 0
            End If
            Dim tempoentregafor = Convert.ToDouble(Tempoentragafor_prodTextBox.Text)
            command.Parameters.Add("@tempoentrgaforprod", SqlDbType.Float).Value = tempoentregafor
            If Porcentagemfat_prodTextBox.Text = "" Then
                Porcentagemfat_prodTextBox.Text = 0
            End If

            Dim porcentagemfatprod = Convert.ToDouble(Porcentagemfat_prodTextBox.Text)
            command.Parameters.Add("@porcentagemfatprod", SqlDbType.Float).Value = porcentagemfatprod
            command.Parameters.Add("@classiffiscalprod", SqlDbType.VarChar, 50).Value = Classificfiscal_prodTextBox.Text
            command.Parameters.Add("@tabelafiscalprod", SqlDbType.VarChar, 50).Value = Tabelafiscal_prodTextBox.Text
            command.Parameters.Add("@situacaoprod", SqlDbType.VarChar, 50).Value = Situacao_prodComboBox.Text
            command.Parameters.Add("@DescontoFabrica_prod", SqlDbType.VarChar, 50).Value = DescontoFabrica_prodTextBox.Text
            command.Parameters.Add("@foto_prod", SqlDbType.VarChar, 50).Value = ""
            command.Parameters.Add("@Subtituicao_tributaria", SqlDbType.Float).Value = TextBox231.Text
            command.Parameters.Add("@EmbalagemFabrica_prod", SqlDbType.VarChar, 50).Value = TextBox245.Text
            command.Parameters.Add("@CodigoMlb_prod", SqlDbType.VarChar, 50).Value = TextBox233.Text
            command.Parameters.Add("@EstoquePrateleira_prod", SqlDbType.VarChar, 50).Value = TextBox232.Text
            ' -------------------------------------------------------------------------------------------------
            command.Parameters.Add("@CodComp1_prod", SqlDbType.VarChar, 50).Value = TextBox260.Text

            If TextBox238.Text = "" Then
                TextBox238.Text = 0
            End If
            command.Parameters.Add("@QtdeComp1_prod", SqlDbType.Float).Value = TextBox238.Text
            command.Parameters.Add("@CodComp2_prod", SqlDbType.VarChar, 50).Value = TextBox261.Text

            If TextBox259.Text = "" Then
                TextBox259.Text = 0
            End If
            command.Parameters.Add("@QtdeComp2_prod", SqlDbType.Float).Value = TextBox259.Text
            command.Parameters.Add("@CodComp3_prod", SqlDbType.VarChar, 50).Value = TextBox263.Text

            If TextBox262.Text = "" Then
                TextBox262.Text = 0
            End If
            command.Parameters.Add("@QtdeComp3_prod", SqlDbType.Float).Value = TextBox262.Text
            command.Parameters.Add("@CodComp4_prod", SqlDbType.VarChar, 50).Value = TextBox265.Text

            If TextBox264.Text = "" Then
                TextBox264.Text = 0
            End If
            command.Parameters.Add("@QtdeComp4_prod", SqlDbType.Float).Value = TextBox264.Text
            command.Parameters.Add("@CodComp5_prod", SqlDbType.VarChar, 50).Value = TextBox267.Text

            If TextBox266.Text = "" Then
                TextBox266.Text = 0
            End If
            command.Parameters.Add("@QtdeComp5_prod", SqlDbType.Float).Value = TextBox266.Text
            command.Parameters.Add("@Bugiganga_prod", SqlDbType.VarChar, 50).Value = ComboBox32.Text
            command.Parameters.Add("@RaizSimNao_prod", SqlDbType.VarChar, 50).Value = ComboBox41.Text
            ' ****************************************************************************
            ' campos de estoque
            command.Parameters.Add("@EstoqueInicial_prod", SqlDbType.Float).Value = 0
            command.Parameters.Add("@DataEstoqueInicial_prod", SqlDbType.Date).Value = Date.Now
            command.Parameters.Add("@ConsumoDaDataIncial_prod", SqlDbType.Float).Value = 0
            command.Parameters.Add("@DataAtualizacaoEstoque_prod", SqlDbType.Date).Value = Date.Now
            command.Parameters.Add("@MaxConsumoEstoque_prod", SqlDbType.Float).Value = 0


            ' a seguir comandos para gravar os ítens coletados do formulário ------------------

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())

            Finally
                connection.Close()
            End Try
        End If

        If reply = DialogResult.No Then
            Me.ProdutosBindingSource.MoveLast()
        End If


        menu_confirmarprod.Visible = False
        flag = ""
        travarCamposprod()
        habilitarbotoesconfirmarprod()
        btn_calcPrecos.Enabled = False
        DesistirOperaçãoToolStripMenuItem2.Visible = False
        Button74.Enabled = True
        Button75.Enabled = True
        Button112.Enabled = False

        TextBox327.Enabled = False
        TextBox329.Enabled = False
        TextBox331.Enabled = False

        Button112.BackColor = Color.LightGray
        'restabelece o tabcontrol1
        TabControl1.TabPages.Add(tbpg_clientes)
        TabControl1.TabPages.Add(tbpg_pedFornecedor)
        TabControl1.TabPages.Add(tbpg_transportadoras)
        TabControl1.TabPages.Add(tbpg_capitalGiro)
        TabControl1.TabPages.Add(tab_nfe)
        TabControl1.TabPages.Add(pedidos)
        TabControl1.TabPages.Add(tabpage_NFE_e)
        TabControl1.TabPages.Add(Tabpg_cupomfiscal)
        TabControl1.TabPages.Add(tbpg_bkup)
        TabControl1.TabPages.Add(tbpg_orcamento)
        TabControl1.TabPages.Add(tbg_relatorios)
        ' outro tabcontrol
        tabpage_produtos.TabPages.Insert(1, TabPage_gridProd)
        tabpage_produtos.TabPages.Insert(2, tbpg_listapreco)
        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub
    'REm zerar campos FLOAT do form produtos no botão incluir em forma de sub e definir outros campos
    Public Sub zerando_camposFormProd()
        Precovarejo_prodTextBox.Text = "0,00"
        Precoatacado_prodTextBox.Text = "0,00"
        Markup_prodTextBox.Text = "0,00"
        Estaquemax_prodTextBox.Text = "0"
        Estoquemin_prodTextBox.Text = "0"
        Pedcolocados_prodTextBox.Text = "0"
        Pedencomendados_prodTextBox.Text = "0"
        TextBox253.Text = "0,00"
        ' -------------------------------
        TextBox327.Text = "0"
        TextBox328.Text = "0,00"
        TextBox329.Text = "0"
        TextBox330.Text = "0,00"
        TextBox331.Text = "0"
        TextBox332.Text = "0,00"
        ' -------------------------------
        Ipi_prodTextBox.Text = "0,00"
        Custo_prodTextBox.Text = "0,00"
        Peso_prodTextBox.Text = "0,00"
        Tempoentragafor_prodTextBox.Text = "0,00"
        Porcentagemfat_prodTextBox.Text = "0,00"
        Situacao_prodComboBox.Text = "NORMAL"
        Abc_prodComboBox.Text = "c"
        TextBox231.Text = "0,00"
        TextBox233.Text = "0"
        TextBox245.Text = "0"
        TextBox234.Text = "0"
        TextBox232.Text = "0"

        ' quantidade composição produto
        TextBox238.Text = "0"
        TextBox259.Text = "0"
        TextBox262.Text = "0"
        TextBox264.Text = "0"
        TextBox266.Text = "0"

        ' código composição produto
        TextBox260.Text = "0"
        TextBox261.Text = "0"
        TextBox263.Text = "0"
        TextBox265.Text = "0"
        TextBox267.Text = "0"

    End Sub
    ' no clicar limpa o campo se estiver incluindo no campo preço varejo do produto.....
    Private Sub Precovarejo_prodTextBox_Click(sender As Object, e As EventArgs) Handles Precovarejo_prodTextBox.Click
        If flag = "incluir" Or flag = "alterar" Then
            Precovarejo_prodTextBox.Text = ""
        End If
    End Sub

    'rotina para apagar registro quando o botão apagar é clicado ...
    Private Sub menu_apagarprod_Click(sender As Object, e As EventArgs) Handles menu_apagarprod.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from produtos where cod_prod = @cod_prod"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = Cod_prodTextBox.Text

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
                ProdutosBindingSource.MoveFirst()
                MessageBox.Show("Apagado com sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try
        Else
            'Process No
        End If

        '    habilitarbotoesgravarprod()

    End Sub
    'REm sub do botão altera do form produtos
    Private Sub menu_alterarprod_Click(sender As Object, e As EventArgs) Handles menu_alterarprod.Click


            habilitarbotoesalterarprod()
            destravarCamposprod()
            menu_confirmarprod.Visible = True
            flag = "alterar"
            Cod_prodTextBox.Enabled = False
            desabilitatextbox()
            btn_calcPrecos.Enabled = True
            Button74.Enabled = False
            Button75.Enabled = False
        FlagProdPesquisa = "1"
        Button112.Enabled = True
        Button112.BackColor = Color.Coral
            '--------------------------------
            'remove o tab control
        TabControl1.TabPages.Remove(tbpg_clientes)
            TabControl1.TabPages.Remove(tbpg_pedFornecedor)
            TabControl1.TabPages.Remove(tbpg_transportadoras)
            TabControl1.TabPages.Remove(tbpg_capitalGiro)
            TabControl1.TabPages.Remove(tab_nfe)
            TabControl1.TabPages.Remove(pedidos)
            TabControl1.TabPages.Remove(tabpage_NFE_e)
            TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
            TabControl1.TabPages.Remove(tbpg_bkup)
            TabControl1.TabPages.Remove(tbpg_orcamento)
            TabControl1.TabPages.Remove(tbg_relatorios)
        ' ----------------------------------------
        ' remove tabpage

            tabpage_produtos.TabPages.Remove(TabPage_gridProd)
            tabpage_produtos.TabPages.Remove(tbpg_listapreco)


    End Sub
    ' atualiza a tabela produtos e coloca na ordem da primeira coluna.
    Private Sub atualizar_tabpageprod(sender As Object, e As EventArgs) Handles TabPage_gridProd.Enter

        ' a próxima ordem coloca o datagrid de PRODUTOS na page tabela em ordem alfabética columns(1)
        ProdutosDataGridView.Sort(ProdutosDataGridView.Columns(5), System.ComponentModel.ListSortDirection.Ascending)
        ' atualiza o banco de dados
        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
    End Sub
    ' quando clicar consulta ele abre a tabela produtos atualizada na ordem de crescente de códigos
    Private Sub menu_consultarprod_Click(sender As Object, e As EventArgs) Handles menu_consultarprod.Click

        tabpage_produtos.SelectedIndex = 1
        ' atualiza o banco de dados
        destravarCamposprod()
        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub

    ' pega a entrada do preço atacado e verifica se é número ou não, e transforma em decimal.
    Private Sub Precoatacado_prodTextBox_Validating(ByVal sender As Object,
                                    ByVal e As System.ComponentModel.CancelEventArgs) Handles Precoatacado_prodTextBox.Validating


        Dim currency As Decimal
        If flag = "incluir" Or flag = "alterar" Then
            'Convert the current value to currency, with or without a currency symbol.
            If Precoatacado_prodTextBox.Text = "" Then

                Exit Sub

            End If


            If Not Decimal.TryParse(Me.Precoatacado_prodTextBox.Text,
                                    Globalization.NumberStyles.Currency, Nothing, currency) Then


                'Don't let the user leave the field if the value is invalid.
                With Me.Precoatacado_prodTextBox.HideSelection = False
                    Precoatacado_prodTextBox.SelectAll()
                    MessageBox.Show("Entre com um valor válido", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Precoatacado_prodTextBox.HideSelection = True

                End With
                e.Cancel = True
            End If
        End If

    End Sub
    'edita os números do precovarejo
    Private Sub Precoatacado_prodTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Precoatacado_prodTextBox.Validated

        If Precoatacado_prodTextBox.Text = "" Then
            Exit Sub
        End If
        If flag = "incluir" Or flag = "alterar" Then
            'Display the value as local currency  
            'Precoatacado_prodTextBox.Text = Decimal.Parse(Me.Precoatacado_prodTextBox.Text).ToString("c")
        End If
    End Sub
    ' no clicar limpa o campo se estiver incluino.....
    Private Sub Precoatacado_prodTextBox_Click(sender As Object, e As EventArgs) Handles Precoatacado_prodTextBox.Click
        If flag = "incluir" Or flag = "alterar" Then
            Precoatacado_prodTextBox.Text = ""
        End If
    End Sub
    'Rem pega os dados do data grido prod e joga no form com double click
    Private Sub ProdutosDataGridView_DoubleClick_1(sender As Object, e As EventArgs)

        travarCamposprod()
        tabpage_produtos.SelectedIndex = 0

    End Sub

  


    Private Sub bnt_cadProdnfe_Click(sender As Object, e As EventArgs) Handles bnt_cadProdnfe.Click

        
        ' marca as notas repetidas com a letra a b c para não cadastrar duas vezes
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim command As SqlCommand

        Dim xx As Integer
        Dim CodigoAnterior As String = ""
        Dim NumeroNota(3000) As String



        For xx = 0 To VendasMlbDataGridView.RowCount() - 1

            command = connection.CreateCommand()
            command.CommandText = "SELECT * FROM VendasMlb WHERE Id_VendasMlb = '" & VendasMlbDataGridView.Item(0, xx).Value & "'"
            command.CommandType = CommandType.Text
            ' ------------------------------------------------

            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()
            While lrd.Read

                NumeroNota(xx) = lrd("NUmeroPedido2_VendasMlb").ToString

            End While
            connection.Close()
           

            ' acrescenta uma letra atrás do codigo vendas mlb para mudar o código e não permitir que ele seja relançado
            If CodigoAnterior = NumeroNota(xx) Then
                NumeroNota(xx) = NumeroNota(xx) + "A"
            End If


            If CodigoAnterior = (NumeroNota(xx) + "A") Then
                NumeroNota(xx) = NumeroNota(xx) + "B"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "B") Then
                NumeroNota(xx) = NumeroNota(xx) + "C"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "C") Then
                NumeroNota(xx) = NumeroNota(xx) + "D"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "D") Then
                NumeroNota(xx) = NumeroNota(xx) + "E"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "E") Then
                NumeroNota(xx) = NumeroNota(xx) + "F"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "F") Then
                NumeroNota(xx) = NumeroNota(xx) + "G"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "G") Then
                NumeroNota(xx) = NumeroNota(xx) + "H"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "H") Then
                NumeroNota(xx) = NumeroNota(xx) + "I"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "I") Then
                NumeroNota(xx) = NumeroNota(xx) + "J"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "J") Then
                NumeroNota(xx) = NumeroNota(xx) + "K"
            End If

            If CodigoAnterior = (NumeroNota(xx) + "K") Then
                NumeroNota(xx) = NumeroNota(xx) + "L"
            End If

            Dim command2 As SqlCommand
            command2 = connection.CreateCommand()
            command2.CommandText = "update VendasMlb set NUmeroPedido2_VendasMlb = @NUmeroPedido2_VendasMlb  where  Id_VendasMlb = '" & VendasMlbDataGridView.Item(0, xx).Value & "'"
            command2.CommandType = CommandType.Text
            command2.Parameters.Add("@NUmeroPedido2_VendasMlb", SqlDbType.VarChar, 50).Value = NumeroNota(xx)

            Try

                connection.Open()
                command2.ExecuteNonQuery()
                connection.Close()

            Catch ex As Exception

                MessageBox.Show(ex.ToString())

            End Try


            ' End If

            CodigoAnterior = NumeroNota(xx)

        Next

        Me.VendasMlbTableAdapter.Fill(Me.DataSetFinal.VendasMlb)

    End Sub
    'REM CADASTRA OS DADOS PARA CALCULAR O CAPITAL DE GIRO DOS FORNECEDORES no arquivo capitalgirofornecdor
    Private Sub btn_data_Click(sender As Object, e As EventArgs) Handles btn_data.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "select * from nfefornecedor as d left outer join capitalgirofornecedor as i  on d.numeronota_nfe = i.numeronfe_klgiro where i.numeronfe_klgiro is null"
        connection.Open()

        Dim connection2 As SqlConnection
        connection2 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        Dim lrd As SqlDataReader = command.ExecuteReader()


        While lrd.Read()


            'convertendo a data emissão de string para date
            Dim dataemissao = lrd("dEmi_dataemissaonfe").ToString()
            Dim dE = DateTime.ParseExact(dataemissao, "yyyy-MM-dd", Nothing)

            'convertendo a data emissão de string para date
            Dim datavencdup1 = lrd("dVen1_datavencimentodupnfe").ToString()
            Dim d1v = DateTime.ParseExact(datavencdup1, "yyyy-MM-dd", Nothing)

            'convertendo a data emissão de string para date
            Dim datavencdup2 = lrd("dVen2_datavencimentodupnfe").ToString()
            Dim d2v = DateTime.ParseExact(datavencdup2, "yyyy-MM-dd", Nothing)

            'convertendo a data emissão de string para date
            Dim datavencdup3 = lrd("dVen3_datavencimentodupnfe").ToString()
            Dim d3v = DateTime.ParseExact(datavencdup3, "yyyy-MM-dd", Nothing)

            'convertendo a data emissão de string para date
            Dim datavencdup4 = lrd("dVen4_datavencimentodupnfe").ToString()
            Dim d4v = DateTime.ParseExact(datavencdup4, "yyyy-MM-dd", Nothing)

            'convertendo a data emissão de string para date
            Dim datavencdup5 = lrd("dVen5_datavencimentodupnfe").ToString()
            Dim d5v = DateTime.ParseExact(datavencdup5, "yyyy-MM-dd", Nothing)

            Dim result1 = DateDiff(DateInterval.Day, dE, d1v)
            Dim result2 = DateDiff(DateInterval.Day, dE, d2v)
            Dim result3 = DateDiff(DateInterval.Day, dE, d3v)
            Dim result4 = DateDiff(DateInterval.Day, dE, d4v)
            Dim result5 = DateDiff(DateInterval.Day, dE, d5v)
            Dim total As Integer
            Dim divisor As Integer = 1


            If result2 > 0 Then

                divisor = divisor + 1
            End If

            If result3 > 0 Then

                divisor = divisor + 1
            End If

            If result4 > 0 Then

                divisor = divisor + 1
            End If

            If result5 > 0 Then

                divisor = divisor + 1
            End If

            total = (result1 + result2 + result3 + result4 + result5) / divisor

            Dim rzsocial = lrd("xNome_razaoemissornfe").ToString()
            Dim vrgiro = lrd("vprod_vrunitarioprodnfe").ToString()
            Dim numeronota = lrd("numeronota_nfe").ToString()

            Dim cmd As SqlCommand

            '-------------------------------------------------------------------------
            cmd = connection2.CreateCommand()
            cmd.CommandText = "INSERT capitalgirofornecedor (numeronfe_klgiro,dataemit_klgiro, razaosocial_klgiro,valor_klgiro,mediadiaspg_klgiro,tlvrXgiro_klgiro) values (@numeronfe_klgiro,@dataemit_klgiro, @razaosocial_klgiro,@valor_klgiro,@mediadiaspg_klgiro,@tlvrXgiro_klgiro)"

            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@numeronfe_klgiro", SqlDbType.VarChar, 50).Value = numeronota
            'REM o comando CDate desinverte a data mas coloca o time, e para tirar esse problema, coloquei o varchar em 10
            cmd.Parameters.Add("@dataemit_klgiro", SqlDbType.VarChar, 10).Value = CDate(dE)
            cmd.Parameters.Add("@razaosocial_klgiro", SqlDbType.VarChar, 50).Value = rzsocial
            cmd.Parameters.Add("@valor_klgiro", SqlDbType.Float).Value = Convert.ToDouble(vrgiro, CultureInfo.InvariantCulture)
            cmd.Parameters.Add("@mediadiaspg_klgiro", SqlDbType.Float).Value = total
            Dim resultadomulti = (Convert.ToDouble(vrgiro, CultureInfo.InvariantCulture) * total)
            cmd.Parameters.Add("@tlvrXgiro_klgiro", SqlDbType.Float).Value = Math.Round(Convert.ToDouble(resultadomulti), 2)


            Try
                connection2.Open()
                cmd.ExecuteNonQuery()
                connection2.Close()

                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())

            Finally
                connection2.Close()
            End Try

        End While
        connection.Close()

    End Sub

    Private Sub btn_relfor_Click(sender As Object, e As EventArgs) Handles btn_relfor.Click
        ' *****************************************************************************************************
        ' curiosidades
        'faz uma busca no arquivo de kapital de giro, de acordo com a data estipulada no combobox da tabela kgiro
         'Dim sql As String = "select * from capitalgirofornecedor cp where cp.dataemit_klgiro  > GetDate() -" & cbx_diasforn.Text
        'Dim sql2 As String = "select SUM(cp.tlvrXgiro_klgiro)/SUM(cp.valor_klgiro) as resultado  from capitalgirofornecedor cp where cp.dataemit_klgiro  > GetDate() - " & cbx_diasforn.Text
        ' **********************************************************************************************

        ' pegar o último número gravado com datagrid
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)

        Dim UltimoID As String = "0"
        Dim command15 As SqlCommand
        command15 = connection.CreateCommand()
        command15.CommandText = "select id_PedidoCompra  from PedidoCompra  where id_PedidoCompra = (select max(id_PedidoCompra) from PedidoCompra) "
        Try
            connection.Open()

            Dim lrd15 As SqlDataReader = command15.ExecuteReader()
            While lrd15.Read

                If lrd15("id_PedidoCompra") Is DBNull.Value Then
                    UltimoID = "0"
                Else
                    UltimoID = lrd15("id_PedidoCompra")
                End If

            End While

            connection.Close()
        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try

        TextBox222.Text = UltimoID

        ' ---------------------------------------------- 
        btn_relfor.Enabled = False
        Button85.Enabled = False
        Button86.Enabled = True
        Button76.Enabled = False

        TextBox284.Enabled = False
        TextBox284.Clear()
        TabControl2.TabPages.Add(Tab_fornecedor)
        TabControl2.SelectedIndex = 1
        RadioButton11.Enabled = False
        RadioButton12.Enabled = False
        Button15.Enabled = False
        Button98.Enabled = False
        ComboBox26.Enabled = False

    End Sub

    Private Sub TabControl2_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl2.Selected


    End Sub
    'REm pega todos os varlores da tabela produtos
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ProdutosBindingSource.Filter = String.Empty


    End Sub
    'REM pega todos os valores selecionados nos combobox da tabela produtos fornecedor e linha
    Private Sub btn_filt_prod_click(sender As Object, e As EventArgs) Handles btn_filt_prod.Click

        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", cmbox_linhaprod.Text, cmbox_forprod.Text)

    End Sub
    'Pega todos od fornecedores da tabela produto
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", cmbox_forprod.Text)

    End Sub
    'mostra as colunas selecionadas no combobox da tabela produtos


    Private Sub btn_calcPrecos_Click(sender As Object, e As EventArgs) Handles btn_calcPrecos.Click

        ' zerando variáveis
        If Ipi_prodTextBox.Text = "" Then
            Ipi_prodTextBox.Text = 0
        End If
        If TextBox253.Text = "" Then
            TextBox253.Text = 0
        End If
        If TextBox231.Text = "" Then
            TextBox231.Text = 0
        End If
        If TextBox327.Text = "" Then
            TextBox327.Text = 0
        End If
        If TextBox329.Text = "" Then
            TextBox329.Text = 0
        End If
        If TextBox331.Text = "" Then
            TextBox331.Text = 0
        End If



        '-----------------------------------

        If Markup_prodTextBox.Text <> 0 And Custo_prodTextBox.Text <> 0 And Markup_prodTextBox.Text <> "0,00" And Custo_prodTextBox.Text <> "0,00" Then

            Precoatacado_prodTextBox.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox253.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            Precovarejo_prodTextBox.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (Markup_prodTextBox.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox328.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox327.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox330.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox329.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")
            TextBox332.Text = (((Custo_prodTextBox.Text * (1 + (Ipi_prodTextBox.Text / 100))) / (1 - (TextBox331.Text / 100)) * (1 + (TextBox231.Text / 100)))).ToString("F2")

        Else

            MessageBox.Show("Escolha o Custo e o Markup")

        End If


    End Sub


    Private Sub tab_nfe_click(sender As Object, e As EventArgs) Handles tab_nfe.Enter


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select  top 1 dEmi_dataemissaonfe  from nfefornecedor  where dEmi_dataemissaonfe = (select max(dEmi_dataemissaonfe) from nfefornecedor) "
        connection.Open()


        Dim lrd As SqlDataReader = command.ExecuteReader()

      
        connection.Close()


    End Sub

    'FORM TRANSPORTADORA  'FORM TRANSPORTADORA  'FORM TRANSPORTADORA  'FORM TRANSPORTADORA  'FORM TRANSPORTADORA 
    Private Sub tabpage_transportadora_Click(sender As Object, e As EventArgs) Handles tabpage_trans.Click

        Me.TransportadorasTableAdapter1.Fill(Me.DataSetFinal.transportadoras)
        mnu_confirmartrans.Visible = False
        btn_procuraCEpTrans.Enabled = False
        travarCamposTrans()

    End Sub

    'Rotina sub para botão incluir da tansportadora
    Private Sub IncluirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncluirToolStripMenuItem.Click

        ' transportadora_cadastrada = False

        ClearTextBoxTrans()
        habilitarbotoesincluirTrans()
        flag = "incluir"
        btn_procuraCEpTrans.Enabled = True
        DesistirOperaçãoToolStripMenuItem.Visible = True
        msk_CNPJTrans.Focus()
        cadastro_transportadoras = False
        msk_CNPJTrans.Enabled = True
        btn_verificaCnpj.Enabled = True
        btn_procuraCEpTrans.Enabled = False
        ' removendo as tabs do tabcontrol
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        ' TabControl1.TabPages.Remove(TabPage7)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
        '  tira outra page de outra tabcontrol
        tabpage_trans.TabPages.Remove(tab_tabelatrans)



    End Sub
    'destraba campos para form transportadora
    Private Sub destravarCamposTrans()

        Razaosocial_transTextBox.Enabled = True
        Endereco_transTextBox.Enabled = True
        Numerorua_transTextBox.Enabled = True
        Bairro_transTextBox.Enabled = True
        Cidade_transTextBox.Enabled = True
        cbx_estadotrans.Enabled = True
        Telefone_transTextBox.Enabled = True
        EMAIL_transTextBox.Enabled = True
        OBS_transTextBox.Enabled = True
        msk_CNPJTrans.Enabled = True
        cbx_InsEsttrans.Enabled = True
        msk_CEP.Enabled = True
        btn_verificaCnpj.Enabled = True
        DesistirOperaçãoToolStripMenuItem.Visible = True
        btn_procuraCEpTrans.Enabled = True

    End Sub
    'rotina sub para travar campos transportadora
    Private Sub travarCamposTrans()

        Razaosocial_transTextBox.Enabled = False
        Endereco_transTextBox.Enabled = False
        Numerorua_transTextBox.Enabled = False
        Bairro_transTextBox.Enabled = False
        Cidade_transTextBox.Enabled = False
        cbx_estadotrans.Enabled = False
        Telefone_transTextBox.Enabled = False
        EMAIL_transTextBox.Enabled = False
        OBS_transTextBox.Enabled = False
        msk_CNPJTrans.Enabled = False
        cbx_InsEsttrans.Enabled = False
        msk_CEP.Enabled = False
        btn_verificaCnpj.Enabled = False
        btn_procuraCEpTrans.Enabled = False

    End Sub
    'limpa campos para travar campos
    Private Sub ClearTextBoxTrans()

        Razaosocial_transTextBox.Clear()
        Endereco_transTextBox.Clear()
        Numerorua_transTextBox.Clear()
        Bairro_transTextBox.Clear()
        Cidade_transTextBox.Clear()
        cbx_estadotrans.Text = ""
        Telefone_transTextBox.Clear()
        EMAIL_transTextBox.Clear()
        OBS_transTextBox.Clear()
        msk_CNPJTrans.Clear()
        cbx_InsEsttrans.Clear()
        msk_CEP.Clear()

    End Sub
    'desabilita botões de arquivo no form trans e habilita botão do menu confirmar
    Private Sub habilitarbotoesincluirTrans()

        IncluirToolStripMenuItem.Enabled = False
        AlterarToolStripMenuItem.Enabled = False
        ApagarToolStripMenuItem.Enabled = False
        ConsultarToolStripMenuItem.Enabled = False

    End Sub

    Private Sub deshabilitarmenuTrans()

        IncluirToolStripMenuItem.Enabled = True
        AlterarToolStripMenuItem.Enabled = True
        ApagarToolStripMenuItem.Enabled = True
        ConsultarToolStripMenuItem.Enabled = True
        mnu_confirmartrans.Visible = False
        DesistirOperaçãoToolStripMenuItem.Visible = False

    End Sub


    Private Sub btn_procuraCEpTrans_Click(sender As Object, e As EventArgs) Handles btn_procuraCEpTrans.Click

        Try
            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", msk_CEP.Text)
            ds.ReadXml(xml)
            Endereco_transTextBox.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
            Bairro_transTextBox.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            Cidade_transTextBox.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            cbx_estadotrans.Text = ds.Tables(0).Rows(0)("uf").ToString()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Erro")

        End Try

        If Endereco_transTextBox.Text = "" Then

            MessageBox.Show("nenhum CEP foi achado")
            msk_CEP.Clear()

        End If
    End Sub

    Private Sub mnu_confirmartrans_Click(sender As Object, e As EventArgs) Handles mnu_confirmartrans.Click

        'Razaosocial_transTextBox.Focus()

        Dim reply As DialogResult = MessageBox.Show("Confirmar a alteração/inclusão ?", "Atenção!!!", _
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()

            If flag = "incluir" Then
                command.CommandText = "INSERT INTO transportadoras (Razaosocial_trans,endereco_trans,numerorua_trans,bairro_trans,cidade_trans,estado_trans,CEP_trans,telefone_trans,CNPJ_trans,INSEST_trans,EMAIL_trans,OBS_trans,id_trans ) values (@Razaosocial_trans,@endereco_trans,@numerorua_trans,@bairro_trans,@cidade_trans,@estado_trans,@CEP_trans,@telefone_trans,@CNPJ_trans,@INSEST_trans,@EMAIL_trans,@OBS_trans,@id_trans)"
            Else

                command.CommandText = "update transportadoras set Razaosocial_trans = @Razaosocial_trans,endereco_trans = @endereco_trans,numerorua_trans = @numerorua_trans,bairro_trans = @bairro_trans,cidade_trans = @cidade_trans,estado_trans = @estado_trans,CEP_trans = @CEP_trans,telefone_trans = @telefone_trans,CNPJ_trans = @CNPJ_trans,INSEST_trans = @INSEST_trans,EMAIL_trans = @EMAIL_trans,OBS_trans = @OBS_trans,id_trans=@id_trans where CNPJ_trans = @CNPJ_trans"
            End If

            command.CommandType = CommandType.Text
            '  command.Parameters.Add("@id_trans", SqlDbType.VarChar, 50).Value = "Id_transTextBox.Text"
            command.Parameters.Add("@Razaosocial_trans", SqlDbType.VarChar, 50).Value = Razaosocial_transTextBox.Text
            command.Parameters.Add("@endereco_trans", SqlDbType.VarChar, 50).Value = Endereco_transTextBox.Text
            command.Parameters.Add("@numerorua_trans", SqlDbType.VarChar, 50).Value = Numerorua_transTextBox.Text
            command.Parameters.Add("@bairro_trans", SqlDbType.VarChar, 50).Value = Bairro_transTextBox.Text
            command.Parameters.Add("@cidade_trans", SqlDbType.VarChar, 50).Value = Cidade_transTextBox.Text
            command.Parameters.Add("@estado_trans", SqlDbType.VarChar, 50).Value = cbx_estadotrans.Text
            command.Parameters.Add("@CEP_trans", SqlDbType.VarChar, 50).Value = msk_CEP.Text
            command.Parameters.Add("@telefone_trans", SqlDbType.VarChar, 50).Value = Telefone_transTextBox.Text
            command.Parameters.Add("@CNPJ_trans", SqlDbType.VarChar, 50).Value = msk_CNPJTrans.Text
            command.Parameters.Add("@INSEST_trans", SqlDbType.VarChar, 50).Value = cbx_InsEsttrans.Text
            command.Parameters.Add("@EMAIL_trans", SqlDbType.VarChar, 50).Value = EMAIL_transTextBox.Text
            command.Parameters.Add("@OBS_trans", SqlDbType.VarChar, 50).Value = OBS_transTextBox.Text
            command.Parameters.Add("@id_trans", SqlDbType.VarChar, 50).Value = "0"

            ' a seguir comandos para gravar os ítens coletados do formulário ------------------
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try

            cadastro_transportadoras = True
            travarCamposTrans()
            deshabilitarmenuTrans()
            flag = ""
            ' TabControl1.TabPages.Remove(TabPage7)
            ColocandoTabControl1()

            'mostra as tabpage
            tabpage_trans.TabPages.Insert(1, tab_tabelatrans)
            Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)
            Me.TransportadorasTableAdapter.Fill(Me.DataSetFinal.transportadoras)

            Exit Sub
        End If

        If reply = DialogResult.No Then

            Me.TransportadorasBindingSource1.MoveLast()
            cadastro_transportadoras = False
            travarCamposTrans()
            deshabilitarmenuTrans()
            flag = ""
        End If

    End Sub
    Private Sub RemovendoTabcontrol1()
        '  retira as tabs
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        'TabControl1.TabPages.Remove(TabPage7)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
    End Sub
    Private Sub ColocandoTabControl1()

    End Sub
    'REm botão que deisiste da operação

    Private Sub DesistirOperaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesistirOperaçãoToolStripMenuItem.Click

        Me.TransportadorasBindingSource1.MoveLast()
        flag = ""
        btn_procuraCEpTrans.Enabled = False
        mnu_confirmartrans.Visible = False
        DesistirOperaçãoToolStripMenuItem.Visible = False
        deshabilitarmenuTrans()
        travarCamposTrans()


        restaurar_tab(TabControl1.SelectedTab.ToString)





    End Sub
    'rotina de menus para form clientes
    Private Sub habilitarbotoesalterarcliente()

        IncluirToolStripMenuItem1.Enabled = False
        AlterarToolStripMenuItem1.Enabled = False
        ApagarToolStripMenuItem1.Enabled = False
        ConsultarToolStripMenuItem1.Enabled = False
        ConfirmarToolStripMenuItem.Visible = True
        DesistirOperaçãoToolStripMenuItem1.Visible = True

    End Sub

    Private Sub IncluirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IncluirToolStripMenuItem1.Click

        habilitarbotoesalterarcliente()
        ClearTextBox()
        destravarCampos()
        btn_buscarcepcliente.Enabled = True
        ConfirmarToolStripMenuItem.Visible = True
        flag = "incluir"

        Credito_clienteTextBox.Text = 0
        Totalcompra_clienteTextBox.Text = 0
        Saldo_clienteTextBox1.Text = 0

        '' marcar os radiogroup mais comuns na inclusão para eles não ficarem em brancos
        pes_fisica.BackColor = Color.Silver
        pes_fisica.Checked = False
        pes_juridica.Checked = False
        pes_juridica.BackColor = Color.Silver

        isento_sim.BackColor = Color.Silver
        isento_sim.Checked = False
        isento_nao.Checked = False
        isento_nao.BackColor = Color.Silver

        naovender_cliente.BackColor = Color.Silver
        naovender_cliente.Checked = False
        vender_cliente.Checked = False
        vender_cliente.BackColor = Color.Silver

        'esconde as tabs tabcontrol1
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)


        tab_form_clientes.TabPages.Remove(tab_grid_clientes)



    End Sub

    Private Sub AlterarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AlterarToolStripMenuItem1.Click

        flag = "alterar"
        habilitarbotoesalterarcliente()
        destravarCampos()
        btn_buscarcepcliente.Enabled = True
        ConfirmarToolStripMenuItem.Visible = True
        DesistirOperaçãoToolStripMenuItem1.Visible = True


        ' btn_buscarcepcliente.Enabled = True


        'esconde as tabs tabcontrol1
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)


        tab_form_clientes.TabPages.Remove(tab_grid_clientes)


    End Sub

    Private Sub ApagarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ApagarToolStripMenuItem1.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from cliente where id_cliente = @id_cliente"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@id_cliente", SqlDbType.VarChar, 50).Value = Id_clienteTextBox.Text

            Try

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

                Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)
                ClienteBindingSource.MoveFirst()
                MessageBox.Show("Apagado com sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try
        Else
            'Process No
        End If

        Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)

        habilitarbotoesgravar()

    End Sub

    Private Sub ConfirmarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmarToolStripMenuItem.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a alteração?", "Atenção!!!", _
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Email_clienteTextBox.Text = "não tem" Then

            If Email_clienteTextBox.Text = "" Then
                MessageBox.Show("email não foi preenchido")
                Exit Sub
            End If

            If EmailAddressCheck(Email_clienteTextBox.Text) = False And Email_clienteTextBox.Text <> "não tem" Then
                MessageBox.Show("Email INCORRETO")
                Exit Sub
            End If

        End If



        If reply = DialogResult.Yes Then

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()

            If flag = "incluir" Then
                command.CommandText = "INSERT INTO cliente (nome_cliente,fj_cliente,Nfantasia_cliente ,endereco_cliente,numerorua_cliente,bairro_cliente,cidade_cliente,estado_cliente,cep_cliente,codIBGE_cliente,telefone_cliente,obs_cliente,rg_cliente,cnpj_cliente,email_cliente,ativo_cliente,credito_cliente,totalcompra_cliente,saldo_cliente,isento_cliente,insestadual_cliente,cpf_cliente) values (@nome_cliente,@fj_cliente,@Nfantasia_cliente ,@endereco_cliente,@numerorua_cliente,@bairro_cliente,@cidade_cliente,@estado_cliente,@cep_cliente,@codIBGE_cliente,@telefone_cliente,@obs_cliente,@rg_cliente,@cnpj_cliente,@email_cliente,@ativo_cliente,@credito_cliente,@totalcompra_cliente,@saldo_cliente,@isento_cliente,@insestadual_cliente,@cpf_cliente)"
            Else
                command.CommandText = "update cliente set nome_cliente=@nome_cliente,fj_cliente=@fj_cliente,Nfantasia_cliente = @Nfantasia_cliente,endereco_cliente=@endereco_cliente,numerorua_cliente=@numerorua_cliente,bairro_cliente=@bairro_cliente,cidade_cliente=@cidade_cliente,estado_cliente=@estado_cliente,cep_cliente=@cep_cliente,codIBGE_cliente=@codIBGE_cliente,telefone_cliente=@telefone_cliente,obs_cliente=@obs_cliente,rg_cliente=@rg_cliente,cnpj_cliente=@cnpj_cliente,email_cliente=@email_cliente,ativo_cliente=@ativo_cliente,credito_cliente=@credito_cliente,totalcompra_cliente=@totalcompra_cliente,saldo_cliente=@saldo_cliente,isento_cliente=@isento_cliente,insestadual_cliente=@insestadual_cliente, cpf_cliente=@cpf_cliente where id_cliente=@id_cliente"
            End If


            command.CommandType = CommandType.Text

            command.Parameters.Add("@id_cliente", SqlDbType.VarChar, 50).Value = Id_clienteTextBox.Text
            command.Parameters.Add("@nome_cliente", SqlDbType.VarChar, 50).Value = Nome_clienteTextBox.Text

            'esse if  verifica se vai gravar pessoa física ou jurídica no arquivo na tabela cliente --------------------------------
            'nesse primeiro passo eu verifico se o campo está vazio, porque o arquivo foi chupado do interbase, e pode acontecer null

            If pes_fisica.Checked = True Then
                command.Parameters.Add("@fj_cliente", SqlDbType.VarChar, 50).Value = "Fisica"
            Else
                command.Parameters.Add("@fj_cliente", SqlDbType.VarChar, 50).Value = "Jurídica"
            End If

            command.Parameters.Add("@nfantasia_cliente", SqlDbType.VarChar, 50).Value = Nfantasia_clienteTextBox.Text
            command.Parameters.Add("@endereco_cliente", SqlDbType.VarChar, 100).Value = Endereco_clienteTextBox.Text
            command.Parameters.Add("@numerorua_cliente", SqlDbType.VarChar, 10).Value = Numerorua_clienteTextBox.Text
            command.Parameters.Add("@bairro_cliente", SqlDbType.VarChar, 30).Value = Bairro_clienteTextBox.Text
            command.Parameters.Add("@cidade_cliente", SqlDbType.VarChar, 50).Value = Cidade_clienteTextBox.Text
            command.Parameters.Add("@estado_cliente", SqlDbType.VarChar, 3).Value = Estado_clienteComboBox.Text

            command.Parameters.Add("@cep_cliente", SqlDbType.VarChar, 11).Value = Cep_clienteMaskedTextBox.Text
            command.Parameters.Add("@telefone_cliente", SqlDbType.VarChar, 50).Value = Telefone_clienteTextBox.Text
            command.Parameters.Add("@obs_cliente", SqlDbType.VarChar, 50).Value = Obs_clienteTextBox.Text

            'esse if verifica se vai gravar RG OU CNPJ na tabela cliente ------------------

            command.Parameters.Add("@rg_cliente", SqlDbType.VarChar, 50).Value = msktxtbox_rgcliente.Text
            command.Parameters.Add("@cpf_cliente", SqlDbType.VarChar, 50).Value = msk_cpfcliente.Text

            command.Parameters.Add("@cnpj_cliente", SqlDbType.VarChar, 50).Value = msktxt_cnpjcliente.Text
            command.Parameters.Add("@insestadual_cliente", SqlDbType.VarChar, 50).Value = msk_insestadualcliente.Text
            command.Parameters.Add("@email_cliente", SqlDbType.VarChar, 50).Value = Email_clienteTextBox.Text

            'esse if verifica se é um cliente ativo ou impedido de vender no arquivo -------------------
            'nesse primeiro passo eu verifico se o campo está vazio, porque o arquivo foi chupado do interbase, e pode acontecer null

            If vender_cliente.Checked = True Then
                command.Parameters.Add("@ativo_cliente", SqlDbType.VarChar, 50).Value = "vender"
            Else
                command.Parameters.Add("@ativo_cliente", SqlDbType.VarChar, 50).Value = "não vender"
            End If


            ' fim do if ------------------------------------------------------------------------

            'continuação da gravação dos ítens da tabela cliente -----------------------------

            command.Parameters.Add("@credito_cliente", SqlDbType.VarChar, 50).Value = Credito_clienteTextBox.Text
            command.Parameters.Add("@totalcompra_cliente", SqlDbType.VarChar, 50).Value = Totalcompra_clienteTextBox.Text
            command.Parameters.Add("@saldo_cliente", SqlDbType.VarChar, 50).Value = Saldo_clienteTextBox1.Text
            command.Parameters.Add("@codIBGE_cliente", SqlDbType.VarChar, 50).Value = CodIBGE_clienteTextBox.Text

            'esse if verifica se é um cliente isento ou não --------------------------------

            'nesse primeiro passo eu verifico se o campo está vazio, porque o arquivo foi chupado do interbase, e pode acontecer null

            If isento_sim.Checked = True Then
                command.Parameters.Add("@isento_cliente", SqlDbType.VarChar, 50).Value = "sim"
            Else
                command.Parameters.Add("@isento_cliente", SqlDbType.VarChar, 50).Value = "não"
            End If


            ' a seguir comandos para gravar os ítens coletados do formulário ------------------
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

                MessageBox.Show("Sucesso!")
                ''#Insert some code here, woo

            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try
        End If

        If reply = DialogResult.No Then
            Me.ClienteBindingSource.MovePrevious()
            Me.ClienteBindingSource.MoveNext()
        End If

        flag = ""
        travarCampos()
        habilitarmenuclientes()
        btn_buscarcepcliente.Enabled = False
        ConfirmarToolStripMenuItem.Visible = False
        'mostra as tabs tabcontrol1
        TabControl1.TabPages.Insert(0, tbpg_produtos)
        '  TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        TabControl1.TabPages.Insert(5, tab_nfe)
        TabControl1.TabPages.Insert(6, pedidos)
        TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
        TabControl1.TabPages.Insert(9, tbpg_bkup)
        TabControl1.TabPages.Insert(10, tbpg_orcamento)
        TabControl1.TabPages.Insert(11, tbg_relatorios)

        'mostra as tabpage
        tab_form_clientes.TabPages.Insert(1, tab_grid_clientes)
        Me.ClienteTableAdapter.Fill(Me.DataSetFinal.cliente)


    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridTransportadoras.DoubleClick

        tabpage_trans.SelectedIndex = 0
        travarCamposTrans()

    End Sub

    Private Sub AlterarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlterarToolStripMenuItem.Click

        mnu_confirmartrans.Visible = True
        destravarCamposTrans()
        habilitarbotoesincluirTrans()
        flag = "alterar"
        btn_procuraCEpTrans.Enabled = True
        DesistirOperaçãoToolStripMenuItem.Visible = True
        msk_CNPJTrans.Enabled = False
        btn_verificaCnpj.Enabled = False

        ' removendo as tabs do tabcontrol
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        ' TabControl1.TabPages.Remove(TabPage7)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
        '  tira outra page de outra tabcontrol
        tabpage_trans.TabPages.Remove(tab_tabelatrans)


    End Sub

    Private Sub restaurar_tab(p1 As String)


        If p1 = "TabPage: {Produtos}" Then


            TabControl1.TabPages.Insert(1, tbpg_clientes)
            TabControl1.TabPages.Insert(2, tbpg_transportadoras)
            TabControl1.TabPages.Insert(3, tbpg_pedFornecedor)

            TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
            TabControl1.TabPages.Insert(5, tab_nfe)
            TabControl1.TabPages.Insert(6, pedidos)
            TabControl1.TabPages.Insert(7, tabpage_NFE_e)
            TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
            TabControl1.TabPages.Insert(9, tbpg_bkup)
            TabControl1.TabPages.Insert(10, tbpg_orcamento)
            TabControl1.TabPages.Insert(11, tbg_relatorios)

            tabpage_produtos.TabPages.Insert(1, TabPage_gridProd)
            tabpage_produtos.TabPages.Insert(2, tbpg_listapreco)

        End If



        If p1 = "TabPage: {Clientes}" Then



            TabControl1.TabPages.Insert(0, tbpg_produtos)
            TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
            TabControl1.TabPages.Insert(3, tbpg_transportadoras)
            TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
            TabControl1.TabPages.Insert(5, tab_nfe)
            TabControl1.TabPages.Insert(6, pedidos)
            TabControl1.TabPages.Insert(7, tabpage_NFE_e)
            TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
            TabControl1.TabPages.Insert(9, tbpg_bkup)
            TabControl1.TabPages.Insert(10, tbpg_orcamento)
            TabControl1.TabPages.Insert(11, tbg_relatorios)

            tab_form_clientes.TabPages.Insert(1, tab_grid_clientes)

        End If

        If p1 = "TabPage: {Transportadoras}" Then

            '  restaurar as tabs
            TabControl1.TabPages.Insert(0, tbpg_produtos)
            TabControl1.TabPages.Insert(1, tbpg_clientes)
            TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)

            TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
            TabControl1.TabPages.Insert(5, tab_nfe)
            TabControl1.TabPages.Insert(6, pedidos)
            TabControl1.TabPages.Insert(7, tabpage_NFE_e)
            TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
            TabControl1.TabPages.Insert(9, tbpg_bkup)
            TabControl1.TabPages.Insert(10, tbpg_orcamento)
            TabControl1.TabPages.Insert(11, tbg_relatorios)

            'mostra as tabpage
            tabpage_trans.TabPages.Insert(1, tab_tabelatrans)

        End If


        p1 = ""



    End Sub


    Private Sub DesistirOperaçãoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DesistirOperaçãoToolStripMenuItem1.Click



        flag = ""
        btn_buscarcepcliente.Enabled = False
        DesistirOperaçãoToolStripMenuItem1.Visible = False
        ConfirmarToolStripMenuItem.Visible = False
        habilitamenucliente()
        travarCampos()
        restaurar_tab(TabControl1.SelectedTab.ToString)
        tab_form_clientes.SelectedIndex = 0



    End Sub

    Private Sub habilitamenucliente()

        IncluirToolStripMenuItem1.Enabled = True
        AlterarToolStripMenuItem1.Enabled = True
        ApagarToolStripMenuItem1.Enabled = True
        ConsultarToolStripMenuItem1.Enabled = True

    End Sub

    Private Sub ConsultarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarToolStripMenuItem.Click

        tabpage_trans.SelectedIndex = 1

    End Sub

    Private Sub ConsultarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConsultarToolStripMenuItem1.Click

        tab_form_clientes.SelectedIndex = 1

    End Sub

    Private Sub btn_verificaCnpj_click(sender As Object, e As EventArgs) Handles btn_verificaCnpj.Click
        'REM verifica se o produto já foi cadastrado mas só se for incluir

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand


        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT CNPJ_trans  from transportadoras where CNPJ_trans = '" & msk_CNPJTrans.Text & "'"
        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        '  Validação verifica se o codigo do sql, retorna algo
        If lrd.Read().ToString = False Then


            destravarCamposTrans()
            mnu_confirmartrans.Visible = True
            con.Close()
            msk_CNPJTrans.Enabled = False
            btn_verificaCnpj.Enabled = False

        Else

            mnu_confirmartrans.Visible = False
            MessageBox.Show("A transportadora " & lrd("CNPJ_trans").ToString & " já foi cadastrada!!!!")

            msk_CNPJTrans.Clear()
            msk_CNPJTrans.Focus()

        End If

        If msk_CNPJTrans.Text = "  ,   ,   /     - " Then
            mnu_confirmartrans.Visible = False
        End If

    End Sub
    'buca transportadora por cnpj


    Private Sub txt_nomeBuscaTrans_TextChanged(sender As Object, e As EventArgs) Handles txt_nomeBuscaTrans.TextChanged
        TransportadorasBindingSource1.Filter = String.Format("Razaosocial_trans LIKE '{0}%'", txt_nomeBuscaTrans.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_telefonebuscatrans.TextChanged

        TransportadorasBindingSource1.Filter = String.Format("telefone_trans LIKE '{0}%'", txt_telefonebuscatrans.Text)

    End Sub

    Private Sub msk_cnpjBuscaTrans_TextChanged(sender As Object, e As EventArgs) Handles msk_cnpjBuscaTrans.TextChanged

        If msk_CNPJTrans.Text <> "" Then

            TransportadorasBindingSource1.Filter = String.Format("CNPJ_trans LIKE '{0}%'", msk_cnpjBuscaTrans.Text)

        Else

            TransportadorasBindingSource1.Filter = String.Empty


        End If
    End Sub


    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txt_buscaclientenome.TextChanged

        ClienteBindingSource.Filter = String.Format("nome_cliente LIKE '{0}%'", txt_buscaclientenome.Text)

    End Sub

    Private Sub msk_buscaclientecnpj_MaskInputRejected(sender As Object, e As EventArgs) Handles msk_buscaclientecnpj.TextChanged
        ClienteBindingSource.Filter = String.Format("cnpj_cliente LIKE '{0}%'", msk_buscaclientecnpj.Text)
    End Sub
    'rotina que verifica a existência do código no form produtos
    Public Sub verificaCodigoProdutos()

        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT *  from produtos where cod_prod = '" & Cod_prodTextBox.Text & "'"

        con.Open()


        'REM verifica se cdigo prod existe banco do produto na nota para não gravar duas vezes
        Dim lrd As SqlDataReader = cmd.ExecuteReader()



        Try
            If lrd.Read() = True Then
                MessageBox.Show("O código do produto " & Cod_prodTextBox.Text & " já foi cadastrado!!!!")
                Cod_prodTextBox.Clear()
                Cod_prodTextBox.Focus()
                con.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()

        If Cod_prodTextBox.Text = "" Then
            menu_confirmarprod.Visible = False
        End If

        Cod_prodTextBox.Enabled = False
        Button112.Enabled = True
        Button112.BackColor = Color.Coral

    End Sub

    Private Sub txt_produranomeprod_TextChanged_2(sender As Object, e As EventArgs) Handles txt_produranomeprod.TextChanged
        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", txt_produranomeprod.Text)
    End Sub

    Private Sub ProdutosDataGridView_DoubleClick(sender As Object, e As EventArgs)
        tabpage_produtos.SelectedIndex = 0
    End Sub



    Private Sub btn_busca_prod_rela_Click(sender As Object, e As EventArgs)

        ProdutosBindingSource2.Filter = String.Empty

    End Sub

    'coloca o aruivo da tabela no form com o duplo click
    Private Sub dataDrigProdRela_DoubleClick(sender As Object, e As EventArgs)
        tabpage_produtos.SelectedIndex = 0
    End Sub
    'Rotina para pegar os dados não lidos do arquivo nfefornecedor e atualizar preços no arquivo produtos
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub


    'rotina de gravação do novo custo retirado do arquivo xml
    Private Sub corrigirCusto(custofinal As String, codigo As String)

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim custo2 As Double

        custo2 = (Convert.ToDouble(custofinal))


        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "update produtos set custo_prod = ROUND(@prevalor, 2) where cod_prodfor = '" & codigo & "'"
        command.CommandType = CommandType.Text
        command.Parameters.Add("@prevalor", SqlDbType.Float).Value = custo2

        Dim command2 As SqlCommand
        command2 = connection.CreateCommand()
        command2.CommandText = "update nfefornecedor set cadastrounoarquivoprodutos_nfe = @lido where cProd_codigoprodfornfe = '" & codigo & "'"
        command2.CommandType = CommandType.Text
        command2.Parameters.Add("@lido", SqlDbType.VarChar, 50).Value = "lido"

        MessageBox.Show(custofinal)

        Try

            connection.Open()
            command.ExecuteNonQuery()
            command2.ExecuteNonQuery()
            connection.Close()


        Catch ex As Exception

            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())

        End Try

    End Sub

   
    ' PEGANDO O ARQUIVO DE PRODUTO PARA FAZER O PEDIDO PARA A MARFINITE
    Private Sub ProdutosDataGridView1_DoubleClick(sender As Object, e As EventArgs)

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim v_SelectRow As Integer
        v_SelectRow = Me.dataGridPediMarf.CurrentRow.Index

        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "insert into pedidoMarfinite (numero_pedmarf,dataemissao_pedmarf,codprod_pedmarf,nomeprod_pedmarf,quantidadeprod_pedmarfr,precounitarioprod_pedmarf,ipiprod_pedmarf,total_pedmarf,descontoprod_pedmarf) values (@numero_pedmarf, @dataemissao_pedmarf, @codprod_pedmarf, @nomeprod_pedmarf,@quantidadeprod_pedmarfr, @precounitarioprod_pedmarf, @ipiprod_pedmarf, @total_pedmarf,@descontoprod_pedmarf) "
        command.CommandType = CommandType.Text
        'command.Parameters.Add("@numero_pedmarf", SqlDbType.VarChar, 50).Value = txt_numeropedmarf.Text
        command.Parameters.Add("@dataemissao_pedmarf", SqlDbType.Date).Value = Date.Now
        command.Parameters.Add("@codprod_pedmarf", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(1, v_SelectRow).Value
        command.Parameters.Add("@nomeprod_pedmarf", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(5, v_SelectRow).Value

        Dim qtdPedMarf As Integer

        Try
            qtdPedMarf = InputBox("Escolha a quantidade", "Escolha a quantidade")
        Catch ex As Exception
            qtdPedMarf = 1
        End Try

        command.Parameters.Add("@quantidadeprod_pedmarfr", SqlDbType.Float).Value = qtdPedMarf
        command.Parameters.Add("@precounitarioprod_pedmarf", SqlDbType.Float).Value = dataGridPediMarf.Item(16, v_SelectRow).Value
        command.Parameters.Add("@ipiprod_pedmarf", SqlDbType.Float).Value = dataGridPediMarf.Item(14, v_SelectRow).Value

        Dim totalpedmarf = ((dataGridPediMarf.Item(16, v_SelectRow).Value) * (1 + (dataGridPediMarf.Item(14, v_SelectRow).Value) / 100)) * qtdPedMarf
        command.Parameters.Add("@total_pedmarf", SqlDbType.Float).Value = Math.Round(totalpedmarf, 2)
        ' ESCOLHENDO O DESCONTO
        Dim desconto As Integer
        Try
            desconto = InputBox("Qual é o desconto?", "Desconto ")
        Catch ex As Exception
            MessageBox.Show("Escolher um desconto.Produto escolhido foi cancelado.")
            Exit Sub
        End Try

        command.Parameters.Add("@descontoprod_pedmarf", SqlDbType.Float).Value = desconto


        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Me.PedidoMarfiniteTableAdapter.Fill(Me.DataSetFinal.pedidoMarfinite)
        TabControlPedMarf.SelectedIndex = 0
        MenuStrip4.Enabled = True
        ' PedidoMarfiniteBindingSource.Filter = String.Format("numero_pedmarf LIKE '{0}' ", txt_numeropedmarf.Text)

    End Sub

    Private Sub DeletaItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletarItemToolStripMenuItem.Click


        ' verifica se o compo está preenchido

        If TextBox27.Text = "" Then

            MessageBox.Show("Campo de código em branco !!!")

            Exit Sub
        End If

        ' apaga registro
        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            ' -----------------------------------------
            ' -----------------------------------------
            ' lendo a quantidade da tabela de produtos

            command = connection.CreateCommand()
            command.CommandText = "select * from produtos where nome_prod = '" & TextBox215.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            Dim EstoqueAtual As Integer = 0
            Dim QuantidadeEntradaNota As Double

            While lrd.Read()
                EstoqueAtual = lrd("estoqueatual_prod")
            End While
            connection.Close()

            ' calculando o estoque com o cancelamento da entrada
            QuantidadeEntradaNota = TextBox26.Text
            EstoqueAtual -= QuantidadeEntradaNota
            TextBox218.Text = EstoqueAtual

            command = connection.CreateCommand()
            command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod where cod_prod=@cod_prod "
            command.CommandType = CommandType.Text
            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = TextBox210.Text
            command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = EstoqueAtual

            ' apagar dados de alteração da tabela produtos

        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())

        Finally
            connection.Close()
        End Try


        ' --------------------------------------
            ' apagar os dados da tabela
            Dim v_SelectRow As Integer
            v_SelectRow = Me.NotasEntradaDataGridView.CurrentRow.Index

        command = connection.CreateCommand()
            command.CommandText = "delete from NotasEntrada where  Id_EntradaNota = @Id_EntradaNota"
        command.CommandType = CommandType.Text
            command.Parameters.Add("@Id_EntradaNota", SqlDbType.VarChar, 50).Value = NotasEntradaDataGridView.Item(0, v_SelectRow).Value

        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()
            Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
            ProdutosBindingSource.MoveFirst()
            MessageBox.Show("Apagado com sucesso!")
            ''#Insert some code here, woo
        Catch ex As Exception
            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())


        Finally
            connection.Close()
        End Try
        Else
        'Process No
        End If

        Me.NotasEntradaTableAdapter.Fill(Me.DataSetFinal.NotasEntrada)
        TextBox27.Clear()
        TextBox215.Clear()
        TextBox26.Clear()
        TextBox64.Clear()
        TextBox210.Clear()
        TextBox218.Clear()

    End Sub
    Private Sub DistintosToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            'Me.DataSetFinal.cadastrodoNCM)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

   

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_deletaritempedidosnfe.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim totalvalordoitem As Double
      
        Try

            Dim v_SelectRow As Integer
            v_SelectRow = Me.ItemPedidosDataGridView.CurrentRow.Index

            Dim result = MessageBox.Show("Confirmar a Deleção?", "Atenção!!!", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then

                  Dim command As SqlCommand
                command = connection.CreateCommand()
                command.CommandText = "delete from ItemPedidos where nome_item = @nome and id_item = @id_cod"
                command.CommandType = CommandType.Text
                command.Parameters.Add("@nome", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(3, v_SelectRow).Value
                command.Parameters.Add("@id_cod", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(10, v_SelectRow).Value


                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

         
                'rem PASSA O VALOR DO CAMPO DO VR TOTAL PARA A VARIÁVEL
                MessageBox.Show(Valortotal_pedTextBox.Text)
                MessageBox.Show(ItemPedidosDataGridView.Item(7, v_SelectRow).Value)
                Valortotal_pedTextBox.Text = Valortotal_pedTextBox.Text - ItemPedidosDataGridView.Item(7, v_SelectRow).Value

                Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

            End If

        Catch ex As Exception

            MessageBox.Show("Impossível apagar campos nulo")

        End Try

    End Sub


    Private Sub ProdutosDataGridView1_DoubleClick_1(sender As Object, e As EventArgs) Handles ProdutosDataGridView1.DoubleClick

        Dim y As Integer = ItemPedidosDataGridView.RowCount()
        If y > 19 Then
            MessageBox.Show("Só pode conter 20 ítens")
            Exit Sub
        End If

        Dim contador As Integer = 0

        Dim connection5 As SqlConnection
        connection5 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        'REM coloca ponteiro junto com row escolhida
        Dim v_SelectRow As Integer
        v_SelectRow = Me.ProdutosDataGridView1.CurrentRow.Index

        'REM pega a quantidade de produtos no pedido
        Dim qtdPedMarf As Integer

        Try
            qtdPedMarf = InputBox("Escolha a quantidade", "Escolha a quantidade")

        Catch ex As Exception
            TabControlpedidos_nfe.SelectedIndex = 0
            Exit Sub
        End Try


        Dim command5 As SqlCommand
        command5 = connection5.CreateCommand()
        command5.CommandText = "insert into itemPedidos (data_item,for_item,linha_item,nome_item,cor_item,quantidade_item,precovarejo_item,totalvalor_item,entregue_item,codpedido_item, codcliente_item,codprod_item,custototal_item,vendedor_item,dataentrega_item, horariocadastro_item,ped_orc_item,peso_item,qtdeNfe_item,NCM_item,tabelaFIscal_item, codproduto_item,PrecoTabela_item) values (@data_item,@for_item,@linha_item,@nome_item,@cor_item,@quantidade_item,@precovarejo_item,@totalvalor_item,@entregue_item, @codpedido_item ,@codcliente_item,@codprod_item,@custototal_item,@vendedor_item,@dataentrega_item, @hora_pedido_item,@ped_orc_item,@peso_item,@qtdeNfe_item,@NCM_item,@tabelaFIscal_item,@codproduto_item,@PrecoTabela_item)"

        command5.CommandType = CommandType.Text
        '  command.Parameters.Add("@cod_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(1, v_SelectRow).Value
        command5.Parameters.Add("@data_item", SqlDbType.Date).Value = Dataemissao_pedDateTimePicker.Text
        command5.Parameters.Add("@for_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(3, v_SelectRow).Value
        command5.Parameters.Add("@linha_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(4, v_SelectRow).Value
        command5.Parameters.Add("@nome_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(5, v_SelectRow).Value + " " + ProdutosDataGridView1.Item(6, v_SelectRow).Value
        command5.Parameters.Add("@cor_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(6, v_SelectRow).Value
        command5.Parameters.Add("@quantidade_item", SqlDbType.Int).Value = qtdPedMarf
        '   BUSCANDO O PREÇO CORRETO - PODE SER VAREJO OU ATACADO OU ATACADO COM 5%
        Dim TipoVendaVendedores As String = ""
        Dim PrecoCorreto As String = 0

        If txt_TipoVendaPedido.Text = "normal" Then
            TipoVendaVendedores = 1
        End If
        If txt_TipoVendaPedido.Text = "Preço no atacado" Then
            TipoVendaVendedores = 2
        End If
        If txt_TipoVendaPedido.Text = "com 5% de desconto" Then
            TipoVendaVendedores = 3
        End If

         Select TipoVendaVendedores
            Case 1
                PrecoCorreto = ProdutosDataGridView1.Item(7, v_SelectRow).Value
            Case 2
                PrecoCorreto = ProdutosDataGridView1.Item(7, v_SelectRow).Value
            Case 3
                PrecoCorreto = ProdutosDataGridView1.Item(7, v_SelectRow).Value
        End Select

        command5.Parameters.Add("@precovarejo_item", SqlDbType.Float).Value = PrecoCorreto
        command5.Parameters.Add("@hora_pedido_item", SqlDbType.VarChar, 50).Value = hora_final

        'REm calcular o valor total do ítem
        Dim totalvalordoitem As Double = 0
        Dim valor As Double = 0
        Try
            totalvalordoitem = PrecoCorreto * qtdPedMarf
            'rem PASSA O VALOR DO CAMPO DO VR TOTAL PARA A VARIÁVEL
            valor = Valortotal_pedTextBox.Text
            '    soma O VALOR DA COLUNA 
            totalvalordoitem = valor + ((PrecoCorreto) * qtdPedMarf)
            Valortotal_pedTextBox.Text = totalvalordoitem
        Catch ex As Exception
            MessageBox.Show("Está sem valor de varejo")
            Exit Sub
        End Try

        totalvalordoitem = (PrecoCorreto) * qtdPedMarf

        command5.Parameters.Add("@totalvalor_item", SqlDbType.Float).Value = totalvalordoitem.ToString("F2")
        command5.Parameters.Add("@entregue_item", SqlDbType.VarChar, 50).Value = "Não Entregue"
        command5.Parameters.Add("@codcliente_item", SqlDbType.VarChar, 50).Value = Codcli_pedTextBox.Text
        command5.Parameters.Add("@codprod_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(1, v_SelectRow).Value
             Dim CustoTlItem As Double = (ProdutosDataGridView1.Item(16, v_SelectRow).Value * (1 + (ProdutosDataGridView1.Item(14, v_SelectRow).Value / 100)) * qtdPedMarf)
        command5.Parameters.Add("@custototal_item", SqlDbType.Float).Value = CustoTlItem.ToString("F2")
     
        command5.Parameters.Add("@vendedor_item", SqlDbType.VarChar, 50).Value = Vendedor_pedComboBox.Text
        command5.Parameters.Add("@dataentrega_item", SqlDbType.VarChar, 50).Value = ""
        command5.Parameters.Add("@codpedido_item", SqlDbType.VarChar, 50).Value = Id_pedidosTextBox.Text
        command5.Parameters.Add("@ped_orc_item", SqlDbType.VarChar, 50).Value = "válido"
        command5.Parameters.Add("@peso_item", SqlDbType.Float).Value = ProdutosDataGridView1.Item(15, v_SelectRow).Value * qtdPedMarf
        command5.Parameters.Add("@NCM_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(22, v_SelectRow).Value
        command5.Parameters.Add("@tabelaFIscal_item", SqlDbType.VarChar, 50).Value = ProdutosDataGridView1.Item(23, v_SelectRow).Value

        Dim comissao As Double = TextBox62.Text
        command5.Parameters.Add("@qtdeNfe_item", SqlDbType.Float).Value = (totalvalordoitem * (comissao / 100)).ToString("F2")
        Dim PorcentagemLucro As Double = (1 - (CustoTlItem / totalvalordoitem)) * 100
        command5.Parameters.Add("@codproduto_item", SqlDbType.Float).Value = PorcentagemLucro.ToString("F2")
        command5.Parameters.Add("@PrecoTabela_item", SqlDbType.Float).Value = PrecoCorreto


        Try
            connection5.Open()
            command5.ExecuteNonQuery()
            connection5.Close()

            'VOlta para a tela de pedidos e atualiza a tabela ....
            TabControlpedidos_nfe.SelectedIndex = 0
            Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
            ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}%'", Id_pedidosTextBox.Text)

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try


    End Sub




    Private Sub GerarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerarPedidoToolStripMenuItem.Click

        somatotal = 0
        AcertarPreco = True

        'DESABILITA MENU DO FORM PEDIDOS NFE
        GerarPedidoToolStripMenuItem.Enabled = False
        ConfirmarPedidoToolStripMenuItem.Enabled = False
        DeletarPedidoToolStripMenuItem.Enabled = False
        btn_conifmardadospedNFE.ForeColor = Color.Black
        btn_conifmardadospedNFE.Enabled = True
        txt_horario_pedido.Enabled = False
        IMprimir_pedidos.Enabled = False
        ComboBox15.Enabled = True
        ComboBox16.Enabled = True
        HabilitarEnvioToolStripMenuItemPedido.Enabled = False
        RadioButton7.Enabled = False
        RadioButton9.Enabled = False

        btn_buscaTansPedido.Enabled = False
        btn_buscaCliPedido.Enabled = True
        Button54.Enabled = False



        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
    

        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControlpedidos_nfe.TabPages.Remove(TabPageConsultaPedidos)
        ' TabControlpedidos_nfe.TabPages.Remove(Tbpg_consultaOrcPed)
        TabControlpedidos_nfe.TabPages.Remove(tabpageProdutos_nfe)
        TabControlpedidos_nfe.TabPages.Remove(TabPage9)

        TabControlpedidos_nfe.TabPages.Add(TabPageClientes_nfe)
        TabControlpedidos_nfe.TabPages.Add(TabPageTransportadora_nfe)



        travacamposformpedidosNFE()
        limparformpedidosNFE()
        ComboBox15.Text = ""

        'valida campos necessários
        Vendedor_pedComboBox.Enabled = True
        Dataemissao_pedDateTimePicker.Enabled = True
        'pega a data do dia
        Dataemissao_pedDateTimePicker.Text = Date.Now

        Obsvendedor_pedTextBox.Enabled = True
        Obsgerente_pedTextBox.Enabled = True
        Endercoentrega_pedTextBox.Enabled = True
        cbx_FormadepagamentoPed.Enabled = True
        Email_pedTextBox.Enabled = True
        DesistirOperaçãoToolStripMenuItem3.Enabled = True
        Button42.Enabled = False
        Button46.Enabled = False
        Button47.Enabled = False
        Button49.Visible = False
        Button50.Visible = False
        Button51.Visible = False
        Button52.Enabled = False
        Button58.Enabled = False

        ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}%'", "jhgkjhbjugiug8gtljhgb...")

    End Sub
    'trava campos do form pedidos NFE
    Private Sub travacamposformpedidosNFE()

        'REM trava os campos dos dados cadastrais
        Id_pedidosTextBox.Enabled = False
        Vendedor_pedComboBox.Enabled = False
        Valortotal_pedTextBox.Enabled = False
        Dataemissao_pedDateTimePicker.Enabled = False
        Email_pedTextBox.Enabled = False

        'REM trava os campos dos Dados dos clientes
        Razaosocialcliente_pedTextBox.Enabled = False
        Nomefantasiacliente_pedTextBox.Enabled = False
        Codcli_pedTextBox.Enabled = False

        'REM trava os dados das entregas
        Codtransportadora_pedTextBox.Enabled = False
        Nometransportadora_pedTextBox.Enabled = False
        Endercoentrega_pedTextBox.Enabled = False

        'REM trava os campos das observações
        Obsvendedor_pedTextBox.Enabled = False
        Obsgerente_pedTextBox.Enabled = False
        cbx_FormadepagamentoPed.Enabled = False
       
        'REM trava o botão delete
        btn_deletaritempedidosnfe.Enabled = False
        Endercoentrega_pedTextBox.Enabled = False
        Codtransportadora_pedTextBox.Enabled = False
        btn_enviarEMail.Enabled = False

    End Sub




    Private Sub limparformpedidosNFE()
        'REM libera os campos dos dados cadastrais
        Id_pedidosTextBox.Clear()
        Vendedor_pedComboBox.Text = ""
        Valortotal_pedTextBox.Clear()
        'REM libera os campos dos Dados dos clientes
        Codtransportadora_pedTextBox.Clear()
        Razaosocialcliente_pedTextBox.Clear()
        Nomefantasiacliente_pedTextBox.Clear()
        Codcli_pedTextBox.Clear()
        'REM libera os dados das entregas
        Nometransportadora_pedTextBox.Clear()
        Endercoentrega_pedTextBox.Clear()
        'REM lrbera os campos das observações
        Obsvendedor_pedTextBox.Clear()
        Obsgerente_pedTextBox.Clear()
        cbx_FormadepagamentoPed.Text = ""
        Codtransportadora_pedTextBox.Clear()
        ComboBox16.Text = ""

        Email_pedTextBox.Clear()


    End Sub


    Private Sub travarcamposformpedidosNFE()
        'REM libera os campos dos dados cadastrais
        Id_pedidosTextBox.Enabled = False
        ' = False
        Vendedor_pedComboBox.Enabled = False
        Valortotal_pedTextBox.Enabled = False
        Dataemissao_pedDateTimePicker.Enabled = False
        'REM libera os campos dos Dados dos clientes
        Razaosocialcliente_pedTextBox.Enabled = False
        Nomefantasiacliente_pedTextBox.Enabled = False
        Codcli_pedTextBox.Enabled = False
        'REM libera os dados das entregas
        Codtransportadora_pedTextBox.Enabled = False
        Nometransportadora_pedTextBox.Enabled = False
        Endercoentrega_pedTextBox.Enabled = False
        'REM lrbera os campos das observações
        Obsvendedor_pedTextBox.Enabled = False
        Obsgerente_pedTextBox.Enabled = False
        cbx_FormadepagamentoPed.Enabled = False
        ComboBox16.Enabled = False
        'REM deabilita o botão delete
        btn_deletaritempedidosnfe.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles txt_buscaClienteNFE.TextChanged

        VendasMlbDataGridView.DataSource = VendasMlbBindingSource
        VendasMlbBindingSource.Filter = String.Format("NUmeroPedido2_VendasMlb LIKE '{0}%'", txt_buscaClienteNFE.Text)

    End Sub

    Public Sub retorna_horario(hora As String)
        hora_final = Convert.ToString(hora)
    End Sub

    Private Sub btn_conifmardadospedNFE_Click(sender As Object, e As EventArgs) Handles btn_conifmardadospedNFE.Click

        flag = "produtos"

        If Email_pedTextBox.Text = "" Then
            MessageBox.Show("Definir o Email")
            Exit Sub
        End If

        If Vendedor_pedComboBox.Text = "" Or Razaosocialcliente_pedTextBox.Text = "" Or Nometransportadora_pedTextBox.Text = "" Or ComboBox15.Text = "" Then
            MessageBox.Show("preencher o campo dos vendedores e do Nome do cliente, a Transportadora e o EMAIL de envio ")
            Exit Sub
        End If


        Dim date1 As New Date()
        date1 = Date.Now
        Dim ci As CultureInfo = CultureInfo.InvariantCulture

        txt_horario_pedido.Text = date1.ToString("dd.yyyy.hh.mm.ss.FFFFF", ci)
        retorna_horario(txt_horario_pedido.Text)

        TabControlpedidos_nfe.TabPages.Remove(TabPageClientes_nfe)
        TabControlpedidos_nfe.TabPages.Remove(TabPageTransportadora_nfe)
        TabControlpedidos_nfe.TabPages.Insert(1, tabpageProdutos_nfe)


        btn_conifmardadospedNFE.Enabled = False
        btn_deletaritempedidosnfe.Enabled = True
        ConfirmarPedidoToolStripMenuItem.Enabled = True
       
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "insert into PedidoNFE (codcli_ped,vendedor_ped,formadepagamento_ped,obsvendedor_ped,obsgerente_ped,dataemissao_ped,razaosocialcliente_ped,nomefantasiacliente_ped,codtransportadora_ped,nometransportadora_ped,endercoentrega_ped,valortotal_ped,horariocadastro_ped,orcamento_pedido_ped,email_ped,TipoVenda_ped,EnvioEmail_ped,DisponibilidadeEstoque_ped,JaFoiEntregue_ped) values (@codcli_ped,@vendedor_ped,@formadepagamento_ped,@obsvendedor_ped,@obsgerente_ped,@dataemissao_ped,@razaosocialcliente_ped,@nomefantasiacliente_ped,@codtransportadora_ped,@nometransportadora_ped,@endercoentrega_ped,@valortotal_ped,@horariocadastro_ped,@orcamento_pedido_ped,@email_ped,@TipoVenda_ped,@EnvioEmail_ped,@DisponibilidadeEstoque_ped,@JaFoiEntregue_ped)"
       
        command.CommandType = CommandType.Text
        command.Parameters.Add("@codcli_ped", SqlDbType.VarChar, 50).Value = Codcli_pedTextBox.Text
        command.Parameters.Add("@vendedor_ped", SqlDbType.VarChar, 50).Value = Vendedor_pedComboBox.Text
        command.Parameters.Add("@formadepagamento_ped", SqlDbType.VarChar, 50).Value = cbx_FormadepagamentoPed.Text
        command.Parameters.Add("@obsvendedor_ped", SqlDbType.VarChar, 50).Value = Obsvendedor_pedTextBox.Text
        command.Parameters.Add("@obsgerente_ped", SqlDbType.VarChar, 50).Value = Obsgerente_pedTextBox.Text
        command.Parameters.Add("@dataemissao_ped", SqlDbType.Date).Value = Dataemissao_pedDateTimePicker.Text
        command.Parameters.Add("@razaosocialcliente_ped", SqlDbType.VarChar, 50).Value = Razaosocialcliente_pedTextBox.Text
        command.Parameters.Add("@nomefantasiacliente_ped", SqlDbType.VarChar, 50).Value = Nomefantasiacliente_pedTextBox.Text
        command.Parameters.Add("@codtransportadora_ped", SqlDbType.VarChar, 50).Value = Codtransportadora_pedTextBox.Text
        command.Parameters.Add("@nometransportadora_ped", SqlDbType.VarChar, 50).Value = Nometransportadora_pedTextBox.Text
        command.Parameters.Add("@valortotal_ped", SqlDbType.VarChar, 50).Value = Valortotal_pedTextBox.Text
        command.Parameters.Add("@endercoentrega_ped", SqlDbType.VarChar, 50).Value = Endercoentrega_pedTextBox.Text
        command.Parameters.Add("@horariocadastro_ped", SqlDbType.VarChar, 50).Value = hora_final
        command.Parameters.Add("@orcamento_pedido_ped", SqlDbType.VarChar, 50).Value = "PEDIDO"
        command.Parameters.Add("@email_ped", SqlDbType.VarChar, 50).Value = Email_pedTextBox.Text
        command.Parameters.Add("@TipoVenda_ped", SqlDbType.VarChar, 50).Value = txt_TipoVendaPedido.Text
        command.Parameters.Add("@EnvioEmail_ped", SqlDbType.VarChar, 50).Value = ComboBox15.Text
        command.Parameters.Add("@DisponibilidadeEstoque_ped", SqlDbType.VarChar, 50).Value = ComboBox16.Text
        command.Parameters.Add("@JaFoiEntregue_ped", SqlDbType.VarChar, 50).Value = "Não"


        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)
        PedidoNFEBindingSource.Filter = String.Format("horariocadastro_ped LIKE '{0}%'", txt_horario_pedido.Text)
        ' verifica se a é alterar ou insertar

        ItemPedidosBindingSource.Filter = String.Format("horariocadastro_item LIKE '{0}%'", txt_horario_pedido.Text)


        TabControlpedidos_nfe.SelectedIndex = 0
        travacamposformpedidosNFE()
        ComboBox16.Enabled = False

        btn_deletaritempedidosnfe.Enabled = True
        DesistirOperaçãoToolStripMenuItem3.Enabled = False
        ComboBox15.Enabled = False
        btn_conifmardadospedNFE.BackColor = Color.LightGray

      
    End Sub

    Private Sub ClienteDataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles ClienteDataGridView1.DoubleClick


        Dim v_SelectRow As Integer
        v_SelectRow = Me.ClienteDataGridView1.CurrentRow.Index

        Codcli_pedTextBox.Text = ClienteDataGridView1.Item(0, v_SelectRow).Value
        Razaosocialcliente_pedTextBox.Text = ClienteDataGridView1.Item(1, v_SelectRow).Value
        Nomefantasiacliente_pedTextBox.Text = ClienteDataGridView1.Item(3, v_SelectRow).Value
        Email_pedTextBox.Text = ClienteDataGridView1.Item(14, v_SelectRow).Value
        TabControlpedidos_nfe.SelectedIndex = 0


    End Sub

    Private Sub TransportadorasDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles TransportadorasDataGridView.DoubleClick

        Dim v_SelectRow As Integer
        v_SelectRow = Me.TransportadorasDataGridView.CurrentRow.Index

        Codtransportadora_pedTextBox.Text = TransportadorasDataGridView.Item(9, v_SelectRow).Value
        Nometransportadora_pedTextBox.Text = TransportadorasDataGridView.Item(1, v_SelectRow).Value
        TabControlpedidos_nfe.SelectedIndex = 0

    End Sub

    Private Sub ConfirmarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmarPedidoToolStripMenuItem.Click


        flag = ""
        flag1 = ""

        TabControlpedidos_nfe.TabPages.Remove(tabpageProdutos_nfe)

        'REM deslibera os campos dos dados cadastrais
        Id_pedidosTextBox.Enabled = False
        Vendedor_pedComboBox.Enabled = False
        Valortotal_pedTextBox.Enabled = False
        Dataemissao_pedDateTimePicker.Enabled = False
        'REM deslibera os campos dos Dados dos clientes
        Razaosocialcliente_pedTextBox.Enabled = False
        Nomefantasiacliente_pedTextBox.Enabled = False
        Codcli_pedTextBox.Enabled = False
        'REM deslibera os dados das entregas
        Codtransportadora_pedTextBox.Enabled = False
        Nometransportadora_pedTextBox.Enabled = False
        Endercoentrega_pedTextBox.Enabled = False
        'REM deslrbera os campos das observações
        Obsvendedor_pedTextBox.Enabled = False
        Obsgerente_pedTextBox.Enabled = False
        cbx_FormadepagamentoPed.Enabled = False
        ComboBox16.Enabled = False
        'REM deseabilita o botão delete
        btn_deletaritempedidosnfe.Enabled = False
        Endercoentrega_pedTextBox.Enabled = False
        Codtransportadora_pedTextBox.Enabled = False

        RadioButton7.Enabled = True
        RadioButton9.Enabled = True
        RadioButton9.Checked = True

        Button42.Enabled = True
        Button46.Enabled = True
        Button47.Enabled = True
        Button49.Visible = True
        ConfirmarPedidoToolStripMenuItem.Enabled = False

        'habilita botão de enviar 

        HabilitarEnvioToolStripMenuItemPedido.Enabled = True
        DesistirOperaçãoToolStripMenuItem3.Enabled = False
        '     GRAVAR O VALR TOTAL DO PEDIDO
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' soma a coluna dos valores e o põe textbox e grava
        Dim valor As String = 0
        ' Dim valor10 As Double = 0

        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView.Rows
            valor += Linha.Cells(7).Value
        Next

        ' -----------------------------------------
        '***********************************************************
        'valor = valor10 * 1
        PrecoAtacado = True

        'If valor10 < 500000 And txt_TipoVendaPedido.Text = "normal" Then
        '    valor = valor10 * 1
        '    PrecoAtacado = True
        'End If
        'If valor10 >= 500000 And txt_TipoVendaPedido.Text = "normal" Then
        '    valor = valor10 * 0.89
        'End If
        ' ***************************************************************

        ' Preço no atacado
        'If txt_TipoVendaPedido.Text = "Preço no atacado" Then
        '    valor = valor10 * 1
        'End If

        Valortotal_pedTextBox.Text = valor

        Dim valor1 = valor.Replace(",", ".")
        '------------------------------
        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "update PedidoNFE set valortotal_ped = ROUND(@prevalor, 2) where id_pedidos = '" & Id_pedidosTextBox.Text & "'"
        command.CommandType = CommandType.Text
        command.Parameters.Add("@prevalor", SqlDbType.Float).Value = Valortotal_pedTextBox.Text
        Try

            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())

        End Try

        Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)

        '-----------------------------


        Dim command7 As SqlCommand
        command7 = connection.CreateCommand()
        command7.CommandType = CommandType.Text
        Dim precovarejo As String
        Dim totalvalor As String
        Dim precotabela As String
        Dim PorcentagemBalcao As Double
        Dim AtacadoVarejo As String

        Dim xx As Integer
        For xx = 0 To ItemPedidosDataGridView.RowCount() - 1
            ' -----------------------------------------
            If txt_TipoVendaPedido.Text = "normal" Then
                precovarejo = ItemPedidosDataGridView.Item(6, xx).Value * 1
                totalvalor = ItemPedidosDataGridView.Item(6, xx).Value * ItemPedidosDataGridView.Item(5, xx).Value
                precotabela = ItemPedidosDataGridView.Item(6, xx).Value * 1
                AtacadoVarejo = "Varejo"
            End If

            'If txt_TipoVendaPedido.Text = "normal" Then
            '    precovarejo = ItemPedidosDataGridView.Item(6, xx).Value * 0.89
            '    totalvalor = precovarejo * ItemPedidosDataGridView.Item(5, xx).Value
            '    precotabela = ItemPedidosDataGridView.Item(6, xx).Value * 0.89
            '    AtacadoVarejo = "Atacado"
            'End If

            'If txt_TipoVendaPedido.Text <> "normal" Then
            '    precovarejo = ItemPedidosDataGridView.Item(6, xx).Value * 1
            '    totalvalor = ItemPedidosDataGridView.Item(6, xx).Value * ItemPedidosDataGridView.Item(5, xx).Value
            '    precotabela = ItemPedidosDataGridView.Item(6, xx).Value * 1
            '    AtacadoVarejo = "Varejo"
            'End If

            ' calcula a porcentagem
            PorcentagemBalcao = (1 - (ItemPedidosDataGridView.Item(14, xx).Value / totalvalor)) * 100
            Dim PorcentagemBalcao2 As String = PorcentagemBalcao.ToString("F2")
            Dim precovarejo1 = precovarejo.Replace(",", ".")
            Dim totalvalor1 = totalvalor.Replace(",", ".")
            Dim precotabela1 = precotabela.Replace(",", ".")

            command7.CommandText = "update ItemPedidos set precovarejo_item = '" & precovarejo1 & "',totalvalor_item = '" & totalvalor1 & "',PrecoTabela_item = '" & precotabela1 & "',totalPedido_item = '" & valor1 & "', codproduto_item = '" & PorcentagemBalcao2 & "', AtacadoVarejo_item = '" & AtacadoVarejo & "'  where id_item = '" & ItemPedidosDataGridView.Item(10, xx).Value & "'"

            Try
                connection.Open()
                command7.ExecuteNonQuery()
                connection.Close()


            Catch ex As Exception

                MessageBox.Show(ex.ToString())
                connection.Close()

            End Try
        Next
        Button52.Enabled = True
        Button58.Enabled = False

        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)


    End Sub


    'busca pedido para preencher nota fiscal
    Private Sub btn_buscarPedidoNFE_Click(sender As Object, e As EventArgs) Handles btn_buscarPedidoNFE.Click

        '' remove a tab consulta e acrescenta a tab TabPage_PedidosNFE
        ''RETIRA A VISIBILIDADE DA PAGE DESEJADA
        'TabControl1.TabPages.Remove(tbpg_produtos)
        'TabControl1.TabPages.Remove(tbpg_clientes)
        'TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        'TabControl1.TabPages.Remove(tbpg_transportadoras)
        'TabControl1.TabPages.Remove(tbpg_capitalGiro)
        'TabControl1.TabPages.Remove(tab_nfe)
        ''TabControl1.TabPages.Remove(tabpage_NFE_e)
        'TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        'TabControl1.TabPages.Remove(tbpg_bkup)
        'TabControl1.TabPages.Remove(pedidos)
        'TabControl1.TabPages.Remove(tbpg_orcamento)
        'TabControl1.TabPages.Remove(tbg_relatorios)

        '' remove tbpg de outro tabcontrol
        'TabControl_NFE.TabPages.Insert(1, TabPage_PedidosNFE)
        'TabControl_NFE.TabPages.Remove(TbPg_consultaNFe)

        'btn_confimraNfeEmitida.Enabled = True
        'btn_buscarPedidoNFE.Enabled = False
        'TabControl_NFE.SelectedIndex = 1
        'Dim dt As Date = Now
        'dt = dt.AddDays(-60)
        'DateTimePicker2.Text = dt
        'DateTimePicker3.Text = Date.Now
        'cbx_CFOP.Text = ""
        'cbx_VolNfeEmitidas.Text = ""
        'ComboBox12.Text = ""
        'TextBox30.Clear()
        'TextBox31.Clear()

        '' zerar campos
        'txt_vrduplicata1.Text = ""
        'txt_vrduplicata2.Text = ""
        'txt_vrduplicata3.Text = ""
        'txt_vrduplicata4.Text = ""
        'txt_vrduplicata5.Text = ""
        'rdb_vezesduplicata1.Enabled = True


    End Sub

    Private Sub clearNFE()
        D_Nome.Text = ""
        D_Endereco.Text = ""
        D_Email.Text = ""
        D_Cep.Text = ""
        D_Bairro.Text = ""
        D_Municipio.Text = ""
        D_Estado.Text = ""
        D_Telefone.Text = ""
        D_Cnpj.Text = ""
        txt_cpfNFE.Text = ""
        msk_ieNFE.Text = ""

    End Sub
    Private Sub ItemPedidosDataGridView1_DoubleClick(sender As Object, e As EventArgs)


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command2 As SqlCommand
        command2 = connection.CreateCommand

        command = connection.CreateCommand()

        command2.CommandType = CommandType.Text

        Dim qtdeDevida As Double
        Dim qtdEntregue As Double
        Dim v_SelectRow2 As Integer

        v_SelectRow2 = Me.ItemPedidosDataGridView1.CurrentRow.Index

        If ItemPedidosDataGridView1.Item(0, v_SelectRow2).Value <> "Totalmente Entregue" Then
            Try

                If ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value Is DBNull.Value Then
                    ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value = 0
                End If

                qtdeDevida = (ItemPedidosDataGridView1.Item(4, v_SelectRow2).Value) - (ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value)
                qtdEntregue = InputBox("Digite a quantidade a ser entregue :", "Quantidade", qtdeDevida)

                If qtdEntregue > ItemPedidosDataGridView1.Item(4, v_SelectRow2).Value Then

                    MessageBox.Show(" A QUANTIDADE TEM QUE SER MENOR QUE A EXISTENTE")

                    Exit Sub

                End If

                If (qtdEntregue + ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value) > ItemPedidosDataGridView1.Item(4, v_SelectRow2).Value Then

                    MessageBox.Show(" A QUANTIDADE TEM QUE SER MENOR QUE A EXISTENTE")

                    Exit Sub

                End If

                If (qtdEntregue + ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value) = ItemPedidosDataGridView1.Item(4, v_SelectRow2).Value Then


                    command.CommandText = "update itemPedidos set entregue_item = 'Totalmente Entregue',qtdeaserentregadaNFE_item = " & qtdEntregue & " where id_item = " & ItemPedidosDataGridView1.Item(8, v_SelectRow2).Value
                    command2.CommandText = "update itemPedidos set quantidadeparcialentregue_item = " & (qtdEntregue + ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value) & "where id_item = " & ItemPedidosDataGridView1.Item(8, v_SelectRow2).Value

                End If

                If (qtdEntregue + ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value) < ItemPedidosDataGridView1.Item(4, v_SelectRow2).Value Then

                    command.CommandText = "update itemPedidos set entregue_item = 'Parcialmente Entregue',qtdeaserentregadaNFE_item = " & qtdEntregue & " where id_item = " & ItemPedidosDataGridView1.Item(8, v_SelectRow2).Value
                    command2.CommandText = "update itemPedidos set quantidadeparcialentregue_item = " & (qtdEntregue + ItemPedidosDataGridView1.Item(5, v_SelectRow2).Value) & "where id_item = " & ItemPedidosDataGridView1.Item(8, v_SelectRow2).Value

                End If

            Catch ex As Exception

                MessageBox.Show(ex.ToString)
                Exit Sub

            End Try

            Try

                connection.Open()
                command.ExecuteNonQuery()
                command2.ExecuteNonQuery()
                connection.Close()

                Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

            Catch ex As Exception



            End Try

        End If



    End Sub

    ' **********************************************************************************************************************
    '   EXEMPLO DE COMO MOSTRAR OUTRA TELA

    'FormularioItemNfeEmitida.Show()
    'FormularioItemNfeEmitida.txt_NomeCliNovoForm.Text = D_Nome.Text
    'FormularioItemNfeEmitida.Txt_numeroCliNovoForm.Text = txt_coPEdNFe.Text
    'FormularioItemNfeEmitida.ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}'", Me.txt_coPEdNFe.Text)
    ' *****************************************************************************************************************************


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Verifica se a NFE pode ser gerada
        If D_Estado.Text = "" Or txt_nNfe.Text = "" Or cbx_CFOP.Text = "" Then
            MessageBox.Show("Preencher o campo do Estado, CFOP e Numero da Nota")
            Exit Sub
        End If

        ' Directory.CreateDirectory("C:\Users\FERNANDO12\Desktop\Notas Fiscais\" & Format(Date.Now, "yyyy-MM-dd") & "\" & TextBox16.Text & "\")
        'Directory.CreateDirectory("\\FERNANDO\Projeto Programa Marfinite Mogi\Xls Orcamento pedidos\pedidos enviados\" & Format(Date.Now, "yyyy-MM-dd") & "\" & Vendedor_pedComboBox.Text & "\")


        'Dim Arquivo As New System.IO.StreamWriter("C:\Users\FERNANDO12\Desktop\Notas Fiscais\" & Format(Date.Now, "yyyy-MM-dd") & "\" & TextBox16.Text & "\" & D_Nome.Text & "_" & Format(Date.Now, "yyyy-MM-dd") & "_" & txt_nNfe.Text & "_" & txt_coPEdNFe.Text & ".txt")
        '
        'Variávei que acumulam os totais
        Dim TlVrNota As Double
        Dim TlVrPis As Double
        Dim TlVrCofins As Double
        Dim TlVrICM1 As Double

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select * from estados where nome_estado = '" & D_Estado.Text & "'"

        Dim tabela1 As String = 0
        Dim tabela2 As String = 0

        connection.Open()
        Dim lrd As SqlDataReader = command.ExecuteReader()

        While lrd.Read

            tabela1 = lrd("tabela1_ICMestado")
            tabela2 = lrd("tabela2_ICMestado")

        End While

        connection.Close()


        'cadastro do emissor
        'Arquivo.WriteLine("NOTA FISCAL|1|")
        'Arquivo.WriteLine("A|2.00|NFe|")
        ' VERIFICA SE ENTRADA E SAÍDA
        Dim ent_saida As String
        If TextBox31.Text = "entrada" Then
            ent_saida = "0"
        Else
            ent_saida = "1"
        End If

        'Arquivo.WriteLine("B|35||" & TextBox30.Text & "|1|55|1|" & txt_nNfe.Text & "|" & Format(Date.Now, "yyyy-MM-dd") & "|" & Format(Date.Now, "yyyy-MM-dd") & "|" & Format(DateTime.Now, "HH:mm:ss") & "|" & ent_saida & "|3530607|1|1||1|1|3|2.2.19|")
        'Arquivo.WriteLine("C|FERNANDO FRASCARI - EPP||454131384115||287474|4754701|3|")
        'Arquivo.WriteLine("C02|72844228000179|")
        'Arquivo.WriteLine("C05|AVENIDA HENRIQUE PERES|1880||VILA BERNADOTTI|3530607|MOGI DAS CRUZES|SP|08735400|1058|BRASIL|1147276401|")

        ''cadastro do destinatário
        'Arquivo.WriteLine("E|" & D_Nome.Text & "|" & msk_ieNFE.Text & "||" & D_Email.Text & "|")

        'If Txt_fisicajuridicaNFE.Text = "Jurídica" Then
        '    Arquivo.WriteLine("E02|" & D_Cnpj.Text & "|")
        'Else
        '    Arquivo.WriteLine("E03|" & txt_cpfNFE.Text & "|")
        'End If

        'Arquivo.WriteLine("E05|" & D_Endereco.Text & "|" & Numerodarua_pedTextBox.Text & "||" & D_Bairro.Text & "|" & Txt_CodIBGE.Text & "|" & D_Municipio.Text & "|" & D_Estado.Text & "|" & D_Cep.Text & "|1058|BRASIL|" & MaskedTextBox8.Text & "|")

        'For x As Integer = 0 To ItemPedidosDataGridView1.Rows.Count() - 1

        '    Dim codigo_produto As String = ItemPedidosDataGridView1.Item(1, (x)).Value
        '    Dim nome_produto As String = ItemPedidosDataGridView1.Item(2, (x)).Value
        '    Dim NCM_prod As String = ItemPedidosDataGridView1.Item(9, (x)).Value

        '    'Pegando em double para depois formatar com duas casas depois da vírgula em string
        '    Dim quantidade_prod1 As Double = ItemPedidosDataGridView1.Item(3, (x)).Value
        '    Dim vrunitario_prod1 As Double = ItemPedidosDataGridView1.Item(4, (x)).Value

        '    'Jogando o double no string com 4 casas
        '    Dim quantidade_prod As String = quantidade_prod1.ToString("F4").Replace(",", ".")
        '    Dim vrunitario_prod As String = vrunitario_prod1.ToString("F4").Replace(",", ".")
        '    'jogando o resultado da multiplicação double em string com duas casas
        '    Dim vrtlitem_prod1 As Double = quantidade_prod1 * vrunitario_prod1
        '    Dim vrtlitem_prod = vrtlitem_prod1.ToString("F2").Replace(",", ".")


        '    Arquivo.WriteLine("H|" & (x + 1) & "|")
        '    Arquivo.WriteLine("I|" & codigo_produto & "||" & nome_produto & "|" & NCM_prod & "||" & cbx_CFOP.Text & "|UN|" & quantidade_prod & "|" & vrunitario_prod & "|" & vrtlitem_prod & "||UN|" & quantidade_prod & "|" & vrunitario_prod & "|||||1||")
        '    Arquivo.WriteLine("M|")
        '    Arquivo.WriteLine("N|")

        '    'Calcular o ICM
        '    Dim aliquotaICM As Double = 0
        '    If ItemPedidosDataGridView1.Item(10, (x)).Value = "1" Then
        '        aliquotaICM = tabela1
        '    Else
        '        aliquotaICM = tabela2
        '    End If

        '    Dim ICM1 As Double = (vrtlitem_prod1 * (aliquotaICM)) / 100
        '    Dim ICM = ICM1.ToString("F2").Replace(",", ".")
        '    'somando o tl do vr de icm
        '    TlVrICM1 += ICM1

        '    'calcular o total da nota
        '    TlVrNota += vrtlitem_prod1
        '    'txt_vrduplicata1.Text = txt_vrduplicata1.Text.Trim()
        '    'txt_vrduplicata1.Text = txt_vrduplicata1.Text.Replace(".", ",")

        '    Arquivo.WriteLine("N02|0|00|3|" & vrtlitem_prod & "|" & aliquotaICM & "|" & ICM & "|")
        '    Arquivo.WriteLine("O|||||999|")
        '    Arquivo.WriteLine("O08|53|0.00|")

        '    'calcular o pis
        '    Dim pis1 As Double = ((0.65 * vrtlitem_prod) / 100)
        '    Dim pis = pis1.ToString("F2").Replace(",", ".")
        '    TlVrPis += pis
        '    Arquivo.WriteLine("Q|")
        '    Arquivo.WriteLine("Q02|01|" & vrtlitem_prod & "|1.00|" & pis & "|")

        '    'calcular o cofins
        '    Dim confins1 As Double = ((3.0 * vrtlitem_prod) / 100)
        '    Dim cofins = confins1.ToString("F2").Replace(",", ".")
        '    TlVrCofins += cofins
        '    Arquivo.WriteLine("S|")
        '    Arquivo.WriteLine("S02|01|" & vrtlitem_prod & "|1.00|" & cofins & "|")

        'Next
        'Dim TlVrNtoa2 As String = TlVrNota
        'TlVrNtoa2 = TlVrNtoa2.Trim()
        'TlVrNtoa2 = TlVrNtoa2.Replace(".", ",")
        'Dim TlVrNota3 = TlVrNtoa2.ToString.Replace(",", ".")

        '' TlVrNota = TlVrNota.ToString.Replace(",", ".")
        'Dim TlVrICM = TlVrICM1.ToString("F2").Replace(",", ".")
        'Arquivo.WriteLine("W|")
        'Arquivo.WriteLine("W02|" & TlVrNota3 & "|" & TlVrICM & "|||" & TlVrNota3 & "||||||||||")
        '' rem buscando dados das transportadoras
        'command = connection.CreateCommand()
        'command.CommandText = "select * from transportadoras where id_trans = '" & CodTrans_nfeemitidaTextBox.Text & "'"

        'connection.Open()
        'Dim lrd2 As SqlDataReader = command.ExecuteReader()
        'Dim insEst As String = "454131384115"
        'Dim enderecoTrans As String = "av.henrique peres, 1880"
        'Dim estadoTrans As String = "sp"
        'Dim cidadeTrans As String = "mogi das cruzes"
        'Dim CNPJTrans As String = "72844228000179"

        'While lrd2.Read

        '    insEst = lrd2("INSEST_trans")
        '    enderecoTrans = lrd2("endereco_trans")
        '    estadoTrans = lrd2("estado_trans")
        '    cidadeTrans = lrd2("cidade_trans")
        '    CNPJTrans = lrd2("CNPJ_trans")

        'End While
        'connection.Close()
        '' VERIFICA frete
        'Dim frete As String
        'If ComboBox12.Text = "emitente" Then
        '    frete = "0"
        'Else
        '    frete = "1"
        'End If

        'Arquivo.WriteLine("X|" & frete & "|")
        'Arquivo.WriteLine("X03|" & NomeTrans_nfeemitidaTextBox.Text & "|" & insEst & "|" & enderecoTrans & "|" & estadoTrans & "|" & cidadeTrans & "|")
        'Arquivo.WriteLine("X04|" & CNPJTrans & "|")
        'Arquivo.WriteLine("X18|||")
        ''formatano o valor peso
        'Dim peso As Double = Peso_nfeemitidaTextBox.Text
        'Dim peso2 = peso.ToString("F3").Replace(",", ".")
        'Arquivo.WriteLine("X26|" & cbx_VolNfeEmitidas.Text & "|VOLUMES|||" & peso2 & "|" & peso2 & "|")
        '' acertando a posição das datas
        'Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
        'Dim date1 As Date = date_duplicata1.Text
        'Dim date2 As Date = date_duplicata2.Text
        'Dim date3 As Date = date_duplicata3.Text
        'Dim date4 As Date = date_duplicata4.Text
        'Dim date5 As Date = date_duplicata5.Text
        ''formatano o valor duplicata
        'Dim Vrduplicata1_1 As String = txt_vrduplicata1.Text
        'Dim Vrduplicata1_2 = Vrduplicata1_1.Trim()
        'Vrduplicata1_2 = Vrduplicata1_1.Replace(".", ",")
        'Dim vrduplicata1 As String = Vrduplicata1_2.ToString.Replace(",", ".")

        '' rotinas para declarar as duplicatas
        'If txt_vrduplicata1.Text <> "" And txt_vrduplicata2.Text = "" And txt_vrduplicata3.Text = "" And txt_vrduplicata4.Text = "" And txt_vrduplicata5.Text = "" Then

        '    Arquivo.WriteLine("Y|")
        '    Arquivo.WriteLine("Y02|" & txt_nNfe.Text & "|" & TlVrNota3 & "||" & TlVrNota3 & "|")
        '    Arquivo.WriteLine("Y07|" & txt_nNfe.Text & "|" & Format(Date.Now, "yyyy-MM-dd") & "|" & TlVrNota3 & "|")
        '    Arquivo.WriteLine("Z| Val aprox Tributos R$ " & (TlVrNota3 * 0.3234) / 100 & " (32,34%) Fonte : IBPT|")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obsNFE.Text & "||")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obs2.Text & "||")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & "| Vencto: " & Format(Date.Now, "yyyy-MM-dd") & " Valor R$ " & TlVrNota3 & "|")

        'End If
        'If txt_vrduplicata1.Text <> "" And txt_vrduplicata2.Text <> "" And txt_vrduplicata3.Text = "" And txt_vrduplicata4.Text = "" And txt_vrduplicata5.Text = "" Then

        '    Arquivo.WriteLine("Y|")
        '    Arquivo.WriteLine("Y02|" & txt_nNfe.Text & "|" & vrduplicata1 & "||" & vrduplicata1 & "|" & txt_nNfe.Text & "|" & txt_vrduplicata2.Text & "||" & txt_vrduplicata2.Text & "|")
        '    Arquivo.WriteLine("Y07|" & txt_nNfe.Text & "|" & date1.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata1.Text & "|" & txt_nNfe.Text & "|" & date2.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata2.Text & "|")
        '    Arquivo.WriteLine("Z| Val aprox Tributos R$ " & (TlVrNota3 * 0.333) / 100 & " (33,30%) Fonte : IBPT|")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obsNFE.Text & "||")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obs2.Text & "||")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /1 | Vencto: " & date_duplicata1.Text & " Valor R$ " & txt_vrduplicata1.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /2 | Vencto: " & date_duplicata2.Text & " Valor R$ " & txt_vrduplicata2.Text & "|")

        'End If
        'If txt_vrduplicata1.Text <> "" And txt_vrduplicata2.Text <> "" And txt_vrduplicata3.Text <> "" And txt_vrduplicata4.Text = "" And txt_vrduplicata5.Text = "" Then

        '    Arquivo.WriteLine("Y|")
        '    Arquivo.WriteLine("Y02|" & txt_nNfe.Text & "|" & vrduplicata1 & "||" & vrduplicata1 & "|" & txt_nNfe.Text & "|" & txt_vrduplicata2.Text & "||" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata3.Text & "||" & txt_vrduplicata3.Text & "|")
        '    Arquivo.WriteLine("Y07|" & txt_nNfe.Text & "|" & date1.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata1.Text & "|" & txt_nNfe.Text & "|" & date2.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & date3.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata3.Text & "|")
        '    Arquivo.WriteLine("Z| Val aprox Tributos R$ " & (TlVrNota3 * 0.3236) / 100 & " (32,36%) Fonte : IBPT|")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obsNFE.Text & "||")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obs2.Text & "||")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /1 | Vencto: " & date_duplicata1.Text & " Valor R$ " & txt_vrduplicata1.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /2 | Vencto: " & date_duplicata2.Text & " Valor R$ " & txt_vrduplicata2.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /3 | Vencto: " & date_duplicata3.Text & " Valor R$ " & txt_vrduplicata3.Text & "|")

        'End If
        'If txt_vrduplicata1.Text <> "" And txt_vrduplicata2.Text <> "" And txt_vrduplicata3.Text <> "" And txt_vrduplicata4.Text <> "" And txt_vrduplicata5.Text = "" Then

        '    Arquivo.WriteLine("Y|")
        '    Arquivo.WriteLine("Y02|" & txt_nNfe.Text & "|" & vrduplicata1 & "||" & vrduplicata1 & "|" & txt_nNfe.Text & "|" & txt_vrduplicata2.Text & "||" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata3.Text & "||" & txt_vrduplicata3.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata4.Text & "||" & txt_vrduplicata4.Text & "|")
        '    Arquivo.WriteLine("Y07|" & txt_nNfe.Text & "|" & date1.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata1.Text & "|" & txt_nNfe.Text & "|" & date2.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & date3.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata3.Text & "|" & txt_nNfe.Text & "|" & date4.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata4.Text & "|")
        '    Arquivo.WriteLine("Z| Val aprox Tributos R$ " & (TlVrNota3 * 0.3199) / 100 & " (31,99%) Fonte : IBPT|")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obsNFE.Text & "||")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obs2.Text & "||")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /1 | Vencto: " & date_duplicata1.Text & " Valor R$ " & txt_vrduplicata1.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /2 | Vencto: " & date_duplicata2.Text & " Valor R$ " & txt_vrduplicata2.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /3 | Vencto: " & date_duplicata3.Text & " Valor R$ " & txt_vrduplicata3.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /4 | Vencto: " & date_duplicata4.Text & " Valor R$ " & txt_vrduplicata4.Text & "|")

        'End If
        'If txt_vrduplicata1.Text <> "" And txt_vrduplicata2.Text <> "" And txt_vrduplicata3.Text <> "" And txt_vrduplicata4.Text <> "" And txt_vrduplicata5.Text <> "" Then

        '    Arquivo.WriteLine("Y|")
        '    Arquivo.WriteLine("Y02|" & txt_nNfe.Text & "|" & vrduplicata1 & "||" & vrduplicata1 & "|" & txt_nNfe.Text & "|" & txt_vrduplicata2.Text & "||" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata3.Text & "||" & txt_vrduplicata3.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata4.Text & "||" & txt_vrduplicata4.Text & "|" & txt_nNfe.Text & "|" & txt_vrduplicata5.Text & "||" & txt_vrduplicata5.Text & "|")
        '    Arquivo.WriteLine("Y07|" & txt_nNfe.Text & "|" & date1.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata1.Text & "|" & txt_nNfe.Text & "|" & date2.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata2.Text & "|" & txt_nNfe.Text & "|" & date3.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata3.Text & "|" & txt_nNfe.Text & "|" & date4.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata4.Text & "|" & txt_nNfe.Text & "|" & date5.ToString("yyyy-MM-dd", ci) & "|" & txt_vrduplicata5.Text & "|")
        '    Arquivo.WriteLine("Z| Val aprox Tributos R$ " & (TlVrNota3 * 0.34) / 100 & " (34%) Fonte : IBPT|")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obsNFE.Text & "||")
        '    Arquivo.WriteLine("Z04| Observação :" & txt_obs2.Text & "||")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /1 | Vencto: " & date_duplicata1.Text & " Valor R$ " & txt_vrduplicata1.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /2 | Vencto: " & date_duplicata2.Text & " Valor R$ " & txt_vrduplicata2.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /3 | Vencto: " & date_duplicata3.Text & " Valor R$ " & txt_vrduplicata3.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /4 | Vencto: " & date_duplicata4.Text & " Valor R$ " & txt_vrduplicata4.Text & "|")
        '    Arquivo.WriteLine("Z04| Fatura " & txt_nNfe.Text & " /5 | Vencto: " & date_duplicata5.Text & " Valor R$ " & txt_vrduplicata5.Text & "|")

        'End If


        'Arquivo.Close()
        ''------------------------------------------------------------------------

        'NFE_EmitidasTableAdapter.Fill(DataSetFinal.NFE_Emitidas)
        'btn_buscarPedidoNFE.Enabled = True
        'Button4.Enabled = False

    End Sub
    'Busca o arquivo Txt para correção e futura emissão via programa NFE
    Private Sub btn_buscatext_Click(sender As Object, e As EventArgs)

        'Dim MyFolderBrowser As New System.Windows.Forms.OpenFileDialog
        'MyFolderBrowser.InitialDirectory = "C:\NFE\"

        ''filtra para exibir somente arquivos de imagens

        'MyFolderBrowser.Filter = "Texts (*.txt;*.csv)|*.txt;*.csv|" & "All files (*.*)|*.*"

        'Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        'If dlgResult = Windows.Forms.DialogResult.OK Then
        '    txt_caminhoTXT.Text = MyFolderBrowser.FileName
        'End If

        'Dim fluxoTexto As IO.StreamReader
        'Dim linhaTexto As String
        'Dim contador As Integer = 0

        'RichTextBox1.Text = ""

        ''busca o arquivo NFe.txt para ser lido
        'If IO.File.Exists(txt_caminhoTXT.Text) Then
        '    fluxoTexto = New IO.StreamReader(txt_caminhoTXT.Text)
        '    linhaTexto = fluxoTexto.ReadLine

        '    While Not fluxoTexto.EndOfStream
        '        RichTextBox1.Text &= linhaTexto & vbCrLf
        '        linhaTexto = fluxoTexto.ReadLine
        '    End While

        '    fluxoTexto.Close()

        '    Dim texto As String = RichTextBox1.Text
        '    Dim matriz() As String
        '    Dim j As Integer

        '    matriz = texto.Split("|")

        '    For j = 0 To matriz.GetUpperBound(0)
        '        ListBox1.Items.Add(matriz(j))

        '        ' MessageBox.Show(j & " " & matriz(j))

        '        Select Case j
        '            Case 12
        '                txt_nNfe.Text = matriz(j)
        '            Case 48
        '                D_Nome.Text = matriz(j)
        '            Case 49
        '                msk_ieNFE.Text = matriz(j)
        '            Case 51
        '                D_Email.Text = matriz(j)
        '            Case 53
        '                D_Cnpj.Text = matriz(j)
        '            Case 55
        '                D_Endereco.Text = matriz(j)
        '            Case 56
        '                Numerodarua_pedTextBox.Text = matriz(j)
        '            Case 58
        '                D_Bairro.Text = matriz(j)
        '            Case 59
        '                Txt_CodIBGE.Text = matriz(j)
        '            Case 60
        '                D_Municipio.Text = matriz(j)
        '            Case 61
        '                D_Estado.Text = matriz(j)
        '            Case 62
        '                D_Cep.Text = matriz(j)
        '            Case 65
        '                D_Telefone.Text = matriz(j)
        '            Case 74
        '                cbx_CFOP.Text = matriz(j)
        '        End Select



        '    Next
        'End If

        'Dim newString As String
        'Dim sourceString As String = txt_caminhoTXT.Text
        'Try
        '    newString = sourceString.Substring(sourceString.LastIndexOf("-"))
        'Catch ex As Exception
        '    newString = ""
        'End Try

        ''   Dim novaString = sourceString.Substring(sourceString.LastIndexOf("."))
        'Dim stringFinal = newString.Replace(".txt", "")
        'txt_coPEdNFe.Text = (stringFinal.Replace("-", ""))

        'ListBox1.Text = ""
        'ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}'", txt_coPEdNFe.Text)


    End Sub

    ' gerar arquivo txt
    Private Sub GerarArquivoTXTToolStripMenuItem_Click(sender As Object, e As EventArgs)


        'ListBox2.Items.Clear()

        'ListBox2.Items.Add("DADOS DO EMISSOR")
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("                                             " & TextBox16.Text & "   " & TextBox13.Text & "   " & TextBox11.Text & "   " & ComboBox4.Text)
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("DADOS DO DESTINATÁRIO")
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("                                              " & D_Nome.Text & "   " & D_Endereco.Text & "   " & D_Complemento.Text & "   " & D_Email.Text)
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("                                              " & D_Cep.Text & "   " & D_Bairro.Text & "   " & D_Municipio.Text & "   " & D_Estado.Text & "   " & D_Telefone.Text)
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("                                              " & D_Cnpj.Text & "   " & txt_cpfNFE.Text & "   " & msk_ieNFE.Text)
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("DADOS DOS PRODUTOS")
        'ListBox2.Items.Add("")
        'ListBox2.Items.Add("                                          " & "   NOME DO PRODUTO                            " & "COR                                 " & " QUANTIDADE                              " & " VALOR UNITÁRIO                              " & " VALOR TOTAL   ")

        ''---------------------------------------------------------------------------------
        'Dim nome As String
        'Dim cor As String
        'Dim qtde As String
        'Dim valor As String
        ''------------------------------------------
        'Dim espaconome As Integer
        'Dim espacocor As Integer
        'Dim espacoqtde As Integer
        'Dim espacovalor As Integer
        ''---------------------------
        'Dim pontinhosnome As String
        'Dim pontinhoscor As String
        'Dim pontinhosqtde As String
        'Dim pontinhosvalor As String


        'Dim w2 As Integer
        'Dim w3 As Integer
        'Dim w4 As Integer

        'For z As Integer = 0 To ItemPedidosDataGridView1.Rows.Count() - 1

        '    nome = ItemPedidosDataGridView1.Item(2, z).Value.ToString.Length
        '    cor = ItemPedidosDataGridView1.Item(3, z).Value.ToString.Length
        '    qtde = ItemPedidosDataGridView1.Item(6, z).Value.ToString.Length
        '    valor = ItemPedidosDataGridView1.Item(7, z).Value.ToString.Length


        '    espaconome = 50 - nome
        '    espacocor = 50 - cor
        '    espacoqtde = 50 - qtde
        '    espacovalor = 50 - valor

        '    pontinhosnome = ""
        '    pontinhoscor = ""
        '    pontinhosqtde = ""
        '    pontinhosvalor = ""


        '    For w1 = 0 To espaconome
        '        pontinhosnome += "."

        '    Next

        '    For w2 = 0 To espacocor
        '        pontinhoscor += "."

        '    Next

        '    For w3 = 0 To espacoqtde
        '        pontinhosqtde += "."

        '    Next

        '    For w4 = 0 To espacovalor
        '        pontinhosvalor += "."

        '    Next

        '    ListBox2.Items.Add("")
        '    ListBox2.Items.Add("                                             " & ItemPedidosDataGridView1.Item(2, z).Value & pontinhosnome & ItemPedidosDataGridView1.Item(3, z).Value & pontinhoscor & ItemPedidosDataGridView1.Item(6, z).Value & pontinhosqtde & ItemPedidosDataGridView1.Item(7, z).Value & pontinhosvalor & ItemPedidosDataGridView1.Item(8, z).Value)



        'Next

    End Sub


    Private Sub rdb_vezesduplicata2_Click(sender As Object, e As EventArgs) Handles rdb_vezesduplicata2.Click

        'Dim vrduplicata1 As Double = (TextBox5.Text / 2)
        'txt_vrduplicata1.Text = vrduplicata1.ToString("F2")

        'date_duplicata2.Enabled = True
        'txt_vrduplicata2.Enabled = True

        'Dim vrduplicata2 As Double = (TextBox5.Text / 2)
        'txt_vrduplicata2.Text = vrduplicata2.ToString("F2")
        ''-----------------------------
        'date_duplicata3.Enabled = False
        'txt_vrduplicata3.Enabled = False
        'txt_vrduplicata3.Text = ""

        ''--------------------------------
        'date_duplicata4.Enabled = False
        'txt_vrduplicata4.Enabled = False
        'txt_vrduplicata4.Text = ""

        '' ------------------------------
        'date_duplicata5.Enabled = False
        'txt_vrduplicata5.Enabled = False
        'txt_vrduplicata5.Text = ""
        '' acertando as datas
        'date_duplicata1.Text = DateAdd("d", 30, DateTime.Now)
        'date_duplicata2.Text = DateAdd("d", 60, DateTime.Now)
        'date_duplicata3.Text = DateAdd("d", 90, DateTime.Now)
        'date_duplicata4.Text = DateAdd("d", 120, DateTime.Now)
        'date_duplicata5.Text = DateAdd("d", 150, DateTime.Now)

    End Sub

    Private Sub rdb_vezesduplicata3_Click(sender As Object, e As EventArgs) Handles rdb_vezesduplicata3.Click

        'Dim vrduplicata1 As Double = (TextBox5.Text / 3)
        'txt_vrduplicata1.Text = vrduplicata1.ToString("F2")

        'date_duplicata2.Enabled = True
        'txt_vrduplicata2.Enabled = True

        'Dim vrduplicata2 As Double = (TextBox5.Text / 3)
        'txt_vrduplicata2.Text = vrduplicata2.ToString("F2")

        ''----------------------------------
        'date_duplicata3.Enabled = True
        'txt_vrduplicata3.Enabled = True

        'Dim vrduplicata3 As Double = (TextBox5.Text / 3)
        'txt_vrduplicata3.Text = vrduplicata3.ToString("F2")

        ''----------------------------------
        'date_duplicata4.Enabled = False
        'txt_vrduplicata4.Enabled = False
        'txt_vrduplicata4.Text = ""

        '' -----------------------------------
        'date_duplicata5.Enabled = False
        'txt_vrduplicata5.Enabled = False
        'txt_vrduplicata5.Text = ""
        '' acertando as datas
        'date_duplicata1.Text = DateAdd("d", 30, DateTime.Now)
        'date_duplicata2.Text = DateAdd("d", 60, DateTime.Now)
        'date_duplicata3.Text = DateAdd("d", 90, DateTime.Now)
        'date_duplicata4.Text = DateAdd("d", 120, DateTime.Now)
        'date_duplicata5.Text = DateAdd("d", 150, DateTime.Now)

    End Sub

    Private Sub rdb_vezesduplicata4_Click(sender As Object, e As EventArgs) Handles rdb_vezesduplicata4.Click

        'Dim vrduplicata1 As Double = (TextBox5.Text / 4)
        'txt_vrduplicata1.Text = vrduplicata1.ToString("F2")


        'date_duplicata2.Enabled = True
        'txt_vrduplicata2.Enabled = True

        'Dim vrduplicata2 As Double = (TextBox5.Text / 4)
        'txt_vrduplicata2.Text = vrduplicata2.ToString("F2")

        ' '----------------------------------
        'date_duplicata3.Enabled = True
        'txt_vrduplicata3.Enabled = True

        'Dim vrduplicata3 As Double = (TextBox5.Text / 4)
        'txt_vrduplicata3.Text = vrduplicata3.ToString("F2")

        ''----------------------------------
        'date_duplicata4.Enabled = True
        'txt_vrduplicata4.Enabled = True

        'Dim vrduplicata4 As Double = (TextBox5.Text / 4)
        'txt_vrduplicata4.Text = vrduplicata4.ToString("F2")

        ' '----------------------------------
        'date_duplicata5.Enabled = False
        'txt_vrduplicata5.Enabled = False
        'txt_vrduplicata5.Text = ""
        '' acertando as datas
        'date_duplicata1.Text = DateAdd("d", 30, DateTime.Now)
        'date_duplicata2.Text = DateAdd("d", 60, DateTime.Now)
        'date_duplicata3.Text = DateAdd("d", 90, DateTime.Now)
        'date_duplicata4.Text = DateAdd("d", 120, DateTime.Now)
        'date_duplicata5.Text = DateAdd("d", 150, DateTime.Now)
    End Sub

    Private Sub rdb_vezesduplicata5_Click(sender As Object, e As EventArgs) Handles rdb_vezesduplicata5.Click
        'Dim vrduplicata1 As Double = (TextBox5.Text / 5)
        'txt_vrduplicata1.Text = vrduplicata1.ToString("F2")

        'date_duplicata2.Enabled = True
        'txt_vrduplicata2.Enabled = True

        'Dim vrduplicata2 As Double = (TextBox5.Text / 5)
        'txt_vrduplicata2.Text = vrduplicata2.ToString("F2")

        ''----------------------------------
        'date_duplicata3.Enabled = True
        'txt_vrduplicata3.Enabled = True

        'Dim vrduplicata3 As Double = (TextBox5.Text / 5)
        'txt_vrduplicata3.Text = vrduplicata3.ToString("F2")

        '  '----------------------------------
        'date_duplicata4.Enabled = True
        'txt_vrduplicata4.Enabled = True

        'Dim vrduplicata4 As Double = (TextBox5.Text / 5)
        'txt_vrduplicata4.Text = vrduplicata4.ToString("F2")

        ''----------------------------------
        'date_duplicata5.Enabled = True
        'txt_vrduplicata5.Enabled = True

        'Dim vrduplicata5 As Double = (TextBox5.Text / 5)
        'txt_vrduplicata5.Text = vrduplicata5.ToString("F2")

        ' ' acertando as datas
        'date_duplicata1.Text = DateAdd("d", 30, DateTime.Now)
        'date_duplicata2.Text = DateAdd("d", 60, DateTime.Now)
        'date_duplicata3.Text = DateAdd("d", 90, DateTime.Now)
        'date_duplicata4.Text = DateAdd("d", 120, DateTime.Now)
        'date_duplicata5.Text = DateAdd("d", 150, DateTime.Now)

    End Sub

    Private Sub rdb_vezesduplicata1_Click(sender As Object, e As EventArgs) Handles rdb_vezesduplicata1.Click

        'Dim vrduplicata1 As Double = TextBox5.Text
        'txt_vrduplicata1.Text = vrduplicata1.ToString("F2")
        ''----------------------------------
        'date_duplicata2.Enabled = False
        'txt_vrduplicata2.Enabled = False
        'txt_vrduplicata2.Text = ""
        ''----------------------------------
        'date_duplicata3.Enabled = False
        'txt_vrduplicata3.Enabled = False
        'txt_vrduplicata3.Text = ""
        ''----------------------------------
        'date_duplicata4.Enabled = False
        'txt_vrduplicata4.Enabled = False
        'txt_vrduplicata4.Text = ""
        ''----------------------------------
        'date_duplicata5.Enabled = False
        'txt_vrduplicata5.Enabled = False
        'txt_vrduplicata5.Text = ""
        '' acertando as datas
        'date_duplicata1.Text = DateAdd("d", 30, DateTime.Now)
        'date_duplicata2.Text = DateAdd("d", 60, DateTime.Now)
        'date_duplicata3.Text = DateAdd("d", 90, DateTime.Now)
        'date_duplicata4.Text = DateAdd("d", 120, DateTime.Now)
        'date_duplicata5.Text = DateAdd("d", 150, DateTime.Now)

    End Sub



    Private Sub ProdutosDataGridView_DoubleClick_2(sender As Object, e As EventArgs) Handles ProdutosDataGridView.DoubleClick

       
        If FlagProdutos = "1" Then
            ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox268.Text)
            tabpage_produtos.SelectedIndex = 0
            FlagProdutos = ""
            travarCamposprod()
        Else
            tabpage_produtos.SelectedIndex = 0
            travarCamposprod()
        End If

    End Sub

    Private Sub Cod_prodTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cod_prodTextBox.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            ' e.Handled = True
            verificaCodigoProdutos()
        End If

    End Sub


    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txt_procuracodigoProd.TextChanged

        ProdutosBindingSource.Filter = String.Format("codbarras_prod LIKE '{0}%'", txt_procuracodigoProd.Text)

    End Sub
    'rotina para capturar fotos de produto
    '  Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles btn_capturaFotos.Click

    'Dim MyFolderBrowser As New System.Windows.Forms.OpenFileDialog
    'MyFolderBrowser.InitialDirectory = "C:\Users\FERNANDO12\Desktop\Projeto Programa Marfinite Mogi\fotos Produtos"

    ''filtra para exibir somente arquivos de imagens

    'MyFolderBrowser.Filter = "All files (*.*)|*.*"

    'Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

    'If dlgResult = Windows.Forms.DialogResult.OK Then
    '    txt_caminhoTXT.Text = MyFolderBrowser.FileName
    '    PictureBox1.ImageLocation = MyFolderBrowser.FileName
    'End If

    ' End Sub


    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles btn_ValidarCNPJ.Click


        IsValidaCNPJ(msktxt_cnpjcliente.Text)

        If IsValidaCNPJ(msktxt_cnpjcliente.Text) = False Then
            MessageBox.Show("CNPJ INVÁLIDO")
        Else
            MessageBox.Show("CNPJ VÁLIDO")
        End If


    End Sub

    Public Shared Function IsValidaCNPJ(ByVal value As String) As Boolean
        Dim multiplier1() As Integer = New Integer() {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim multiplier2() As Integer = New Integer() {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim sum As Integer = 0
        Dim leftOver As Integer
        Dim digit As String
        value = value.Trim()
        value = value.Replace(".", "")
        value = value.Replace(",", "")
        value = value.Replace(" ", "")
        value = value.Replace("/", "")
        value = value.Replace("-", "")
        value = value.Replace("_", "")

        Dim tempCPF As String = value

        If Not value.Length = 14 Then
            Return False ' Maior/Menor que 14 dígitos
        End If

        tempCPF = tempCPF.Substring(0, 12)
        For i As Integer = 0 To 11
            sum = sum + Integer.Parse(tempCPF(i).ToString * multiplier1(i))
        Next
        leftOver = sum Mod 11
        If leftOver < 2 Then
            leftOver = 0
        Else
            leftOver = 11 - leftOver
        End If
        digit = leftOver.ToString
        tempCPF = tempCPF + digit
        sum = 0
        For i As Integer = 0 To 12
            sum = sum + Integer.Parse(tempCPF(i).ToString * multiplier2(i))
        Next
        leftOver = sum Mod 11
        If leftOver < 2 Then
            leftOver = 0
        Else
            leftOver = 11 - leftOver
        End If
        digit = digit + leftOver.ToString
        Return value.EndsWith(digit)
    End Function ' IsValidaCNPJ

    Private Sub ApagarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarToolStripMenuItem.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from transportadoras where CNPJ_trans = @CNPJ_trans"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@CNPJ_trans", SqlDbType.VarChar, 50).Value = msk_CNPJTrans.Text

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
                ProdutosBindingSource.MoveFirst()
                MessageBox.Show("Apagado com sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try
        Else
            'Process No
        End If

        Me.TransportadorasTableAdapter.Fill(Me.DataSetFinal.transportadoras)

    End Sub
    Private Sub PedidoNFEDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles PedidoNFEDataGridView.DoubleClick

        TabControlpedidos_nfe.SelectedIndex = 0
        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
        ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}%'", Id_pedidosTextBox.Text)
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView.Rows
            valor += Linha.Cells(7).Value
        Next

        Valortotal_pedTextBox.Text = valor
        variavelClique = Id_pedidosTextBox.Text

    End Sub

    Private Sub DeletarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletarPedidoToolStripMenuItem.Click

        ' Código de acesso
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        Dim date1 As New Date()
        date1 = Date.Now
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim datacodigo2 = date1.ToString("dd.MM.yyyy.hh", ci)
        datacodigo2 = datacodigo2.Replace(".", "")

        If codigoEntrada <> datacodigo2 Then
             MessageBox.Show("Código inválido")
            Exit Sub
        End If

        If Id_pedidosTextBox.Text = "" Then
            MessageBox.Show("selecionar um pedido")
            Exit Sub

        End If

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()

            '  APAGAR OS ÍTENS REFERENTES AOS PEDIDOS
            Dim yy As Integer
            Try

                For yy = 0 To ItemPedidosDataGridView.RowCount() - 1

                    command = connection.CreateCommand()
                    command.CommandText = "delete from ItemPedidos where nome_item = @nome and id_item = @id_cod"
                    command.CommandType = CommandType.Text
                    command.Parameters.Add("@nome", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(3, yy).Value
                    command.Parameters.Add("@id_cod", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(10, yy).Value
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Next

                Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

            Catch ex As Exception

                MessageBox.Show("Impossível apagar campos nulo")

            End Try


            '   APAGAR O PEDIDO ----------------------------------------
            command.CommandText = "delete from PedidoNFE where id_pedidos = @id_pedidos"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@id_pedidos", SqlDbType.VarChar, 50).Value = Id_pedidosTextBox.Text

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)
                PedidoNFEBindingSource.MoveFirst()
                MessageBox.Show("Apagado com sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        End If


    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles txt_pegaclientepedido.TextChanged

        ClienteBindingSource.Filter = String.Format("nome_cliente LIKE '{0}%'", txt_pegaclientepedido.Text)

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles txt_buscaClienteCNPJPedido.TextChanged

        ClienteBindingSource.Filter = String.Format("cnpj_cliente LIKE '{0}%'", txt_buscaClienteCNPJPedido.Text)

    End Sub

    Private Sub txt_buscaNomeTransPedido_TextChanged(sender As Object, e As EventArgs) Handles txt_buscaNomeTransPedido.TextChanged

        TransportadorasBindingSource1.Filter = String.Format("Razaosocial_trans LIKE '{0}%'", txt_buscaNomeTransPedido.Text)

    End Sub

    Private Sub txt_buscaCNPJtransPedido_TextChanged(sender As Object, e As EventArgs) Handles txt_buscaCNPJtransPedido.TextChanged

        TransportadorasBindingSource1.Filter = String.Format("CNPJ_trans LIKE '{0}%'", txt_buscaCNPJtransPedido.Text)

    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles txt_procuraPedidoNomeVendPed.TextChanged

        PedidoNFEBindingSource.Filter = String.Format("vendedor_ped LIKE '{0}%' and orcamento_pedido_ped LIKE '{1}'", txt_procuraPedidoNomeVendPed.Text, "PEDIDO")

    End Sub
    '
    Private Sub txt_buscaNomeClientePed_TextChanged(sender As Object, e As EventArgs) Handles txt_buscaNomeClientePed.TextChanged

        PedidoNFEBindingSource.Filter = String.Format("razaosocialcliente_ped LIKE '{0}%' and orcamento_pedido_ped LIKE '{1}'", txt_buscaNomeClientePed.Text, "PEDIDO")

    End Sub

    Private Sub txt_buscaCNPJclientePedNfe_TextChanged(sender As Object, e As EventArgs) Handles txt_buscaCodCLiclientePedNfe.TextChanged

        PedidoNFEBindingSource.Filter = String.Format("codcli_ped LIKE '{0}%' and orcamento_pedido_ped LIKE '{1}'", txt_buscaCodCLiclientePedNfe.Text, "PEDIDO")

    End Sub


    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged

        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}'", ComboBox1.Text, "RAIZ")

    End Sub

    Private Sub cbx_buscalinhaPedNFE_TextChanged(sender As Object, e As EventArgs) Handles cbx_buscalinhaPedNFE.TextChanged

        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'  and RaizSimNao_prod LIKE '{2}'", cbx_buscalinhaPedNFE.Text, ComboBox1.Text, "RAIZ")

    End Sub

    Private Sub Button1_Click_5(sender As Object, e As EventArgs) Handles Button1.Click
        ProdutosBindingSource.Filter = String.Empty
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles txt_buscanomeprodPedNFe.TextChanged
        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", txt_buscanomeprodPedNFe.Text)

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox17.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PedidoNFEBindingSource.Filter = String.Empty
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        ClienteBindingSource.Filter = String.Empty

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        TransportadorasBindingSource1.Filter = String.Empty

    End Sub




    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btn_enviarEMail.Click

        If EmailAddressCheck(Email_pedTextBox.Text) = False Then
            MessageBox.Show("Endereço de Email errado")
            Email_pedTextBox.Enabled = True
            Exit Sub
        End If

        Dim SOMA As Double

        '-------  ------------------------------
        Dim endereco As String
        Dim numerorua_cliente As String
        Dim bairro_cliente As String
        Dim cidade_cliente As String
        Dim estado_cliente As String
        Dim cep_cliente As String
        Dim cnpj_cliente As String
        Dim insestadual_cliente As String

        TabControlpedidos_nfe.TabPages.Remove(TabPageClientes_nfe)
        TabControlpedidos_nfe.TabPages.Remove(TabPageTransportadora_nfe)

        'rem lê os dados do arquivo de clientes
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select * from cliente where id_cliente = '" & Codcli_pedTextBox.Text & "'"

        connection.Open()

        Dim lrd As SqlDataReader = command.ExecuteReader()

        While lrd.Read


            If lrd("cnpj_cliente") Is DBNull.Value Then
            Else
                cnpj_cliente = lrd("cnpj_cliente")
            End If

            If lrd("endereco_cliente") Is DBNull.Value Then
            Else
                endereco = lrd("endereco_cliente")
            End If

            If lrd("numerorua_cliente") Is DBNull.Value Then
            Else
                numerorua_cliente = lrd("numerorua_cliente")
            End If

            If lrd("bairro_cliente") Is DBNull.Value Then
            Else
                bairro_cliente = lrd("bairro_cliente")
            End If

            If lrd("cidade_cliente") Is DBNull.Value Then
            Else
                cidade_cliente = lrd("cidade_cliente")
            End If

            If lrd("estado_cliente") Is DBNull.Value Then
            Else
                estado_cliente = lrd("estado_cliente")
            End If

            If lrd("cep_cliente") Is DBNull.Value Then
            Else
                cep_cliente = lrd("cep_cliente")
            End If
            If lrd("insestadual_cliente") Is DBNull.Value Then
            Else
                insestadual_cliente = lrd("insestadual_cliente")
            End If
        End While

        connection.Close()

        'rem passa dados para a planilha excell de pedidos   -------
        Dim xlApp1 As Excel.Application
        Dim xlWorkBook1 As Excel.Workbook
        Dim xlWorkSheet1 As Excel.Worksheet


        xlApp1 = New Excel.Application
        ' xlWorkBook1 = xlApp1.Workbooks.Open("\\FERNANDO\Projeto Programa Marfinite Mogi\Xls Orcamento pedidos\Pedidos.xlsx")
        xlWorkBook1 = xlApp1.Workbooks.Open("\\FERNANDO\Disco C\Projeto Programa Marfinite Mogi\xls ped Marf\Pedidos.xlsx")


        xlWorkSheet1 = CType(xlWorkBook1.Sheets(1), Excel.Worksheet)

        ' Dim x As Integer = ItemPedidosDataGridView.RowCount()

        xlWorkSheet1.Cells(4, 6) = Dataemissao_pedDateTimePicker.Text
        xlWorkSheet1.Cells(5, 6) = Vendedor_pedComboBox.Text
        xlWorkSheet1.Cells(14, 2) = Razaosocialcliente_pedTextBox.Text

        xlWorkSheet1.Cells(44, 2) = Obsvendedor_pedTextBox.Text
        xlWorkSheet1.Cells(45, 2) = Obsgerente_pedTextBox.Text
        xlWorkSheet1.Cells(46, 2) = cbx_FormadepagamentoPed.Text
        xlWorkSheet1.Cells(47, 2) = ComboBox16.Text

        '   ELE VERIFICA O CAMPO PARA VERSE NÃO É NULL ANTES DE MANDAR PARA A PLANILHA
        If endereco Is Nothing Then
        Else
            xlWorkSheet1.Cells(15, 2) = endereco
        End If

        If numerorua_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(16, 2) = numerorua_cliente
        End If
        If bairro_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(17, 2) = bairro_cliente
        End If

        If cidade_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(18, 2) = cidade_cliente
        End If

        If estado_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(19, 2) = estado_cliente
        End If

        If cep_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(20, 2) = cep_cliente
        End If

        If cnpj_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(21, 2) = cnpj_cliente
        End If

        If insestadual_cliente Is Nothing Then
        Else
            xlWorkSheet1.Cells(22, 2) = insestadual_cliente
        End If

        xlWorkSheet1.Cells(23, 2) = Nometransportadora_pedTextBox.Text
        xlWorkSheet1.Cells(24, 2) = Email_pedTextBox.Text
        xlWorkSheet1.Cells(4, 3) = Id_pedidosTextBox.Text
        xlWorkSheet1.Cells(25, 2) = Endercoentrega_pedTextBox.Text

        Dim xx As Integer
        For xx = 0 To ItemPedidosDataGridView.RowCount() - 1
            xlWorkSheet1.Cells(27 + xx, 2) = ItemPedidosDataGridView.Item(3, xx).Value
            xlWorkSheet1.Cells(27 + xx, 3) = ItemPedidosDataGridView.Item(4, xx).Value
            xlWorkSheet1.Cells(27 + xx, 4) = ItemPedidosDataGridView.Item(5, xx).Value
            xlWorkSheet1.Cells(27 + xx, 5) = ItemPedidosDataGridView.Item(6, xx).Value
            xlWorkSheet1.Cells(27 + xx, 6) = ItemPedidosDataGridView.Item(6, xx).Value * ItemPedidosDataGridView.Item(5, xx).Value
            SOMA += ItemPedidosDataGridView.Item(6, xx).Value * ItemPedidosDataGridView.Item(5, xx).Value
        Next

        Directory.CreateDirectory("\\FERNANDO\Disco C\Projeto Programa Marfinite Mogi\xls ped Marf\pedidos enviados\" & Format(Date.Now, "yyyy-MM-dd") & "\" & Vendedor_pedComboBox.Text & "\")
        xlWorkSheet1.Cells(41, 6) = SOMA


        Try
            xlWorkBook1.SaveAs(Filename:="\\FERNANDO\Disco C\Projeto Programa Marfinite Mogi\xls ped Marf\pedidos enviados\" & Format(Date.Now, "yyyy-MM-dd") & "\" & Vendedor_pedComboBox.Text & "\" & Email_pedTextBox.Text & " " & Vendedor_pedComboBox.Text & " " & Id_pedidosTextBox.Text & ".xlsx")

            Dim caminho As String = xlWorkBook1.Path & "\" & Email_pedTextBox.Text & " " & Vendedor_pedComboBox.Text & " " & Id_pedidosTextBox.Text & ".xlsx"
            txt_nome_arquivo.Text = caminho
            xlWorkBook1.Close()

            EnviaEmailBasePedido(txt_nome_arquivo.Text)

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            xlWorkBook1.Close()
        End Try

        'REM inabilitar o campo de enderço de email
        Email_pedTextBox.Enabled = False
        HabilitarEnvioToolStripMenuItemPedido.Enabled = True
        btn_enviarEMail.Enabled = False


    End Sub

    Public Sub EnviaEmailBasePedido(p1 As String)
        Dim senha As String


        If ComboBox15.Text = "vendas@marfinitemogi.com.br" Then
            senha = "marf1505"
        Else
            If ComboBox15.Text = "claudio@marfinitemogi.com.br" Then
                senha = "marf0515"
            Else
                senha = "mogi1993"
            End If
        End If



        Dim objNovoEmail As New MailMessage
        Dim objSmtp As New SmtpClient
        Dim SHostname As String

        objNovoEmail.From = New MailAddress(ComboBox15.Text)
        objNovoEmail.To.Add(New MailAddress(Email_pedTextBox.Text))
        objNovoEmail.Priority = MailPriority.High

        objNovoEmail.Subject = "Pedido marfinite mogi - Número : " + Id_pedidosTextBox.Text + " " + Razaosocialcliente_pedTextBox.Text

        'Formato de e-mail em Html?
        objNovoEmail.IsBodyHtml = True
        objNovoEmail.Attachments.Add(New Net.Mail.Attachment(p1))
        objNovoEmail.Body = "Segue em anexo o Pedido"

        'Configuração de tipagem da linguagem, para não aparecer caracteres estranhos na mensagem
        objNovoEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        objNovoEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

        'Configuração do IP do servidor SMTP
        objSmtp.Host = "smtp.marfinitemogi.com.br"
        objSmtp.Port = "587"

        'Caso queira definir um tempo do timeout 
        objSmtp.Timeout = 65000
        objSmtp.Credentials = New System.Net.NetworkCredential(ComboBox15.Text, senha)

        Try
            objSmtp.Send(objNovoEmail)
        Catch ex As Exception
            Throw ex
        Finally
            objNovoEmail.Dispose()
        End Try
        objNovoEmail.Dispose()

    End Sub

    Public Sub EnviaEmailBaseOrc(p1 As String)

     

    End Sub

    Private Sub PedidoNFEDataGridView2_DoubleClick(sender As Object, e As EventArgs)

        Dim v_SelectRow As Integer
        v_SelectRow = Me.PedidoNFEDataGridView.CurrentRow.Index
        TabControlpedidos_nfe.SelectedIndex = 0
        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
        ItemPedidosBindingSource.Filter = String.Format("codpedido_item LIKE '{0}%'", Id_pedidosTextBox.Text)

    End Sub
    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function

    Private Sub GerarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerarToolStripMenuItem.Click

        ' pega o email e verifica se já foi cadastrado
        Dim Email = InputBox("Digite o Email", "Email")
        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT *  from orcamento2  where EmailEnvio_orc = " & "'" & Email & "'"

        con.Open()
        'REM verifica se cdigo prod existe banco do produto na nota para não gravar duas vezes
        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try

            If lrd.Read() = True Then
                MessageBox.Show("O Email do produto " & Email & " já foi cadastrado!!!!")
                con.Close()
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()


        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tbg_relatorios)

        ' retira palheta consulta orçamento
        EmailErroCliente.TabPages.Remove(tbpg_orcConsulta)

        limparformOrcamento()
        TextBox7.Enabled = True
        TextBox174.Enabled = True
        TextBox180.Enabled = True
        GerarToolStripMenuItem.Enabled = False
        ApagarToolStripMenuItem2.Enabled = True
        DateTimePicker1.Text = Date.Now
        TextBox7.Text = Email
        TextBox174.Focus()




    End Sub


    Private Sub limparformOrcamento()

        TextBox6.Clear()
        TextBox7.Clear()
        TextBox174.Clear()
        TextBox180.Clear()

        DateTimePicker1.Text = Date.Now


    End Sub


    Private Sub ApagarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ApagarToolStripMenuItem2.Click


        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Insert(0, tbpg_produtos)
        TabControl1.TabPages.Insert(1, tbpg_clientes)
        TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        TabControl1.TabPages.Insert(5, tab_nfe)
        TabControl1.TabPages.Insert(6, pedidos)
        TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
        TabControl1.TabPages.Insert(9, tbpg_bkup)
        'TabControl1.TabPages.Insert(10, tbpg_orcamento)
        TabControl1.TabPages.Insert(11, tbg_relatorios)


        'valida campos necessários
        TextBox7.Enabled = False
        TextBox174.Enabled = False
        TextBox180.Enabled = False
        ApagarToolStripMenuItem2.Enabled = False
        GerarToolStripMenuItem.Enabled = True

        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        EmailErroCliente.TabPages.Insert(1, tbpg_orcConsulta)

        ' grava as informações
        ' Dim contador As Integer = 0
        Dim connection5 As SqlConnection
        connection5 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command5 As SqlCommand
        command5 = connection5.CreateCommand()
        command5.CommandText = "insert into orcamento2 (EmailEnvio_orc,Vendedor_orc,DataEmissao_orc,RazaoSocialCliente_orc) values (@EmailEnvio_orc,@Vendedor_orc,@DataEmissao_orc,@RazaoSocialCliente_orc)"
        command5.CommandType = CommandType.Text

        command5.Parameters.Add("@EmailEnvio_orc", SqlDbType.VarChar, 50).Value = TextBox7.Text
        command5.Parameters.Add("@Vendedor_orc", SqlDbType.VarChar, 50).Value = TextBox174.Text
        command5.Parameters.Add("@DataEmissao_orc", SqlDbType.Date).Value = Date.Now
        command5.Parameters.Add("@RazaoSocialCliente_orc", SqlDbType.VarChar, 50).Value = TextBox180.Text

        Try
            connection5.Open()
            command5.ExecuteNonQuery()
            connection5.Close()


        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Orcamento2TableAdapter.Fill(DataSetFinal.orcamento2)


    End Sub

    Private Sub OrcamentoDataGridView_DoubleClick(sender As Object, e As EventArgs)
        EmailErroCliente.SelectedIndex = 0
    End Sub

    Private Sub DataGridViewConsultaOrcamento_DoubleClick(sender As Object, e As EventArgs)
        EmailErroCliente.SelectedIndex = 0
    End Sub

    Private Sub HabilitarEnvioToolStripMenuItemPedido_Click(sender As Object, e As EventArgs) Handles HabilitarEnvioToolStripMenuItemPedido.Click
        HabilitarEnvioToolStripMenuItemPedido.Enabled = False
        btn_enviarEMail.Enabled = True

    End Sub

    Private Sub IMprimir_pedidos_Click_1(sender As Object, e As EventArgs) Handles IMprimir_pedidos.Click
        PrintPreviewDialog2.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage1(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'rem lê os dados do cliente
        Dim endereco As String
        Dim numerorua_cliente As String
        Dim bairro_cliente As String
        Dim cidade_cliente As String
        Dim estado_cliente As String
        Dim cep_cliente As String
        Dim cnpj_cliente As String
        Dim insestadual_cliente As String
        Dim telefoneCliente As String
        Dim fj_cliente As String
        Dim cpf_cliente As String
        Dim rg_cliente As String

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        command = connection.CreateCommand()
        command.CommandText = "select * from cliente where id_cliente = '" & Codcli_pedTextBox.Text & "'"

        connection.Open()

        Dim lrd As SqlDataReader = command.ExecuteReader()

        While lrd.Read
            If lrd("fj_cliente") Is DBNull.Value Then
            Else
                fj_cliente = lrd("fj_cliente")
            End If
            If lrd("cnpj_cliente") Is DBNull.Value Then
            Else
                cnpj_cliente = lrd("cnpj_cliente")
            End If

            If lrd("endereco_cliente") Is DBNull.Value Then
            Else
                endereco = lrd("endereco_cliente")
            End If

            If lrd("numerorua_cliente") Is DBNull.Value Then
            Else
                numerorua_cliente = lrd("numerorua_cliente")
            End If

            If lrd("bairro_cliente") Is DBNull.Value Then
            Else
                bairro_cliente = lrd("bairro_cliente")
            End If

            If lrd("cidade_cliente") Is DBNull.Value Then
            Else
                cidade_cliente = lrd("cidade_cliente")
            End If

            If lrd("estado_cliente") Is DBNull.Value Then
            Else
                estado_cliente = lrd("estado_cliente")
            End If

            If lrd("cep_cliente") Is DBNull.Value Then
            Else
                cep_cliente = lrd("cep_cliente")
            End If
            If lrd("insestadual_cliente") Is DBNull.Value Then
            Else
                insestadual_cliente = lrd("insestadual_cliente")
            End If
            If lrd("telefone_cliente") Is DBNull.Value Then
            Else
                telefoneCliente = lrd("telefone_cliente")
            End If
            If lrd("rg_cliente") Is DBNull.Value Then
            Else
                rg_cliente = lrd("rg_cliente")
            End If
            If lrd("cpf_cliente") Is DBNull.Value Then
            Else
                cpf_cliente = lrd("cpf_cliente")
            End If
           
        End While

        connection.Close()
         'REM LÊ OS DADOS DA TRANSPORTADORA --------------------------------------------------
        Dim enderecoTrans As String
        Dim numeroruaTrans As String
        Dim bairroTrans As String
        Dim cidadeTrans As String
        Dim estadoTrans As String
        Dim cepTrans As String
        Dim cnpjTrans As String
        Dim insestadualTrans As String
        Dim emailTrans As String
        Dim command1 As New SqlCommand
        Dim telefoneTrans As String
      
        command1 = connection.CreateCommand()
        command1.CommandText = "select * from transportadoras where CNPJ_trans = '" & Codtransportadora_pedTextBox.Text & "'"

        connection.Open()

        Dim lrd1 As SqlDataReader = command1.ExecuteReader()


        Try

            While lrd1.Read

                If lrd1("endereco_trans") Is DBNull.Value Then
                Else
                    enderecoTrans = lrd1("endereco_trans")
                End If
                If lrd1("numerorua_trans") Is DBNull.Value Then
                Else
                    numeroruaTrans = lrd1("numerorua_trans")
                End If
                If lrd1("bairro_trans") Is DBNull.Value Then
                Else
                    bairroTrans = lrd1("bairro_trans")
                End If
                If lrd1("cidade_trans") Is DBNull.Value Then
                Else
                    cidadeTrans = lrd1("cidade_trans")
                End If
                If lrd1("estado_trans") Is DBNull.Value Then
                Else
                    estadoTrans = lrd1("estado_trans")
                End If
                If lrd1("CEP_trans") Is DBNull.Value Then
                Else
                    cepTrans = lrd1("CEP_trans")
                End If
                If lrd1("CNPJ_trans") Is DBNull.Value Then
                Else
                    cnpjTrans = lrd1("CNPJ_trans")
                End If
                If lrd1("INSEST_trans") Is DBNull.Value Then
                Else
                    insestadualTrans = lrd1("INSEST_trans")
                End If
                If lrd1("EMAIL_trans") Is DBNull.Value Then
                Else
                    emailTrans = lrd1("EMAIL_trans")
                End If

                If lrd1("telefone_trans") Is DBNull.Value Then
                Else
                    telefoneTrans = lrd1("telefone_trans")
                End If
               
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
        connection.Close()

        'rem cabeçalho 
        e.Graphics.DrawString("MARFINITE MOGI - PEDIDOS", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 160, 5)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 20)
        e.Graphics.DrawString("Av.Henrique Peres, 1880 - Mogi Das Cruzes SP", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 40)
        e.Graphics.DrawString("Tel.(11) 4722 6115 - (11) 2988 9475 ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 60)
        e.Graphics.DrawString("E mail : vendas@marfinitemogi.com.br", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 80)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 100)
        e.Graphics.DrawString("Pedido Número :", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 120)
        e.Graphics.DrawString(Id_pedidosTextBox.Text, New Font("arial", 15, FontStyle.Regular), Brushes.Black, 200, 120)
        e.Graphics.DrawString("Data :", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 300, 120)
        e.Graphics.DrawString(Dataemissao_pedDateTimePicker.Text, New Font("arial", 15, FontStyle.Regular), Brushes.Black, 400, 120)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 130)

        'rem DADOS DO CLIENTE
        e.Graphics.DrawString("DADOS DO CLIENTE", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 160, 150)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 170)
        'rem razão social
        e.Graphics.DrawString("RAZÃO SOCIAL/nome", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 190)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 190)
        e.Graphics.DrawString(Razaosocialcliente_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 190)
        'rem endereço e número
        e.Graphics.DrawString("Endereço", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 210)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 210)
        e.Graphics.DrawString(endereco, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 210)
        e.Graphics.DrawString(numerorua_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 210)
        'rem bairro
        e.Graphics.DrawString("Bairro", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 230)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 230)
        e.Graphics.DrawString(bairro_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 230)
        'rem cep
        e.Graphics.DrawString("cep", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 250)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 250)
        e.Graphics.DrawString(cep_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 250)
        'rem cidade estado
        e.Graphics.DrawString("cidade", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 270)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 270)
        e.Graphics.DrawString(cidade_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 270)
        e.Graphics.DrawString("-", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 400, 270)
        e.Graphics.DrawString(estado_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 270)
        'rem cnpj
             e.Graphics.DrawString("CNPJ/cpf", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 290)
            e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 290)
        If fj_cliente = "Jurídica" Then
            e.Graphics.DrawString(cnpj_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 290)
        Else
            e.Graphics.DrawString(cpf_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 290)
        End If

        'rem ins
        e.Graphics.DrawString("INS.EST/RG", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 310)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 310)
        If fj_cliente = "Jurídica" Then
            e.Graphics.DrawString(insestadual_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 310)
        Else
            e.Graphics.DrawString(rg_cliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 310)
        End If

        'rem email
        e.Graphics.DrawString("Email", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 330)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 330)
        e.Graphics.DrawString(Email_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 330)
        'rem telefone cliente
        e.Graphics.DrawString("Telefone", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 330)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 600, 330)
        e.Graphics.DrawString(telefoneCliente, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 620, 330)
        'rem observação 1 
        e.Graphics.DrawString("Contato/vendedor", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 20, 350)
        e.Graphics.DrawString(":", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 200, 350)
        e.Graphics.DrawString(Obsvendedor_pedTextBox.Text, New Font("arial", 9, FontStyle.Regular), Brushes.Black, 220, 350)
        'rem observação 2 
        e.Graphics.DrawString("Obs/nf 2", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 362)
        e.Graphics.DrawString(":", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 200, 362)
        e.Graphics.DrawString(Obsgerente_pedTextBox.Text, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 220, 362)
        'rem disponibilidade de estoque 
        e.Graphics.DrawString("entrega", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 20, 370)
        e.Graphics.DrawString(":", New Font("arial", 9, FontStyle.Regular), Brushes.Black, 200, 370)
        e.Graphics.DrawString(ComboBox16.Text, New Font("arial", 9, FontStyle.Regular), Brushes.Black, 220, 370)
        e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 380)

        'rem====================================================================================================
        'rem DADOS Da transportadora
        e.Graphics.DrawString("DADOS DA TRANSPORTADORA", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 160, 390)
        'rem razão social
        e.Graphics.DrawString("RAZÃO SOCIAL/nome", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 410)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 410)
        e.Graphics.DrawString(Nometransportadora_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 410)
        'rem endereço e número
        e.Graphics.DrawString("Endereço", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 430)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 430)
        e.Graphics.DrawString(enderecoTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 430)
        e.Graphics.DrawString(numeroruaTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 430)
        'rem bairro
        e.Graphics.DrawString("Bairro", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 450)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 450)
        e.Graphics.DrawString(bairroTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 450)
        'rem cep
        e.Graphics.DrawString("cep", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 470)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 470)
        e.Graphics.DrawString(cepTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 470)
        'rem cidade estado
        e.Graphics.DrawString("cidade", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 490)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 490)
        e.Graphics.DrawString(cidadeTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 490)
        e.Graphics.DrawString("-", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 400, 490)
        e.Graphics.DrawString(estadoTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 490)
        'rem cnpj
        e.Graphics.DrawString("CNPJ/cpf", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 510)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 510)
        e.Graphics.DrawString(cnpjTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 510)
        'rem ins
        e.Graphics.DrawString("INS.EST/RG", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 530)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 530)
        e.Graphics.DrawString(insestadualTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 530)
        'rem email
        e.Graphics.DrawString("Email", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 550)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 550)
        e.Graphics.DrawString(emailTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 550)
        'rem telefone
        e.Graphics.DrawString("telefone", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 500, 550)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 600, 550)
        e.Graphics.DrawString(telefoneTrans, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 620, 550)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 570)
        'rem DADOS DO PEDIDO ========================================================
        ' rem vendedor
        e.Graphics.DrawString("Vendedor", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 590)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 590)
        e.Graphics.DrawString(Vendedor_pedComboBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 590)
        'rem forma de pagamento
        e.Graphics.DrawString("Forma de pagamento", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 610)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 610)
        e.Graphics.DrawString(cbx_FormadepagamentoPed.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 610)
        'rem observação 1
        e.Graphics.DrawString("Observação", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 630)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 630)
        e.Graphics.DrawString(Obsvendedor_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 630)
        'rem observação 2
        e.Graphics.DrawString("Observação", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 650)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 650)
        e.Graphics.DrawString(Obsgerente_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 650)
        'rem endereço de entrega
        e.Graphics.DrawString("Endereço de Entrega ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 670)
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 670)
        e.Graphics.DrawString(Endercoentrega_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 670)
        'rem formatação dos produtos
        e.Graphics.DrawString("Fornecedor", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 690)

        e.Graphics.DrawString("Nome do Produto", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 150, 690)
        'e.Graphics.DrawString("Cor", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 400, 690)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 450, 690)
        e.Graphics.DrawString("Preço  ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, 690)
        e.Graphics.DrawString("Total  ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 670, 690)
        e.Graphics.DrawString("-", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 750, 690)

        '   Dim x As Integer = ItemPedidosDataGridView.RowCount()
        Dim lucroGeral As Double = 0
        Dim VrLucro As Double = 0

        Dim x As Integer
        For x = 0 To ItemPedidosDataGridView.RowCount() - 1
            ' limitando o número de letras do nome do produto
            Dim t As Integer = ItemPedidosDataGridView.Item(1, x).Value.Length()
            If t > 15 Then
                e.Graphics.DrawString(ItemPedidosDataGridView.Item(1, x).Value.substring(0, 15), New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 710 + (x * 15))
            Else
                e.Graphics.DrawString(ItemPedidosDataGridView.Item(1, x).Value.substring(0, t), New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 710 + (x * 15))
            End If
            '  calculando o lucro dos ítens
            VrLucro = (1 - (((ItemPedidosDataGridView.Item(14, x).Value)) / (ItemPedidosDataGridView.Item(7, x).Value))) * 100
            Dim VrLucro2 As Double = VrLucro.ToString("F2")
            '  LUCRO GERAL
            lucroGeral += ((ItemPedidosDataGridView.Item(5, x).Value) * (ItemPedidosDataGridView.Item(14, x).Value))

            e.Graphics.DrawString(ItemPedidosDataGridView.Item(3, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 150, 710 + (x * 15))
            e.Graphics.DrawString(ItemPedidosDataGridView.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 710 + (x * 15))
            e.Graphics.DrawString(ItemPedidosDataGridView.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 710 + (x * 15))
            e.Graphics.DrawString(ItemPedidosDataGridView.Item(7, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 710 + (x * 15))
            '   e.Graphics.DrawString(VrLucro2, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 740, 710 + (x * 15))

        Next

        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 710 + ((x + 1) * 15))
        e.Graphics.DrawString("Total Geral", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 710 + ((x + 2) * 15))
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 710 + ((x + 2) * 15))
        e.Graphics.DrawString(Valortotal_pedTextBox.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 710 + ((x + 2) * 15))

        e.Graphics.DrawString("Peso em Kg", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 710 + ((x + 3) * 15))
        e.Graphics.DrawString(":", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 710 + ((x + 3) * 15))

        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView.Rows
            valor += Linha.Cells(11).Value
        Next

        e.Graphics.DrawString(valor, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 220, 710 + ((x + 3) * 15))
        ' IMPRIMIR A % DO lucro PEDIDO TODO
        Dim lucroGeral2 As Double = (1 - (lucroGeral / Valortotal_pedTextBox.Text)) * 100
        Dim lucroGeral3 As String = lucroGeral2.ToString("F2")
        '  e.Graphics.DrawString(lucroGeral3, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 710 + ((x + 5) * 15))


    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        PedidoNFEBindingSource.Filter = String.Empty
    End Sub

    Private Sub PedidoNFEDataGridView1_Click(sender As Object, e As EventArgs) Handles PedidoNFEDataGridView1.Click

        
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        PedidoNFEBindingSource.Filter = String.Format("vendedor_ped LIKE '{0}%'", TextBox8.Text)

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        PedidoNFEBindingSource.Filter = String.Format("razaosocialcliente_ped LIKE '{0}%'", TextBox9.Text)

    End Sub

    Private Sub TextBox19_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        ' trocando o binding source(fonte de dados do datagridview) pelo original
        PedidoNFEDataGridView1.DataSource = PedidoNFEBindingSource
        'Para comparar inteiros, converter a coluna em string
        PedidoNFEBindingSource.Filter = String.Format("Convert(id_pedidos, 'System.String') like '{0}%'", TextBox19.Text)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        'Dim reply As DialogResult = MessageBox.Show("Confirmar a geração da NOTA FISCAL?", "Atenção!!!", _
        ' MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        'If reply = DialogResult.Yes Then

        '    Dim connection As SqlConnection
        '    connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        '    Dim VrAserLancadoNfe As String
        '    Dim variavel2 As Boolean = False

        '    Try
        '        'coloca o ponteiro onde ele está clicado
        '        Dim v_SelectRow2 As Integer
        '        v_SelectRow2 = Me.PedidoNFEDataGridView.CurrentRow.Index

        '        Dim command5 As SqlCommand
        '        command5 = connection.CreateCommand()
        '        command5.CommandText = "select * from ItemPedidos where codpedido_item = '" & PedidoNFEDataGridView1.Item(0, v_SelectRow2).Value & "'"

        '        connection.Open()

        '        Dim lrd2 As SqlDataReader = command5.ExecuteReader()
        '        While lrd2.Read

        '            'verifica se tem algum campo de quantidade diferente de zero
        '            If lrd2("qtdeNfe_item") Is DBNull.Value Then
        '                VrAserLancadoNfe = "0"
        '            Else
        '                VrAserLancadoNfe = lrd2("qtdeNfe_item")
        '            End If
        '            'india se achou algum vr diferente de zero
        '            If VrAserLancadoNfe = 0 Then
        '            Else
        '                variavel2 = True
        '            End If


        '        End While

        '        connection.Close()
        '    Catch ex As Exception
        '        MessageBox.Show("Não foi selecionado nenhum Ítem")
        '        Exit Sub
        '    End Try

        '    ' verifica se achou algum vr diferente de zero nas quantidades lançadas
        '    If variavel2 = False Then
        '        MessageBox.Show("Não foi escolhido nenhum Ítem")
        '        Exit Sub
        '    End If



        '    'coloca o ponteiro onde ele está clicado
        '    Dim v_SelectRow As Integer
        '    v_SelectRow = Me.PedidoNFEDataGridView1.CurrentRow.Index

        '    'variáveis do arquivo de clientes
        '    Dim endereco As String
        '    Dim numerorua_cliente As String
        '    Dim bairro_cliente As String
        '    Dim cidade_cliente As String
        '    Dim estado_cliente As String
        '    Dim cep_cliente As String
        '    Dim cnpj_cliente As String
        '    Dim insestadual_cliente As String
        '    Dim telefone_cliente As String
        '    Dim email_cliente As String
        '    Dim codIBGE_cliente As String
        '    Dim fj_cliente As String
        '    Dim cpf_cliente As String


        '    Dim command As SqlCommand
        '    command = connection.CreateCommand()
        '    command.CommandText = "select * from cliente where id_cliente = '" & PedidoNFEDataGridView1.Item(6, v_SelectRow).Value & "'"
        '    Try



        '        connection.Open()

        '        Dim lrd As SqlDataReader = command.ExecuteReader()
        '        While lrd.Read


        '            If lrd("cnpj_cliente") Is DBNull.Value Then
        '                cnpj_cliente = "0"
        '            Else
        '                cnpj_cliente = lrd("cnpj_cliente")
        '            End If

        '            If lrd("endereco_cliente") Is DBNull.Value Then
        '                endereco = "0"
        '            Else
        '                endereco = lrd("endereco_cliente")
        '            End If

        '            If lrd("numerorua_cliente") Is DBNull.Value Then
        '                numerorua_cliente = "0"
        '            Else
        '                numerorua_cliente = lrd("numerorua_cliente")
        '            End If

        '            If lrd("bairro_cliente") Is DBNull.Value Then
        '                bairro_cliente = "0"
        '            Else
        '                bairro_cliente = lrd("bairro_cliente")
        '            End If

        '            If lrd("cidade_cliente") Is DBNull.Value Then
        '                cidade_cliente = "0"
        '            Else
        '                cidade_cliente = lrd("cidade_cliente")
        '            End If

        '            If lrd("estado_cliente") Is DBNull.Value Then
        '                estado_cliente = "0"
        '            Else
        '                estado_cliente = lrd("estado_cliente")
        '            End If

        '            If lrd("cep_cliente") Is DBNull.Value Then
        '                cep_cliente = "0"
        '            Else
        '                cep_cliente = lrd("cep_cliente")
        '            End If
        '            If lrd("insestadual_cliente") Is DBNull.Value Then
        '                insestadual_cliente = "0"
        '            Else
        '                insestadual_cliente = lrd("insestadual_cliente")
        '            End If

        '            If lrd("telefone_cliente") Is DBNull.Value Then
        '                telefone_cliente = "0"
        '            Else
        '                telefone_cliente = lrd("telefone_cliente")
        '            End If
        '            If lrd("email_cliente") Is DBNull.Value Then
        '                email_cliente = "0"
        '            Else
        '                email_cliente = lrd("email_cliente")
        '            End If
        '            If lrd("codIBGE_cliente") Is DBNull.Value Then
        '                codIBGE_cliente = "0"
        '            Else
        '                codIBGE_cliente = lrd("codIBGE_cliente")
        '            End If

        '            If lrd("fj_cliente") Is DBNull.Value Then
        '                fj_cliente = "0"
        '            Else
        '                fj_cliente = lrd("fj_cliente")
        '            End If

        '            If lrd("cpf_cliente") Is DBNull.Value Then
        '                cpf_cliente = "0"
        '            Else
        '                cpf_cliente = lrd("cpf_cliente")
        '            End If
        '        End While

        '        connection.Close()
        '    Catch ex As Exception

        '        MessageBox.Show(ex.ToString)

        '    End Try

        '    'estabelecer um horário que vai funcionar como índice
        '    Dim HorarioNotaEmitida3 As String
        '    Dim date3 As New Date()
        '    date3 = Date.Now
        '    Dim ci3 As CultureInfo = CultureInfo.InvariantCulture
        '    HorarioNotaEmitida3 = date3.ToString("dd.yyyy.hh.mm.ss.FFFFF", ci3)
        '    Dim HorarioNotaEmitida4 As String = Convert.ToString(HorarioNotaEmitida3)

        '    Try
        '        'rem salvar os dados e criar o corpo da NOTA
        '        command = connection.CreateCommand()
        '        command.CommandText = "INSERT INTO NFE_Emitidas (Codigo_nfeemitida,CodigoCliente_nfeemitida,RazaoCliente_nfeemitida,ENderecoCLiente_nfeemitida,NUmeroRuacliente_nfeemitida,BairroCliente_nfeemitida,municipioCliente_nfeemitida,telefoneCLiente_nfeemitida,emailCliente_nfeemitida,estadoCliente_nfeemitida,IBGEcliente_nfeemitida,CEPcliente_nfeemitida,pessoaFouJcliente_nfeemitida,CPFcliente_nfeemitida,CNPJcliente_nfeemitida,IEcliente_nfeemitida,CodigoPedido_nfeemitida,horaEmitida_nfeemitida,NomeTrans_nfeemitida,CodTrans_nfeemitida,Peso_nfeemitida,data_nfeemitidas,vendedor_nfeemitidas) values (@Codigo_nfeemitida,@CodigoCliente_nfeemitida,@RazaoCliente_nfeemitida,@ENderecoCLiente_nfeemitida,@NUmeroRuacliente_nfeemitida,@BairroCliente_nfeemitida,@municipioCliente_nfeemitida,@telefoneCLiente_nfeemitida,@emailCliente_nfeemitida,@estadoCliente_nfeemitida,@IBGEcliente_nfeemitida,@CEPcliente_nfeemitida,@pessoaFouJcliente_nfeemitida,@CPFcliente_nfeemitida,@CNPJcliente_nfeemitida,@IEcliente_nfeemitida,@CodigoPedido_nfeemitid,@horaEmitida_nfeemitida,@NomeTrans_nfeemitida,@CodTrans_nfeemitida,@Peso_nfeemitida,@data_nfeemitidas,@vendedor_nfeemitidas)"
        '        command.CommandType = CommandType.Text

        '        ' rem   SALVAR NA CONFIRMAÇÃO DOS DADOS
        '        command.Parameters.Add("@Codigo_nfeemitida", SqlDbType.VarChar, 50).Value = ""
        '        command.Parameters.Add("@horaEmitida_nfeemitida", SqlDbType.VarChar, 50).Value = HorarioNotaEmitida4

        '        '  ----------------------------------------
        '        command.Parameters.Add("@CodigoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(6, v_SelectRow).Value
        '        command.Parameters.Add("@RazaoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(7, v_SelectRow).Value
        '        command.Parameters.Add("@ENderecoCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = endereco
        '        command.Parameters.Add("@NUmeroRuacliente_nfeemitida", SqlDbType.VarChar, 50).Value = numerorua_cliente
        '        command.Parameters.Add("@BairroCliente_nfeemitida", SqlDbType.VarChar, 50).Value = bairro_cliente
        '        command.Parameters.Add("@municipioCliente_nfeemitida", SqlDbType.VarChar, 50).Value = cidade_cliente
        '        command.Parameters.Add("@telefoneCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = telefone_cliente
        '        command.Parameters.Add("@emailCliente_nfeemitida", SqlDbType.VarChar, 50).Value = email_cliente
        '        command.Parameters.Add("@estadoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = estado_cliente
        '        command.Parameters.Add("@IBGEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = codIBGE_cliente
        '        command.Parameters.Add("@CEPcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cep_cliente
        '        command.Parameters.Add("@pessoaFouJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = fj_cliente
        '        command.Parameters.Add("@CPFcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cpf_cliente
        '        command.Parameters.Add("@CNPJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cnpj_cliente
        '        command.Parameters.Add("@IEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = insestadual_cliente
        '        command.Parameters.Add("@CodigoPedido_nfeemitid", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(0, v_SelectRow).Value
        '        command.Parameters.Add("@CodTrans_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(9, v_SelectRow).Value
        '        command.Parameters.Add("@NomeTrans_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(10, v_SelectRow).Value
        '        command.Parameters.Add("@Peso_nfeemitida", SqlDbType.VarChar, 50).Value = "0"
        '        command.Parameters.Add("@data_nfeemitidas", SqlDbType.Date).Value = Date.Now
        '        command.Parameters.Add("@vendedor_nfeemitidas", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView1.Item(1, v_SelectRow).Value


        '        connection.Open()
        '        command.ExecuteNonQuery()
        '        connection.Close()
        '    Catch ex As Exception

        '        MessageBox.Show(ex.ToString)

        '    End Try

        '    ' pegar o último número gravado com datagrid
        '    Me.NFE_EmitidasTableAdapter.Fill(Me.DataSetFinal.NFE_Emitidas)

        '    Dim UltimoID As String
        '    Dim command15 As SqlCommand
        '    command15 = connection.CreateCommand()
        '    command15.CommandText = "select id_nfeemitidas  from NFE_Emitidas  where id_nfeemitidas = (select max(id_nfeemitidas) from NFE_Emitidas) "
        '    Try
        '        connection.Open()

        '        Dim lrd15 As SqlDataReader = command15.ExecuteReader()
        '        While lrd15.Read

        '            If lrd15("id_nfeemitidas") Is DBNull.Value Then
        '                UltimoID = "0"
        '            Else
        '                UltimoID = lrd15("id_nfeemitidas")
        '            End If

        '        End While

        '        connection.Close()
        '    Catch ex As Exception

        '        MessageBox.Show(ex.ToString)

        '    End Try
        '     txt_nNfe.Text = UltimoID



        '    ' rem buscar os ítens do PEDIDO e transformá-los em ítens da nota
        '    Dim command1 As SqlCommand
        '    command1 = connection.CreateCommand()
        '    Dim yy As Integer
        '    Try

        '        For yy = 0 To ItemPedidosDataGridView2.RowCount() - 1
        '            'If ItemPedidosDataGridView2.Item(10, yy).Value <> "Entregue" Then
        '            command1 = connection.CreateCommand()
        '            command1.CommandText = "INSERT INTO ItemNfeEmitida (NumeroNFe_ItemNfeEmitida,codProd_ItemNfeEmitida,NomeProd_ItemNfeemitida,QtdeProd_ItemNfeEmitida,VrUnitarioProd_ItemNfeEmitida,VrTlProd_itemNfeEmitida,HoraNota_itemNfeEmitida,NumeroPed_itemNfeEmitida,NCM_itemNfeEmitida,tabela_itemNfeEmitida,Peso_itemNfeEmitida,QtdeENtregue_itemNfeEmitida,IDcod_itemNfeEmitida) values (@NumeroNFe_ItemNfeEmitida,@codProd_ItemNfeEmitida,@NomeProd_ItemNfeemitida,@QtdeProd_ItemNfeEmitida,@VrUnitarioProd_ItemNfeEmitida,@VrTlProd_itemNfeEmitida,@HoraNota_itemNfeEmitida,@NumeroPed_itemNfeEmitida,@NCM_itemNfeEmitida,@tabela_itemNfeEmitida,@Peso_itemNfeEmitida,@QtdeENtregue_itemNfeEmitida,@IDcod_itemNfeEmitida)"
        '            command1.CommandType = CommandType.Text
        '            command1.Parameters.Add("@NumeroNFe_ItemNfeEmitida", SqlDbType.VarChar, 50).Value = txt_nNfe.Text
        '            command1.Parameters.Add("@codProd_ItemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(14, yy).Value
        '            command1.Parameters.Add("@NomeProd_ItemNfeemitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(1, yy).Value
        '            command1.Parameters.Add("@QtdeProd_ItemNfeEmitida", SqlDbType.Float).Value = ItemPedidosDataGridView2.Item(6, yy).Value
        '            command1.Parameters.Add("@VrUnitarioProd_ItemNfeEmitida", SqlDbType.Float).Value = ItemPedidosDataGridView2.Item(8, yy).Value
        '            Dim arredonda As String = (ItemPedidosDataGridView2.Item(8, yy).Value).ToString() * (ItemPedidosDataGridView2.Item(6, yy).Value)
        '            command1.Parameters.Add("@VrTlProd_itemNfeEmitida", SqlDbType.Float).Value = arredonda 'ItemPedidosDataGridView2
        '            command1.Parameters.Add("@HoraNota_itemNfeEmitida", SqlDbType.VarChar, 50).Value = HorarioNotaEmitida4
        '            command1.Parameters.Add("@NumeroPed_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(11, yy).Value
        '            command1.Parameters.Add("@NCM_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(19, yy).Value
        '            command1.Parameters.Add("@tabela_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(17, yy).Value
        '            command1.Parameters.Add("@Peso_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(18, yy).Value
        '            command1.Parameters.Add("@QtdeENtregue_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView2.Item(7, yy).Value
        '            command1.Parameters.Add("@IDcod_itemNfeEmitida", SqlDbType.Int).Value = ItemPedidosDataGridView2.Item(20, yy).Value

        '            If ItemPedidosDataGridView2.Item(6, yy).Value <> 0 Then
        '                connection.Open()
        '                command1.ExecuteNonQuery()
        '                connection.Close()
        '            End If
        '        Next

        '        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

        '    Catch ex As Exception

        '        MessageBox.Show("Algo aconteceu de errado")
        '        MessageBox.Show(ex.ToString)

        '    End Try
        '    Me.ItemNfeEmitidaTableAdapter.Fill(Me.DataSetFinal.ItemNfeEmitida)
        '    ' rem zerar os campos do arquivo item pedidos
        '    Dim command2 As SqlCommand
        '    Try
        '        For yy = 0 To ItemPedidosDataGridView2.RowCount() - 1
        '            command2 = connection.CreateCommand()
        '            command2.CommandText = "update ItemPedidos set qtdeNfe_item= @qtdeNfe_item  where id_item = '" & ItemPedidosDataGridView2.Item(20, yy).Value & "'"
        '            command2.CommandType = CommandType.Text
        '            command2.Parameters.Add("@qtdeNfe_item", SqlDbType.Float).Value = 0

        '            connection.Open()
        '            command2.ExecuteNonQuery()
        '            connection.Close()


        '        Next

        '    Catch ex As Exception

        '        MessageBox.Show("Algo ocorreu errado")
        '        MessageBox.Show(ex.ToString())

        '    End Try

        '    Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)


        '    ' passar parâmetros para a tela de notas
        '    D_Nome.Text = PedidoNFEDataGridView1.Item(7, v_SelectRow).Value
        '    D_Endereco.Text = endereco
        '    Numerodarua_pedTextBox.Text = numerorua_cliente
        '    D_Email.Text = email_cliente
        '    D_Cep.Text = cep_cliente
        '    D_Bairro.Text = bairro_cliente
        '    D_Municipio.Text = cidade_cliente
        '    D_Estado.Text = estado_cliente
        '    D_Telefone.Text = telefone_cliente
        '    D_Cnpj.Text = cnpj_cliente
        '    txt_cpfNFE.Text = cpf_cliente
        '    msk_ieNFE.Text = insestadual_cliente
        '    Txt_CodIBGE.Text = codIBGE_cliente
        '    Txt_fisicajuridicaNFE.Text = fj_cliente
        '    txt_codCli_pedNfe.Text = PedidoNFEDataGridView1.Item(6, v_SelectRow).Value
        '    txt_coPEdNFe.Text = PedidoNFEDataGridView1.Item(0, v_SelectRow).Value
        '    ' HoraEmitida_nfeemitidaTextBox.Text = HorarioNotaEmitida4
        '    CodTrans_nfeemitidaTextBox.Text = PedidoNFEDataGridView1.Item(9, v_SelectRow).Value
        '    NomeTrans_nfeemitidaTextBox.Text = PedidoNFEDataGridView1.Item(10, v_SelectRow).Value
        '    Vendedor_nfeemitidasTextBox.Text = PedidoNFEDataGridView1.Item(1, v_SelectRow).Value
        '    cbx_CFOP.Text = "5102"
        '    TextBox30.Text = "Vendas"
        '    TextBox31.Text = "saída"
        '    ComboBox12.Text = "emitente"

        '    TabControl_NFE.SelectedIndex = 0
        '    ' filtra pelo horário em que foi cadastrado
        '    ItemNfeEmitidaBindingSource.Filter = String.Format("HoraNota_itemNfeEmitida LIKE '{0}%'", HorarioNotaEmitida4)
        '    ' soma  o valor d nota
        '    Dim valor2 As Decimal = 0
        '    For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '        valor2 += Linha.Cells(5).Value
        '    Next
        '    TextBox5.Text = valor2
        '    txt_vrduplicata1.Text = valor2

        '    'soma do peso
        '    Dim valor3 As Decimal = 0
        '    For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '        valor3 += Linha.Cells(11).Value
        '    Next
        '    Peso_nfeemitidaTextBox.Text = valor3

        '    'soma do volumes
        '    Dim valor4 As Decimal = 0
        '    For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '        valor4 += Linha.Cells(3).Value
        '    Next
        '    cbx_VolNfeEmitidas.Text = valor4
        '    ' -----------------------------------------------------------------------------
        '    ' trabalhando com as duplicatas
        '    rdb_vezesduplicata1.Enabled = True
        '    txt_vrduplicata1.Text = valor2
        '    txt_vrduplicata1.Enabled = True
        '    ' liberando campos

        '    txt_obsNFE.Enabled = True
        '    TabControl_NFE.TabPages.Remove(TabPage_PedidosNFE)

        '    ' habilitar botões
        '    Button4.Enabled = False
        '    Button10.Enabled = True
        '    Button17.Enabled = False
        '    Button20.Enabled = False
        '    Button21.Enabled = True
        '    Button38.Enabled = True

        '    btn_confimraNfeEmitida.Enabled = True

        '    ' habilitar outros
        '    cbx_CFOP.Enabled = True
        '    D_Nome.Enabled = True
        '    Numerodarua_pedTextBox.Enabled = True
        '    D_Email.Enabled = True
        '    txt_cpfNFE.Enabled = True
        '    D_Endereco.Enabled = True
        '    Txt_fisicajuridicaNFE.Enabled = True
        '    D_Cep.Enabled = True
        '    msk_ieNFE.Enabled = True
        '    D_Bairro.Enabled = True
        '    D_Telefone.Enabled = True
        '    D_Cnpj.Enabled = True
        '    D_Estado.Enabled = True
        '    D_Municipio.Enabled = True
        '    txt_obsNFE.Enabled = True
        '    cbx_VolNfeEmitidas.Enabled = True
        '    rdb_vezesduplicata1.Checked = True
        '    txt_obsNFE.Enabled = True
        '    txt_obs2.Enabled = True
        '    ComboBox12.Enabled = True


        '    ' habilitar duplicatas
        '    rdb_vezesduplicata1.Enabled = True
        '    rdb_vezesduplicata2.Enabled = True
        '    rdb_vezesduplicata3.Enabled = True
        '    rdb_vezesduplicata4.Enabled = True
        '    rdb_vezesduplicata5.Enabled = True
        '    date_duplicata1.Enabled = True
        '    txt_vrduplicata1.Enabled = True
        '    date_duplicata2.Enabled = True
        '    txt_vrduplicata2.Enabled = True
        '    date_duplicata3.Enabled = True
        '    txt_vrduplicata3.Enabled = True
        '    date_duplicata4.Enabled = True
        '    txt_vrduplicata4.Enabled = True
        '    date_duplicata5.Enabled = True
        '    txt_vrduplicata5.Enabled = True
        '    Button20.Enabled = False
        '    '---------------------------------------------------------------------------
        '    '--------------------------------------------------------------------------
        '    ' ATUALIZA O ARQUIVO DE NOTAS, PARA RESOLVERCAMPOS EM BRANCO NO BD
        '    'gravar dados no arquivo nfe Emitidas

        '    Try
        '        'rem salvar os dados e criar o corpo da NOTA
        '        command = connection.CreateCommand()
        '        'command.CommandText = "update  NFE_Emitidas set Codigo_nfeemitida=@Codigo_nfeemitida,CodigoCliente_nfeemitida=@CodigoCliente_nfeemitida,RazaoCliente_nfeemitida=@RazaoCliente_nfeemitida,ENderecoCLiente_nfeemitida=@ENderecoCLiente_nfeemitida,NUmeroRuacliente_nfeemitida=@NUmeroRuacliente_nfeemitida,BairroCliente_nfeemitida=@BairroCliente_nfeemitida,municipioCliente_nfeemitida=@municipioCliente_nfeemitida,telefoneCLiente_nfeemitida=@telefoneCLiente_nfeemitida,emailCliente_nfeemitida=@emailCliente_nfeemitida,estadoCliente_nfeemitida=@estadoCliente_nfeemitida,IBGEcliente_nfeemitida=@IBGEcliente_nfeemitida,CEPcliente_nfeemitida=@CEPcliente_nfeemitida,pessoaFouJcliente_nfeemitida=@pessoaFouJcliente_nfeemitida,CPFcliente_nfeemitida=@CPFcliente_nfeemitida,CNPJcliente_nfeemitida=@CNPJcliente_nfeemitida,IEcliente_nfeemitida=@IEcliente_nfeemitida,CodigoPedido_nfeemitida=@CodigoPedido_nfeemitida,VrFatura_nfeemitida=@VrFatura_nfeemitida,dataduplicata1_nfeemitida=@dataduplicata1_nfeemitida,Vrduplicata1_nfeemitida=@Vrduplicata1_nfeemitida,Vrduplicata2_nfeemitida=@Vrduplicata2_nfeemitida,dataduplicata2_nfeemitida=@dataduplicata2_nfeemitida,dataduplicata3_nfeemitida=@dataduplicata3_nfeemitida,Vrduplicata3_nfeemitida=@Vrduplicata3_nfeemitida,dataduplicata4_nfeemitida=@dataduplicata4_nfeemitida,Vrduplicata4_nfeemitida=@Vrduplicata4_nfeemitida,dataduplicata5_nfeemitida=@dataduplicata5_nfeemitida,Vrduplicata5_nfeemitida=@Vrduplicata5_nfeemitida,CFOP_nfeemitida=@CFOP_nfeemitida,VOlumes_nfeemitida=@VOlumes_nfeemitida,Peso_nfeemitida=@Peso_nfeemitida,emissorNota_nfeemitidas=@emissorNota_nfeemitidas,obsNota_nfeemitida=@obsNota_nfeemitida,obxNCM_nfeemitida=@obxNCM_nfeemitida,ent_saida_nfeemitidas=@ent_saida_nfeemitidas,descOperacao_nfeemitida=@descOperacao_nfeemitida,frete_nfeemitida=@frete_nfeemitida,CodTrans_nfeemitida=@CodTrans_nfeemitida,NomeTrans_nfeemitida=@NomeTrans_nfeemitida where horaEmitida_nfeemitida = '" & HoraEmitida_nfeemitidaTextBox.Text & "'"
        '        command.CommandType = CommandType.Text
        '        command.Parameters.Add("@Codigo_nfeemitida", SqlDbType.VarChar, 50).Value = txt_nNfe.Text
        '        command.Parameters.Add("@CodigoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = txt_codCli_pedNfe.Text
        '        command.Parameters.Add("@RazaoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Nome.Text
        '        command.Parameters.Add("@ENderecoCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Endereco.Text
        '        command.Parameters.Add("@NUmeroRuacliente_nfeemitida", SqlDbType.VarChar, 50).Value = Numerodarua_pedTextBox.Text
        '        command.Parameters.Add("@BairroCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Bairro.Text
        '        command.Parameters.Add("@municipioCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Municipio.Text
        '        command.Parameters.Add("@telefoneCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Telefone.Text
        '        command.Parameters.Add("@emailCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Email.Text
        '        command.Parameters.Add("@estadoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Estado.Text
        '        command.Parameters.Add("@IBGEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = Txt_CodIBGE.Text
        '        command.Parameters.Add("@CEPcliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Cep.Text
        '        command.Parameters.Add("@pessoaFouJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = Txt_fisicajuridicaNFE.Text
        '        command.Parameters.Add("@CPFcliente_nfeemitida", SqlDbType.VarChar, 50).Value = txt_cpfNFE.Text
        '        command.Parameters.Add("@CNPJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Cnpj.Text
        '        command.Parameters.Add("@IEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = msk_ieNFE.Text
        '        command.Parameters.Add("@CodigoPedido_nfeemitida", SqlDbType.VarChar, 50).Value = txt_coPEdNFe.Text
        '        command.Parameters.Add("@CFOP_nfeemitida", SqlDbType.VarChar, 50).Value = cbx_CFOP.Text
        '        command.Parameters.Add("@VOlumes_nfeemitida", SqlDbType.VarChar, 50).Value = cbx_VolNfeEmitidas.Text
        '        command.Parameters.Add("@Peso_nfeemitida", SqlDbType.Float).Value = Peso_nfeemitidaTextBox.Text
        '        'command.Parameters.Add("@emissorNota_nfeemitidas", SqlDbType.VarChar, 50).Value = TextBox16.Text
        '        command.Parameters.Add("@obsNota_nfeemitida", SqlDbType.VarChar, 50).Value = txt_obsNFE.Text
        '        command.Parameters.Add("@obxNCM_nfeemitida", SqlDbType.VarChar, 50).Value = txt_obs2.Text
        '        command.Parameters.Add("@ent_saida_nfeemitidas", SqlDbType.VarChar, 50).Value = TextBox31.Text
        '        command.Parameters.Add("@descOperacao_nfeemitida", SqlDbType.VarChar, 50).Value = TextBox30.Text
        '        command.Parameters.Add("@frete_nfeemitida", SqlDbType.VarChar, 50).Value = ComboBox12.Text
        '        command.Parameters.Add("@CodTrans_nfeemitida", SqlDbType.VarChar, 50).Value = CodTrans_nfeemitidaTextBox.Text
        '        command.Parameters.Add("@NomeTrans_nfeemitida", SqlDbType.VarChar, 50).Value = NomeTrans_nfeemitidaTextBox.Text

        '        ' aqui grava os dados referentes a ao vr da fatura 
        '        command.Parameters.Add("@VrFatura_nfeemitida", SqlDbType.Float).Value = TextBox5.Text
        '        command.Parameters.Add("@dataduplicata1_nfeemitida", SqlDbType.Date).Value = date_duplicata1.Text
        '        command.Parameters.Add("@Vrduplicata1_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata1.Text


        '        If txt_vrduplicata2.Text = "" Then
        '            command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '            command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = 0

        '        Else
        '            command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = date_duplicata2.Text
        '            command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata2.Text
        '        End If

        '        If txt_vrduplicata3.Text = "" Then
        '            command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '            command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = 0

        '        Else
        '            command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = date_duplicata3.Text
        '            command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata3.Text
        '        End If

        '        If txt_vrduplicata4.Text = "" Then
        '            command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '            command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = 0
        '        Else
        '            command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = date_duplicata4.Text
        '            command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata4.Text
        '        End If
        '        If txt_vrduplicata5.Text = "" Then
        '            command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '            command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = 0

        '        Else
        '            command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = date_duplicata5.Text
        '            command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata5.Text
        '        End If

        '        connection.Open()
        '        command.ExecuteNonQuery()
        '        connection.Close()

        '    Catch ex As Exception

        '        MessageBox.Show(ex.ToString)

        '    End Try

        '    '-------------------------------------------------------------------------------
        '    '-----------------------------------------------------------------------------

        'End If

    End Sub


    Private Sub ItemPedidosDataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles ItemPedidosDataGridView2.DoubleClick

        
    End Sub

    Private Sub NFE_EmitidasDataGridView_Click(sender As Object, e As EventArgs) Handles NFE_EmitidasDataGridView.Click

        Dim v_SelectRow As Integer
        v_SelectRow = Me.NFE_EmitidasDataGridView.CurrentRow.Index
        If (NFE_EmitidasDataGridView.Item(0, v_SelectRow).Value) IsNot DBNull.Value Then
            ItemNfeEmitidaBindingSource.Filter = String.Format("HoraNota_itemNfeEmitida LIKE '{0}%'", (NFE_EmitidasDataGridView.Item(30, v_SelectRow).Value))

            'TextBox20.Text = PedidoNFEDataGridView1.Item(1, v_SelectRow).Value
            'TextBox21.Text = PedidoNFEDataGridView1.Item(11, v_SelectRow).Value
            'Dim valor As Decimal = 0
            ''For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView2.Rows
            '    valor += Linha.Cells(9).Value
            'Next

            'TextBox22.Text = valor
        End If
    End Sub


    Private Sub btn_confimraNfeEmitida_Click(sender As Object, e As EventArgs) Handles btn_confimraNfeEmitida.Click

        'If cbx_CFOP.Text = "" Or cbx_VolNfeEmitidas.Text = "" Or TextBox30.Text = "" Then
        '    MessageBox.Show("preencher o campo do CFOP e o Volume e frete")
        '    Exit Sub
        'End If

        ''gravar dados no arquivo nfe Emitidas
        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim valor3 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '    valor3 += Linha.Cells(11).Value
        'Next
        'Peso_nfeemitidaTextBox.Text = valor3


        'Try
        '    'rem salvar os dados e criar o corpo da NOTA
        '    command = connection.CreateCommand()
        '    'command.CommandText = "update  NFE_Emitidas set Codigo_nfeemitida=@Codigo_nfeemitida,CodigoCliente_nfeemitida=@CodigoCliente_nfeemitida,RazaoCliente_nfeemitida=@RazaoCliente_nfeemitida,ENderecoCLiente_nfeemitida=@ENderecoCLiente_nfeemitida,NUmeroRuacliente_nfeemitida=@NUmeroRuacliente_nfeemitida,BairroCliente_nfeemitida=@BairroCliente_nfeemitida,municipioCliente_nfeemitida=@municipioCliente_nfeemitida,telefoneCLiente_nfeemitida=@telefoneCLiente_nfeemitida,emailCliente_nfeemitida=@emailCliente_nfeemitida,estadoCliente_nfeemitida=@estadoCliente_nfeemitida,IBGEcliente_nfeemitida=@IBGEcliente_nfeemitida,CEPcliente_nfeemitida=@CEPcliente_nfeemitida,pessoaFouJcliente_nfeemitida=@pessoaFouJcliente_nfeemitida,CPFcliente_nfeemitida=@CPFcliente_nfeemitida,CNPJcliente_nfeemitida=@CNPJcliente_nfeemitida,IEcliente_nfeemitida=@IEcliente_nfeemitida,CodigoPedido_nfeemitida=@CodigoPedido_nfeemitida,VrFatura_nfeemitida=@VrFatura_nfeemitida,dataduplicata1_nfeemitida=@dataduplicata1_nfeemitida,Vrduplicata1_nfeemitida=@Vrduplicata1_nfeemitida,Vrduplicata2_nfeemitida=@Vrduplicata2_nfeemitida,dataduplicata2_nfeemitida=@dataduplicata2_nfeemitida,dataduplicata3_nfeemitida=@dataduplicata3_nfeemitida,Vrduplicata3_nfeemitida=@Vrduplicata3_nfeemitida,dataduplicata4_nfeemitida=@dataduplicata4_nfeemitida,Vrduplicata4_nfeemitida=@Vrduplicata4_nfeemitida,dataduplicata5_nfeemitida=@dataduplicata5_nfeemitida,Vrduplicata5_nfeemitida=@Vrduplicata5_nfeemitida,CFOP_nfeemitida=@CFOP_nfeemitida,VOlumes_nfeemitida=@VOlumes_nfeemitida,Peso_nfeemitida=@Peso_nfeemitida,emissorNota_nfeemitidas=@emissorNota_nfeemitidas,obsNota_nfeemitida=@obsNota_nfeemitida,obxNCM_nfeemitida=@obxNCM_nfeemitida,ent_saida_nfeemitidas=@ent_saida_nfeemitidas,descOperacao_nfeemitida=@descOperacao_nfeemitida,frete_nfeemitida=@frete_nfeemitida,CodTrans_nfeemitida=@CodTrans_nfeemitida,NomeTrans_nfeemitida=@NomeTrans_nfeemitida where horaEmitida_nfeemitida = '" & HoraEmitida_nfeemitidaTextBox.Text & "'"
        '    command.CommandType = CommandType.Text
        '    command.Parameters.Add("@Codigo_nfeemitida", SqlDbType.VarChar, 50).Value = txt_nNfe.Text
        '    command.Parameters.Add("@CodigoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = txt_codCli_pedNfe.Text
        '    command.Parameters.Add("@RazaoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Nome.Text
        '    command.Parameters.Add("@ENderecoCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Endereco.Text
        '    command.Parameters.Add("@NUmeroRuacliente_nfeemitida", SqlDbType.VarChar, 50).Value = Numerodarua_pedTextBox.Text
        '    command.Parameters.Add("@BairroCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Bairro.Text
        '    command.Parameters.Add("@municipioCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Municipio.Text
        '    command.Parameters.Add("@telefoneCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Telefone.Text
        '    command.Parameters.Add("@emailCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Email.Text
        '    command.Parameters.Add("@estadoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Estado.Text
        '    command.Parameters.Add("@IBGEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = Txt_CodIBGE.Text
        '    command.Parameters.Add("@CEPcliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Cep.Text
        '    command.Parameters.Add("@pessoaFouJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = Txt_fisicajuridicaNFE.Text
        '    command.Parameters.Add("@CPFcliente_nfeemitida", SqlDbType.VarChar, 50).Value = txt_cpfNFE.Text
        '    command.Parameters.Add("@CNPJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = D_Cnpj.Text
        '    command.Parameters.Add("@IEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = msk_ieNFE.Text
        '    command.Parameters.Add("@CodigoPedido_nfeemitida", SqlDbType.VarChar, 50).Value = txt_coPEdNFe.Text
        '    command.Parameters.Add("@CFOP_nfeemitida", SqlDbType.VarChar, 50).Value = cbx_CFOP.Text
        '    command.Parameters.Add("@VOlumes_nfeemitida", SqlDbType.VarChar, 50).Value = cbx_VolNfeEmitidas.Text
        '    command.Parameters.Add("@Peso_nfeemitida", SqlDbType.Float).Value = Peso_nfeemitidaTextBox.Text
        '    'command.Parameters.Add("@emissorNota_nfeemitidas", SqlDbType.VarChar, 50).Value = TextBox16.Text
        '    command.Parameters.Add("@obsNota_nfeemitida", SqlDbType.VarChar, 50).Value = txt_obsNFE.Text
        '    command.Parameters.Add("@obxNCM_nfeemitida", SqlDbType.VarChar, 50).Value = txt_obs2.Text
        '    command.Parameters.Add("@ent_saida_nfeemitidas", SqlDbType.VarChar, 50).Value = TextBox31.Text
        '    command.Parameters.Add("@descOperacao_nfeemitida", SqlDbType.VarChar, 50).Value = TextBox30.Text
        '    command.Parameters.Add("@frete_nfeemitida", SqlDbType.VarChar, 50).Value = ComboBox12.Text
        '    command.Parameters.Add("@CodTrans_nfeemitida", SqlDbType.VarChar, 50).Value = CodTrans_nfeemitidaTextBox.Text
        '    command.Parameters.Add("@NomeTrans_nfeemitida", SqlDbType.VarChar, 50).Value = NomeTrans_nfeemitidaTextBox.Text

        '    ' aqui grava os dados referentes a ao vr da fatura 
        '    command.Parameters.Add("@VrFatura_nfeemitida", SqlDbType.Float).Value = TextBox5.Text
        '    command.Parameters.Add("@dataduplicata1_nfeemitida", SqlDbType.Date).Value = date_duplicata1.Text
        '    command.Parameters.Add("@Vrduplicata1_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata1.Text


        '    If txt_vrduplicata2.Text = "" Then
        '        command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '        command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = 0

        '    Else
        '        command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = date_duplicata2.Text
        '        command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata2.Text
        '    End If

        '    If txt_vrduplicata3.Text = "" Then
        '        command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '        command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = 0

        '    Else
        '        command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = date_duplicata3.Text
        '        command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata3.Text
        '    End If

        '    If txt_vrduplicata4.Text = "" Then
        '        command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '        command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = 0
        '    Else
        '        command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = date_duplicata4.Text
        '        command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata4.Text
        '    End If
        '    If txt_vrduplicata5.Text = "" Then
        '        command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '        command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = 0

        '    Else
        '        command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = date_duplicata5.Text
        '        command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata5.Text
        '    End If

        '    connection.Open()
        '    command.ExecuteNonQuery()
        '    connection.Close()

        'Catch ex As Exception

        '    MessageBox.Show(ex.ToString)

        'End Try


        '' habilitar botões
        'Button17.Enabled = True

        'Button21.Enabled = False
        'Button10.Enabled = False
        'btn_confimraNfeEmitida.Enabled = False
        '' habilitar outros
        'cbx_CFOP.Enabled = False
        'D_Nome.Enabled = False
        'Numerodarua_pedTextBox.Enabled = False
        'D_Email.Enabled = False
        'txt_cpfNFE.Enabled = False
        'D_Endereco.Enabled = False
        'Txt_fisicajuridicaNFE.Enabled = False
        'D_Cep.Enabled = False
        'msk_ieNFE.Enabled = False
        'D_Bairro.Enabled = False
        'D_Telefone.Enabled = False
        'D_Cnpj.Enabled = False
        'D_Estado.Enabled = False
        'D_Municipio.Enabled = False
        'txt_obsNFE.Enabled = False
        'ComboBox12.Enabled = False
        'txt_obs2.Enabled = False
        'Button38.Enabled = False
        '' Data_nfeemitidasDateTimePicker.Enabled = False


        '' habilitar duplicatas
        'rdb_vezesduplicata1.Enabled = False
        'rdb_vezesduplicata2.Enabled = False
        'rdb_vezesduplicata3.Enabled = False
        'rdb_vezesduplicata4.Enabled = False
        'rdb_vezesduplicata5.Enabled = False
        'date_duplicata1.Enabled = False
        'txt_vrduplicata1.Enabled = False
        'date_duplicata2.Enabled = False
        'txt_vrduplicata2.Enabled = False
        'date_duplicata3.Enabled = False
        'txt_vrduplicata3.Enabled = False
        'date_duplicata4.Enabled = False
        'txt_vrduplicata4.Enabled = False
        'date_duplicata5.Enabled = False
        'txt_vrduplicata5.Enabled = False
        'cbx_VolNfeEmitidas.Enabled = False
        'txt_obsNFE.Enabled = False
        'txt_obs2.Enabled = False

        '' rem acertar o valor das duplicatas
        'txt_vrduplicata1.Text = txt_vrduplicata1.Text.Trim()
        'txt_vrduplicata1.Text = txt_vrduplicata1.Text.Replace(".", ",")
        'Dim VrDup1 As Double = txt_vrduplicata1.Text
        'Dim VrDup11 As String = VrDup1.ToString("F2")
        ''VrDup11 = VrDup11.Trim()
        ''VrDup11 = VrDup11.Replace(",", ".")
        'txt_vrduplicata1.Text = VrDup11
        '' valor duplicata 2
        'txt_vrduplicata2.Text = txt_vrduplicata2.Text.Trim()
        'txt_vrduplicata2.Text = txt_vrduplicata2.Text.Replace(".", ",")
        'If txt_vrduplicata2.Text <> "" Then
        '    Dim VrDup2 As Double = txt_vrduplicata2.Text
        '    Dim VrDup22 As String = VrDup2.ToString("F2")
        '    'VrDup22 = VrDup22.Trim()
        '    'VrDup22 = VrDup22.Replace(",", ".")
        '    txt_vrduplicata2.Text = VrDup22
        'End If
        '' valor duplicata 3
        'txt_vrduplicata3.Text = txt_vrduplicata3.Text.Trim()
        'txt_vrduplicata3.Text = txt_vrduplicata3.Text.Replace(".", ",")
        'If txt_vrduplicata3.Text <> "" Then
        '    Dim VrDup3 As Double = txt_vrduplicata3.Text
        '    Dim VrDup33 As String = VrDup3.ToString("F2")
        '    'VrDup33 = VrDup33.Trim()
        '    'VrDup33 = VrDup33.Replace(",", ".")
        '    txt_vrduplicata3.Text = VrDup33
        'End If
        '' valor duplicata 4
        'txt_vrduplicata4.Text = txt_vrduplicata4.Text.Trim()
        'txt_vrduplicata4.Text = txt_vrduplicata4.Text.Replace(".", ",")
        'If txt_vrduplicata4.Text <> "" Then
        '    Dim VrDup4 As Double = txt_vrduplicata4.Text
        '    Dim VrDup44 As String = VrDup4.ToString("F2")
        '    'VrDup44 = VrDup44.Trim()
        '    'VrDup44 = VrDup44.Replace(",", ".")
        '    txt_vrduplicata4.Text = VrDup44
        'End If
        '' valor duplicata 5
        'txt_vrduplicata5.Text = txt_vrduplicata5.Text.Trim()
        'txt_vrduplicata5.Text = txt_vrduplicata5.Text.Replace(".", ",")
        'If txt_vrduplicata5.Text <> "" Then
        '    Dim VrDup5 As Double = txt_vrduplicata5.Text
        '    Dim VrDup55 As String = VrDup5.ToString("F2")
        '    'VrDup55 = VrDup55.Trim()
        '    'VrDup55 = VrDup55.Replace(",", ".") 
        '    txt_vrduplicata5.Text = VrDup55
        'End If


        '' habilitar gerar ou imprimir
        ''If TextBox16.Text = "FERNANDO FRASCARI EPP" Then
        ''    Button4.Enabled = True
        ''    Button20.Enabled = False
        ''Else
        ''    Button20.Enabled = True
        ''    Button4.Enabled = False
        ''End If

        'cbx_VolNfeEmitidas.Enabled = False

        'Me.NFE_EmitidasTableAdapter.Fill(Me.DataSetFinal.NFE_Emitidas)
        'btn_buscarPedidoNFE.Enabled = True
        ''coloca A VISIBILIDADE DA PAGE DESEJADA
        'TabControl1.TabPages.Insert(0, tbpg_produtos)
        'TabControl1.TabPages.Insert(1, tbpg_clientes)
        'TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        'TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        'TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        'TabControl1.TabPages.Insert(5, tab_nfe)
        'TabControl1.TabPages.Insert(6, pedidos)
        ''TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        'TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
        'TabControl1.TabPages.Insert(9, tbpg_bkup)
        'TabControl1.TabPages.Insert(10, tbpg_orcamento)
        'TabControl1.TabPages.Insert(11, tbg_relatorios)
        '' colocar as tbpg
        ''TabControl_NFE.TabPages.Insert(0, TabPage_NFE)
        'TabControl_NFE.TabPages.Remove(tbpg_transNfe)
        'TabControl_NFE.TabPages.Insert(1, TbPg_consultaNFe)

    End Sub

    Private Sub TabControl_NFE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl_NFE.SelectedIndexChanged
        If TabControl_NFE.SelectedIndex = 1 Then
            PedidoNFEBindingSource.Filter = String.Format("razaosocialcliente_ped LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")
            ItemPedidosBindingSource.Filter = String.Format("nome_item LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")

             ' pegando os dados das datas
            Dim ano As Integer = Today.Year
            Dim mes As Integer = Today.Month

            Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
            DateTimePicker19.Text = Date.Now
            DateTimePicker18.Text = primeiroDia.ToString

        End If

    End Sub

    Private Sub Button10_Click_2(sender As Object, e As EventArgs) Handles Button10.Click

        ' verifica se o campo de cidade está preenchido, ele faz a busca do codIbge por ele
        If Txt_CodIBGE.Text = "" Then
            MessageBox.Show("Verificar o CEP")
            Exit Sub
        End If

        ' rotina que lê código IBGE
        Dim ds As New DataSet()
        Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", D_Cep.Text)
        ds.ReadXml(xml)
        D_Endereco.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
        D_Bairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
        D_Municipio.Text = ds.Tables(0).Rows(0)("cidade").ToString()
        D_Estado.Text = ds.Tables(0).Rows(0)("uf").ToString()

        If D_Endereco.Text = "" Then
            MessageBox.Show("Não foi achado nenhum CEP")
            Exit Sub
        End If

        'rotina para ler o código do IBGE no arquivo copiado da receita
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select * from tab_municipios where nome = '" & D_Municipio.Text & "'"

        connection.Open()
        Dim lrd As SqlDataReader = command.ExecuteReader()

        Try

            If lrd.Read() = False Then
                MessageBox.Show("O nome da cidade está errado - código do IBGE não foi achado")
                connection.Close()
                Exit Sub
            Else
                MessageBox.Show("O código do IBGE foi achado")
                Txt_CodIBGE.Text = lrd("id").ToString
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro")
        End Try

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        NFE_EmitidasBindingSource.Filter = String.Format("RazaoCliente_nfeemitida LIKE '{0}%'", TextBox4.Text)

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        ' trocando o binding source(fonte de dados do datagridview) pelo original
        NFE_EmitidasDataGridView.DataSource = NFE_EmitidasBindingSource
        'Para comparar inteiros, converter a coluna em string
        NFE_EmitidasBindingSource.Filter = String.Format("Convert(id_nfeemitidas, 'System.String') like '{0}%'", TextBox23.Text)
        ' NFE_EmitidasBindingSource.Filter = String.Format("CodigoPedido_nfeemitida LIKE '{0}%'", TextBox23.Text)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        NFE_EmitidasBindingSource.Filter = String.Empty

    End Sub


    

   

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        IsValidaCNPJ(msktxt_cnpjcliente.Text)

        If IsValidaCNPJ(D_Cnpj.Text) = False Then
            MessageBox.Show("CNPJ INVÁLIDO")
        Else
            MessageBox.Show("CNPJ VÁLIDO")
        End If

    End Sub



    Private Sub NFE_EmitidasDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles NFE_EmitidasDataGridView.DoubleClick

        


        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ''coloca o ponteiro onde ele está clicado
        'Dim v_SelectRow2 As Integer
        'v_SelectRow2 = Me.NFE_EmitidasDataGridView.CurrentRow.Index


        ''variáveis do arquivo de clientes
        'Dim endereco As String
        'Dim numerorua_cliente As String
        'Dim bairro_cliente As String
        'Dim cidade_cliente As String
        'Dim estado_cliente As String
        'Dim cep_cliente As String
        'Dim cnpj_cliente As String
        'Dim insestadual_cliente As String
        'Dim telefone_cliente As String
        'Dim email_cliente As String
        'Dim codIBGE_cliente As String
        'Dim fj_cliente As String
        'Dim cpf_cliente As String


        'Dim command As SqlCommand
        'command = connection.CreateCommand()
        'command.CommandText = "select * from cliente where id_cliente = '" & NFE_EmitidasDataGridView.Item(17, v_SelectRow2).Value & "'"
        'Try

        '    connection.Open()
        '    Dim lrd As SqlDataReader = command.ExecuteReader()
        '    While lrd.Read

        '        If lrd("cnpj_cliente") Is DBNull.Value Then
        '            cnpj_cliente = "0"
        '        Else
        '            cnpj_cliente = lrd("cnpj_cliente")
        '        End If

        '        If lrd("endereco_cliente") Is DBNull.Value Then
        '            endereco = "0"
        '        Else
        '            endereco = lrd("endereco_cliente")
        '        End If

        '        If lrd("numerorua_cliente") Is DBNull.Value Then
        '            numerorua_cliente = "0"
        '        Else
        '            numerorua_cliente = lrd("numerorua_cliente")
        '        End If

        '        If lrd("bairro_cliente") Is DBNull.Value Then
        '            bairro_cliente = "0"
        '        Else
        '            bairro_cliente = lrd("bairro_cliente")
        '        End If

        '        If lrd("cidade_cliente") Is DBNull.Value Then
        '            cidade_cliente = "0"
        '        Else
        '            cidade_cliente = lrd("cidade_cliente")
        '        End If

        '        If lrd("estado_cliente") Is DBNull.Value Then
        '            estado_cliente = "0"
        '        Else
        '            estado_cliente = lrd("estado_cliente")
        '        End If

        '        If lrd("cep_cliente") Is DBNull.Value Then
        '            cep_cliente = "0"
        '        Else
        '            cep_cliente = lrd("cep_cliente")
        '        End If
        '        If lrd("insestadual_cliente") Is DBNull.Value Then
        '            insestadual_cliente = "0"
        '        Else
        '            insestadual_cliente = lrd("insestadual_cliente")
        '        End If

        '        If lrd("telefone_cliente") Is DBNull.Value Then
        '            telefone_cliente = "0"
        '        Else
        '            telefone_cliente = lrd("telefone_cliente")
        '        End If
        '        If lrd("email_cliente") Is DBNull.Value Then
        '            email_cliente = "0"
        '        Else
        '            email_cliente = lrd("email_cliente")
        '        End If
        '        If lrd("codIBGE_cliente") Is DBNull.Value Then
        '            codIBGE_cliente = "0"
        '        Else
        '            codIBGE_cliente = lrd("codIBGE_cliente")
        '        End If

        '        If lrd("fj_cliente") Is DBNull.Value Then
        '            fj_cliente = "0"
        '        Else
        '            fj_cliente = lrd("fj_cliente")
        '        End If

        '        If lrd("cpf_cliente") Is DBNull.Value Then
        '            cpf_cliente = "0"
        '        Else
        '            cpf_cliente = lrd("cpf_cliente")
        '        End If
        '    End While

        '    connection.Close()
        'Catch ex As Exception

        '    MessageBox.Show(ex.ToString)

        'End Try

        'Me.ItemNfeEmitidaTableAdapter.Fill(Me.DataSetFinal.ItemNfeEmitida)
        'Try
        '    ' passar parâmetros para a tela de notas
        '    D_Nome.Text = NFE_EmitidasDataGridView.Item(2, v_SelectRow2).Value
        '    D_Endereco.Text = endereco
        '    Numerodarua_pedTextBox.Text = numerorua_cliente
        '    D_Email.Text = email_cliente
        '    D_Cep.Text = cep_cliente
        '    D_Bairro.Text = bairro_cliente
        '    D_Municipio.Text = cidade_cliente
        '    D_Estado.Text = estado_cliente
        '    D_Telefone.Text = telefone_cliente
        '    D_Cnpj.Text = cnpj_cliente
        '    txt_cpfNFE.Text = cpf_cliente
        '    msk_ieNFE.Text = insestadual_cliente
        '    Txt_CodIBGE.Text = codIBGE_cliente
        '    Txt_fisicajuridicaNFE.Text = fj_cliente
        '    txt_codCli_pedNfe.Text = NFE_EmitidasDataGridView.Item(17, v_SelectRow2).Value
        '    txt_coPEdNFe.Text = NFE_EmitidasDataGridView.Item(1, v_SelectRow2).Value
        '    txt_nNfe.Text = NFE_EmitidasDataGridView.Item(0, v_SelectRow2).Value
        '    cbx_CFOP.Text = NFE_EmitidasDataGridView.Item(31, v_SelectRow2).Value
        '    cbx_VolNfeEmitidas.Text = NFE_EmitidasDataGridView.Item(34, v_SelectRow2).Value
        '    Vendedor_nfeemitidasTextBox.Text = NFE_EmitidasDataGridView.Item(36, v_SelectRow2).Value
        '    txt_obsNFE.Text = NFE_EmitidasDataGridView.Item(37, v_SelectRow2).Value
        '    txt_obs2.Text = NFE_EmitidasDataGridView.Item(38, v_SelectRow2).Value
        '    TextBox31.Text = NFE_EmitidasDataGridView.Item(39, v_SelectRow2).Value
        '    TextBox30.Text = NFE_EmitidasDataGridView.Item(40, v_SelectRow2).Value
        '    ComboBox12.Text = NFE_EmitidasDataGridView.Item(41, v_SelectRow2).Value
        '    'HoraEmitida_nfeemitidaTextBox.Text = NFE_EmitidasDataGridView.Item(30, v_SelectRow2).Value
        '    CodTrans_nfeemitidaTextBox.Text = NFE_EmitidasDataGridView.Item(32, v_SelectRow2).Value
        '    NomeTrans_nfeemitidaTextBox.Text = NFE_EmitidasDataGridView.Item(33, v_SelectRow2).Value
        '    'Data_nfeemitidasDateTimePicker.Text = NFE_EmitidasDataGridView.Item(42, v_SelectRow2).Value


        'Catch ex As Exception

        '    MessageBox.Show(ex.ToString)

        'End Try

        '' calcula o vr da nota
        'Dim valor2 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '    valor2 += Linha.Cells(5).Value
        'Next
        'TextBox5.Text = valor2
        '' calcula o peso da nota
        'Dim valor3 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
        '    valor3 += Linha.Cells(11).Value
        'Next
        'Peso_nfeemitidaTextBox.Text = valor3


        ''  passando os vr e as datas
        '            If NFE_EmitidasDataGridView.Item(19, v_SelectRow2).Value IsNot DBNull.Value Then
        '        rdb_vezesduplicata1.Checked = True
        '        date_duplicata1.Text = NFE_EmitidasDataGridView.Item(19, v_SelectRow2).Value
        '        txt_vrduplicata1.Text = NFE_EmitidasDataGridView.Item(20, v_SelectRow2).Value
        '    Else
        '        date_duplicata1.Text = ""
        '        txt_vrduplicata1.Text = ""
        '    End If
        '    If NFE_EmitidasDataGridView.Item(21, v_SelectRow2).Value IsNot DBNull.Value Then
        '        rdb_vezesduplicata2.Checked = True
        '        date_duplicata2.Text = NFE_EmitidasDataGridView.Item(21, v_SelectRow2).Value
        '        txt_vrduplicata2.Text = NFE_EmitidasDataGridView.Item(22, v_SelectRow2).Value
        '    Else
        '        date_duplicata2.Text = ""
        '        txt_vrduplicata2.Text = ""
        '    End If
        '    If NFE_EmitidasDataGridView.Item(23, v_SelectRow2).Value IsNot DBNull.Value Then
        '        rdb_vezesduplicata3.Checked = True
        '        date_duplicata3.Text = NFE_EmitidasDataGridView.Item(23, v_SelectRow2).Value
        '        txt_vrduplicata3.Text = NFE_EmitidasDataGridView.Item(24, v_SelectRow2).Value
        '    Else
        '        date_duplicata3.Text = ""
        '        txt_vrduplicata3.Text = ""
        '    End If
        '    If NFE_EmitidasDataGridView.Item(25, v_SelectRow2).Value IsNot DBNull.Value Then
        '        rdb_vezesduplicata4.Checked = True
        '        date_duplicata4.Text = NFE_EmitidasDataGridView.Item(25, v_SelectRow2).Value
        '        txt_vrduplicata4.Text = NFE_EmitidasDataGridView.Item(26, v_SelectRow2).Value
        '    Else
        '        date_duplicata4.Text = ""
        '        txt_vrduplicata4.Text = ""
        '    End If
        '    If NFE_EmitidasDataGridView.Item(27, v_SelectRow2).Value IsNot DBNull.Value Then
        '        rdb_vezesduplicata5.Checked = True
        '        date_duplicata5.Text = NFE_EmitidasDataGridView.Item(27, v_SelectRow2).Value
        '        txt_vrduplicata5.Text = NFE_EmitidasDataGridView.Item(28, v_SelectRow2).Value
        '    Else
        '        date_duplicata5.Text = ""
        '        txt_vrduplicata5.Text = ""
        '    End If


        '    TabControl_NFE.SelectedIndex = 0
        ''ItemNfeEmitidaBindingSource.Filter = String.Format("HoraNota_itemNfeEmitida LIKE '{0}%'", HoraEmitida_nfeemitidaTextBox.Text)

    End Sub



    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        '' remove a tab consulta e acrescenta a tab TabPage_PedidosNFE
        'TabControl1.TabPages.Remove(tbpg_produtos)
        'TabControl1.TabPages.Remove(tbpg_clientes)
        'TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        'TabControl1.TabPages.Remove(tbpg_transportadoras)
        'TabControl1.TabPages.Remove(tbpg_capitalGiro)
        'TabControl1.TabPages.Remove(tab_nfe)
        ''TabControl1.TabPages.Remove(tabpage_NFE_e)
        'TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        'TabControl1.TabPages.Remove(tbpg_bkup)
        'TabControl1.TabPages.Remove(pedidos)
        'TabControl1.TabPages.Remove(tbpg_orcamento)
        'TabControl1.TabPages.Remove(tbg_relatorios)
        '' habilitar botões
        'Button21.Enabled = True
        'Button10.Enabled = True
        'btn_confimraNfeEmitida.Enabled = True
        '' habilitar outros
        'cbx_CFOP.Enabled = True
        'D_Nome.Enabled = True
        'Numerodarua_pedTextBox.Enabled = True
        'D_Email.Enabled = True
        'txt_cpfNFE.Enabled = True
        'D_Endereco.Enabled = True
        'Txt_fisicajuridicaNFE.Enabled = True
        'D_Cep.Enabled = True
        'msk_ieNFE.Enabled = True
        'D_Bairro.Enabled = True
        'D_Telefone.Enabled = True
        'D_Cnpj.Enabled = True
        'D_Estado.Enabled = True
        'D_Municipio.Enabled = True
        'txt_obsNFE.Enabled = True
        'cbx_VolNfeEmitidas.Enabled = True
        'txt_obs2.Enabled = True
        'Button38.Enabled = True

        '' habilitar duplicatas
        'rdb_vezesduplicata1.Enabled = True
        'rdb_vezesduplicata2.Enabled = True
        'rdb_vezesduplicata3.Enabled = True
        'rdb_vezesduplicata4.Enabled = True
        'rdb_vezesduplicata5.Enabled = True

        '' habilitando as duplicatas

        '' Data_nfeemitidasDateTimePicker.Enabled = True

        ''acrescenta  e remove telas
        'TabControl_NFE.TabPages.Remove(TbPg_consultaNFe)
        'TabControl_NFE.TabPages.Add(tbpg_transNfe)

    End Sub


    Private Sub TransportadorasDataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles TransportadorasDataGridView1.DoubleClick

        'coloca o ponteiro onde ele está clicado
        Dim v_SelectRow As Integer
        v_SelectRow = Me.TransportadorasDataGridView1.CurrentRow.Index
        CodTrans_nfeemitidaTextBox.Text = TransportadorasDataGridView1.Item(9, v_SelectRow).Value
        NomeTrans_nfeemitidaTextBox.Text = TransportadorasDataGridView1.Item(1, v_SelectRow).Value
        TabControl_NFE.SelectedIndex = 0
        'soma do peso
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView1.Rows
            valor3 += Linha.Cells(11).Value
        Next
        Peso_nfeemitidaTextBox.Text = valor3
    End Sub

    
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage

        
        ' Pedido compra
        ' primeira linha
        e.Graphics.DrawString(DateTimePicker37.Text, New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("PEDIDO DE COMPRA        N.  ", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 200, 5)
        e.Graphics.DrawString(TextBox284.Text, New Font("arial", 15, FontStyle.Bold), Brushes.Black, 450, 5)
        e.Graphics.DrawString(PedidoCompraDataGridView.Item(5, 0).Value, New Font("arial", 15, FontStyle.Bold), Brushes.Black, 20, 30)

        'segunda linha
        e.Graphics.DrawString("Fernando Frascari EPP [BugigangasMil Utilidades Domésticas ltd]", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 20, 50)
        ' terceira linha
        e.Graphics.DrawString("Av Henrique Peres, 1880 - Mogi das Cruzes - SP -  Cep: 08735-400", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 20, 100)
        ' quarta linha
        e.Graphics.DrawString("CNPJ - 72.844.228/0001-79                                    IE -454.131.384.115  ", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 20, 125)
        ' quinta linha
        e.Graphics.DrawString("TEL : (11) 2988-9475                                              Contato - Silvia ou Fernando", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 20, 150)
        'sexta linha
        e.Graphics.DrawString("Email : vendas@marfinitemogi.com.br                         Home - www.marfinitemogi.com.br", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 20, 175)

        ' sétima linha
        e.Graphics.DrawString("Vendedor :", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 20, 200)
        e.Graphics.DrawString(ComboBox46.Text, New Font("arial", 13, FontStyle.Regular), Brushes.Black, 150, 200)
        e.Graphics.DrawString("Email -  :", New Font("arial", 13, FontStyle.Regular), Brushes.Black, 350, 200)
        e.Graphics.DrawString(ComboBox47.Text, New Font("arial", 13, FontStyle.Regular), Brushes.Black, 450, 200)
        e.Graphics.DrawString("__________________________________________________________________________________________________________________  :", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 225)


        e.Graphics.DrawString("Condições de pagamento : BOLETO", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 250)
        '  linhazz:00
        e.Graphics.DrawString("Entrega de segunda a sexta das 9:00 às 18:00 horas  ", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 275)
        '  linha
        e.Graphics.DrawString("Endereço de entrega e cobrança: Av. Henrique Peres, n 1880, Vila Bernadotti ", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 300)
        ' linha
        e.Graphics.DrawString("MOGI DAS CRUZES - SP CEP: 08735-400", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 325)
        ' linha
        e.Graphics.DrawString("Enviar arquivo XML para: nfe2@marfinitemogi.com.br", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 350)
        e.Graphics.DrawString("__________________________________________________________________________________________________________________  :", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 375)


        ' cabecalho
        e.Graphics.DrawString("Código Produto", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 400)
        e.Graphics.DrawString("Nome do Produto", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 250, 400)
        e.Graphics.DrawString("Cor  ", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 550, 400)
        e.Graphics.DrawString("Quantidade  ", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 700, 400)


        Try
            For x = 0 To 30

                e.Graphics.DrawString(PedidoCompraDataGridView.Item(9, x).Value, New Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 425 + (x * 20))
                e.Graphics.DrawString(PedidoCompraDataGridView.Item(10, x).Value, New Font("arial", 12, FontStyle.Regular), Brushes.Black, 200, 425 + (x * 20))
                e.Graphics.DrawString(PedidoCompraDataGridView.Item(8, x).Value, New Font("arial", 12, FontStyle.Regular), Brushes.Black, 550, 425 + (x * 20))
                e.Graphics.DrawString(PedidoCompraDataGridView.Item(11, x).Value, New Font("arial", 12, FontStyle.Regular), Brushes.Black, 720, 425 + (x * 20))

            Next
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        PrintPreviewDialog5.ShowDialog()
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument3.PrintPage

        ' PEGAR O FATOR DIVISOR
        Dim Divisor As Integer
        Try
            Divisor = InputBox("Digite o divisor", "Fator divisor")
        Catch ex As Exception
            Divisor = 1
        End Try

        ' define entrada e saída
        If TextBox31.Text = "saída" Then
            e.Graphics.DrawString("X", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 490, 50)
        Else
            e.Graphics.DrawString("X", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 600, 50)
        End If

        ' NÚMERO NOTA - LINHA 1
        e.Graphics.DrawString(txt_nNfe.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 700, 50)
        ' ´VENDA E CFOP - LINHA 2
        e.Graphics.DrawString(TextBox30.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString(cbx_CFOP.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 220, 130)
        'DADOS DO EMITENTE - LINHA 3
        'NOME Do cliente
        e.Graphics.DrawString(D_Nome.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 175)
        'CNPJ ou cpf
        If Txt_fisicajuridicaNFE.Text = "Jurídica" Then
            e.Graphics.DrawString(D_Cnpj.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 175)
        Else
            e.Graphics.DrawString(txt_cpfNFE.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 175)
        End If
       'DATA EMISSÃO
        ' e.Graphics.DrawString(Data_nfeemitidasDateTimePicker.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 700, 175)

        'ENDEREÇO - LINHA 4
        e.Graphics.DrawString(D_Endereco.Text + " " + Numerodarua_pedTextBox.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 205)
        'BAIRRO
        e.Graphics.DrawString(D_Bairro.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 400, 205)
        ' CEP
        e.Graphics.DrawString(D_Cep.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 560, 205)
        ' DATA SAÍDA
        'e.Graphics.DrawString(DateTimePicker20.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 700, 205)

        'CIDADE - telefone - ESTADO - INSCRIÇÃO
        e.Graphics.DrawString(D_Municipio.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 240)

        If Divisor = 1 Then
            e.Graphics.DrawString(D_Telefone.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 280, 240)
        End If

        e.Graphics.DrawString(D_Estado.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 458, 240)
        e.Graphics.DrawString(msk_ieNFE.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 240)

        ' IMPRESSÃO DE DUPLICATAS NA NOTA
        If Divisor = 1 Then

            ' PRIMEIRA DUPLICATA
            e.Graphics.DrawString(txt_nNfe.Text & ".1 :", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 275)
            '    e.Graphics.DrawString(txt_vrduplicata1.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 100, 275)
            '    e.Graphics.DrawString(date_duplicata1.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 200, 275)
            'e.Graphics.DrawString("|||", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 300, 275)

            ' SEGUNDA DUPLICATA
            '       If txt_vrduplicata2.Text <> "" Then
            e.Graphics.DrawString(txt_nNfe.Text & ".2 :", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 300, 275)
            '     e.Graphics.DrawString(txt_vrduplicata2.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 400, 275)
            '     e.Graphics.DrawString(date_duplicata2.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 500, 275)
            'e.Graphics.DrawString("|||", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 600, 275)
        End If

        ' TERCEIRA DUPLICATA
        'If txt_vrduplicata3.Text <> "" Then
        '    e.Graphics.DrawString(txt_nNfe.Text & ".3 :", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 600, 275)
        '    e.Graphics.DrawString(txt_vrduplicata3.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 650, 275)
        '    e.Graphics.DrawString(date_duplicata3.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 720, 275)
        'End If

        '' QUARTA DUPLICATA
        'If txt_vrduplicata4.Text <> "" Then
        '    e.Graphics.DrawString(txt_nNfe.Text & ".4 :", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 295)
        '    e.Graphics.DrawString(txt_vrduplicata4.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 100, 295)
        '    e.Graphics.DrawString(date_duplicata4.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 200, 295)
        '    ' e.Graphics.DrawString("|||", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 300, 295)
        'End If

        '' QUINTA DUPLICATA
        'If txt_vrduplicata5.Text <> "" Then
        '    e.Graphics.DrawString(txt_nNfe.Text & ".5 :", New Font("arial", 12, FontStyle.Regular), Brushes.Black, 300, 295)
        '    e.Graphics.DrawString(txt_vrduplicata5.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 400, 295)
        '    e.Graphics.DrawString(date_duplicata5.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 600, 295)
        'End If
        'End If

        Dim VrTotalNotaSilvia As Double = 0
        Dim vrtotal As Double
        ' GERAR LISTA DE PRODUTOS
        For x As Integer = 0 To ItemPedidosDataGridView1.Rows.Count() - 1
            e.Graphics.DrawString(ItemPedidosDataGridView1.Item(1, (x)).Value, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 360 + (x * 20))
            e.Graphics.DrawString(ItemPedidosDataGridView1.Item(2, (x)).Value, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 100, 360 + (x * 20))
            ' ncm
            e.Graphics.DrawString(ItemPedidosDataGridView1.Item(9, (x)).Value, New Font("arial", 6, FontStyle.Bold), Brushes.Black, 330, 360 + (x * 20))
            e.Graphics.DrawString("pc", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 410, 360 + (x * 20))

            Dim quantidade As Integer = (ItemPedidosDataGridView1.Item(3, (x)).Value) \ Divisor
            If quantidade < 1 Then
                quantidade = 1
            End If

            e.Graphics.DrawString(quantidade, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 480, 360 + (x * 20))
            ' formatando o preço unitário
            Dim PrecoUnitario As Double = ItemPedidosDataGridView1.Item(4, (x)).Value
            e.Graphics.DrawString(PrecoUnitario.ToString("F2"), New Font("arial", 8, FontStyle.Bold), Brushes.Black, 570, 360 + (x * 20))
            ' formatando o preço total do ítem
            vrtotal = (quantidade * ItemPedidosDataGridView1.Item(4, (x)).Value)
            VrTotalNotaSilvia += (quantidade * ItemPedidosDataGridView1.Item(4, (x)).Value)
            e.Graphics.DrawString(vrtotal.ToString("F2"), New Font("arial", 8, FontStyle.Bold), Brushes.Black, 650, 360 + (x * 20))
            e.Graphics.DrawString("0", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 723, 360 + (x * 20))
        Next
        'formatando o preço total da nota
        TextBox5.Text = VrTotalNotaSilvia.ToString("F2")

        If Divisor <> 1 Then
            ' QUANDO TIVER DIVISOR SERÁ SEMPRE UMA ÚNICA DUPLICATA A VISTA
            e.Graphics.DrawString(txt_nNfe.Text & ".1 :", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 275)
            e.Graphics.DrawString(TextBox5.Text, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 100, 275)
            e.Graphics.DrawString("Parcela única a Vista", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 275)
        End If


        ' OBSERVAÇÃO FIXAS
        ' OUTROS DADOS - primeira linha
        e.Graphics.DrawString(TextBox5.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 680)
        e.Graphics.DrawString("0.00", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 150, 680)
        e.Graphics.DrawString(TextBox5.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 700, 680)
        'segunda linha
        e.Graphics.DrawString("0.00", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 20, 710)
        e.Graphics.DrawString("0.00", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 150, 710)
        e.Graphics.DrawString("0.00", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 350, 710)
        e.Graphics.DrawString("0.00", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 500, 710)
        e.Graphics.DrawString(TextBox5.Text, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 700, 710)
        ' TRANSPORTE 
        ' PEGANDO OS DADOS DA TRANSPORTADORA
        'REM LÊ OS DADOS DA TRANSPORTADORA --------------------------------------------------
        Dim enderecoTrans As String
        Dim numeroruaTrans As String
        Dim bairroTrans As String
        Dim cidadeTrans As String
        Dim estadoTrans As String
        Dim cepTrans As String
        Dim cnpjTrans As String
        Dim insestadualTrans As String
        Dim emailTrans As String
        Dim command1 As New SqlCommand
        Dim telefoneTrans As String

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        command1 = connection.CreateCommand()
        command1.CommandText = "select * from transportadoras where CNPJ_trans = '" & CodTrans_nfeemitidaTextBox.Text & "'"

        connection.Open()

        Dim lrd1 As SqlDataReader = command1.ExecuteReader()


        Try

            While lrd1.Read

                If lrd1("endereco_trans") Is DBNull.Value Then
                Else
                    enderecoTrans = lrd1("endereco_trans")
                End If
                If lrd1("numerorua_trans") Is DBNull.Value Then
                Else
                    numeroruaTrans = lrd1("numerorua_trans")
                End If
                If lrd1("bairro_trans") Is DBNull.Value Then
                Else
                    bairroTrans = lrd1("bairro_trans")
                End If
                If lrd1("cidade_trans") Is DBNull.Value Then
                Else
                    cidadeTrans = lrd1("cidade_trans")
                End If
                If lrd1("estado_trans") Is DBNull.Value Then
                Else
                    estadoTrans = lrd1("estado_trans")
                End If
                If lrd1("CEP_trans") Is DBNull.Value Then
                Else
                    cepTrans = lrd1("CEP_trans")
                End If
                If lrd1("CNPJ_trans") Is DBNull.Value Then
                Else
                    cnpjTrans = lrd1("CNPJ_trans")
                End If
                If lrd1("INSEST_trans") Is DBNull.Value Then
                Else
                    insestadualTrans = lrd1("INSEST_trans")
                End If
                If lrd1("EMAIL_trans") Is DBNull.Value Then
                Else
                    emailTrans = lrd1("EMAIL_trans")
                End If

                If lrd1("telefone_trans") Is DBNull.Value Then
                Else
                    telefoneTrans = lrd1("telefone_trans")
                End If

            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
        connection.Close()

        ' ESTADO TRANSPORTADORA - LINHA 1
        ' Nome transportadora
        e.Graphics.DrawString(NomeTrans_nfeemitidaTextBox.Text, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 20, 765)
        ' EMITENTE E DESTINATÁRIO
        If ComboBox12.Text = "emitente" Then
            e.Graphics.DrawString("1", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 450, 765)
        Else
            e.Graphics.DrawString("2", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 450, 765)
        End If
        ' CNPJ TRANSPORTADORA
        e.Graphics.DrawString(cnpjTrans, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 650, 765)

        ' ENDEREÇO TRANSPORTADORA - LINHA 2
        e.Graphics.DrawString(enderecoTrans + " " + numeroruaTrans, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 20, 795)
        ' MUNICIPIO TRANSPORTADORA 
        e.Graphics.DrawString(cidadeTrans, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 400, 795)
        ' ESTADO TRANSPORTADORA
        e.Graphics.DrawString(estadoTrans, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 585, 795)
        ' INSCRIÇÃO TRANSPORTADORA 
        e.Graphics.DrawString(insestadualTrans, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 650, 795)

        ' VOLUMES E PESO
        Dim Volume As Integer = cbx_VolNfeEmitidas.Text \ Divisor
        Dim Peso As Integer = (Peso_nfeemitidaTextBox.Text) \ Divisor
        e.Graphics.DrawString(Volume, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 20, 830)
        e.Graphics.DrawString("VOLUMES", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 150, 830)
        e.Graphics.DrawString(Peso, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 550, 830)
        e.Graphics.DrawString(Peso, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 720, 830)
        ' OBSERVAÇÕES NO CORPO DA NOTA
        e.Graphics.DrawString(txt_obsNFE.Text, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 880)
        e.Graphics.DrawString(txt_obs2.Text, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 900)
        ' NÚMERO DA NOTA NO CANHOTO
        e.Graphics.DrawString(txt_nNfe.Text, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 700, 1040)

        ' RESTAURAR OS BOTÕES E TABELAS
        btn_buscarPedidoNFE.Enabled = True
        Button4.Enabled = False
    End Sub


    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM PedidoNFE WHERE dataemissao_ped BETWEEN  '" & DateTimePicker2.Text & "' and '" & DateTimePicker3.Text & "'"

        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "PedidoNFE")
            connection.Close()
            PedidoNFEDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ComboBox7_TextChanged(sender As Object, e As EventArgs) Handles ComboBox7.TextChanged
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox7.Text)
        Label94.Text = ProdutosDataGridView4.Rows.Count() - 1
    End Sub

    Private Sub ComboBox8_TextChanged(sender As Object, e As EventArgs) Handles ComboBox8.TextChanged
        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox8.Text, ComboBox7.Text)
        Label94.Text = ProdutosDataGridView4.Rows.Count() - 1
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        ProdutosBindingSource.Filter = String.Empty
        Label94.Text = ProdutosDataGridView4.Rows.Count() - 1
    End Sub

    Private Sub PrintDocument4_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument4.PrintPage
        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   1", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)
        ' escolhendo o cabeçalho de impressão
       
        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select

        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)



        Try
            For x As Integer = 0 To 45

                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (x * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (x * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (x * 20))

                If x >= 45 Then
                    PrintDocument5.Print()
                End If

            Next
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

   

    Private Sub PrintDocument5_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument5.PrintPage

        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   2", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)

        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select

        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)


        Dim l As Integer = 0

        Try
            For x As Integer = 45 To 90

                l += 1
                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (l * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))

                If x = 90 Then

                    PrintDocument6.Print()
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PrintDocument6_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument6.PrintPage
        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   3", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)

        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select
        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)

        Dim l As Integer = 0

        Try
            For x As Integer = 90 To 135

                l += 1
                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (l * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))



                If x = 135 Then
                    PrintDocument7.Print()
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PrintDocument7_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument7.PrintPage
        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   4", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)

        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select
        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)

        Dim l As Integer = 0

        Try
            For x As Integer = 135 To 180

                l += 1
                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (l * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))


                If x = 180 Then
                    PrintDocument8.Print()
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PrintDocument8_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument8.PrintPage
        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   5", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)

        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select
        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)

        Dim l As Integer = 0

        Try
            For x As Integer = 180 To 225

                l += 1
                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (l * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))

                If x = 225 Then
                    PrintDocument9.Print()
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PrintDocument9_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument9.PrintPage

        ' cabeçalho
        e.Graphics.DrawString("CHEK LIST", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   6", New Font("arial", 15, FontStyle.Bold), Brushes.Black, 600, 5)

        Select Case variavelImpressao
            Case 1
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 2
                e.Graphics.DrawString(ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 3
                e.Graphics.DrawString(ComboBox29.Text & ",  " & "Raiz", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
            Case 4
                e.Graphics.DrawString(ComboBox29.Text & ",  " & ComboBox30.Text & ",  " & "Raiz, Bugiganga", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 100, 40)
        End Select
        ' dados da lista
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 85)
        e.Graphics.DrawString("", New Font("arial", 13, FontStyle.Bold), Brushes.Black, 20, 100)

        e.Graphics.DrawString("Cod For", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 130)
        e.Graphics.DrawString("Nome ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 120, 130)
        e.Graphics.DrawString("cor", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 350, 130)
        e.Graphics.DrawString("Quantidade", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 450, 130)
        e.Graphics.DrawString("EstMin", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 550, 130)
        e.Graphics.DrawString("ConsMax", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 130)
        e.Graphics.DrawString("Encom", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 670, 130)

        Dim l As Integer = 0

        Try
            For x As Integer = 225 To 270

                l += 1
                e.Graphics.DrawString(ProdutosDataGridView4.Item(2, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 120, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 350, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(12, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 450, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(10, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 550, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(28, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 600, 170 + (l * 20))
                e.Graphics.DrawString(ProdutosDataGridView4.Item(17, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 670, 170 + (l * 20))
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 170 + (l * 20))

            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub btn_iniciarVenda_Click_1(sender As Object, e As EventArgs) Handles btn_iniciarVenda.Click

        If ComboBox2.Text = "" Then
            MessageBox.Show("Por favor, escolha um vendedor para iniciar a venda.")
            Exit Sub
        End If

        ' acertando os botões
        TextBox1.Clear()
        Button12.Enabled = True
        Button11.Enabled = False
        Button11.Enabled = True
        btn_addProd.Enabled = True
        Button84.Enabled = False
        RadioButton10.Checked = True
        RadioButton8.Checked = False

        BalcaoBindingSource.Filter = String.Format("nomevendedor_balcao LIKE '{0}%'", "oairgoafg000....çojdasfghaoirgy")

        'estabelecer um horário que vai funcionar como índice
        Dim HorarioNotaEmitida3 As String
        Dim date3 As New Date()
        date3 = Date.Now
        Dim ci3 As CultureInfo = CultureInfo.InvariantCulture
        '  HorarioNotaEmitida3 = date3.ToString("dd.yyyy.hh.mm.ss.FFFFF", ci3)
        HorarioNotaEmitida3 = date3.ToString("dd.yyyy.hh.mm.FFFF", ci3)
        HorarioNotaEmitida3 = HorarioNotaEmitida3.Replace(".", "")
        TextBox1.Text = Convert.ToString(HorarioNotaEmitida3)
        ' acertando os botões
        ComboBox2.Enabled = False
        btn_iniciarVenda.Enabled = False
        Button32.Enabled = True


        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        ' TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
        ' outro tabcontrol
        tbcotrl_pdv.TabPages.Insert(1, tbpg_produtosPDV)
        tbcotrl_pdv.TabPages.Remove(tbpg_VendasBalcao)
        tbcotrl_pdv.TabPages.Remove(TabPage6)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Button32.Enabled = True
        Button12.Enabled = False
        ComboBox2.Enabled = True
        Button11.Enabled = False
        tbcotrl_pdv.TabPages.Remove(tbpg_produtosPDV)

        ' trabalhando os radiobutton - formas de pagamento
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
        RadioButton5.Enabled = True
        RadioButton6.Enabled = True
        ' checar a venda a prazo, pois o preço foi calculado como a prazo
        RadioButton6.Checked = True
        Button84.Enabled = False
        RadioButton10.Checked = True
        RadioButton8.Checked = False

        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)

    End Sub

    Private Sub tbcotrl_pdv_Click(sender As Object, e As EventArgs) Handles tbcotrl_pdv.Click
        If tbcotrl_pdv.SelectedIndex = 1 Then
            TextBox35.Focus()
        End If
    End Sub

    Private Sub ComboBox9_TextChanged(sender As Object, e As EventArgs) Handles ComboBox9.TextChanged

        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox9.Text)

    End Sub

    Private Sub ComboBox10_TextChanged(sender As Object, e As EventArgs) Handles ComboBox10.TextChanged

        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox10.Text, ComboBox9.Text)

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click

        ProdutosBindingSource.Filter = String.Empty

    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged

        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox25.Text)

    End Sub

    Private Sub GravarBalcao()

        ' Dim contador As Integer = 0
        Dim connection5 As SqlConnection
        connection5 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        'REM coloca ponteiro junto com row escolhida
        Dim v_SelectRow As Integer
        v_SelectRow = Me.ProdutosDataGridView2.CurrentRow.Index

        'REM pega a quantidade de produtos no pedido
        Dim qtdPedMarf As Integer
        Dim NumeroNota As String = ""
        Dim NumeroNota2 As String = ""

        If RadioButton8.Checked = True Or RadioButton23.Checked = True Then
            Try
                NumeroNota = InputBox("Digite o Número da Nota")
                ' acrescenta S ou f no numero da nota
                If RadioButton23.Checked = True Then
                    NumeroNota2 = "S" + NumeroNota
                End If
                
                If RadioButton8.Checked = True Then
                    NumeroNota2 = "MLB" + NumeroNota
                End If
              
                'REM verifica se o produto já foi cadastrado no arquivo balcão(tem defeito-se a nota tiver vários itens)
                Dim cmd As New SqlCommand
                cmd.Connection = connection5
                cmd.CommandText = "SELECT *  from balcao where NumeroNotaMlb_balcao = '" & NumeroNota2 & "'"
                ' ---------------------------------------------------------------
                connection5.Open()
                'REM verifica se código prod existe no arquivo balcão, para não gravar duas vezes
                Dim lrd5 As SqlDataReader = cmd.ExecuteReader()

                Try
                    If lrd5.Read() = True Then
                        MessageBox.Show("Esta nota fiscal número " & NumeroNota2 & " já foi cadastrada!!!!")
                        Exit Sub
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                connection5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Exit Sub
            End Try
        End If
        ' -------------------------------------------------------------------------------
        Try
            qtdPedMarf = InputBox("Escolha a quantidade", "Escolha a quantidade")
        Catch ex As Exception
            tbcotrl_pdv.SelectedIndex = 0
            Exit Sub
        End Try


        Dim command5 As SqlCommand
        command5 = connection5.CreateCommand()
        command5.CommandText = "insert into balcao (Avista_APrazo_balcao,FormaPgto_balcao,NumeroNotaMlb_balcao,id2_balcao,nomevendedor_balcao,codprod_balcao,forprod_balcao,linhaprod_balcao,corprod_balcao,quantidadeprod_balcao,precoprod_balcao,totalprod_balcao,datavenda_prodbalcao,desconto_balcao,nomeProd_balcao,Custo_balcao,vendaOrcamento_balcao) values (@Avista_APrazo_balcao,@FormaPgto_balcao,@NumeroNotaMlb_balcao,@id2_balcao,@nomevendedor_balcao,@codprod_balcao,@forprod_balcao,@linhaprod_balcao,@corprod_balcao,@quantidadeprod_balcao,@precoprod_balcao,@totalprod_balcao,@datavenda_prodbalcao,@desconto_balcao,@nomeProd_balcao,@Custo_balcao,@vendaOrcamento_balcao)"
        command5.CommandType = CommandType.Text

        command5.Parameters.Add("@id2_balcao", SqlDbType.VarChar, 50).Value = TextBox1.Text
        command5.Parameters.Add("@nomevendedor_balcao", SqlDbType.VarChar, 50).Value = ComboBox2.Text
        command5.Parameters.Add("@codprod_balcao", SqlDbType.VarChar, 50).Value = ProdutosDataGridView2.Item(1, v_SelectRow).Value
        command5.Parameters.Add("@forprod_balcao", SqlDbType.VarChar, 50).Value = ProdutosDataGridView2.Item(4, v_SelectRow).Value
        command5.Parameters.Add("@linhaprod_balcao", SqlDbType.VarChar, 50).Value = ProdutosDataGridView2.Item(5, v_SelectRow).Value
        command5.Parameters.Add("@corprod_balcao", SqlDbType.VarChar, 50).Value = ProdutosDataGridView2.Item(7, v_SelectRow).Value
        command5.Parameters.Add("@quantidadeprod_balcao", SqlDbType.Int).Value = qtdPedMarf
        If RadioButton8.Checked = True Or RadioButton23.Checked = True Then
            command5.Parameters.Add("@NumeroNotaMlb_balcao", SqlDbType.VarChar, 50).Value = NumeroNota2
        End If
        If RadioButton10.Checked = True Then
            command5.Parameters.Add("@NumeroNotaMlb_balcao", SqlDbType.VarChar, 50).Value = "0"
        End If
       

        '--------------------------------------------------------------------------------------------
        ' ESCOLHENDO O PREÇO DA LOJA OU DA NET
        Dim PrecoValor As Double = 0

        If RadioButton10.Checked = True Then
            PrecoValor = ProdutosDataGridView2.Item(8, v_SelectRow).Value
        End If
        
        If RadioButton23.Checked = True Then
            PrecoValor = ProdutosDataGridView2.Item(32, v_SelectRow).Value
        End If

        If RadioButton8.Checked = True Then
            PrecoValor = ProdutosDataGridView2.Item(9, v_SelectRow).Value
        End If

       
        command5.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoValor
        ' --------------------------------------------------------------------------------------------------------
        ' CALCULANDO O TOTAL DO BALCAO POR ÍTEM
        Dim TLProdBalcao As Double = PrecoValor * qtdPedMarf
        Dim TLProdBalcao2 As String = TLProdBalcao.ToString("F2")
        command5.Parameters.Add("@totalprod_balcao", SqlDbType.Float).Value = TLProdBalcao2
        command5.Parameters.Add("@datavenda_prodbalcao", SqlDbType.Date).Value = date_pdv.Text
        command5.Parameters.Add("@nomeProd_balcao", SqlDbType.VarChar, 50).Value = (ProdutosDataGridView2.Item(6, v_SelectRow).Value)
        ' Tlpedido_prodbalcao ainda sem o desconto a vista, caso ele ocorra
        command5.Parameters.Add("@desconto_balcao", SqlDbType.Float).Value = TLProdBalcao2

        ' calcula o custo dos produtos
        Dim Tlpedido_prodbalcao As Double = ((ProdutosDataGridView2.Item(16, v_SelectRow).Value) * (1 + (ProdutosDataGridView2.Item(25, v_SelectRow).Value) / 100)) * qtdPedMarf
        Dim Tlpedido_prodbalcao2 As String = Tlpedido_prodbalcao.ToString("F2")
        command5.Parameters.Add("@Custo_balcao", SqlDbType.Float).Value = Tlpedido_prodbalcao2
        ' calcula o lucro da operação
        Dim LucroBalcao As Double = (1 - (Tlpedido_prodbalcao / TLProdBalcao2)) * 100
        Dim LucroBalcao2 As String = LucroBalcao.ToString("F2")
        command5.Parameters.Add("@vendaOrcamento_balcao", SqlDbType.Float).Value = LucroBalcao2
        command5.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A vista"
        command5.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Cartão"

        Try
            connection5.Open()
            command5.ExecuteNonQuery()
            connection5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        ' ---------------------------------------------------------------------------------
        'Volta para a tela de pedidos e atualiza a tabela ....
        tbcotrl_pdv.SelectedIndex = 0
        BalcaoTableAdapter.Fill(DataSetFinal.balcao)
        BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}%'", TextBox1.Text)

        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
            valor += Linha.Cells(6).Value
        Next

        Label105.Text = valor



    End Sub

    Private Sub CriarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CriarPedidoToolStripMenuItem.Click

        FlagNotaentrada = "valido"

        Dim NumeroNotaENtrada As Integer = 0
        '  TextBox27.Enabled = True

        Try
            NumeroNotaENtrada = InputBox("Digite o número da Nota", "Digite")
            If NumeroNotaENtrada = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        TextBox27.Text = NumeroNotaENtrada
       


        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT * from NotasEntrada    where NumeroNotaEntrada = " & "'" & NumeroNotaENtrada & "'"
        con.Open()


        'REM verifica se cdigo de contas já existe banco do dados para não gravar duas vezes

        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try
            If lrd.Read() = True Then

                MessageBox.Show("O código já foi cadastrado !")
                CriarPedidoToolStripMenuItem.Enabled = True
                DeletarItemToolStripMenuItem.Enabled = True
                TextBox27.Clear()
                con.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()

        CriarPedidoToolStripMenuItem.Enabled = False
        DeletarItemToolStripMenuItem.Enabled = False
        Button67.Enabled = True

       
        


    End Sub

    Private Sub ComboBox13_TextChanged(sender As Object, e As EventArgs)
        ' ProdutosBindingSource1.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}%'", ComboBox13.Text, TextBox26.Text)
    End Sub

    Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs)
        ' ProdutosBindingSource1.Filter = String.Format("nome_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}%'", TextBox27.Text, TextBox26.Text)
    End Sub

    Private Sub TabControlPedMarf_Click(sender As Object, e As EventArgs) Handles TabControlPedMarf.Click
        ' pegando os dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month

        Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
        DateTimePicker24.Text = Date.Now
        DateTimePicker23.Text = DateAdd("d", -90, DateTime.Now)

        ProdutosBindingSource1.Filter = String.Empty



    End Sub

    Private Sub dataGridPediMarf_DoubleClick(sender As Object, e As EventArgs) Handles dataGridPediMarf.DoubleClick

        'If FlagNotaentrada <> "valido" Then
        '    Exit Sub
        'End If

        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim command As SqlCommand


        'Dim v_SelectRow As Integer
        'v_SelectRow = Me.dataGridPediMarf.CurrentRow.Index

        'TextBox210.Text = dataGridPediMarf.Item(1, v_SelectRow).Value
        'TextBox215.Text = dataGridPediMarf.Item(5, v_SelectRow).Value

        '' -----------------------------------
        '' Pegar a quantidade de entrada
        'Dim QuantidadeEntradaNota As Integer = 0

        'Try
        '    QuantidadeEntradaNota = InputBox("Digite a quantidade comprada", "Digite", 0)
        '    If QuantidadeEntradaNota = 0 Then
        '        MessageBox.Show("Operação cancelada !!!")
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'TextBox26.Text = QuantidadeEntradaNota
        '' -----------------------------------------
        '' Pegar o preço de entrada
        'Dim PrecoEntradaNota As Double = 0
        'Try
        '    PrecoEntradaNota = InputBox("Digite o preço de entrada sem ipi", "Digite", 0)
        '    If PrecoEntradaNota = 0 Then
        '        MessageBox.Show("Operação cancelada !!!")
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'TextBox64.Text = PrecoEntradaNota

        '' ----------------------------
        '' lendo o valor da tabela de produtos

        'command = connection.CreateCommand()
        'command.CommandText = "select * from produtos where nome_prod = '" & TextBox215.Text & "'"
        'connection.Open()
        'Dim lrd As SqlDataReader = command.ExecuteReader()

        'Dim EstoqueAtual As Integer = 0
        'Dim CustoAtual As Double = 0
        'Dim IpiProduto As Double = 0
        'Dim MkProduto As Double = 0
        'Dim PrecoVenda As Double = 0

        'While lrd.Read()
        '    CustoAtual = lrd("custo_prod")
        '    EstoqueAtual = lrd("estoqueatual_prod")
        '    IpiProduto = lrd("ipi_prod")
        '    MkProduto = lrd("markup_prod")

        'End While
        'connection.Close()
        '' calculando o estoque com a nova entrada de material
        'EstoqueAtual += QuantidadeEntradaNota
        'PrecoVenda = ((PrecoEntradaNota * (1 + (IpiProduto / 100))) / ((100 - MkProduto) / 100)).ToString("F2")

        'If CustoAtual <> PrecoEntradaNota Then
        '    ' mostrando o resultado para alterar o custo
        '    Dim result = MessageBox.Show("Custo Atual : " & CustoAtual, "Custo Lançado(se quiser alterar clique em SIM) : " & TextBox64.Text, MessageBoxButtons.YesNo)
        '    If result = DialogResult.No Then
        '        command = connection.CreateCommand()
        '        command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod where id_codprod=@id_codprod "
        '        command.CommandType = CommandType.Text
        '        command.Parameters.Add("@id_codprod", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(0, v_SelectRow).Value
        '        command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = EstoqueAtual

        '    ElseIf result = DialogResult.Yes Then
        '        command = connection.CreateCommand()
        '        command.CommandText = "update produtos set custo_prod=@custo_prod,estoqueatual_prod=@estoqueatual_prod, precovarejo_prod=@precovarejo_prod, precoatacado_prod = @precoatacado_prod where id_codprod=@id_codprod "
        '        command.CommandType = CommandType.Text
        '        command.Parameters.Add("@id_codprod", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(0, v_SelectRow).Value
        '        command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = EstoqueAtual
        '        command.Parameters.Add("@custo_prod", SqlDbType.Float).Value = PrecoEntradaNota
        '        command.Parameters.Add("@precovarejo_prod", SqlDbType.Float).Value = PrecoVenda
        '        command.Parameters.Add("@precoatacado_prod", SqlDbType.Float).Value = PrecoVenda

        '    End If
        'Else

        '    command = connection.CreateCommand()
        '    command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod where id_codprod=@id_codprod "
        '    command.CommandType = CommandType.Text
        '    command.Parameters.Add("@id_codprod", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(0, v_SelectRow).Value
        '    command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = EstoqueAtual
        'End If

        '' gravar dados de alteração da tabela produtos



        'Try
        '    connection.Open()
        '    command.ExecuteNonQuery()
        '    connection.Close()
        'Catch ex As Exception
        '    MessageBox.Show("Algo ocorreu errado")
        '    MessageBox.Show(ex.ToString())

        'Finally
        '    connection.Close()
        'End Try

        'Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
        '' --------------------------------------
        '' Gravar od dados da tabela


        'command = connection.CreateCommand()
        'command.CommandText = "INSERT INTO NotasEntrada (FornecedorEntrada,NumeroNotaEntrada,LinhaProdutoEntrada,CorProdutoEntrada,QuantidadeNotaEntrada,PrecoNotaEntrada,DataNotaEntrada, CodProdEntrada, NomeProdEntrada) values (@FornecedorEntrada,@NumeroNotaEntrada,@LinhaProdutoEntrada,@CorProdutoEntrada,@QuantidadeNotaEntrada,@PrecoNotaEntrada,@DataNotaEntrada, @CodProdEntrada, @NomeProdEntrada)"

        'command.CommandType = CommandType.Text

        'command.Parameters.Add("@FornecedorEntrada", SqlDbType.VarChar, 50).Value = ComboBox13.Text
        'command.Parameters.Add("@NumeroNotaEntrada", SqlDbType.VarChar, 50).Value = TextBox27.Text
        'command.Parameters.Add("@LinhaProdutoEntrada", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(4, v_SelectRow).Value
        'command.Parameters.Add("@CorProdutoEntrada", SqlDbType.VarChar, 50).Value = dataGridPediMarf.Item(6, v_SelectRow).Value
        'command.Parameters.Add("@QuantidadeNotaEntrada", SqlDbType.Float).Value = QuantidadeEntradaNota
        'command.Parameters.Add("@PrecoNotaEntrada", SqlDbType.Float).Value = PrecoEntradaNota
        'command.Parameters.Add("@DataNotaEntrada", SqlDbType.Date).Value = DateTimePicker36.Text
        'command.Parameters.Add("@CodProdEntrada", SqlDbType.VarChar, 50).Value = TextBox210.Text
        'command.Parameters.Add("@NomeProdEntrada", SqlDbType.VarChar, 50).Value = TextBox215.Text

        '' a seguir comandos para gravar os ítens coletados do formulário ------------------
        'Try
        '    connection.Open()
        '    command.ExecuteNonQuery()
        '    connection.Close()
        '    MessageBox.Show("Sucesso!")
        'Catch ex As Exception
        '    MessageBox.Show("Algo ocorreu errado")
        '    MessageBox.Show(ex.ToString())
        'Finally
        '    connection.Close()
        'End Try

        'TabControlPedMarf.SelectedIndex = 0
        'Me.NotasEntradaTableAdapter.Fill(Me.DataSetFinal.NotasEntrada)
        'NotasEntradaBindingSource.Filter = String.Format("NumeroNotaEntrada LIKE '{0}'", TextBox27.Text)


    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        copiarDiretorio(TextBox28.Text, TextBox29.Text)
        copiarDiretorio(TextBox28.Text, TextBox219.Text)

    End Sub
    'Public Class Form1
    '    Inherits System.Windows.Forms.Form
    Private Sub copiarDiretorio(ByVal CaminhoFonte As String, ByVal CaminhoDestino As String, Optional ByVal Sobrepor As Boolean = False)

        Dim DiretorioFonte As String = TextBox28.Text
        Dim DiretorioDestino As String = TextBox29.Text
        My.Computer.FileSystem.CopyDirectory(DiretorioFonte, DiretorioDestino, True)

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        OpenFileDialog1.InitialDirectory = "e:\"
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|Todos (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
    End Sub

    

    Private Sub localizandoCFOP()

        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        'command = connection.CreateCommand()
        'command.CommandText = "select * from TabelaCFOP where  codigo_cfop = '" & cbx_CFOP.Text & "'"

        'connection.Open()

        'Dim lrd As SqlDataReader = command.ExecuteReader()

        'While lrd.Read()


        '    If lrd("descricao_cfop") Is DBNull.Value Then
        '        MessageBox.Show("esse CFOP não existe")
        '        cbx_CFOP.Text = ""
        '        Exit Sub
        '    Else
        '        TextBox30.Text = lrd("descricao_cfop")
        '    End If

        '    If lrd("operacao") Is DBNull.Value Then
        '        MessageBox.Show("esse CFOP não existe")
        '        cbx_CFOP.Text = ""
        '    Else
        '        TextBox31.Text = lrd("operacao")
        '    End If

        'End While
        'connection.Close()

    End Sub


    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        localizandoCFOP()
    End Sub

    Private Sub cbx_CFOP_TextChanged(sender As Object, e As EventArgs) Handles cbx_CFOP.TextChanged
        TextBox30.Clear()
        TextBox31.Clear()

    End Sub


    Private Sub Vendedor_pedComboBox_TextChanged(sender As Object, e As EventArgs) Handles Vendedor_pedComboBox.TextChanged

        Dim connection As SqlConnection
        '  Try
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' Catch ex As Exception
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=sa;Password=12345678")
        ' End Try


        command = connection.CreateCommand()
        command.CommandText = "select * from vendedor where nome_vendedor = '" & Vendedor_pedComboBox.Text & "'"

        connection.Open()

        Dim lrd As SqlDataReader = command.ExecuteReader()
        Dim TipoVenda As String = ""
        Dim comissao As Double = 0

        While lrd.Read()
            TipoVenda = lrd("nickname")
            comissao = lrd("comissao_vendedor")
        End While

        connection.Close()

        txt_TipoVendaPedido.Text = TipoVenda
        TextBox62.Text = comissao
    End Sub

    Private Sub RadioButton9_Click(sender As Object, e As EventArgs)

     



    End Sub

    Private Sub RadioButton10_Click(sender As Object, e As EventArgs)

       

    End Sub

  

   
    ' MOSTRA A TELA PREVIEW E IMPRESSÃO ESCOLHENDO A IMPRESSORA

    Dim WithEvents PDB As New ToolStripButton("Printer")

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        OpenFileDialog1.InitialDirectory = "f:\"
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|Todos (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        PrintPreviewDialog1.Document = PrintDocument1
        DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrinterSettings.PrinterName = "\\SERVFER-PC\EPSON LX-300+ /II"
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).Items.Add(PDB)
    End Sub
    Private Sub PDB_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles PDB.Click
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles btn_CalcOrcRel.Click
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM itemOrcamento WHERE data_ItemOrc BETWEEN   convert (datetime, '" & DateTimePicker4.Text & "' ,103)  and convert (datetime, '" & DateTimePicker5.Text & "' ,103)"

        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "itemOrcamento")
            connection.Close()
            ItemOrcamentoDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemOrcamentoDataGridView1.Rows
            valor += Linha.Cells(4).Value
        Next
        txt_VrTlOrcRel.Text = valor
        TextBox10.Text = ItemOrcamentoDataGridView1.RowCount()

    End Sub

    Private Sub ItemPedidosDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles ItemPedidosDataGridView.DoubleClick

        If Button61.Enabled = True Then


            Dim v_SelectRow As Integer
            v_SelectRow = Me.ItemPedidosDataGridView.CurrentRow.Index


            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "update ItemPedidos set entregue_item =@entregue_item, dataentrega_item = @dataentrega_item  where id_item = @id_item"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@id_item", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(10, v_SelectRow).Value

            If ItemPedidosDataGridView.Item(16, v_SelectRow).Value = "Não Entregue" Then
                command.Parameters.Add("@entregue_item", SqlDbType.VarChar, 50).Value = "Entregue"
                command.Parameters.Add("@dataentrega_item", SqlDbType.Date).Value = DateAdd("d", -1, DateTime.Now)
            Else
                command.Parameters.Add("@entregue_item", SqlDbType.VarChar, 50).Value = "Não Entregue"
                command.Parameters.Add("@dataentrega_item", SqlDbType.Date).Value = "01/01/1900"

            End If

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
            ' ------------------------------------------------
            ' ----------------------------
            ' lendo o valor da tabela de produtos

            command = connection.CreateCommand()
            command.CommandText = "select * from produtos where cod_prod = '" & ItemPedidosDataGridView.Item(12, v_SelectRow).Value & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            Dim EstoqueAtual As Integer = 0
            While lrd.Read()
                EstoqueAtual = lrd("estoqueatual_prod")
            End While
            connection.Close()
            ' ---------------------------------------------
            ' Calculando o estoque 
            Dim SomandoEstoqueAtual As Integer = 0
            Dim SubtraindoEstoqueAtual As Integer = 0

            SomandoEstoqueAtual = 0    ' EstoqueAtual + ItemPedidosDataGridView.Item(5, v_SelectRow).Value
            SubtraindoEstoqueAtual = 0 ' EstoqueAtual - ItemPedidosDataGridView.Item(5, v_SelectRow).Value

            command = connection.CreateCommand()
            command.CommandText = "update produtos set  estoqueatual_prod = @estoqueatual_prod  where cod_prod = @cod_prod"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView.Item(12, v_SelectRow).Value

            If ItemPedidosDataGridView.Item(16, v_SelectRow).Value = "Não Entregue" Then
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.VarChar, 50).Value = SubtraindoEstoqueAtual
             Else
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.VarChar, 50).Value = SomandoEstoqueAtual
          
            End If

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

            Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
        Else
            MessageBox.Show("As mudanças não estão habilitadas")
        End If

    End Sub

    Private Sub PrintPreviewDialog2_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog2.Load

        Try

            PrintPreviewDialog2.Document = PrintDocument1
            DirectCast(PrintPreviewDialog2, Form).WindowState = FormWindowState.Maximized
            PrintDialog2.Document = PrintDocument1
            PrintDialog2.PrinterSettings.PrinterName = "\\SERVIDOR\EPSON L355 Series (Caixa)"


            CType(PrintPreviewDialog2.Controls(1), ToolStrip).Items.Add(PDB)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try



    End Sub

    Private Sub PrintDocument10_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument10.PrintPage
        'rem cabeçalho 
        e.Graphics.DrawString(" ***  MARFINITE MOGI - BugigangasMil ***", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 5)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 10, 10)
        e.Graphics.DrawString("Av.Henrique Peres, 1880 - Mogi Das Cruzes SP", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 25)
        e.Graphics.DrawString("cnpj:72844228/0001-79 ie:454131384115", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 40)
        e.Graphics.DrawString(date_pdv.Text + "      Código : " + TextBox1.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 10, 55)
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 60)
        e.Graphics.DrawString("CUPOM", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 30, 80)
        e.Graphics.DrawString("Nome do Produto-Quantidade-Preço-Total- desconto", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 95)


        Dim x As Integer
        For x = 0 To BalcaoDataGridView.RowCount() - 1

            Dim t As Integer = BalcaoDataGridView.Item(0, x).Value.Length()
            If t > 20 Then
                e.Graphics.DrawString(BalcaoDataGridView.Item(0, x).Value.substring(0, 15), New Font("arial", 7, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))
            Else
                e.Graphics.DrawString(BalcaoDataGridView.Item(0, x).Value.substring(0, t), New Font("arial", 7, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))
            End If

            e.Graphics.DrawString(BalcaoDataGridView.Item(4, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 100, 110 + (x * 15))
            e.Graphics.DrawString(BalcaoDataGridView.Item(5, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 125, 110 + (x * 15))
            e.Graphics.DrawString(BalcaoDataGridView.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 170, 110 + (x * 15))
            If RadioButton5.Checked = True Then
                e.Graphics.DrawString(BalcaoDataGridView.Item(6, x).Value * 0.97, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 225, 110 + (x * 15))
            Else
                e.Graphics.DrawString(BalcaoDataGridView.Item(6, x).Value, New Font("arial", 8, FontStyle.Regular), Brushes.Black, 225, 110 + (x * 15))
            End If
        Next
        x += 1
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 12))

        x += 1
        e.Graphics.DrawString("TOTAL :       R$ ", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        e.Graphics.DrawString(Label105.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))

        x += 1
        If RadioButton6.Checked = True Then
            e.Graphics.DrawString("A PRAZO", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        Else
            e.Graphics.DrawString("À VISTA", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        End If

        Dim pagamento As String = 0
        If RadioButton1.Checked = True Then
            pagamento = 1
        End If
        If RadioButton2.Checked = True Then
            pagamento = 2
        End If
        If RadioButton3.Checked = True Then
            pagamento = 3
        End If
        If RadioButton4.Checked = True Then
            pagamento = 4
        End If


        Select Case pagamento
            Case 1
                e.Graphics.DrawString("DINHEIRO", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))

            Case 2
                e.Graphics.DrawString("CARTÃO", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))

            Case 3
                e.Graphics.DrawString("BOLETO", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))

            Case 4
                e.Graphics.DrawString("OUTROS", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))

        End Select



        x += 1
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 13))
        x += 1
        e.Graphics.DrawString("TROCAS ATÉ 07 DIAS NA LOJA, SOMENTE EM CASO DE DEFEITO", New Font("arial", 6, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("COM ESSE COMPROVANTE", New Font("arial", 6, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("Valor aproximado de Tributos R$", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        ' claculando o tributo
        Dim VrTributo As Double = Label105.Text * 0.3224
        Dim VrTributo2 As String = VrTributo.ToString("F2")
        e.Graphics.DrawString(VrTributo2, New Font("arial", 8, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))
        e.Graphics.DrawString(" (32,24%) ", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 230, 110 + (x * 15))

        x += 1
        e.Graphics.DrawString(" **** Não é válido como CUPOM FISCAL *****", New Font("arial", 8, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("www.marfinitemogi.com.br", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))
        x += 1
        e.Graphics.DrawString("11 47226115 ", New Font("arial", 8, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))
        ' vendedor
        x += 1
        e.Graphics.DrawString("VENDEDOR : ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 10, 110 + (x * 15))
        e.Graphics.DrawString(ComboBox2.Text, New Font("arial", 10, FontStyle.Bold), Brushes.Black, 200, 110 + (x * 15))


        x += 1
        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", New Font("arial", 15, FontStyle.Regular), Brushes.Black, 10, 110 + (x * 15))

    End Sub

    Private Sub Button32_Click_1(sender As Object, e As EventArgs) Handles Button32.Click

        ' trabalhando os radiobutton - formas de pagamento
        If RadioButton5.Checked = False And
            RadioButton6.Checked = False Then
            MessageBox.Show("Por favor, escolha a vista ou a prazo")
            Exit Sub

        End If
        If RadioButton1.Checked = False And
            RadioButton2.Checked = False And
            RadioButton3.Checked = False And
            RadioButton4.Checked = False Then
            MessageBox.Show("Escolha a forma de pagamento")
            Exit Sub
        End If
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "update balcao set totalpedido_prodbalcao=@totalpedido_prodbalcao,Avista_APrazo_balcao=@Avista_APrazo_balcao, FormaPgto_balcao=@FormaPgto_balcao  where id2_balcao = '" & TextBox1.Text & "'"
        command.CommandType = CommandType.Text
        command.Parameters.Add("@totalpedido_prodbalcao", SqlDbType.Float).Value = Label105.Text
        ' SALVANDO AS FORMAS DE PAGAMENTO
      
        If RadioButton5.Checked = True Then

            command.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A vista"
        Else
            command.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A prazo"
        End If

        If RadioButton1.Checked = True Then
            command.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Dinheiro"
        End If
        If RadioButton2.Checked = True Then
            command.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Cartão"
        End If
        If RadioButton3.Checked = True Then
            command.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Boleto"
        End If
        If RadioButton4.Checked = True Then
            command.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Outros"
        End If
     
        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()


        Catch ex As Exception

            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())
            connection.Close()

        End Try

        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)
        ' manda imprimir o boleto
        PrintPreviewDialog3.ShowDialog()
        ComboBox2.Text = ""
        btn_iniciarVenda.Enabled = True

        ' apaga textbox1  que se repete
        TextBox1.Clear()
        TextBox1.Text = ""
        BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}'", "kouigsfdghiugiug")

        'coloca A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Insert(0, tbpg_produtos)
        TabControl1.TabPages.Insert(1, tbpg_clientes)
        TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        TabControl1.TabPages.Insert(5, tab_nfe)
        TabControl1.TabPages.Insert(6, pedidos)
        TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        TabControl1.TabPages.Insert(9, tbpg_bkup)
        TabControl1.TabPages.Insert(10, tbpg_orcamento)
        TabControl1.TabPages.Insert(11, tbg_relatorios)
        ' outro tabcontrol
        tbcotrl_pdv.TabPages.Insert(1, tbpg_VendasBalcao)
        tbcotrl_pdv.TabPages.Insert(2, TabPage6)

        'trabalhando com os radiobutton
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        RadioButton5.Enabled = False
        RadioButton6.Enabled = False


        ' limpando os campos
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox3.Text = ""
        Label105.Text = ""
        Button32.Enabled = False
        ReabrirVendaBalcao = ""
        btn_addProd.Enabled = False
        BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}'", "kouighiugiug")




    End Sub

    Private Sub PrintPreviewDialog3_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog3.Load

        PrintPreviewDialog3.Document = PrintDocument10
        DirectCast(PrintPreviewDialog3, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument10
        PrintDialog1.PrinterSettings.PrinterName = "\\silvia\MP-4200 TH"
        'PrintDialog1.PrinterSettings.PrinterName = "\\Central2\MP-4200 TH"
        CType(PrintPreviewDialog3.Controls(1), ToolStrip).Items.Add(PDB)

    End Sub


    Private Sub PrintPreviewDialog4_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog4.Load

        PrintPreviewDialog4.Document = PrintDocument2
        DirectCast(PrintPreviewDialog4, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument2
        PrintDialog1.PrinterSettings.PrinterName = "\\SERVIDOR\EPSON L355 Series (Caixa)"
        CType(PrintPreviewDialog4.Controls(1), ToolStrip).Items.Add(PDB)

    End Sub

    Private Sub ProdutosDataGridView2_DoubleClick_1(sender As Object, e As EventArgs) Handles ProdutosDataGridView2.DoubleClick
        GravarBalcao()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        BalcaoDataGridView.DataSource = BalcaoBindingSource
        BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}%'", TextBox3.Text)

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        BalcaoBindingSource.Filter = String.Empty

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim NumeroDelecao As String = ""

        Try
            Dim v_SelectRow As Integer
            v_SelectRow = Me.BalcaoDataGridView.CurrentRow.Index

            Dim result = MessageBox.Show("Confirmar a Deleção?", "Atenção!!!", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                NumeroDelecao = BalcaoDataGridView.Item(14, v_SelectRow).Value
                Dim command As SqlCommand
                command = connection.CreateCommand()
                command.CommandText = "delete from balcao where id_balcao = @id_cod"
                command.CommandType = CommandType.Text

                command.Parameters.Add("@id_cod", SqlDbType.VarChar, 50).Value = NumeroDelecao

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()


                ' -----------------------------------------
                ' -----------------------------------------
                ' lendo a quantidade da tabela de produtos

                'command = connection.CreateCommand()
                'command.CommandText = "select * from produtos where nome_prod = '" & BalcaoDataGridView.Item(0, v_SelectRow).Value & "'"
                'connection.Open()
                'Dim lrd As SqlDataReader = command.ExecuteReader()

                'Dim EstoqueAtual As Integer = 0


                'While lrd.Read()
                '    EstoqueAtual = lrd("estoqueatual_prod")
                'End While
                'connection.Close()
                'TextBox220.Text = EstoqueAtual

                '' calculando o estoque com o cancelamento da entrada
                'EstoqueAtual += BalcaoDataGridView.Item(4, v_SelectRow).Value
                'TextBox221.Text = BalcaoDataGridView.Item(4, v_SelectRow).Value
                'command = connection.CreateCommand()
                'command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod where nome_prod=@nome_prod "
                'command.CommandType = CommandType.Text
                'command.Parameters.Add("@nome_prod", SqlDbType.VarChar, 50).Value = BalcaoDataGridView.Item(0, v_SelectRow).Value
                'command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = EstoqueAtual

                '' apagar dados de alteração da tabela produtos

                'Try
                '    connection.Open()
                '    command.ExecuteNonQuery()
                '    connection.Close()
                'Catch ex As Exception

                '    MessageBox.Show(ex.ToString())

                'Finally
                '    connection.Close()
                'End Try


                ' --------------------------------------
                Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)
                Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

            End If

        Catch ex As Exception
            MessageBox.Show("Impossível apagar campos nulo")
        End Try

        'somar valor da coluna
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
            valor += Linha.Cells(6).Value
        Next
        Label105.Text = valor
    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        If RadioButton5.Checked = True Then
            'somar valor da coluna
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor * 0.97

        Else
            'somar valor da coluna
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor
        End If

        ' calcular o valor de desconto a vista e gravar no banco de dados

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

         Dim valorCalculadoAvista As String
        Dim command7 As SqlCommand
        command7 = connection.CreateCommand()
        command7.CommandType = CommandType.Text

        Dim VariavelCustoBalcao As Double
        Dim xx As Integer
        For xx = 0 To BalcaoDataGridView.RowCount() - 1

            VariavelCustoBalcao = 0.97
            valorCalculadoAvista = BalcaoDataGridView.Item(6, xx).Value * VariavelCustoBalcao
            Dim valorCalculadoAvista2 = valorCalculadoAvista.Replace(",", ".")
      
            Dim PorcentagemBalcao As Double = (1 - (BalcaoDataGridView.Item(13, xx).Value / valorCalculadoAvista)) * 100
            Dim PorcentagemBalcao2 As String = PorcentagemBalcao.ToString("F2")
            command7.CommandText = "update balcao set vendaOrcamento_balcao= '" & PorcentagemBalcao2 & "', desconto_balcao = '" & valorCalculadoAvista2 & "' where id_balcao = '" & BalcaoDataGridView.Item(14, xx).Value & "'"

            Try
                connection.Open()
                command7.ExecuteNonQuery()
                connection.Close()


            Catch ex As Exception

                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())
                connection.Close()

            End Try
        Next

        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)


    End Sub

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click
        If RadioButton5.Checked = True Then
            'somar valor da coluna
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor * 0.97

        Else
            'somar valor da coluna
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor
        End If

        ' calcular o valor de desconto a vista e gravar no banco de dados

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim valorCalculadoAvista As String
        Dim command7 As SqlCommand
        command7 = connection.CreateCommand()
        command7.CommandType = CommandType.Text

        Dim VariavelCustoBalcao As Double
        Dim xx As Integer
        For xx = 0 To BalcaoDataGridView.RowCount() - 1

            VariavelCustoBalcao = 0.97
            valorCalculadoAvista = BalcaoDataGridView.Item(6, xx).Value
            Dim valorCalculadoAvista2 = valorCalculadoAvista.Replace(",", ".")
       
            Dim PorcentagemBalcao As Double = (1 - (BalcaoDataGridView.Item(13, xx).Value / valorCalculadoAvista)) * 100
            Dim PorcentagemBalcao2 As String = PorcentagemBalcao.ToString("F2")
            command7.CommandText = "update balcao set vendaOrcamento_balcao= '" & PorcentagemBalcao2 & "', desconto_balcao = '" & valorCalculadoAvista2 & "' where id_balcao = '" & BalcaoDataGridView.Item(14, xx).Value & "'"

            Try
                connection.Open()
                command7.ExecuteNonQuery()
                connection.Close()


            Catch ex As Exception

                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())
                connection.Close()

            End Try
        Next

        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)

    End Sub


   

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        If TextBox32.Text = "" Then
            MessageBox.Show("Clicar em um ítem para poder reabrir a venda")
            Exit Sub
        End If

        ReabrirVendaBalcao = "reaberta"

        ' acertando os botões
        TextBox1.Text = TextBox3.Text ' código de venda
        Button12.Enabled = True
        Button11.Enabled = False
        Button11.Enabled = True
        ComboBox2.Text = TextBox32.Text ' vendedor
        ComboBox2.Enabled = False
        ' trabalhando as formas de venda
        If TextBox33.Text = "A prazo" Then
            RadioButton6.Checked = True
        Else
            RadioButton5.Checked = True
        End If
        ' trabalhando com as formas de pagamento
        If TextBox34.Text = "Dinheiro" Then
            RadioButton1.Checked = True
        End If
        If TextBox34.Text = "Cartão" Then
            RadioButton2.Checked = True
        End If
        If TextBox34.Text = "Boleto" Then
            RadioButton3.Checked = True
        End If
        If TextBox34.Text = "Outros" Then
            RadioButton4.Checked = True
        End If

        'somar valor da coluna
        If RadioButton5.Checked = True Then
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor * 0.97
        Else
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView.Rows
                valor += Linha.Cells(6).Value
            Next
            Label105.Text = valor
        End If

        btn_iniciarVenda.Enabled = False
        Button32.Enabled = False

        'RETIRA A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Remove(tbpg_produtos)
        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        ' TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)
        '    outro tabcontrol
        tbcotrl_pdv.TabPages.Insert(1, tbpg_produtosPDV)
        tbcotrl_pdv.TabPages.Remove(tbpg_VendasBalcao)

        ' ativar alteração
        Button84.Enabled = True


    End Sub

    Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs) Handles TextBox35.TextChanged

        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox35.Text)

    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click

        ClienteBindingSource.Filter = String.Empty
    End Sub



    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker6.Text & "' ,103)  and convert (datetime, '" & DateTimePicker7.Text & "' ,103)"
        '  convert (datetime, '" & DateTimePicker6.Text & "' ,103)  and convert (datetime, '" & DateTimePicker7.Text & "' ,103)
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView3.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView3.Rows
            valor += Linha.Cells(10).Value
        Next
        TextBox36.Text = valor.ToString("F2")

        ' soma a coluna dos valores da comissão dos vendedores e o põe no campo certo
        Dim valor5 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView3.Rows
            valor5 += Linha.Cells(23).Value
        Next
        TextBox63.Text = valor5.ToString("F2")
        ' pegando dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim dia As Integer = Today.Day
        ' descobrindo quantos dias tem um mes
        Dim quant As Integer = System.DateTime.DaysInMonth(ano, mes)
        ' mostra os dias do mês
        TextBox142.Text = quant

        ' calculando a projeção
        TextBox37.Text = ((valor / dia) * quant).ToString("F2")
        TextBox40.Text = (valor / dia).ToString("F2")
        Dim valorCusto As Decimal = 0

        ' calculando o custo
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView3.Rows
            valorCusto += Linha.Cells(16).Value
        Next
        TextBox45.Text = valorCusto.ToString("F2")

        'calculando a porcentagem de lucro
        If valorCusto = 0 And valor5 = 0 Then
        Else
            Dim VrPorcentagem As Double = (1 - ((valorCusto + valor5) / valor)) * 100
            TextBox46.Text = VrPorcentagem.ToString("F2")
        End If
        ' -----------------------------------------------------------------
        ' CALCULANDO AS VENDAS do DIA
        Dim sql5 As String = "SELECT * FROM ItemPedidos WHERE data_item =  convert (datetime, '" & DateTimePicker7.Text & "' ,103)"
        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView3.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '------------------------------------------------------------------
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor15 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView3.Rows
            valor15 += Linha.Cells(10).Value
        Next
        TextBox79.Text = valor15.ToString("F2")

    End Sub

    Private Sub TabControl4_Click(sender As Object, e As EventArgs) Handles TabControl4.Click
        ' pegando os dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month

        Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
        DateTimePicker7.Text = Date.Now
        DateTimePicker9.Text = Date.Now
        DateTimePicker5.Text = Date.Now
        DateTimePicker11.Text = Date.Now
        DateTimePicker17.Text = Date.Now
        DateTimePicker22.Text = Date.Now
        DateTimePicker26.Text = Date.Now

        DateTimePicker6.Text = primeiroDia.ToString
        DateTimePicker8.Text = primeiroDia.ToString
        DateTimePicker4.Text = primeiroDia.ToString
        DateTimePicker10.Text = primeiroDia.ToString
        DateTimePicker16.Text = primeiroDia.ToString
        DateTimePicker21.Text = primeiroDia.ToString
        DateTimePicker25.Text = primeiroDia.ToString

        ' EXEMPLO DE COMO ACHAR O ÚLTIMO DIA DO ANO
        'Dim ultimoDia As DateTime = New DateTime(ano, mes + 1, 1).AddDays(-1)
        'DateTimePicker7.Text = ultimoDia.ToString

    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker8.Text & "' ,103)  and convert (datetime, '" & DateTimePicker9.Text & "' ,103)and nomevendedor_balcao <> 'fernando'"
        '  "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker8.Text & "' ,103)  and convert (datetime, '" & DateTimePicker9.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView2.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView2.Rows
            valor += Linha.Cells(12).Value
        Next
        ' *******************************************************
        Dim VendasReaisBalcao As Double = 0
        Dim sql25 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker8.Text & "' ,103)  and convert (datetime, '" & DateTimePicker9.Text & "' ,103)   and nomevendedor_balcao = 'fernando'"
        Dim dataadapter25 As New SqlDataAdapter(sql25, connection)
        Dim ds25 As New DataSet()
        Try
            connection.Open()
            dataadapter25.Fill(ds25, "balcao")
            connection.Close()
            BalcaoDataGridView6.DataSource = ds25.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma da venda da bugigangas
        Dim VendasBugigangas As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView6.Rows
            VendasBugigangas += Linha.Cells(12).Value
        Next
        VendasReaisBalcao = valor '- VendasBugigangas
        TextBox38.Text = VendasReaisBalcao
        '******************************************************
        ' soma a coluna dos valores e o põe no campo certo
        Dim valorCusto As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView2.Rows
            valorCusto += Linha.Cells(17).Value
        Next
        TextBox42.Text = valorCusto.ToString("F2")
        ' pegando dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim dia As Integer = Today.Day
        ' descobrindo quantos dias tem um mes
        Dim quant As Integer = System.DateTime.DaysInMonth(ano, mes)
        ' mostra os dia de um mês
        TextBox143.Text = quant
        ' calculando a projeção
        TextBox39.Text = ((VendasReaisBalcao / dia) * quant).ToString("F2")
        ' calculando a média
        TextBox41.Text = (VendasReaisBalcao / dia).ToString("F2")
        'calculando a porcentagem de lucro
        If valorCusto = 0 Or valor = 0 Then
        Else
            Dim VrPorcentagem As Double = (1 - (valorCusto / VendasReaisBalcao)) * 100
            TextBox43.Text = VrPorcentagem.ToString("F2")
        End If
        ' -----------------------------------
        ' ticket médio
        Dim sql65 As String = "SELECT DISTINCT id2_balcao FROM [dbo].[balcao] WHERE [datavenda_prodbalcao] BETWEEN   convert (datetime, '" & DateTimePicker8.Text & "' ,103)  and convert (datetime, '" & DateTimePicker9.Text & "' ,103) and nomevendedor_balcao <> 'fernando'"
        Dim dataadapter65 As New SqlDataAdapter(sql65, connection)
        Dim ds65 As New DataSet()
        Try
            connection.Open()
            dataadapter65.Fill(ds65, "balcao")
            connection.Close()
            BalcaoDataGridView2.DataSource = ds65.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' MessageBox.Show(BalcaoDataGridView2.RowCount())
        TextBox197.Text = BalcaoDataGridView2.RowCount()
        TextBox198.Text = BalcaoDataGridView2.RowCount() / dia
        TextBox190.Text = TextBox38.Text / BalcaoDataGridView2.RowCount()

        ' --------------------------------------------------------------------
        ' Calculando os tichets emitidos no dia
        ' ticket médio
        Dim sql30 As String = "SELECT DISTINCT id2_balcao FROM [dbo].[balcao] WHERE  datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker9.Text & "' ,103) and nomevendedor_balcao <> 'fernando'"
        Dim dataadapter30 As New SqlDataAdapter(sql30, connection)
        Dim ds30 As New DataSet()
        Try
            connection.Open()
            dataadapter30.Fill(ds30, "balcao")
            connection.Close()
            BalcaoDataGridView2.DataSource = ds30.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        TextBox199.Text = BalcaoDataGridView2.RowCount()


        ' ----------------------------------------------------------------
        '' CALCULANDO AS VENDAS Do DIA
        Dim sql20 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao = convert (datetime, '" & DateTimePicker9.Text & "' ,103) and nomevendedor_balcao <> 'fernando'"
        '  "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker8.Text & "' ,103)  and convert (datetime, '" & DateTimePicker9.Text & "' ,103)"
        Dim dataadapter20 As New SqlDataAdapter(sql20, connection)
        Dim ds20 As New DataSet()
        Try
            connection.Open()
            dataadapter20.Fill(ds20, "balcao")
            connection.Close()
            BalcaoDataGridView2.DataSource = ds20.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView2.Rows
            valor20 += Linha.Cells(9).Value
        Next
        TextBox173.Text = valor20.ToString("F2")

      
       

    End Sub

    Private Sub PrintPreviewDialog5_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog5.Load

        PrintPreviewDialog5.Document = PrintDocument3
        DirectCast(PrintPreviewDialog5, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument3
        'PrintDialog1.PrinterSettings.PrinterName = "\\bematech\EPSON LX-300+ /II"
        PrintDialog1.PrinterSettings.PrinterName = "\\CENTRAL2\EPSON LX-300+ /II"
        CType(PrintPreviewDialog5.Controls(1), ToolStrip).Items.Add(PDB)

    End Sub

    Private Sub TextBox44_TextChanged(sender As Object, e As EventArgs) Handles TextBox44.TextChanged
        ' trocando o binding source(fonte de dados do datagridview) pelo original
        PedidoNFEDataGridView.DataSource = PedidoNFEBindingSource
        'Para comparar inteiros, converter a coluna em string
        PedidoNFEBindingSource.Filter = String.Format("Convert(id_pedidos, 'System.String') like '{0}%'", TextBox44.Text)

    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' CALCULANDO OS TOTAIS

        Dim sql10 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)"

        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo

        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor10 += Linha.Cells(10).Value
        Next
        Label134.Text = valor10.ToString("f2")

        ' calculando o custo
        Dim valorCusto10 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto10 += Linha.Cells(16).Value
        Next
        Label135.Text = valorCusto10.ToString("f2")
        ''calculando a porcentagem de lucro
        Try
            Dim VrPorcentagem10 As Double = (1 - (valorCusto10 / valor10)) * 100
            Label136.Text = VrPorcentagem10.ToString("F2")
        Catch ex As Exception

        End Try

        ' ------------------------------------------------
        ' cadeiras
        Dim sql1 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103) and  linha_item = 'cadeiras'"

        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds1 As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds1, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor1 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor1 += Linha.Cells(10).Value
        Next
        TextBox47.Text = valor1

        ' calculando o custo
        Dim valorCusto1
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto1 += Linha.Cells(16).Value
        Next
        TextBox57.Text = valorCusto1
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem1 As Double = (1 - (valorCusto1 / valor1)) * 100
            TextBox58.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor1 / valor10)) * 100
            Label137.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '---------------------------------------------------------
        ' -----------------------------------------------------
        ' CALCULANDO AS MESAS 
        Dim sql3 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103) and  linha_item = 'mesas'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor3 += Linha.Cells(10).Value
        Next
        TextBox48.Text = valor3

        ' calculando o custo
        Dim valorCusto3 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto3 += Linha.Cells(16).Value
        Next
        TextBox59.Text = valorCusto3.ToString("F2")
        ''calculando a porcentagem de lucro
        Dim VrPorcentagem3 As Double
        If valorCusto3 = 0 Or valor3 = 0 Then
        Else

            VrPorcentagem3 = (1 - (valorCusto3 / valor3)) * 100
        End If
        TextBox60.Text = VrPorcentagem3.ToString("F2")
        Dim cadeiras As Double = TextBox48.Text
        Dim mesas As Double = TextBox47.Text
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor3 / valor10)) * 100
            Label138.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        TextBox61.Text = cadeiras + mesas
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS CAIXAS
        Dim sql4 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'caixas'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor4 += Linha.Cells(10).Value
        Next
        TextBox49.Text = valor4

        ' calculando o custo
        Dim valorCusto4 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto4 += Linha.Cells(16).Value
        Next

        TextBox65.Text = (valorCusto4).ToString("F2")

        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem4 As Double = (1 - (valorCusto4 / valor4)) * 100
            TextBox66.Text = VrPorcentagem4.ToString("F2")
        Catch ex As Exception
            MessageBox.Show("")
        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor4 / valor10)) * 100
            Label144.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
         ' ---------------------------------------------------------------------------------
        'CALCULANDO AS lixeiras
        Dim sql5 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'lixeiras'"

        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor5 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor5 += Linha.Cells(10).Value
        Next
        TextBox50.Text = valor5

        ' calculando o custo
        Dim valorCusto5
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto5 += Linha.Cells(16).Value
        Next
        TextBox67.Text = valorCusto5
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem5 As Double = (1 - (valorCusto5 / valor5)) * 100
            TextBox68.Text = VrPorcentagem5.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor5 / valor10)) * 100
            Label145.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS organizado
        Dim sql6 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'organizado'"

        Dim dataadapter6 As New SqlDataAdapter(sql6, connection)
        Dim ds6 As New DataSet()
        Try
            connection.Open()
            dataadapter6.Fill(ds6, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds6.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor6 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor6 += Linha.Cells(10).Value
        Next
        TextBox51.Text = valor6

        ' calculando o custo
        Dim valorCusto6
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto6 += Linha.Cells(16).Value
        Next
        TextBox69.Text = valorCusto6
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem6 As Double = (1 - (valorCusto6 / valor6)) * 100
            TextBox70.Text = VrPorcentagem6.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try


            Dim VrPorcentagem1 As Double = ((valor6 / valor10)) * 100
            Label146.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ' ---------------------------------------------------------------------------------

        'CALCULANDO AS lixeiras
        Dim sql7 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'piscina'"

        Dim dataadapter7 As New SqlDataAdapter(sql7, connection)
        Dim ds7 As New DataSet()
        Try
            connection.Open()
            dataadapter7.Fill(ds7, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds7.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor7 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor7 += Linha.Cells(10).Value
        Next
        TextBox111.Text = valor7

        ' calculando o custo
        Dim valorCusto7
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto7 += Linha.Cells(16).Value
        Next
        TextBox114.Text = valorCusto7
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem7 As Double = (1 - (valorCusto7 / valor7)) * 100
            TextBox117.Text = VrPorcentagem7.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try

            Dim VrPorcentagem1 As Double = ((valor7 / valor10)) * 100
            Label196.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ' ---------------------------------------------------------------------------------
        ' ---------------------------------------------------------------------------------

        'CALCULANDO AS prod.var
        Dim sql8 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'prod.var'"

        Dim dataadapter8 As New SqlDataAdapter(sql8, connection)
        Dim ds8 As New DataSet()
        Try
            connection.Open()
            dataadapter8.Fill(ds8, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds8.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor8 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor8 += Linha.Cells(10).Value
        Next
        TextBox112.Text = valor8

        ' calculando o custo
        Dim valorCusto8
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto8 += Linha.Cells(16).Value
        Next
        TextBox115.Text = valorCusto8
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem8 As Double = (1 - (valorCusto8 / valor8)) * 100
            TextBox118.Text = VrPorcentagem8.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try

            Dim VrPorcentagem1 As Double = ((valor8 / valor10)) * 100
            Label197.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS pallets
        Dim sql9 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker10.Text & "' ,103)  and convert (datetime, '" & DateTimePicker11.Text & "' ,103)  and  linha_item = 'pallets'"

        Dim dataadapter9 As New SqlDataAdapter(sql9, connection)
        Dim ds9 As New DataSet()
        Try
            connection.Open()
            dataadapter9.Fill(ds9, "PedidoNFE")
            connection.Close()
            ItemPedidosDataGridView4.DataSource = ds9.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor9 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valor9 += Linha.Cells(10).Value
        Next
        TextBox113.Text = valor9

        ' calculando o custo
        Dim valorCusto9 As Double = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
            valorCusto9 += Linha.Cells(16).Value
        Next
        TextBox116.Text = valorCusto9.ToString("F2")
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem9 As Double = (1 - (valorCusto9 / valor9)) * 100
            TextBox119.Text = VrPorcentagem9.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try

            Dim VrPorcentagem1 As Double = ((valor9 / valor10)) * 100
            Label198.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ' ---------------------------------------------------------------------------------

        Label148.Text = 100 - Label137.Text - Label138.Text - Label144.Text - Label145.Text - Label146.Text - Label196.Text - Label197.Text - Label198.Text
        TextBox52.Text = Label134.Text - TextBox47.Text - TextBox48.Text - TextBox49.Text - TextBox50.Text - TextBox51.Text - TextBox111.Text - TextBox112.Text - TextBox113.Text
        TextBox53.Text = Label135.Text - TextBox57.Text - TextBox59.Text - TextBox65.Text - TextBox67.Text - TextBox69.Text - TextBox114.Text - TextBox115.Text - TextBox116.Text
        'calculando a porcentagem de lucro da linha
        Dim VrPorcentagem11 As Double = (1 - (TextBox53.Text / TextBox52.Text)) * 100
        TextBox54.Text = VrPorcentagem11.ToString("F2")
       



    End Sub

   
    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        
      
    End Sub
    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA VERÔNICA
        Dim sql As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker12.Text & "' ,103)  and convert (datetime, '" & DateTimePicker13.Text & "' ,103) and  nomevendedor_balcao = 'verônica'"

        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor += Linha.Cells(9).Value
        Next
        TextBox56.Text = valor.ToString("F2")


        ' CALCULANDO AS VENDAS DA roberto
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker12.Text & "' ,103)  and convert (datetime, '" & DateTimePicker13.Text & "' ,103) and  nomevendedor_balcao = 'alessandro'"

        Dim dataadapter2 As New SqlDataAdapter(sql2, connection)
        Dim ds2 As New DataSet()
        Try
            connection.Open()
            dataadapter2.Fill(ds2, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor2 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor2 += Linha.Cells(9).Value
        Next
        TextBox74.Text = valor2.ToString("F2")
        'TextBox74.Text = "0"

        ' CALCULANDO AS VENDAS DA mario
         Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker12.Text & "' ,103)  and convert (datetime, '" & DateTimePicker13.Text & "' ,103) and  nomevendedor_balcao = 'mario'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor3 += Linha.Cells(9).Value
        Next
        TextBox75.Text = valor3.ToString("F2")

        ' CALCULANDO AS VENDAS DA celso
        Dim sql4 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker12.Text & "' ,103)  and convert (datetime, '" & DateTimePicker13.Text & "' ,103) and  nomevendedor_balcao = 'celso'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor4 += Linha.Cells(9).Value
        Next
        TextBox76.Text = valor4.ToString("F2")
        TextBox77.Text = "0"

    End Sub


    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click

        ' pegando os dados das datas
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        '' calculando o custo veronica
        Dim sql10 As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker14.Text & "' ,103)  and convert (datetime, '" & DateTimePicker15.Text & "' ,103) and  vendedor_item = 'verônica'"

        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView7.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor10 += Linha.Cells(16).Value
        Next
        TextBox148.Text = valor10.ToString("F2")

        ' ****************************************************
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor += Linha.Cells(10).Value
        Next
        TextBox84.Text = valor.ToString("F2")

        ' ******************************************************
        If valor <> 0 Then
            TextBox176.Text = ((1 - valor10 / valor) * 100).ToString("F2")
        End If

        ' -----------------------------------------------------------------------------------------
     
        ' calculando o custo alessandro

        Dim sql20 As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker14.Text & "' ,103)  and convert (datetime, '" & DateTimePicker15.Text & "' ,103) and  vendedor_item = 'alessandro'"

        Dim dataadapter20 As New SqlDataAdapter(sql20, connection)
        Dim ds20 As New DataSet()
        Try
            connection.Open()
            dataadapter20.Fill(ds20, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView7.DataSource = ds20.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor20 += Linha.Cells(16).Value
        Next
        TextBox150.Text = valor20.ToString("F2")
        ' ****************************************************
        Dim valor2 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor2 += Linha.Cells(10).Value
        Next
        TextBox83.Text = valor2.ToString("F2")

        ' ******************************************************
        If valor2 <> 0 Then
            TextBox177.Text = ((1 - valor20 / valor2) * 100).ToString("F2")
        Else
            TextBox177.Text = 0
        End If

        ' -----------------------------------
        ' calculando o custo mario
        Dim sql30 As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker14.Text & "' ,103)  and convert (datetime, '" & DateTimePicker15.Text & "' ,103) and  vendedor_item = 'mario'"

        Dim dataadapter30 As New SqlDataAdapter(sql30, connection)
        Dim ds30 As New DataSet()
        Try
            connection.Open()
            dataadapter30.Fill(ds30, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView7.DataSource = ds30.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor30 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor30 += Linha.Cells(16).Value
        Next
        TextBox149.Text = valor30.ToString("F2")
        ' ****************************************************
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor3 += Linha.Cells(10).Value
        Next
        TextBox82.Text = valor3.ToString("F2")

        ' ******************************************************
        If valor3 <> 0 Then
            TextBox178.Text = ((1 - valor30 / valor3) * 100).ToString("F2")
        Else
            TextBox178.Text = 0
        End If

        ' -------------------------------------------------------------
        ' calculando o custo celso
        Dim sql40 As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker14.Text & "' ,103)  and convert (datetime, '" & DateTimePicker15.Text & "' ,103) and  vendedor_item = 'celso'"

        Dim dataadapter40 As New SqlDataAdapter(sql40, connection)
        Dim ds40 As New DataSet()
        Try
            connection.Open()
            dataadapter40.Fill(ds40, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView7.DataSource = ds40.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor40 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor40 += Linha.Cells(16).Value
        Next
        TextBox175.Text = valor40.ToString("F2")
        ' ****************************************************
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor4 += Linha.Cells(10).Value
        Next
        TextBox81.Text = valor4.ToString("F2")

        ' ******************************************************
        If valor4 <> 0 Then
            TextBox179.Text = ((1 - valor40 / valor4) * 100).ToString("F2")
        Else
            TextBox179.Text = 0
        End If

        ' -------------------------------------------------------------
        ' calculando o custo gabi
        Dim sqlCris As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker14.Text & "' ,103)  and convert (datetime, '" & DateTimePicker15.Text & "' ,103) and  vendedor_item = 'Bee'"

        Dim dataadapterCris As New SqlDataAdapter(sqlCris, connection)
        Dim dsCris As New DataSet()
        Try
            connection.Open()
            dataadapterCris.Fill(dsCris, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView7.DataSource = dsCris.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valorCris As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valorCris += Linha.Cells(16).Value
        Next
        TextBox171.Text = valorCris.ToString("F2")
        ' ****************************************************
        Dim valor5 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView7.Rows
            valor5 += Linha.Cells(10).Value
        Next
        TextBox80.Text = valor5.ToString("F2")
        ' ******************************************************
        If valor5 <> 0 Then
            TextBox172.Text = ((1 - valorCris / valor5) * 100).ToString("F2")
        Else
            TextBox172.Text = 0
        End If

        ' calculando o total
        TextBox165.Text = (valor + valor2 + valor3 + valor4 + valor5).ToString("F2")
        TextBox18.Text = (valor10 + valor20 + valor30 + valor40 + valorCris).ToString("F2")
        TextBox164.Text = ((1 - (valor10 + valor20 + valor30 + valor40 + valorCris) / (valor + valor2 + valor3 + valor4 + valor5)) * 100).ToString("F2")


    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' CALCULANDO OS TOTAIS

        Dim sql10 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN   convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103) "

        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo

        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor10 += Linha.Cells(9).Value
        Next
        Label172.Text = valor10.ToString("f2")

        ' ------------------------------------------------
        ' cadeiras
        Dim sql1 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'cadeiras'"

        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds1 As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds1, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor1 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor1 += Linha.Cells(9).Value
        Next
        TextBox102.Text = valor1
        Dim calcula1 As Double = ((valor1 / valor10)) * 100
        Label169.Text = calcula1.ToString("F2")


        '---------------------------------------------------------
        ' CALCULANDO AS MESAS 
        Dim sql3 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'mesas'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor3 += Linha.Cells(9).Value
        Next
        TextBox101.Text = valor3
        Dim calcula3 As Double = ((valor3 / valor10)) * 100
        Label168.Text = calcula3.ToString("F2")

      
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS CAIXAS
        Dim sql4 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'caixas'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor4 += Linha.Cells(9).Value
        Next
        TextBox100.Text = valor4
        Dim calcula4 As Double = ((valor4 / valor10)) * 100
        Label167.Text = calcula4.ToString("F2")

    
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS lixeiras
        Dim sql5 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'lixeiras'"

        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor5 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor5 += Linha.Cells(9).Value
        Next
        TextBox99.Text = valor5
        Dim calcula5 As Double = ((valor5 / valor10)) * 100
        Label166.Text = calcula5.ToString("F2")

      
        ' ---------------------------------------------------------------------------------
        'CALCULANDO AS organizado
        Dim sql6 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'organizado'"

        Dim dataadapter6 As New SqlDataAdapter(sql6, connection)
        Dim ds6 As New DataSet()
        Try
            connection.Open()
            dataadapter6.Fill(ds6, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds6.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor6 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor6 += Linha.Cells(9).Value
        Next
        TextBox98.Text = valor6
        Dim calcula6 As Double = ((valor6 / valor10)) * 100
        Label165.Text = calcula6.ToString("F2")
        ' ---------------------------------------------------------------------------------

        ' piscinas
        Dim sql7 As String = "SELECT * FROM pedidoMarfinite WHERE dataemissao_pedmarf BETWEEN  convert (datetime, '" & DateTimePicker16.Text & "' ,103)  and convert (datetime, '" & DateTimePicker17.Text & "' ,103)  and  linha_pedmarfgeral = 'piscina'"

        Dim dataadapter7 As New SqlDataAdapter(sql7, connection)
        Dim ds7 As New DataSet()
        Try
            connection.Open()
            dataadapter7.Fill(ds7, "pedidoMarfinite")
            connection.Close()
            PedidoMarfiniteDataGridView1.DataSource = ds7.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor7 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.PedidoMarfiniteDataGridView1.Rows
            valor7 += Linha.Cells(9).Value
        Next
        TextBox55.Text = valor7
        Dim calcula7 As Double = ((valor7 / valor10)) * 100
        Label203.Text = calcula7.ToString("F2")


    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click

        ' Pegando o código para entrar na função
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        Else
            Button61.Enabled = True
            Button42.Enabled = False
        End If

    End Sub
    ' verifica se um ano é bissexto
    Public Function Bissexto(intAno As Integer) As Boolean
        '
        ' verifica se um ano é bissexto
        '
        Bissexto = False

        If intAno Mod 4 = 0 Then
            If intAno Mod 100 = 0 Then
                If intAno Mod 400 = 0 Then
                    Bissexto = True
                End If
            Else
                Bissexto = True
            End If
        End If

    End Function
    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM NFE_Emitidas WHERE data_nfeemitidas BETWEEN  convert (datetime, '" & DateTimePicker18.Text & "' ,103)  and convert (datetime, '" & DateTimePicker19.Text & "' ,103)"
     
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "NFE_Emitidas")
            connection.Close()
            NFE_EmitidasDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.NFE_EmitidasDataGridView.Rows
            valor += Linha.Cells(18).Value
        Next
        TextBox103.Text = valor.ToString("F2")


    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Deseja mesmo sair?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub tbcotrl_pdv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcotrl_pdv.SelectedIndexChanged
        ' pegando os dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month


        Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
        DateTimePicker13.Text = Date.Now
        DateTimePicker12.Text = primeiroDia.ToString
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' CALCULANDO OS TOTAIS

        Dim sql10 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103) "

        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo

        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor10 += Linha.Cells(9).Value
        Next
        Label187.Text = valor10.ToString("f2")

        ' calculando o custo
        Dim valorCusto10 As Double
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto10 += Linha.Cells(17).Value
        Next
        Label186.Text = valorCusto10.ToString("f2")
        ''calculando a porcentagem de lucro
        Try
            Dim VrPorcentagem10 As Double = (1 - (valorCusto10 / valor10)) * 100
            Label185.Text = VrPorcentagem10.ToString("F2")
        Catch ex As Exception

        End Try

        ' ------------------------------------------------
        ' cadeiras
        Dim sql1 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'cadeiras'"

        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds1 As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds1, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor1 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor1 += Linha.Cells(9).Value
        Next
        TextBox110.Text = valor1

        ' calculando o custo
        Dim valorCusto1
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto1 += Linha.Cells(17).Value
        Next
        TextBox105.Text = valorCusto1
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem1 As Double = (1 - (valorCusto1 / valor1)) * 100
            TextBox104.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor1 / valor10)) * 100
            Label184.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        ''---------------------------------------------------------
        '' -----------------------------------------------------
        ' CALCULANDO AS MESAS 
        Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103) and  linhaprod_balcao = 'mesas'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor3 += Linha.Cells(9).Value
        Next
        TextBox109.Text = valor3

        ' calculando o custo
        Dim valorCusto3
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto3 += Linha.Cells(17).Value
        Next
        TextBox97.Text = valorCusto3
        ''calculando a porcentagem de lucro
        Dim VrPorcentagem3 As Double
        If valorCusto3 = 0 Or valor3 = 0 Then
        Else

            VrPorcentagem3 = (1 - (valorCusto3 / valor3)) * 100
        End If
        TextBox96.Text = VrPorcentagem3.ToString("F2")
        Dim cadeiras As Double = TextBox110.Text
        Dim mesas As Double = TextBox109.Text
        ' ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor3 / valor10)) * 100
            Label183.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        TextBox120.Text = cadeiras + mesas
        '' ---------------------------------------------------------------------------------
        ''CALCULANDO AS CAIXAS
        Dim sql4 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'caixas'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor4 += Linha.Cells(9).Value
        Next
        TextBox108.Text = valor4

        ' calculando o custo
        Dim valorCusto4
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto4 += Linha.Cells(17).Value
        Next
        TextBox95.Text = valorCusto4
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem4 As Double = (1 - (valorCusto4 / valor4)) * 100
            TextBox94.Text = VrPorcentagem4.ToString("F2")
        Catch ex As Exception
            MessageBox.Show("")
        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor4 / valor10)) * 100
            Label182.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '' ---------------------------------------------------------------------------------
        ''CALCULANDO AS lixeiras
        Dim sql5 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'lixeiras'"

        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor5 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor5 += Linha.Cells(9).Value
        Next
        TextBox107.Text = valor5

        ' calculando o custo
        Dim valorCusto5
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto5 += Linha.Cells(17).Value
        Next
        TextBox93.Text = valorCusto5
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem5 As Double = (1 - (valorCusto5 / valor5)) * 100
            TextBox92.Text = VrPorcentagem5.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try
            Dim VrPorcentagem1 As Double = ((valor5 / valor10)) * 100
            Label181.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '' ---------------------------------------------------------------------------------
        ''CALCULANDO AS organizado
        Dim sql6 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'organizado'"

        Dim dataadapter6 As New SqlDataAdapter(sql6, connection)
        Dim ds6 As New DataSet()
        Try
            connection.Open()
            dataadapter6.Fill(ds6, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds6.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor6 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor6 += Linha.Cells(9).Value
        Next
        TextBox106.Text = valor6

        ' calculando o custo
        Dim valorCusto6
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto6 += Linha.Cells(17).Value
        Next
        TextBox91.Text = valorCusto6
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem6 As Double = (1 - (valorCusto6 / valor6)) * 100
            TextBox90.Text = VrPorcentagem6.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try


            Dim VrPorcentagem1 As Double = ((valor6 / valor10)) * 100
            Label180.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '' ---------------------------------------------------------------------------------

        ''CALCULANDO AS piscina
        Dim sql7 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'piscina'"

        Dim dataadapter7 As New SqlDataAdapter(sql7, connection)
        Dim ds7 As New DataSet()
        Try
            connection.Open()
            dataadapter7.Fill(ds7, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds7.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor7 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor7 += Linha.Cells(9).Value
        Next
        TextBox121.Text = valor7

        ' calculando o custo
        Dim valorCusto7
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto7 += Linha.Cells(17).Value
        Next
        TextBox122.Text = valorCusto7
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem7 As Double = (1 - (valorCusto7 / valor7)) * 100
            TextBox123.Text = VrPorcentagem7.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try

            Dim VrPorcentagem1 As Double = ((valor7 / valor10)) * 100
            Label208.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '' ---------------------------------------------------------------------------------
        '' ---------------------------------------------------------------------------------

        ''CALCULANDO AS prod.var
        Dim sql8 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN convert (datetime, '" & DateTimePicker21.Text & "' ,103)  and convert (datetime, '" & DateTimePicker22.Text & "' ,103)  and  linhaprod_balcao = 'prod.var'"

        Dim dataadapter8 As New SqlDataAdapter(sql8, connection)
        Dim ds8 As New DataSet()
        Try
            connection.Open()
            dataadapter8.Fill(ds8, "balcao")
            connection.Close()
            BalcaoDataGridView4.DataSource = ds8.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor8 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valor8 += Linha.Cells(9).Value
        Next
        TextBox124.Text = valor8

        ' calculando o custo
        Dim valorCusto8
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView4.Rows
            valorCusto8 += Linha.Cells(17).Value
        Next
        TextBox125.Text = valorCusto8
        ''calculando a porcentagem de lucro
        Try

            Dim VrPorcentagem8 As Double = (1 - (valorCusto8 / valor8)) * 100
            TextBox126.Text = VrPorcentagem8.ToString("F2")
        Catch ex As Exception

        End Try
        ''calculando a porcentagem de lucro da linha
        Try

            Dim VrPorcentagem1 As Double = ((valor8 / valor10)) * 100
            Label210.Text = VrPorcentagem1.ToString("F2")
        Catch ex As Exception

        End Try
        '' ---------------------------------------------------------------------------------
        ''CALCULANDO AS pallets
        'Dim sql9 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  '" & DateTimePicker10.Text & "' and '" & DateTimePicker11.Text & "' and  linha_item = 'pallets'"

        'Dim dataadapter9 As New SqlDataAdapter(sql9, connection)
        'Dim ds9 As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter9.Fill(ds9, "PedidoNFE")
        '    connection.Close()
        '    ItemPedidosDataGridView4.DataSource = ds9.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        '' soma a coluna dos valores e o põe no campo certo
        'Dim valor9 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
        '    valor9 += Linha.Cells(10).Value
        'Next
        'TextBox113.Text = valor9

        '' calculando o custo
        'Dim valorCusto9
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView4.Rows
        '    valorCusto9 += Linha.Cells(16).Value
        'Next
        'TextBox116.Text = valorCusto9
        ' ''calculando a porcentagem de lucro
        'Try

        '    Dim VrPorcentagem9 As Double = (1 - (valorCusto9 / valor9)) * 100
        '    TextBox119.Text = VrPorcentagem9.ToString("F2")
        'Catch ex As Exception

        'End Try
        ' ''calculando a porcentagem de lucro da linha
        'Try

        '    Dim VrPorcentagem1 As Double = ((valor9 / valor10)) * 100
        '    Label198.Text = VrPorcentagem1.ToString("F2")
        'Catch ex As Exception

        'End Try
        '' ---------------------------------------------------------------------------------

        Label170.Text = 100 - Label210.Text - Label208.Text - Label180.Text - Label181.Text - Label182.Text - Label183.Text - Label184.Text
        TextBox89.Text = Label187.Text - TextBox110.Text - TextBox109.Text - TextBox108.Text - TextBox107.Text - TextBox106.Text - TextBox121.Text - TextBox124.Text
        TextBox88.Text = Label186.Text - TextBox125.Text - TextBox122.Text - TextBox91.Text - TextBox93.Text - TextBox95.Text - TextBox97.Text - TextBox105.Text
        'calculando a porcentagem de lucro da linha
        Dim VrPorcentagem11 As Double = (1 - (TextBox88.Text / TextBox89.Text)) * 100
        TextBox87.Text = VrPorcentagem11.ToString("F2")


    End Sub

    Private Sub TabControlpedidos_nfe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlpedidos_nfe.SelectedIndexChanged
        ' pegando os dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month

        Dim primeiroDia As DateTime = New DateTime(ano, mes, 1)
        DateTimePicker15.Text = Date.Now
        DateTimePicker14.Text = primeiroDia.ToString
    End Sub

   

   

   
    Private Sub ItemPedidosDataGridView5_DoubleClick(sender As Object, e As EventArgs)


        'Dim v_SelectRow As Integer
        'v_SelectRow = Me.ItemPedidosDataGridView5.CurrentRow.Index

        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103) and  convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_item = '" & ItemPedidosDataGridView5.Item(6, v_SelectRow).Value & "'"

        'TextBox128.Text = ItemPedidosDataGridView5.Item(2, v_SelectRow).Value

        'Dim dataadapter As New SqlDataAdapter(sql2, connection)
        'Dim ds As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter.Fill(ds, "ItemPedidos")
        '    connection.Close()
        '    ItemPedidosDataGridView5.DataSource = ds.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        '' soma a coluna dos valores e o põe no campo certo
        'Dim valor As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView5.Rows
        '    valor += Linha.Cells(4).Value
        'Next


        '' --------------------------------------------
        'Dim v_SelectRow2 As Integer
        '' v_SelectRow2 = Me.BalcaoDataGridView5.CurrentRow.Index

        'Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103) and  convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_balcao = '" & BalcaoDataGridView5.Item(5, v_SelectRow).Value & "'"

        'Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        'Dim ds3 As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter3.Fill(ds3, "balcao")
        '    connection.Close()
        '    ' BalcaoDataGridView5.DataSource = ds3.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        '' soma a coluna dos valores e o põe no campo certo
        'Dim valor3 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
        '    valor3 += Linha.Cells(3).Value
        'Next
        '' -------------------------------
        ''resultado
        'Dim diferenca As Integer

        'diferenca = DateDiff("d", DateTimePicker23.Text, DateTimePicker24.Text)
        'TextBox127.Text = (((valor + valor3) / diferenca) * 30).ToString("F2")
        'TextBox163.Text = valor + valor3

    End Sub

    Private Sub BalcaoDataGridView5_DoubleClick(sender As Object, e As EventArgs)

        'Dim v_SelectRow As Integer
        'v_SelectRow = Me.ItemPedidosDataGridView5.CurrentRow.Index

        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103) and  convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_item = '" & ItemPedidosDataGridView5.Item(6, v_SelectRow).Value & "'"


        'Dim dataadapter As New SqlDataAdapter(sql2, connection)
        'Dim ds As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter.Fill(ds, "ItemPedidos")
        '    connection.Close()
        '    ItemPedidosDataGridView5.DataSource = ds.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        '' soma a coluna dos valores e o põe no campo certo
        'Dim valor As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView5.Rows
        '    valor += Linha.Cells(4).Value
        'Next


        '' --------------------------------------------
        'Dim v_SelectRow2 As Integer
        'v_SelectRow2 = Me.BalcaoDataGridView5.CurrentRow.Index

        'Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103) and  convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_balcao = '" & BalcaoDataGridView5.Item(5, v_SelectRow).Value & "'"

        'TextBox128.Text = BalcaoDataGridView5.Item(6, v_SelectRow).Value

        'Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        'Dim ds3 As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter3.Fill(ds3, "balcao")
        '    connection.Close()
        '    BalcaoDataGridView5.DataSource = ds3.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        '' soma a coluna dos valores e o põe no campo certo
        'Dim valor3 As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
        '    valor3 += Linha.Cells(3).Value
        'Next
        '' -------------------------------
        ''resultado
        'Dim diferenca As Integer
        'diferenca = DateDiff("d", DateTimePicker23.Text, DateTimePicker24.Text)
        'TextBox127.Text = (((valor + valor3) / diferenca) * 30).ToString("F2")
        'TextBox163.Text = valor + valor3


    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "update PedidoNFE set formadepagamento_ped = @formaDePagamento where id_pedidos = '" & Id_pedidosTextBox.Text & "'"
        command.CommandType = CommandType.Text
        command.Parameters.Add("@formaDePagamento", SqlDbType.VarChar, 50).Value = cbx_FormadepagamentoPed.Text

        Try

            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)
        cbx_FormadepagamentoPed.Enabled = False
        Button46.Enabled = False

    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click

        cbx_FormadepagamentoPed.Enabled = True
        Button46.Enabled = True

    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"


        Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE dataentrega_item BETWEEN   convert (datetime, '" & DateTimePicker25.Text & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103) and entregue_item = 'Entregue' "
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView6.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna do faturamento e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView6.Rows
            valor += Linha.Cells(9).Value
        Next
        TextBox133.Text = valor

        ' soma a coluna do comissões
        Dim valorComissao As Decimal = 0

        ' soma a coluna dos custos e o põe no campo certo
        Dim valor2 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView6.Rows
            valor2 += Linha.Cells(12).Value
        Next
        TextBox86.Text = valor2
       

        ' ---------------------------------------------
        Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker25.Text & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103)"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "balcao")
            connection.Close()
            BalcaoDataGridView6.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView6.Rows
            valor10 += Linha.Cells(12).Value
        Next
        ' TextBox130.Text = valor10
        ' soma a coluna dos custos e o põe no campo certo
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView6.Rows
            valor20 += Linha.Cells(17).Value
        Next
        TextBox85.Text = valor20
        ' -------------------------------
          'faturamento
        Dim faturamentolinha As Double = TextBox133.Text
        Dim faturamentobalcao As Double = valor10
        TextBox134.Text = (faturamentolinha + faturamentobalcao).ToString("F2")
        ' custos
        Dim custoslinha As Double = TextBox86.Text
        Dim custosbalcao As Double = TextBox85.Text
        TextBox136.Text = (custoslinha + custosbalcao).ToString("F2")

        ' lucro
        TextBox129.Text = (faturamentobalcao - custosbalcao).ToString("f2")
        TextBox135.Text = (faturamentolinha - custoslinha - valorComissao).ToString("f2")
        TextBox137.Text = ((faturamentobalcao - custosbalcao) + (faturamentolinha - custoslinha - valorComissao)).ToString("f2")
        ' porcentagens
        Dim lucroBalcao As Double = faturamentobalcao - custosbalcao
        Dim lucroLinha As Double = faturamentolinha - custoslinha - valorComissao
        Dim lucroTotal As Double = (faturamentobalcao - custosbalcao) + (faturamentolinha - custoslinha - valorComissao)

        TextBox138.Text = ((lucroBalcao / faturamentobalcao) * 100).ToString("f2")
        TextBox139.Text = (((lucroLinha) / faturamentolinha) * 100).ToString("f2")
        TextBox140.Text = (((lucroTotal) / (faturamentobalcao + faturamentolinha)) * 100).ToString("f2")

        ' faz a projeção do faturamento
        ' pegando dados das datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim dia As Integer = Today.Day
        ' descobrindo quantos dias tem um mes
        Dim quant As Integer = System.DateTime.DaysInMonth(ano, mes)

        ' calculando a projeção
        TextBox141.Text = (((faturamentolinha + faturamentobalcao) / dia) * quant).ToString("F2")
        TextBox314.Text = (((custoslinha + custosbalcao) / dia) * quant).ToString("F2")
        TextBox315.Text = (((lucroLinha + lucroBalcao) / dia) * quant).ToString("F2")

        ' ------------------------------------------------------------------------------

        Dim sql25 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker25.Text & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103)   and nomevendedor_balcao = 'fernando'"

        Dim dataadapter25 As New SqlDataAdapter(sql25, connection)
        Dim ds25 As New DataSet()
        Try
            connection.Open()
            dataadapter25.Fill(ds25, "balcao")
            connection.Close()
            BalcaoDataGridView6.DataSource = ds25.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        ' soma da venda da bugigangas
        Dim VendasBugigangas As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView6.Rows
            VendasBugigangas += Linha.Cells(12).Value
        Next
        TextBox153.Text = VendasBugigangas
        TextBox130.Text = valor10 - VendasBugigangas

        ' soma dos custso de vendas da bugiganga e põem no textbox

        Dim valorBugigangas As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView6.Rows
            valorBugigangas += Linha.Cells(17).Value
        Next
        TextBox200.Text = valorBugigangas

        ' calculo do lucro da bugigangas

        TextBox213.Text = VendasBugigangas - valorBugigangas

        ' calculando a procentagem
        Dim porcentagemBugigangas As Double
        If VendasBugigangas <> 0 Then


            porcentagemBugigangas = ((valorBugigangas / VendasBugigangas))
            TextBox201.Text = ((1 - porcentagemBugigangas) * 100).ToString("f2")
        End If
        ' ---------------------------------------------------------------------------------
        ' valor não entregue
        Dim dataNaoEntregue As Date
        Dim DiasProdutosNaoEntregue As Integer = (cbx_DiasProdutosNaoEntregue.Text) * -1

        dataNaoEntregue = DateAdd("d", DiasProdutosNaoEntregue, DateTime.Now)

        Dim sqlNaoEntregue As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & dataNaoEntregue & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103) and entregue_item = 'Não Entregue' "

        Dim dataadapterNaoEntregue As New SqlDataAdapter(sqlNaoEntregue, connection)
        Dim dsNaoEntregue As New DataSet()
        Try
            connection.Open()
            dataadapterNaoEntregue.Fill(dsNaoEntregue, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView6.DataSource = dsNaoEntregue.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna do faturamento e o põe no campo certo
        Dim valorNaoEntregue As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView6.Rows
            valorNaoEntregue += Linha.Cells(9).Value
        Next
        TextBox131.Text = valorNaoEntregue

        TextBox85.Text = TextBox85.Text - valorBugigangas
        TextBox129.Text = (TextBox130.Text - TextBox85.Text).ToString("f2")
        TextBox138.Text = ((1 - (TextBox85.Text / TextBox130.Text)) * 100).ToString("f2")
        ' --------------------------------------------------------------
        ' Calculando o prazo de entrega

        Dim DataLancamento As Date
        Dim DataDaEntraga As Date
        Dim Diferenca As Integer
        Dim TlDiferenca As Integer = 0
        Dim contador As Integer = 0
        Dim MEdiaEntrega As Double

        Dim dataNaoEntregue2 As Date
        'Dim DiasProdutosNaoEntregue2 As Integer = -30
        dataNaoEntregue2 = DateAdd("d", -30, Date.Now)

        Dim command35 As SqlCommand
        command35 = connection.CreateCommand()
        command35.CommandText = "select * from [dbo].[ItemPedidos] WHERE data_item BETWEEN   convert (datetime, '" & dataNaoEntregue2 & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103) and entregue_item = 'Entregue' "
        Dim sqlNaoEntregue2 As String = "select * from [dbo].[ItemPedidos] WHERE data_item BETWEEN   convert (datetime, '" & dataNaoEntregue2 & "' ,103)  and convert (datetime, '" & DateTimePicker26.Text & "' ,103) and entregue_item = 'Entregue' "

        ' -----------------------------------------------------
        Dim dataadapterNaoEntregue2 As New SqlDataAdapter(sqlNaoEntregue2, connection)
        Dim dsNaoEntregue2 As New DataSet()
        Try
            connection.Open()
            dataadapterNaoEntregue2.Fill(dsNaoEntregue2, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView6.DataSource = dsNaoEntregue2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' ---------------------------------------------------------
        connection.Open()
        Dim lrd As SqlDataReader = command35.ExecuteReader()

        While lrd.Read

            DataLancamento = ItemPedidosDataGridView6.Item(1, contador).Value
            DataDaEntraga = ItemPedidosDataGridView6.Item(13, contador).Value
            Diferenca = DateDiff("d", DataLancamento, DataDaEntraga)
            TlDiferenca = TlDiferenca + Diferenca
            contador = contador + 1
           
        End While

        connection.Close()
        MEdiaEntrega = TlDiferenca / contador
        TextBox132.Text = MEdiaEntrega.ToString("F2")
        TextBox310.Text = (((faturamentolinha + (faturamentobalcao - VendasBugigangas)) / dia) * quant).ToString("F2")
        TextBox311.Text = (((valor2 + (valor20 - valorBugigangas)) / dia) * quant).ToString("F2")
        TextBox312.Text = TextBox310.Text - TextBox311.Text
        TextBox313.Text = ((1 - (TextBox311.Text / TextBox310.Text)) * 100).ToString("f2")



    End Sub

    Private Sub RadioButton7_Click(sender As Object, e As EventArgs) Handles RadioButton7.Click

        If AcertarPreco = True Then
            ' calcular o valor de desconto a vista e gravar no banco de dados

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

            Dim VrMultiplicador As Double

            If ItemPedidosDataGridView.Item(21, 0).Value = "Atacado" Then
                VrMultiplicador = 0.97
            Else
                VrMultiplicador = 0.97
            End If


            Dim valorCalculadoAvista As String
            Dim command7 As SqlCommand
            command7 = connection.CreateCommand()
            command7.CommandType = CommandType.Text

            Dim xx As Integer
            For xx = 0 To ItemPedidosDataGridView.RowCount() - 1

                valorCalculadoAvista = ItemPedidosDataGridView.Item(19, xx).Value * VrMultiplicador
                Dim valorCalculadoAvista2 = valorCalculadoAvista.Replace(",", ".")
                'calculo do total do vr item
                Dim calucloVrTl As String = valorCalculadoAvista * ItemPedidosDataGridView.Item(5, xx).Value
                Dim calucloVrTl2 = calucloVrTl.Replace(",", ".")
                'calculo porcentagem
                Dim PorcentagemBalcao As Double = (1 - (ItemPedidosDataGridView.Item(14, xx).Value / calucloVrTl)) * 100
                Dim PorcentagemBalcao2 As String = PorcentagemBalcao.ToString("F2")
                command7.CommandText = "update ItemPedidos set codproduto_item = '" & PorcentagemBalcao2 & "', precovarejo_item = '" & valorCalculadoAvista2 & "',totalvalor_item = '" & calucloVrTl2 & "' where id_item = '" & ItemPedidosDataGridView.Item(10, xx).Value & "'"

                Try
                    connection.Open()
                    command7.ExecuteNonQuery()
                    connection.Close()


                Catch ex As Exception

                    MessageBox.Show(ex.ToString())
                    connection.Close()

                End Try
            Next

            Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)
            ' soma a coluna dos valores e o põe no campo certo
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView.Rows
                valor += Linha.Cells(7).Value
            Next
            Valortotal_pedTextBox.Text = valor
        End If


    End Sub

    Private Sub RadioButton9_Click_1(sender As Object, e As EventArgs) Handles RadioButton9.Click

        If AcertarPreco = True Then

            ' calcular o valor de desconto a vista e gravar no banco de dados
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            ' User ID=yourUserName;Password=yourPwd;Trusted_Connection=False
            Dim valorCalculadoAvista As String
            Dim command7 As SqlCommand
            command7 = connection.CreateCommand()
            command7.CommandType = CommandType.Text

            Dim xx As Integer
            For xx = 0 To ItemPedidosDataGridView.RowCount() - 1

                valorCalculadoAvista = ItemPedidosDataGridView.Item(19, xx).Value * 1
                Dim valorCalculadoAvista2 = valorCalculadoAvista.Replace(",", ".")

                'calculo do total do vr item
                Dim calucloVrTl As String = valorCalculadoAvista * ItemPedidosDataGridView.Item(5, xx).Value
                Dim calucloVrTl2 = calucloVrTl.Replace(",", ".")
                ' calcula a porcentagem

                Dim PorcentagemBalcao As Double = (1 - (ItemPedidosDataGridView.Item(14, xx).Value / calucloVrTl)) * 100
                Dim PorcentagemBalcao2 As String = PorcentagemBalcao.ToString("F2")

                command7.CommandText = "update ItemPedidos set codproduto_item = '" & PorcentagemBalcao2 & "', precovarejo_item = '" & valorCalculadoAvista2 & "',totalvalor_item = '" & calucloVrTl2 & "' where id_item = '" & ItemPedidosDataGridView.Item(10, xx).Value & "'"

                Try
                    connection.Open()
                    command7.ExecuteNonQuery()
                    connection.Close()


                Catch ex As Exception

                    MessageBox.Show(ex.ToString())
                    connection.Close()

                End Try
            Next

            Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

            ' soma a coluna dos valores e o põe no campo certo
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView.Rows
                valor += Linha.Cells(7).Value
            Next
            Valortotal_pedTextBox.Text = valor
        End If

    End Sub

    Private Sub RadioButton8_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click

        AcertarPreco = False

        'hABILITA MENU DO FORM PEDIDOS NFE
        GerarPedidoToolStripMenuItem.Enabled = True
        ConfirmarPedidoToolStripMenuItem.Enabled = False
        DeletarPedidoToolStripMenuItem.Enabled = True
        btn_conifmardadospedNFE.Enabled = False
        IMprimir_pedidos.Enabled = True
        ComboBox15.Enabled = False
        HabilitarEnvioToolStripMenuItemPedido.Enabled = True


        'coloca A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Insert(0, tbpg_produtos)
        TabControl1.TabPages.Insert(1, tbpg_clientes)
        TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        TabControl1.TabPages.Insert(5, tab_nfe)
        TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        TabControl1.TabPages.Insert(8, Tabpg_cupomfiscal)
        TabControl1.TabPages.Insert(9, tbpg_bkup)
        TabControl1.TabPages.Insert(10, tbpg_orcamento)
        TabControl1.TabPages.Insert(11, tbg_relatorios)

        'coloca A VISIBILIDADE DA PAGE DESEJADA
        TabControlpedidos_nfe.TabPages.Insert(1, TabPageConsultaPedidos)
        TabControlpedidos_nfe.TabPages.Insert(2, TabPage9)

        RadioButton7.Enabled = False
        RadioButton9.Enabled = False

        Button49.Visible = False
        Button50.Visible = True
        Button51.Visible = True



    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        AcertarPreco = True

        Button50.Enabled = False
        Button51.Enabled = True

        RadioButton7.Enabled = True
        RadioButton9.Enabled = True

    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click

        AcertarPreco = False
        Button50.Enabled = True
        Button51.Enabled = False

        RadioButton7.Enabled = False
        RadioButton9.Enabled = False

    End Sub

   
    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click

        TextBox269.Clear()
        TextBox270.Clear()
        TextBox271.Clear()

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker27.Text & "' ,103)  and convert (datetime, '" & DateTimePicker28.Text & "' ,103)"

        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView1.Rows
            valor += Linha.Cells(7).Value
        Next
        TextBox144.Text = valor.ToString("F2")


    End Sub


    'função voltar



    'BOTAO PRODUTOS
    'Botões menu principal
    Private Sub Button54_Click(sender As Object, e As EventArgs)


        'BOTAO PRODUTOS
        panelInicio.Visible = False

        TabControl1.TabPages.Remove(tbpg_clientes)
        TabControl1.TabPages.Remove(tbpg_pedFornecedor)
        TabControl1.TabPages.Remove(tbpg_transportadoras)
        TabControl1.TabPages.Remove(tbpg_capitalGiro)
        TabControl1.TabPages.Remove(tab_nfe)
        TabControl1.TabPages.Remove(pedidos)
        TabControl1.TabPages.Remove(tabpage_NFE_e)
        TabControl1.TabPages.Remove(Tabpg_cupomfiscal)
        TabControl1.TabPages.Remove(tbpg_bkup)
        TabControl1.TabPages.Remove(tbpg_orcamento)
        TabControl1.TabPages.Remove(tbg_relatorios)

        tabpage_produtos.TabPages.Remove(TabPage_gridProd)
        tabpage_produtos.TabPages.Remove(tbpg_listapreco)

        tabpage_produtos.TabPages.Insert(1, TabPage_gridProd)
        tabpage_produtos.TabPages.Insert(2, tbpg_listapreco)



    End Sub



    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles btn_buscaTansPedido.Click
        'TabControlpedidos_nfe.SelectTab(2)
        TabControlpedidos_nfe.TabPages.Insert(2, TabPageTransportadora_nfe)
    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles btn_buscaCliPedido.Click
        TabControlpedidos_nfe.SelectTab(1)
    End Sub





    Private Sub Button44_Click_1(sender As Object, e As EventArgs) Handles btn_addProd.Click
        tbcotrl_pdv.SelectedIndex = 1
    End Sub


   

   
    Private Sub Button54_Click_1(sender As Object, e As EventArgs) Handles Button54.Click

        btn_buscaTansPedido.Enabled = True

    End Sub


    Private Sub Button55_Click_1(sender As Object, e As EventArgs) Handles Button55.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker29.Text & "' ,103)  and convert (datetime, '" & DateTimePicker30.Text & "' ,103)"

        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView8.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView8.Rows
            valor += Linha.Cells(10).Value
        Next
        TextBox152.Text = valor.ToString("F2")

        '' comissão
        Dim valor150 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView8.Rows
            valor150 += Linha.Cells(23).Value
        Next
        TextBox160.Text = (valor150).ToString("F2")

        '' custos proplast

        Dim valor1500 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView8.Rows
            valor1500 += Linha.Cells(16).Value
        Next
        TextBox159.Text = (valor1500).ToString("F2")

        ' lucro
        TextBox161.Text = valor - valor150 - valor1500


        Dim porc As String
        Try

            porc = (1 - ((valor150 + valor1500) / valor)) * 100
            TextBox162.Text = porc
        Catch ex As Exception

        End Try

       

    End Sub

  

    Private Sub Button56_Click_1(sender As Object, e As EventArgs) Handles Button56.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA dinheiro
        Dim sql As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Dinheiro'"

        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor += Linha.Cells(12).Value
        Next
        TextBox154.Text = valor.ToString("F2")
      
        ' CALCULANDO AS VENDAS DA cartão
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Cartão'"

        Dim dataadapter2 As New SqlDataAdapter(sql2, connection)
        Dim ds2 As New DataSet()
        Try
            connection.Open()
            dataadapter2.Fill(ds2, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor2 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor2 += Linha.Cells(12).Value
        Next
        TextBox155.Text = valor2.ToString("F2")

        ' CALCULANDO AS VENDAS DA boleto
        Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Boleto'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor3 += Linha.Cells(9).Value
        Next
        TextBox156.Text = valor3.ToString("F2")

        '    ' CALCULANDO AS VENDAS DA outros
        Dim sql4 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Outros'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor4 += Linha.Cells(9).Value
        Next
        TextBox157.Text = valor4.ToString("F2")

        ' CALCULANDO AS VENDAS DA BUGIGANGA

        Dim sql10 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  nomevendedor_balcao = 'Bee'"

        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor10 += Linha.Cells(9).Value
        Next
        TextBox241.Text = valor10.ToString("F2")

        ' calculando os totais
        Dim ValorLoja As Double = 0
        ValorLoja = (valor4 + valor3 + valor2 + valor)
        TextBox158.Text = ValorLoja
        TextBox242.Text = ValorLoja - valor10

    End Sub

   
   
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If ComboBox3.Text = "" Then
            MessageBox.Show("escolher uma opção")
            Exit Sub
        End If

        ' ----------------------------------------------------------------------------
        'rem lê os dados do arquivo de clientes
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"

        command = connection.CreateCommand()
        command.CommandText = "select * from orcamento2 "
        ' 
        Dim command1 As SqlCommand
        command1 = connection.CreateCommand()
        command1.CommandText = "INSERT INTO EmailErroCliente (ErroEmailCLiente_nomeCliente,ErroEmailCLiente_telefone,ErroEmailCLiente_email,ErroEmailCLiente_contato) Values (@ErroEmailCLiente_nomeCliente,@ErroEmailCLiente_telefone,@ErroEmailCLiente_email,@ErroEmailCLiente_contato)"

        ii = 0


        Dim xx As Integer
        'For xx = 0 To Orcamento2DataGridView.RowCount() - 1
        Dim rr As Integer = TextBox183.Text
        ' ClienteDataGridView.RowCount() - 1
        For xx = TextBox181.Text To rr

            'command1.Parameters.Add("@ErroEmailCLiente_nomeCliente", SqlDbType.VarChar, 50).Value = ClienteDataGridView.Item(1, xx).Value
            'command1.Parameters.Add("@ErroEmailCLiente_telefone", SqlDbType.VarChar, 50).Value = ClienteDataGridView.Item(2, xx).Value
            'command1.Parameters.Add("@ErroEmailCLiente_email", SqlDbType.VarChar, 50).Value = ClienteDataGridView.Item(3, xx).Value
            'command1.Parameters.Add("@ErroEmailCLiente_contato", SqlDbType.VarChar, 50).Value = ClienteDataGridView.Item(4, xx).Value


            Dim objNovoEmail As New MailMessage
            Dim objSmtp As New SmtpClient
            Dim SHostname As String

           

            'If EmailAddressCheck(ClienteDataGridView.Item(3, xx).Value) = True And ClienteDataGridView.Item(3, xx).Value <> "não tem" Then

            '    objNovoEmail.From = New MailAddress("vendas@marfinitemogi.com.br")

            '    If ClienteDataGridView.Item(3, xx).Value <> "" Then

            '        objNovoEmail.To.Add(New MailAddress(ClienteDataGridView.Item(3, xx).Value))

            '        objNovoEmail.Priority = MailPriority.Low
            '        objNovoEmail.Subject = " Produtos que podem ser interessantes para você " + ClienteDataGridView.Item(1, xx).Value
            '        ' -----------------------------
            '        ' função para esperar determinado tempo
            '        'System.Threading.Thread.Sleep(1000)
            '        ' objNovoEmail.Attachments.Add(New Net.Mail.Attachment("C:\Users\Central\Desktop\Promoção de Móveis Marfinite.docx"))

            '        ' --------------------
            '        'Formato de e-mail em Html?
            '        objNovoEmail.IsBodyHtml = True
            '        objNovoEmail.Body = "<a href='http://www.bugigangasmil.com.br'><img src='http://imageshack.com/a/img904/2071/pz0npY.jpg'></img></a>"

            '        'Configuração de tipagem da linguagem, para não aparecer caracteres estranhos na mensagem
            '        objNovoEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
            '        objNovoEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

            '        'Configuração do IP do servidor SMTP
            '        objSmtp.Host = "smtp.marfinitemogi.com.br"
            '        objSmtp.Port = "587"

            '        'Caso queira definir um tempo do timeout 
            '        objSmtp.Timeout = 65000
            '        objSmtp.Credentials = New System.Net.NetworkCredential("vendas@marfinitemogi.com.br", "marf1505")

            '        Try
            '            objSmtp.Send(objNovoEmail)
            '        Catch ex As Exception
            '            ' MessageBox.Show(ex.ToString)
            '            MsgBox(Err.Number & " " & Err.Description)
            '            ii = ii + 1
            '            Clientes(ii) = ClienteDataGridView.Item(1, xx).Value
            '            telefone(ii) = ClienteDataGridView.Item(2, xx).Value
            '            email(ii) = ClienteDataGridView.Item(3, xx).Value
            '        End Try
            '        objNovoEmail.Dispose()
            '    End If
            'Else
            '    If ClienteDataGridView.Item(3, xx).Value <> "não tem" Then
            '        ii = ii + 1
            '        Clientes(ii) = ClienteDataGridView.Item(1, xx).Value
            '        telefone(ii) = ClienteDataGridView.Item(2, xx).Value
            '        email(ii) = ClienteDataGridView.Item(3, xx).Value
            '    End If
            'End If

            System.Threading.Thread.Sleep(5000)

        Next
        MessageBox.Show("fim")
        MessageBox.Show(ii)

        ' PrintDocument11.Print()


    End Sub

   
   
    Private Sub PrintDocument11_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument11.PrintPage

        ' cabeçalho
        e.Graphics.DrawString(TextBox181.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 100, 5)
        e.Graphics.DrawString("  -  ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 150, 5)
        e.Graphics.DrawString(TextBox183.Text, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 5)
        e.Graphics.DrawString(" ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 5)

        For ii = 0 To 1000
            If Clientes(ii) <> "" Then
                e.Graphics.DrawString(ii, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 1, (ii * 15) + 5)
                e.Graphics.DrawString(Clientes(ii), New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, (ii * 15) + 5)
                e.Graphics.DrawString(telefone(ii), New Font("arial", 10, FontStyle.Regular), Brushes.Black, 340, (ii * 15) + 5)
                e.Graphics.DrawString(email(ii), New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, (ii * 15) + 5)

            End If
        Next

    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click

        If EmailAddressCheck(Email_clienteTextBox.Text) = True Then
            MessageBox.Show("Email válido")
        Else
            MessageBox.Show("Email INCORRETO")
        End If
    End Sub

   
   
    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click

        Obsvendedor_pedTextBox.Enabled = True
        Obsgerente_pedTextBox.Enabled = True
        Button52.Enabled = False
        Button58.Enabled = True

    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "update PedidoNFE set obsvendedor_ped = @obsvendedor_ped,  obsgerente_ped = @obsgerente_ped where id_pedidos = '" & Id_pedidosTextBox.Text & "'"
        command.CommandType = CommandType.Text
        command.Parameters.Add("@obsvendedor_ped", SqlDbType.VarChar, 50).Value = Obsvendedor_pedTextBox.Text
        command.Parameters.Add("@obsgerente_ped", SqlDbType.VarChar, 50).Value = Obsgerente_pedTextBox.Text

        Try

            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Me.PedidoNFETableAdapter.Fill(Me.DataSetFinal.PedidoNFE)
        Obsvendedor_pedTextBox.Enabled = False
        Obsgerente_pedTextBox.Enabled = False
        Button52.Enabled = True
        Button58.Enabled = False

    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click

        Button61.Enabled = False
        Button42.Enabled = True

    End Sub
    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click

        Dim DataDespesas3 As Date = "01/01/2000"
        If TextBox185.Text = "" Or TextBox202.Text = "0" Or TextBox204.Text = "" Or DateTimePicker35.Text = DataDespesas3 Then
            MessageBox.Show("Preencher os dados para gravar ou escolher uma data")
            Exit Sub
        End If
        '----------------------------------------------------------------------------
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ----------------------------------------------------------------------------
        Dim command10 As SqlCommand
        command10 = connection.CreateCommand()
        Dim PorcFer As Double = 0
        Dim PorcSil As Double = 0
        Dim TotalFer As Double = 0
        Dim TotalSil As Double = 0


        If IdentificacaoCombobox = 1 Then
            command10.CommandText = "select * from NomeContasFuncionarios where ContasFuncionarios = '" & TextBox204.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_ContasFuncionarios")
                PorcSil = lrd("PorcSil_ContasFuncionarios")
            End While
            connection.Close()
        End If

        ' --------------------------------------------------

        ' Calcular despesas com aluguel
        If IdentificacaoCombobox = 2 Then
            command10.CommandText = "select * from NomeConta_aluguel_Banco where NomeConta_aluguel_Banco = '" & ComboBox11.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_AluguelBanco")
                PorcSil = lrd("PorcSil_AluguelBanco")
            End While
            connection.Close()
        End If


        ' --------------------------------------------------
        ' Calcular despesas com Transporte
        If IdentificacaoCombobox = 3 Then
            command10.CommandText = "select * from ContasTransportes where Nome_ContaTransportes = '" & ComboBox20.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_ContasTrasnportes")
                PorcSil = lrd("PorcSil_ContasTransportes")
            End While
            connection.Close()
        End If


        ' --------------------------------------------------

        ' Calcular despesas Extras
        If IdentificacaoCombobox = 4 Then
            command10.CommandText = "select * from NOmeContaExtras where NomeConta_extras2 = '" & ComboBox21.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_ContaExtras")
                PorcSil = lrd("ProcSil_ContaExtras")
            End While
            connection.Close()
        End If



        ' --------------------------------------------------
        '' Calcular despesas Impostos
        If IdentificacaoCombobox = 5 Then
            command10.CommandText = "select * from NomeContaImposto where NomeContaImpostos = '" & ComboBox22.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_Imposto")
                PorcSil = lrd("PrcSil_Imposto")
            End While
            connection.Close()
        End If


        If IdentificacaoCombobox = 6 Then
            command10.CommandText = "select * from NomeContaOutra where NomeContasOutras2 = '" & ComboBox23.Text & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command10.ExecuteReader()
            While lrd.Read()
                PorcFer = lrd("PorcFer_ContaOutra")
                PorcSil = lrd("PorcSil_ContaOutra")
            End While
            connection.Close()
        End If


        TotalFer = (PorcFer / 100) * TextBox202.Text
        TotalSil = (PorcSil / 100) * TextBox202.Text

        ' --------------------------------------------------------------------------
        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "INSERT INTO NomeContas (PorcentagemFerFras_conta,PorcentagemSilvia_conta,nome_conta,vr_conta,data_conta,codigo_identificação,data_lancamento,Obs_contas,codigo_identificacao2) values (@PorcentagemFerFras_conta,@PorcentagemSilvia_conta,@nome_conta,@vr_conta,@data_conta,@codigo_identificação,@data_lancamento,@Obs_contas,@codigo_identificacao2)"
        command.CommandType = CommandType.Text

        command.Parameters.Add("@nome_conta", SqlDbType.VarChar, 50).Value = TextBox204.Text
        command.Parameters.Add("@vr_conta", SqlDbType.Float).Value = TextBox202.Text
        command.Parameters.Add("@data_conta", SqlDbType.Date).Value = DateTimePicker35.Text
        command.Parameters.Add("@codigo_identificação", SqlDbType.VarChar, 50).Value = TextBox212.Text
        command.Parameters.Add("@data_lancamento", SqlDbType.Date).Value = Today
        command.Parameters.Add("@Obs_contas", SqlDbType.VarChar, 50).Value = TextBox203.Text
        command.Parameters.Add("@codigo_identificacao2", SqlDbType.VarChar, 50).Value = TextBox185.Text
        command.Parameters.Add("@PorcentagemFerFras_conta", SqlDbType.Float).Value = TotalFer
        command.Parameters.Add("@PorcentagemSilvia_conta", SqlDbType.Float).Value = TotalSil

        ' a seguir comandos para gravar os ítens coletados do formulário ------------------
        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()
            MessageBox.Show("Sucesso!")

        Catch ex As Exception

            MessageBox.Show("Algo ocorreu errado")
            MessageBox.Show(ex.ToString())

        Finally
            connection.Close()
        End Try

        Button59.Enabled = True
        Button63.Enabled = False
        Button64.Enabled = True
        TextBox202.Enabled = False
        TextBox185.Enabled = False
        TextBox203.Enabled = False
        Button68.Enabled = False
        Button69.Enabled = True
        Button64.Enabled = False
        Button82.Enabled = True
        Button66.Enabled = True
        Button70.Enabled = True
        Button71.Enabled = False

        ' bloquear os combos
        ComboBox6.Enabled = False
        ComboBox11.Enabled = False
        ComboBox20.Enabled = False
        ComboBox21.Enabled = False
        ComboBox22.Enabled = False
        ComboBox23.Enabled = False

        Me.NomeContasTableAdapter.Fill(Me.DataSetFinal.NomeContas)
        'Dim command20 As SqlCommand
        'command20 = connection.CreateCommand()
        'command20.CommandText = "SELECT * FROM NomeContas WHERE data_lancamento BETWEEN   convert (datetime, '" & DateTimePicker32.Text & "' ,103)  and convert (datetime, '" & DateTimePicker33.Text & "' ,103)"
        'connection.Open()
        'Dim lrd20 As SqlDataReader = command20.ExecuteReader()
        'While lrd20.Read()
        'End While
        'connection.Close()
    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click

        Button71.Enabled = True
        Button82.Enabled = False
        Button69.Enabled = False
        Button66.Enabled = False
        Button70.Enabled = False
        Dim NumeroMaximoCodigo As String = ""

        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "select *  from NomeContas ORDER BY id_conta"
        con.Open()
        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        While lrd.Read()
            NumeroMaximoCodigo = lrd("codigo_identificacao2")
        End While
        con.Close()

        ' limpando campos para serem preenchidos
        TextBox202.Clear()
        TextBox203.Clear()
        TextBox204.Clear()

        'habilitando botões e campos
        Button59.Enabled = False
        Button63.Enabled = True
        Button64.Enabled = False
        TextBox202.Enabled = True
        TextBox202.Text = 0
        TextBox203.Enabled = True
        TextBox203.Text = ""
        DateTimePicker35.Enabled = True
        Button68.Enabled = True

        ' bloquear os combos
        ComboBox6.Enabled = True
        ComboBox11.Enabled = True
        ComboBox20.Enabled = True
        ComboBox21.Enabled = True
        ComboBox22.Enabled = True
        ComboBox23.Enabled = True
        TextBox185.Text = NumeroMaximoCodigo + 1

    End Sub

   

    Private Sub NomeContasDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles NomeContasDataGridView.DoubleClick

        Button64.Enabled = True

        Dim v_SelectRow As Integer
        v_SelectRow = Me.NomeContasDataGridView.CurrentRow.Index
        TextBox185.Text = NomeContasDataGridView.Item(1, v_SelectRow).Value
        TextBox204.Text = NomeContasDataGridView.Item(2, v_SelectRow).Value
        TextBox202.Text = NomeContasDataGridView.Item(3, v_SelectRow).Value
        DateTimePicker35.Text = NomeContasDataGridView.Item(4, v_SelectRow).Value
        TextBox203.Text = NomeContasDataGridView.Item(5, v_SelectRow).Value

    End Sub

    Private Sub ComboBox11_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox11.MouseClick

        IdentificacaoCombobox = 2

    End Sub

    

    Private Sub ComboBox20_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox20.MouseClick

        IdentificacaoCombobox = 3

    End Sub

    Private Sub ComboBox21_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox21.MouseClick

        IdentificacaoCombobox = 4

    End Sub

    Private Sub TextBox202_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles TextBox202.Validating


        Dim currency As Decimal
      
        If Not Decimal.TryParse(Me.TextBox202.Text,
                                    Globalization.NumberStyles.Currency, Nothing, currency) Then


            With Me.TextBox202.HideSelection = False
                TextBox202.SelectAll()
                MessageBox.Show("Entre com um valor válido", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox202.HideSelection = True
                TextBox202.Clear()
            End With
            e.Cancel = True
        End If

    End Sub

    Private Sub Button64_Click(sender As Object, e As EventArgs) Handles Button64.Click


        If TextBox185.Text = "" Then

            MessageBox.Show("Campo de código em branco !!!")

            Exit Sub
        End If

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from NomeContas where codigo_identificacao2 = @codigo_identificacao2"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@codigo_identificacao2", SqlDbType.VarChar, 50).Value = TextBox185.Text

            Try

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                Me.NomeContasTableAdapter.Fill(Me.DataSetFinal.NomeContas)
                NomeContasBindingSource.MoveFirst()
             

                MessageBox.Show("Apagado com sucesso!")

            Catch ex As Exception

                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try

            Me.NomeContasTableAdapter.Fill(Me.DataSetFinal.NomeContas)
            Button64.Enabled = False
        End If



    End Sub

    Private Sub ComboBox22_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox22.MouseClick

        IdentificacaoCombobox = 5

    End Sub

    Private Sub ComboBox23_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox23.MouseClick

        IdentificacaoCombobox = 6

    End Sub

    Private Sub Button66_Click(sender As Object, e As EventArgs) Handles Button66.Click


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        '' Buscando o histórico de arquivos
        Dim sql1 As String = "SELECT * FROM NomeContas WHERE data_conta BETWEEN   convert (datetime, '" & DateTimePicker32.Text & "' ,103)  and convert (datetime, '" & DateTimePicker33.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds1 As New DataSet()

        Try
            connection.Open()
            dataadapter.Fill(ds1, "NomeContas")
            connection.Close()
            NomeContasDataGridView.DataSource = ds1.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Button67_Click(sender As Object, e As EventArgs)



    End Sub



    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click

        Dim connection As SqlConnection

        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        command = connection.CreateCommand()
        Dim TipoVenda As String = ""

        If IdentificacaoCombobox = 1 Then

            command.CommandText = "select * from NomeContasFuncionarios where ContasFuncionarios = '" & ComboBox6.Text & "'"
            TextBox204.Text = ComboBox6.Text
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            While lrd.Read()
                TipoVenda = lrd("tipoContaFuncionarios")
            End While
            connection.Close()
        End If



        If IdentificacaoCombobox = 2 Then

            command.CommandText = "select * from NomeConta_aluguel_Banco where NomeConta_aluguel_banco = '" & ComboBox11.Text & "'"
            TextBox204.Text = ComboBox11.Text
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            While lrd.Read()
                TipoVenda = lrd("tipoContaAluguelBanco")
            End While

            connection.Close()
        End If

        If IdentificacaoCombobox = 3 Then

            command.CommandText = "select * from ContasTransportes where Nome_ContaTransportes = '" & ComboBox20.Text & "'"
            TextBox204.Text = ComboBox20.Text
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            While lrd.Read()
                TipoVenda = lrd("TipoContaTranportes")
            End While

            connection.Close()
        End If

        If IdentificacaoCombobox = 4 Then

            command.CommandText = "select * from NOmeContaExtras where NomeConta_Extras2 = '" & ComboBox21.Text & "'"
            TextBox204.Text = ComboBox21.Text
            connection.Open()

            Dim lrd As SqlDataReader = command.ExecuteReader()
            While lrd.Read()
                TipoVenda = lrd("TipoContaExtra")
            End While
            connection.Close()
        End If

        If IdentificacaoCombobox = 5 Then

            command.CommandText = "select * from NomeContaImposto where NomeContaImpostos = '" & ComboBox22.Text & "'"
            TextBox204.Text = ComboBox22.Text
            connection.Open()

            Dim lrd As SqlDataReader = command.ExecuteReader()
            While lrd.Read()
                TipoVenda = lrd("TipoContaIMposto")
            End While
            connection.Close()
        End If

        If IdentificacaoCombobox = 6 Then

            command.CommandText = "select * from NomeContaOutra where NomeContasOutras2 = '" & ComboBox23.Text & "'"
            TextBox204.Text = ComboBox23.Text
            connection.Open()

            Dim lrd As SqlDataReader = command.ExecuteReader()
            While lrd.Read()
                TipoVenda = lrd("TipoContaOutra")
            End While
            connection.Close()
        End If
        TextBox212.Text = TipoVenda
        TextBox202.Focus()


    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button69_Click_1(sender As Object, e As EventArgs) Handles Button69.Click

        'pegar as datas
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month

        'Dim CodigoIdentificacaoDespesas As String
        TextBox185.Text = InputBox("Qual o código", "Cógigo")


        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT * from NomeContas where codigo_identificacao2 = " & "'" & TextBox185.Text & "'"

        con.Open()


        'REM verifica se cdigo de contas já existe banco do dados para não gravar duas vezes

        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try
            If lrd.Read() = True Then

                TextBox204.Text = lrd("nome_conta")
                TextBox202.Text = lrd("vr_conta").ToString()
                DateTimePicker35.Text = lrd("data_conta")
                TextBox203.Text = lrd("Obs_contas")
                con.Close()

                Exit Sub

            Else

                MessageBox.Show("O código não foi cadastrado !")
                TextBox204.Clear()
                TextBox202.Clear()
                DateTimePicker35.Value = New DateTime(ano, mes + 1, 1).AddDays(-3)
                TextBox203.Clear()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()

    End Sub

    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click

        TextBox185.Clear()
        TextBox204.Clear()
        TextBox202.Clear()
        TextBox203.Clear()


        Button59.Enabled = True
        Button63.Enabled = False
        Button64.Enabled = True
        TextBox202.Enabled = False
        TextBox185.Enabled = False
        TextBox203.Enabled = False
        DateTimePicker35.Enabled = False
        Button68.Enabled = False
        Button69.Enabled = True
        Button64.Enabled = False
        Button82.Enabled = True
        Button66.Enabled = True
        Button70.Enabled = True
        Button71.Enabled = False

        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim DataDespesas2 As Date = New DateTime(ano, mes + 1, 1).AddDays(-3)
        DateTimePicker35.Text = DataDespesas2

        ' bloquear os combos
        ComboBox6.Enabled = False
        ComboBox11.Enabled = False
        ComboBox20.Enabled = False
        ComboBox21.Enabled = False
        ComboBox22.Enabled = False
        ComboBox23.Enabled = False

        Me.NomeContasTableAdapter.Fill(Me.DataSetFinal.NomeContas)
    End Sub

    Private Sub PrintDocument12_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument12.PrintPage

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        'Dim reply As DialogResult = MessageBox.Show("Confirmar a impressão?", "Atenção. Verificar a data da impressão!!!", _
        ' MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)


        ''REM se confirmar a impressão
        'If reply = DialogResult.Yes Then

        Dim sql1 As String = "SELECT * FROM NomeContas WHERE data_conta BETWEEN   convert (datetime, '" & DateTimePicker32.Text & "' ,103)  and convert (datetime, '" & DateTimePicker33.Text & "' ,103) ORDER BY nome_conta"

        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "NomeContas")
            connection.Close()
            NomeContasDataGridView.DataSource = ds.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' cabeçalho
        e.Graphics.DrawString("LISTA DE LANÇAMENTOS DE DESPESAS - MARFINITE MOGI", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   1", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 5)
        ' Nome da Conta
        e.Graphics.DrawString("CONTA  ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 35)
        ' Valor da Conta
        e.Graphics.DrawString("VALOR ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 200, 35)
        ' OBSERVAÇÕES
        e.Graphics.DrawString("OBSERVAÇÕES", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 400, 35)
        ' Data da despesas
        e.Graphics.DrawString("Data da Despesa", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 35)


        Try
            For x As Integer = 0 To NomeContasDataGridView.Rows.Count() - 1

                e.Graphics.DrawString(NomeContasDataGridView.Item(2, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 100 + (x * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(3, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 100 + (x * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(5, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 400, 100 + (x * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(4, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 600, 100 + (x * 20))

                If x = 45 Then
                    PrintDocument13.Print()
                End If

            Next
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a impressão?", "Atenção. Verificar a data da impressão!!!", _
        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)


        'REM se confirmar a impressão
        If reply = DialogResult.Yes Then

            PrintDocument12.Print()


            If reply = DialogResult.No Then

                Me.NomeContasBindingSource.MoveFirst()

            End If
        End If

    End Sub

    Private Sub PrintDocument13_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument13.PrintPage

        ' cabeçalho
        e.Graphics.DrawString("LISTA DE LANÇAMENTOS DE DESPESAS - MARFINITE MOGI", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Pág.   2", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 5)
        ' Nome da Conta
        e.Graphics.DrawString("CONTA  ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 20, 35)
        ' Valor da Conta
        e.Graphics.DrawString("VALOR ", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 200, 35)
        ' OBSERVAÇÕES
        e.Graphics.DrawString("OBSERVAÇÕES", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 400, 35)
        ' Data da despesas
        e.Graphics.DrawString("Data da Despesa", New Font("arial", 10, FontStyle.Bold), Brushes.Black, 600, 35)

        Dim y As Integer = 0

        Try
            For x As Integer = 45 To NomeContasDataGridView.Rows.Count() - 1
                y += 1
                e.Graphics.DrawString(NomeContasDataGridView.Item(2, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 100 + (y * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(3, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 100 + (y * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(5, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 400, 100 + (y * 20))
                e.Graphics.DrawString(NomeContasDataGridView.Item(4, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 600, 100 + (y * 20))

            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub TextBox205_TextChanged(sender As Object, e As EventArgs) Handles TextBox205.TextChanged

    End Sub

    Private Sub ComboBox6_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox6.MouseClick

        IdentificacaoCombobox = 1

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click

        ProdutosBindingSource1.Filter = String.Format("Bugiganga_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}'", "bugiganga", "RAIZ")

        Dim custo_prod1 As String = ""
        Dim ipi_prod1 As String = ""
        Dim estoqueatual_prod1 As String = ""
        Dim ValorEstoqueAtual1 As Double = 0
        Dim ValorEstoqueAtual2 As Double = 0


        For x As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            If dataGridPediMarf.Item(11, x).Value.ToString() < 0 Then
            Else
                custo_prod1 = dataGridPediMarf.Item(14, x).Value.ToString()
                ipi_prod1 = dataGridPediMarf.Item(15, x).Value.ToString()
                estoqueatual_prod1 = dataGridPediMarf.Item(11, x).Value.ToString()
                ValorEstoqueAtual1 = (custo_prod1 * (1 + (ipi_prod1 / 100))) * estoqueatual_prod1
                ValorEstoqueAtual2 += ValorEstoqueAtual1
              End If
        Next
        TextBox309.Text = (ValorEstoqueAtual2 / 0.65).ToString("F2")
        TextBox217.Text = ValorEstoqueAtual2


    End Sub


    Private Sub ComboBox24_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button67_Click_1(sender As Object, e As EventArgs) Handles Button67.Click

        CriarPedidoToolStripMenuItem.Enabled = True
        DeletarItemToolStripMenuItem.Enabled = True
        Button67.Enabled = False

        TextBox27.Clear()
        TextBox210.Clear()
        TextBox215.Clear()
        TextBox26.Clear()
        TextBox64.Clear()
        DateTimePicker36.Text = Today
        FlagNotaentrada = "invalido"

    End Sub



    Private Sub NotasEntradaDataGridView_DoubleClick_1(sender As Object, e As EventArgs)
        Dim v_SelectRow As Integer
        v_SelectRow = Me.NotasEntradaDataGridView.CurrentRow.Index

        TextBox210.Text = NotasEntradaDataGridView.Item(8, v_SelectRow).Value.ToString()
        TextBox215.Text = NotasEntradaDataGridView.Item(9, v_SelectRow).Value.ToString()
        TextBox26.Text = NotasEntradaDataGridView.Item(5, v_SelectRow).Value.ToString()
        TextBox64.Text = NotasEntradaDataGridView.Item(6, v_SelectRow).Value.ToString()
        TextBox27.Text = NotasEntradaDataGridView.Item(2, v_SelectRow).Value.ToString()



    End Sub



    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click

        ProdutosBindingSource1.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox14.Text)

    End Sub

    Private Sub Button73_Click(sender As Object, e As EventArgs) Handles Button73.Click
        ProdutosBindingSource1.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox24.Text, ComboBox14.Text)
    End Sub

    Private Sub TextBox216_TextChanged(sender As Object, e As EventArgs) Handles TextBox216.TextChanged
        ProdutosBindingSource1.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox216.Text)
    End Sub



    Private Sub Button74_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Estoqueatual_prodTextBox_Validating(sender As Object, e As ComponentModel.CancelEventArgs)
        
    End Sub

    Private Sub Button78_Click_1(sender As Object, e As EventArgs) Handles Button78.Click

        TextBox27.Text = ""
        TextBox210.Text = ""
        TextBox215.Text = ""
        TextBox26.Text = ""
        TextBox64.Text = ""
        TextBox218.Text = ""

        Dim NumeroNotaENtrada As Integer = 0

        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT * from NotasEntrada    where NumeroNotaEntrada = " & "'" & TextBox218.Text & "'"
        con.Open()


        'REM verifica se cdigo de contas já existe banco do dados para não gravar duas vezes

        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try

            While lrd.Read

                TextBox27.Text = lrd("NumeroNotaEntrada").ToString
                TextBox210.Text = lrd("CodProdEntrada").ToString
                TextBox215.Text = lrd("NomeProdEntrada").ToString
                TextBox26.Text = lrd("QuantidadeNotaEntrada").ToString
                TextBox64.Text = lrd("PrecoNotaEntrada").ToString

            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()


    End Sub

    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
        ' calcula o estoque médio do balcão e grava na tabela de produtos
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' pega uma data de 90 dias atrás para dar um média de tres meses
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim dia As Integer = Today.Day
        Dim TrintaDiasAtras As DateTime = New DateTime(ano, mes, dia).AddDays(-31)

        Dim v_SelectRow As Integer = 0
        For v_SelectRow = 0 To ProdutosDataGridView3.RowCount() - 1

            Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & TrintaDiasAtras & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView3.Item(3, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView3.Item(4, v_SelectRow).Value & "'"
            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
                dataadapter.Fill(ds, "balcao")
                connection.Close()
                BalcaoDataGridView5.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim quantidadeBalcao As Decimal = 0
            Dim ArredondandoQtdeBalcao As Decimal = 0

            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
                quantidadeBalcao += Linha.Cells(4).Value
            Next

            ArredondandoQtdeBalcao = (quantidadeBalcao)
            TextBox127.Text = (ArredondandoQtdeBalcao).ToString("F2")

            ' ----------------------------------------------------------------------------------
            ' Passando Textbox para integer
            Dim QtdeConsumoMedio As Integer = 0
            QtdeConsumoMedio = TextBox127.Text
            ' ----------------------------------------------------
            ' ******************************************************
            ' LER ARQUIVO PRODUTOS PARA SABER SE É UM PRODUTO RAIZ OU NÃO
            Dim cmd As New SqlCommand
            cmd.Connection = connection
            cmd.CommandText = "SELECT * from PRODUTOS   where cod_prod = '" & ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString() & "'"
            connection.Open()

            'REM verifica se cdigo de contas já existe banco do dados para não gravar duas vezes
            Dim RaizouNao As String = ""
            Dim lrd As SqlDataReader = cmd.ExecuteReader()

            Try
                While lrd.Read
                    RaizouNao = lrd("RaizSimNao_prod").ToString
                End While
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            connection.Close()
            '------------------------------------------------------
            ' ***********************************************************
            Dim command As SqlCommand
            command = connection.CreateCommand()
            ' gravando o consumo medio no arquivo de produtos
            If RaizouNao = "NÃO RAIZ" Then

                command.CommandText = "update produtos set EmbalagemFabrica_prod=@EmbalagemFabrica_prod,EstoqueMedio_prod=@EstoqueMedio_prod,EstoquePrateleira_prod=@EstoquePrateleira_prod,pedencomendados_prod=@pedencomendados_prod,estaquemax_prod=@estaquemax_prod,estoqueatual_prod=@estoqueatual_prod,estoquemin_prod=@estoquemin_prod,MaxConsumoEstoque_prod=@MaxConsumoEstoque_prod,ConsumoMedio_prod=@ConsumoMedio_prod where cod_prod=@cod_prod "
                command.CommandType = CommandType.Text
                command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
                command.Parameters.Add("@ConsumoMedio_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@MaxConsumoEstoque_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@estoquemin_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@estaquemax_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@pedencomendados_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@EmbalagemFabrica_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@EstoquePrateleira_prod", SqlDbType.Int).Value = 0
                command.Parameters.Add("@EstoqueMedio_prod", SqlDbType.Int).Value = 0

            Else

                command.CommandText = "update produtos set MaxConsumoEstoque_prod=@MaxConsumoEstoque_prod,ConsumoMedio_prod=@ConsumoMedio_prod where cod_prod=@cod_prod "
                command.CommandType = CommandType.Text
                command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
                command.Parameters.Add("@ConsumoMedio_prod", SqlDbType.Int).Value = QtdeConsumoMedio

                Dim QuantmaxTemp As Integer = 0
                If ProdutosDataGridView3.Item(7, v_SelectRow).Value Is DBNull.Value Then
                    QuantmaxTemp = 0
                Else
                    QuantmaxTemp = ProdutosDataGridView3.Item(7, v_SelectRow).Value
                End If

                If QuantmaxTemp < ArredondandoQtdeBalcao Then
                    command.Parameters.Add("@MaxConsumoEstoque_prod", SqlDbType.Int).Value = ArredondandoQtdeBalcao
                Else
                    command.Parameters.Add("@MaxConsumoEstoque_prod", SqlDbType.Int).Value = QuantmaxTemp
                End If

            End If


            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        Next

        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub

    Private Sub Button79_Click(sender As Object, e As EventArgs) Handles Button79.Click

        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox18.Text, ComboBox17.Text)

    End Sub

    Private Sub BalcaoDataGridView5_DoubleClick_1(sender As Object, e As EventArgs) Handles BalcaoDataGridView5.DoubleClick

        'Dim v_SelectRow As Integer = 0
        'v_SelectRow = Me.BalcaoDataGridView5.CurrentRow.Index

        '' - tive que mudar a ordem do textbox abaixo porque ele so aceitava funcionar no começo....
        'TextBox128.Text = BalcaoDataGridView5.Item(14, v_SelectRow).Value.ToString()
        'TextBox223.Text = BalcaoDataGridView5.Item(6, v_SelectRow).Value.ToString()

        'Dim connection As SqlConnection
        'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        'Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and nomeProd_balcao = '" & BalcaoDataGridView5.Item(14, v_SelectRow).Value.ToString() & "' and corprod_balcao = '" & BalcaoDataGridView5.Item(6, v_SelectRow).Value.ToString() & "'"
        'Dim dataadapter As New SqlDataAdapter(sql2, connection)
        'Dim ds As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter.Fill(ds, "balcao")
        '    connection.Close()
        '    BalcaoDataGridView5.DataSource = ds.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        '' -----------------------------------
        ''somar quantidade da coluna da tabela balcão
        'Dim quantidadeBalcao As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
        '    quantidadeBalcao += Linha.Cells(7).Value
        'Next

        'TextBox163.Text = quantidadeBalcao
        'TextBox127.Text = (quantidadeBalcao / 3).ToString("F2")
        '' ----------------------------------------------------------------------------------
        '' Pesquisando dados na tabela de pedidos

        'Dim sql3 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and nome_item = '" & TextBox128.Text & "' and cor_item = '" & TextBox223.Text & "'"
        'Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        'Dim ds3 As New DataSet()
        'Try
        '    connection.Open()
        '    dataadapter3.Fill(ds3, "ItemPedidos")
        '    connection.Close()
        '    ItemPedidosDataGridView5.DataSource = ds3.Tables(0)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        '' -----------------------------------
        ''somar quantidade da coluna da tabela balcão
        'Dim quantidadePedidos As Decimal = 0
        'For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView5.Rows
        '    quantidadePedidos += Linha.Cells(8).Value
        'Next

        'TextBox226.Text = quantidadePedidos
        'TextBox227.Text = (quantidadePedidos / 3).ToString("F2")

    End Sub



    Private Sub ProdutosDataGridView3_DoubleClick(sender As Object, e As EventArgs) Handles ProdutosDataGridView3.DoubleClick

        Dim v_SelectRow As Integer = 0
        v_SelectRow = Me.ProdutosDataGridView3.CurrentRow.Index

        ' - tive que mudar a ordem do textbox abaixo porque ele so aceitava funcionar no começo....
        TextBox128.Text = ProdutosDataGridView3.Item(3, v_SelectRow).Value.ToString()
        TextBox223.Text = ProdutosDataGridView3.Item(4, v_SelectRow).Value.ToString()
        TextBox224.Text = ProdutosDataGridView3.Item(3, v_SelectRow).Value.ToString()
        TextBox225.Text = ProdutosDataGridView3.Item(4, v_SelectRow).Value.ToString()
        TextBox228.Text = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
        TextBox11.Text = ProdutosDataGridView3.Item(8, v_SelectRow).Value.ToString()
        TextBox340.Text = ProdutosDataGridView3.Item(9, v_SelectRow).Value.ToString()

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
           ' ------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and nomeProd_balcao = '" & TextBox128.Text & "' and corprod_balcao = '" & TextBox223.Text & "'"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView5.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' -----------------------------------
        'somar quantidade da coluna da tabela balcão
        Dim quantidadeBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
            quantidadeBalcao += Linha.Cells(4).Value
        Next

        Dim DiferencaData As Single = DateDiff("d", DateTimePicker23.Text, DateTimePicker24.Text)
        Label295.Text = DiferencaData
        TextBox163.Text = quantidadeBalcao
        TextBox127.Text = ((quantidadeBalcao / DiferencaData) * 30).ToString("F2")
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim FaturamentoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
            FaturamentoBalcao += Linha.Cells(7).Value
        Next
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim CustoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
            CustoBalcao += Linha.Cells(8).Value
        Next
        TextBox298.Text = FaturamentoBalcao - CustoBalcao
        ' -----------------------------------
       

        ' ----------------------------------------------------------------------------------
        ' Pesquisando dados na tabela de pedidos

        Dim sql3 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_item = '" & TextBox228.Text & "'"
        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView5.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' -----------------------------------
        'somar quantidade da coluna da tabela balcão
        Dim quantidadePedidos As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView5.Rows
            quantidadePedidos += Linha.Cells(4).Value
        Next
        Label296.Text = DiferencaData
        TextBox226.Text = quantidadePedidos
        TextBox227.Text = ((quantidadePedidos / DiferencaData) * 30).ToString("F2")
        

    End Sub


    Private Sub TextBox229_TextChanged(sender As Object, e As EventArgs) Handles TextBox229.TextChanged

        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox229.Text)

    End Sub



    Private Sub Button80_Click(sender As Object, e As EventArgs) Handles Button80.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        ' calcula os pedidos em aberto que falta entregar
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim v_SelectRow As Integer = 0
        For v_SelectRow = 0 To ProdutosDataGridView3.RowCount() - 1

            Dim sql2 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker23.Text & "' ,103)  and convert (datetime, '" & DateTimePicker24.Text & "' ,103) and codprod_item = '" & ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString() & "' and entregue_item = 'Não Entregue' "
            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
                dataadapter.Fill(ds, "ItemPedidos")
                connection.Close()
                ItemPedidosDataGridView9.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim quantidadePedidos As Decimal = 0
            ' Dim ArredondandoQtdeBalcao As Decimal = 0

            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView9.Rows
                quantidadePedidos += Linha.Cells(8).Value
            Next

            ' ArredondandoQtdeBalcao = quantidadePedidos
            TextBox127.Text = quantidadePedidos.ToString("F2")

            ' ----------------------------------------------------------------------------------
            ' Passando Textbox para integer
            Dim QtdePedidosColocados As Integer = 0
            QtdePedidosColocados = TextBox127.Text

            ' gravando o consumo medio no arquivo de produtos
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "update produtos set pedcolocados_prod=@pedcolocados_prod where cod_prod=@cod_prod "
            command.CommandType = CommandType.Text
            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
            command.Parameters.Add("@pedcolocados_prod", SqlDbType.Int).Value = quantidadePedidos
            If ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString() = "363br raiz " Then
                MessageBox.Show(quantidadePedidos)
            End If
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())

            Finally
                connection.Close()
            End Try


        Next

        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub

    Private Sub Button82_Click(sender As Object, e As EventArgs) Handles Button82.Click

        PegarHistoricoArquivoNomeContas()
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        command = connection.CreateCommand()


        ' calculando o gasto com as despesas de funcionários
        Dim ValorTotalFuncionarios As Double = 0
        Dim valorTotalAluguel As Double = 0

        ' ìndices Gerais
        Dim ValorDespesa As Double = 0
        Dim NomeConta As String = ""
        Dim identificacaoConta As Integer = 0
        Dim valorTotalTransporte As Double = 0
        Dim valorTotalContasExtra As Double = 0
        Dim valorTotalImpostos As Double = 0
        Dim contador As Integer = 0
        Dim ValorLucroContabil As Double = 0
        Dim ValorFernando As Double = 0
        Dim ValorTotalFerFunc As Double = 0
        Dim ValorSilvia As Double = 0
        Dim ValorTotalSilFunc As Double = 0
        Dim ValorTotalFerAluguel As Double = 0
        Dim ValorTotalSilAluguel As Double = 0
        Dim ValorTotalFerTrans As Double = 0
        Dim ValorTotalSilTrans As Double = 0
        Dim ValorTotalFerExtras As Double = 0
        Dim ValorTotalSilExtras As Double = 0
        Dim ValorTotalFerImpostos As Double = 0
        Dim ValorTotalSilImpostos As Double = 0
        Dim ValorTotalFerContabil As Double = 0
        Dim ValorTotalSilContabil As Double = 0


        command = connection.CreateCommand()

        For x = 0 To NomeContasDataGridView.RowCount() - 1

            command.CommandText = "SELECT * FROM NomeContas WHERE data_conta BETWEEN   convert (datetime, '" & DateTimePicker32.Text & "' ,103)  and convert (datetime, '" & DateTimePicker33.Text & "' ,103) and id_conta = '" & NomeContasDataGridView.Item(0, x).Value.ToString() & "'"

            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()
            Dim vlrdasdespesas As Double = 0

            While lrd.Read()

                NomeConta = lrd("nome_conta")
                ValorDespesa = lrd("vr_conta")
                identificacaoConta = lrd("codigo_identificação")
                ValorFernando = lrd("PorcentagemFerFras_conta")
                ValorSilvia = lrd("PorcentagemSilvia_conta")

            End While
            connection.Close()

            
            ' ------------------------------------------------------------------------------------------
            ' Calcular Despesas com Funcionários
            If identificacaoConta >= 0 And identificacaoConta <= 49 Then
                ValorTotalFuncionarios += ValorDespesa
                ValorTotalFerFunc += ValorFernando
                ValorTotalSilFunc += ValorSilvia
            End If
            TextBox205.Text = ValorTotalFuncionarios
            TextBox289.Text = ValorTotalFerFunc
            TextBox13.Text = ValorTotalSilFunc
            ' --------------------------------------------------

            ' Calcular despesas com aluguel
         
          
            If identificacaoConta >= 50 And identificacaoConta <= 99 Then
                valorTotalAluguel += ValorDespesa
                ValorTotalFerAluguel += ValorFernando
                ValorTotalSilAluguel += ValorSilvia
            End If
         
            TextBox207.Text = valorTotalAluguel
            TextBox291.Text = ValorTotalFerAluguel
            TextBox15.Text = ValorTotalSilAluguel

            ' --------------------------------------------------
            ' Calcular despesas com Transporte
            If identificacaoConta >= 100 And identificacaoConta <= 149 Then
                valorTotalTransporte += ValorDespesa
                ValorTotalFerTrans += ValorFernando
                ValorTotalSilTrans += ValorSilvia
            End If

             TextBox206.Text = valorTotalTransporte
            TextBox290.Text = ValorTotalFerTrans
            TextBox14.Text = ValorTotalSilTrans
            ' --------------------------------------------------

            ' Calcular despesas Extras
            If identificacaoConta >= 150 And identificacaoConta < 199 Then
                valorTotalContasExtra += ValorDespesa
                ValorTotalFerExtras += ValorFernando
                ValorTotalSilExtras += ValorSilvia
            End If
            TextBox208.Text = valorTotalContasExtra
            TextBox292.Text = ValorTotalFerExtras
            TextBox16.Text = ValorTotalSilExtras

            ' --------------------------------------------------
            '' Calcular despesas Impostos
            If identificacaoConta >= 200 And identificacaoConta < 249 Then
                valorTotalImpostos += ValorDespesa
                ValorTotalFerImpostos += ValorFernando
                ValorTotalSilImpostos += ValorSilvia
            End If
            TextBox209.Text = valorTotalImpostos
            TextBox293.Text = ValorTotalFerImpostos
            TextBox249.Text = ValorTotalSilImpostos

            ' -------------------------------------------------------------------------
            '' Calculos finais

            If identificacaoConta >= 250 Then
                ValorLucroContabil += ValorDespesa
                ValorTotalFerContabil += ValorFernando
                ValorTotalSilContabil += ValorSilvia
            End If
            TextBox184.Text = ValorLucroContabil
            TextBox295.Text = ValorTotalFerContabil
            TextBox287.Text = ValorTotalSilContabil


        Next
        '------------------------------------------------------------------------
        ' -----------------------------------------------------------------------
        ' calculando o lucro de cada setor
      

        ' Somando todas as despesas
        TextBox211.Text = (ValorTotalFuncionarios + valorTotalAluguel + valorTotalTransporte + valorTotalContasExtra + valorTotalImpostos).ToString("F2")
        TextBox294.Text = (ValorTotalFerFunc + ValorTotalFerAluguel + ValorTotalFerTrans + ValorTotalFerExtras + ValorTotalFerImpostos).ToString("F2")
        TextBox285.Text = (ValorTotalSilFunc + ValorTotalSilAluguel + ValorTotalSilTrans + ValorTotalSilExtras + ValorTotalSilImpostos).ToString("F2")
        If TextBox211.Text <> 0 Then
            TextBox214.Text = TextBox184.Text - TextBox211.Text
            TextBox296.Text = TextBox295.Text - TextBox294.Text
            TextBox288.Text = TextBox287.Text - TextBox285.Text
        End If

    End Sub

    Public Sub PegarHistoricoArquivoNomeContas()


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        '' Buscando o histórico de arquivos
        Dim sql1 As String = "SELECT * FROM NomeContas WHERE data_conta BETWEEN   convert (datetime, '" & DateTimePicker32.Text & "' ,103)  and convert (datetime, '" & DateTimePicker33.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql1, connection)
        Dim ds1 As New DataSet()

        Try
            connection.Open()
            dataadapter.Fill(ds1, "NomeContas")
            connection.Close()
            NomeContasDataGridView.DataSource = ds1.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub BalcaoDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles BalcaoDataGridView.DoubleClick

        If Button84.Enabled = True Then

            ' Dim contador As Integer = 0
            Dim connection5 As SqlConnection
            connection5 = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

            Dim v_SelectRow As Integer
            v_SelectRow = Me.BalcaoDataGridView.CurrentRow.Index
            'REM pega a quantidade de produtos no pedido
            Dim PrecoNovo As String = 0
            Dim PrecoNovo2 As Double = 0

            Dim TotalProdNovo As Double = 0
            Dim TotalPedNovo As Double = 0
            Dim xx As Integer


            PrecoNovo = InputBox("Digite o novo preço", "Preço antigo" & BalcaoDataGridView.Item(5, v_SelectRow).Value & " ")
            PrecoNovo2 = PrecoNovo
            If PrecoNovo2 = 0 Then
                Exit Sub
            End If

            TotalProdNovo = PrecoNovo2 * BalcaoDataGridView.Item(4, v_SelectRow).Value
            BalcaoDataGridView.Item(5, v_SelectRow).Value = PrecoNovo2
            BalcaoDataGridView.Item(6, v_SelectRow).Value = TotalProdNovo

            ' calcula o total do item
            For xx = 0 To BalcaoDataGridView.RowCount() - 1
                TotalPedNovo += BalcaoDataGridView.Item(6, xx).Value
            Next
            ' passar o total do pedido para todos os campos
            For xx = 0 To BalcaoDataGridView.RowCount() - 1
                BalcaoDataGridView.Item(7, xx).Value = TotalPedNovo
            Next

            TextBox220.Text = TotalPedNovo

            Dim command5 As SqlCommand
            command5 = connection5.CreateCommand()
            command5.CommandText = "update balcao set precoprod_balcao=@precoprod_balcao, totalprod_balcao=@totalprod_balcao  where id_balcao = '" & BalcaoDataGridView.Item(14, v_SelectRow).Value & "'"
            command5.CommandType = CommandType.Text

            '  command5.Parameters.Add("@id2_balcao", SqlDbType.VarChar, 50).Value = TextBox1.Text
            command5.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoNovo2
            command5.Parameters.Add("@totalprod_balcao", SqlDbType.Float).Value = TotalProdNovo.ToString("F2")

            Try
                connection5.Open()
                command5.ExecuteNonQuery()
                connection5.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

            Dim command10 As SqlCommand
            command10 = connection5.CreateCommand()
            command10.CommandText = "update balcao set totalpedido_prodbalcao=@totalpedido_prodbalcao  where id2_balcao = '" & BalcaoDataGridView.Item(15, v_SelectRow).Value & "'"
            command10.CommandType = CommandType.Text
            command10.Parameters.Add("@totalpedido_prodbalcao", SqlDbType.Float).Value = TotalPedNovo.ToString("F2")



            Try
                connection5.Open()
                command10.ExecuteNonQuery()
                connection5.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If

    End Sub

    Private Sub Button84_Click(sender As Object, e As EventArgs) Handles Button84.Click

        Button32.Enabled = True
        Button12.Enabled = False
        ComboBox2.Enabled = True
        Button11.Enabled = False
        tbcotrl_pdv.TabPages.Remove(tbpg_produtosPDV)

        ' trabalhando os radiobutton - formas de pagamento
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
        RadioButton5.Enabled = True
        RadioButton6.Enabled = True
        ' checar a venda a prazo, pois o preço foi calculado como a prazo
        RadioButton6.Checked = True
        Button84.Enabled = False
        ComboBox2.Text = ""
        btn_iniciarVenda.Enabled = True

        ' apaga textbox1  que se repete
        TextBox1.Clear()
        TextBox1.Text = ""
        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)
        '   BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}'", "kouigsfdghiugiug")

        'coloca A VISIBILIDADE DA PAGE DESEJADA
        TabControl1.TabPages.Insert(0, tbpg_produtos)
        TabControl1.TabPages.Insert(1, tbpg_clientes)
        TabControl1.TabPages.Insert(2, tbpg_pedFornecedor)
        TabControl1.TabPages.Insert(3, tbpg_transportadoras)
        TabControl1.TabPages.Insert(4, tbpg_capitalGiro)
        TabControl1.TabPages.Insert(5, tab_nfe)
        TabControl1.TabPages.Insert(6, pedidos)
        TabControl1.TabPages.Insert(7, tabpage_NFE_e)
        TabControl1.TabPages.Insert(9, tbpg_bkup)
        TabControl1.TabPages.Insert(10, tbpg_orcamento)
        TabControl1.TabPages.Insert(11, tbg_relatorios)
        ' outro tabcontrol
        tbcotrl_pdv.TabPages.Insert(1, tbpg_VendasBalcao)
        tbcotrl_pdv.TabPages.Insert(2, TabPage6)

        'trabalhando com os radiobutton
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        RadioButton5.Enabled = False
        RadioButton6.Enabled = False

        ' limpando os campos
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox3.Text = ""
        Label105.Text = ""
        Button32.Enabled = False
        ReabrirVendaBalcao = ""

        btn_addProd.Enabled = False

        BalcaoBindingSource.Filter = String.Format("id2_balcao LIKE '{0}%'", "kouighiugiug")


    End Sub

    Private Sub TextBox240_TextChanged(sender As Object, e As EventArgs) Handles TextBox240.TextChanged

        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox240.Text)

    End Sub

    
    Private Sub Button81_Click(sender As Object, e As EventArgs) Handles Button81.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim v_SelectRow As Integer = 0
        For v_SelectRow = 0 To ProdutosDataGridView3.RowCount() - 1

            ' ------------------------------------------------------------------------------------
            ' Pesquisando as médias mês anterior

            Dim ano40 As Integer = Today.Year
            Dim mes40 As Integer = Today.Month
            Dim dia40 As Integer = Today.Day
            Dim primeiroDia40 As DateTime = New DateTime(ano40, mes40, dia40).AddDays(-31)
            Dim ultimoDia40 As DateTime = New DateTime(ano40, mes40, dia40).AddDays(-1)


            Dim sql40 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & primeiroDia40 & "' ,103)  and convert (datetime, '" & ultimoDia40 & "' ,103)and nomeProd_balcao = '" & ProdutosDataGridView3.Item(3, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView3.Item(4, v_SelectRow).Value & "'"
            Dim dataadapter40 As New SqlDataAdapter(sql40, connection)
            Dim ds40 As New DataSet()
            Try
                connection.Open()
                dataadapter40.Fill(ds40, "balcao")
                connection.Close()
                BalcaoDataGridView5.DataSource = ds40.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim quantidadeBalcao40 As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
                quantidadeBalcao40 += Linha.Cells(4).Value
            Next
            Dim MesPassado As Integer = quantidadeBalcao40

            ' ------------------------------------------------------
            ' Pesquisando mês retrasado

            Dim ano50 As Integer = Today.Year
            Dim mes50 As Integer = Today.Month
            Dim dia50 As Integer = Today.Day
            Dim primeiroDia50 As DateTime = New DateTime(ano50, mes50, dia50).AddDays(-61)
            Dim ultimoDia50 As DateTime = New DateTime(ano50, mes50, dia50).AddDays(-31)

            Dim sql50 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & primeiroDia50 & "' ,103)  and convert (datetime, '" & ultimoDia50 & "' ,103) and codprod_balcao = '" & ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString() & "'"
            Dim dataadapter50 As New SqlDataAdapter(sql50, connection)
            Dim ds50 As New DataSet()
            Try
                connection.Open()
                dataadapter50.Fill(ds50, "balcao")
                connection.Close()
                BalcaoDataGridView5.DataSource = ds50.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim quantidadeBalcao50 As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
                quantidadeBalcao50 += Linha.Cells(4).Value
            Next

            Dim MesRetrasado As Integer = quantidadeBalcao50
            ' ----------------------------------------------------
            ' ****************************************************
            ' LER ARQUIVO PRODUTOS PARA SABER SE É UM PRODUTO RAIZ OU NÃO
            Dim cmd As New SqlCommand
            cmd.Connection = connection
            cmd.CommandText = "SELECT * from fornecedor   where xNome_for = '" & ProdutosDataGridView3.Item(1, v_SelectRow).Value.ToString() & "'"
            connection.Open()

            'REM verifica se cdigo de contas já existe banco do dados para não gravar duas vezes
            Dim TempoEntrega As String = 0
            Dim lrd As SqlDataReader = cmd.ExecuteReader()

            Try
                While lrd.Read
                    TempoEntrega = lrd("TempoEntrega_fornecedor").ToString
                End While
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            connection.Close()


            ' ******************************************************
            ' --------------------------------------------------------------
            ' gravando na coluna de produtos CrescimentoVendas_prod se o produto está crescendo ou não
            Dim command5 As SqlCommand
            command5 = connection.CreateCommand()
            command5.CommandType = CommandType.Text
            command5.CommandText = "update produtos set EstoqueMedio_prod=@EstoqueMedio_prod,CrescimentoVendas_prod=@CrescimentoVendas_prod, estoquemin_prod=@estoquemin_prod,  estaquemax_prod=@estaquemax_prod  where cod_prod=@codprod and cor_prod = @cor_prod "
            command5.Parameters.Add("@codprod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
            command5.Parameters.Add("@cor_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(4, v_SelectRow).Value.ToString()

            ' passando a vari´vel "MesPassado" como estoque mínimo mais 15 dias de consumo de margem de segurança - ela é calculada para 30 dias
            Dim TempoEntregaInt As Integer = 0
            Integer.TryParse(TempoEntrega, TempoEntregaInt)

            Dim EstoqueMin As Integer = 0
            EstoqueMin = ((MesPassado / 30) * TempoEntregaInt) * 1
            command5.Parameters.Add("@estoquemin_prod", SqlDbType.Int).Value = EstoqueMin
            ' calculando estoque maximo
            Dim EstoqueMax As Integer = 0
            EstoqueMax = ((MesPassado / 30) * TempoEntregaInt) * 3
            command5.Parameters.Add("@estaquemax_prod", SqlDbType.Int).Value = EstoqueMax

            If MesRetrasado > MesPassado Then
                command5.Parameters.Add("@CrescimentoVendas_prod", SqlDbType.VarChar, 50).Value = "Negativo"
            Else
                command5.Parameters.Add("@CrescimentoVendas_prod", SqlDbType.VarChar, 50).Value = "Positivo"
            End If
            Dim EstoqueMedio As Double = (EstoqueMin + EstoqueMax) / 2
            command5.Parameters.Add("@EstoqueMedio_prod", SqlDbType.Float).Value = EstoqueMedio

           

            Try
                connection.Open()
                command5.ExecuteNonQuery()
                connection.Close()

            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())

            End Try
        Next

        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub

    Private Sub Button83_Click(sender As Object, e As EventArgs) Handles Button83.Click

        ' calcula os pedidos em aberto que falta entregar
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim sql40 As String = "SELECT * FROM produtos WHERE fornecedor_prod = '" & ComboBox25.Text & "' and linha_prod = '" & ComboBox31.Text & "'and RaizSimNao_prod = 'RAIZ' ORDER BY nome_prod"
        Dim dataadapter40 As New SqlDataAdapter(sql40, connection)
        Dim ds40 As New DataSet()
        Try
            connection.Open()
            dataadapter40.Fill(ds40, "produtos")
            connection.Close()
            ProdutosDataGridView5.DataSource = ds40.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        For x = 0 To ProdutosDataGridView5.Rows.Count() - 1
            If ProdutosDataGridView5.Item(8, x).Value > ProdutosDataGridView5.Item(9, x).Value Then
                ProdutosDataGridView5.Rows(x).Cells(6).Style.ForeColor = Color.Red
                ProdutosDataGridView5.Rows(x).Cells(8).Style.ForeColor = Color.Red
                ProdutosDataGridView5.Rows(x).Cells(9).Style.ForeColor = Color.Red
            End If
        Next


    End Sub

    Private Sub TextBox243_TextChanged(sender As Object, e As EventArgs) Handles TextBox243.TextChanged
        ProdutosBindingSource1.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox243.Text)
    End Sub

    Private Sub TextBox244_TextChanged(sender As Object, e As EventArgs) Handles TextBox244.TextChanged
        ProdutosBindingSource1.Filter = String.Format("codbarras_prod LIKE '{0}%'", TextBox244.Text)

    End Sub

    Private Sub TextBox250_TextChanged(sender As Object, e As EventArgs) Handles TextBox250.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox250.Text)
    End Sub

    Private Sub TextBox252_TextChanged(sender As Object, e As EventArgs) Handles TextBox252.TextChanged
        ProdutosBindingSource.Filter = String.Format("Apelido_prod LIKE '{0}%'", TextBox252.Text)

    End Sub

    Private Sub Custo_prodTextBox_TextChanged(sender As Object, e As EventArgs) Handles Custo_prodTextBox.TextChanged

    End Sub

    Private Sub Button87_Click(sender As Object, e As EventArgs) Handles Button87.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}' and linha_prod LIKE '{1}' and Bugiganga_prod LIKE '{2}'", ComboBox33.Text, ComboBox34.Text, "bugiganga")
    End Sub

    Private Sub Button88_Click(sender As Object, e As EventArgs) Handles Button88.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        Dim date1 As New Date()
        date1 = Date.Now
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim datacodigo2 = date1.ToString("dd.MM.yyyy.hh", ci)
        datacodigo2 = datacodigo2.Replace(".", "")
        ' --------------------------------
        ' Código de acesso
        If codigoEntrada <> datacodigo2 Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
       
        RadioButton8.Enabled = True
        RadioButton10.Enabled = True
        RadioButton23.Enabled = True
        

    End Sub

    Private Sub TextBox254_TextChanged(sender As Object, e As EventArgs) Handles TextBox254.TextChanged

        ProdutosBindingSource.Filter = String.Format("codbarras_prod LIKE '{0}%'", TextBox254.Text)

    End Sub

    Private Sub Button89_Click(sender As Object, e As EventArgs)

        ProdutosBindingSource.Filter = String.Format("Bugiganga_prod LIKE '{0}%'", "bugiganga")

    End Sub
    Private Sub Button89_Click_1(sender As Object, e As EventArgs) Handles Button89.Click

        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and linha_prod LIKE '{1}' and RaizSimNao_prod LIKE '{2}'", ComboBox27.Text, ComboBox28.Text, "RAIZ")
        Label94.Text = ProdutosDataGridView4.Rows.Count() - 1

    End Sub

    

    Private Sub Button92_Click(sender As Object, e As EventArgs) Handles Button92.Click

        variavelImpressao = "3"
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}%'", ComboBox29.Text, "RAIZ")
        Label94.Text = ProdutosDataGridView4.Rows.Count()

    End Sub

    Private Sub Button90_Click(sender As Object, e As EventArgs) Handles Button90.Click
        ' calcula os pedidos em aberto que falta entregar
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql40 As String = "SELECT * FROM produtos WHERE  fornecedor_prod = '" & ComboBox25.Text & "'and RaizSimNao_prod = 'RAIZ'  ORDER BY nome_prod"
        Dim dataadapter40 As New SqlDataAdapter(sql40, connection)
        Dim ds40 As New DataSet()
        Try
            connection.Open()
            dataadapter40.Fill(ds40, "produtos")
            connection.Close()
            ProdutosDataGridView5.DataSource = ds40.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        For x = 0 To ProdutosDataGridView5.Rows.Count() - 1
            If ProdutosDataGridView5.Item(8, x).Value > ProdutosDataGridView5.Item(9, x).Value Then
                ProdutosDataGridView5.Rows(x).Cells(6).Style.ForeColor = Color.Red
                ProdutosDataGridView5.Rows(x).Cells(8).Style.ForeColor = Color.Red
                ProdutosDataGridView5.Rows(x).Cells(9).Style.ForeColor = Color.Red
            End If

        Next


    End Sub

    Private Sub Label330_Click(sender As Object, e As EventArgs) Handles Label330.Click

    End Sub

    Private Sub TextBox258_TextChanged(sender As Object, e As EventArgs) Handles TextBox258.TextChanged
        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox258.Text)
    End Sub

    Private Sub TextBox256_TextChanged(sender As Object, e As EventArgs) Handles TextBox256.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox256.Text)
    End Sub

    Private Sub TextBox257_TextChanged(sender As Object, e As EventArgs) Handles TextBox257.TextChanged
        ProdutosBindingSource.Filter = String.Format("codbarras_prod LIKE '{0}%'", TextBox257.Text)
    End Sub

    Private Sub TextBox255_TextChanged(sender As Object, e As EventArgs) Handles TextBox255.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox255.Text)
    End Sub

    ' Private Sub Button93_Click(sender As Object, e As EventArgs) Handles Button93.Click


    'REM passa dados para a planilha excell de pedidos   -------
    'Dim xlApp1 As Excel.Application
    'Dim xlWorkBook1 As Excel.Workbook
    'Dim xlWorkSheet1 As Excel.Worksheet
    '' ------------------------------------
    '' Variáveis que vão pegar os valores da tabela e passar para o arquivo
    'Dim NumeroPedido As String
    'Dim DataPedido As Date
    'Dim NomeContato As String
    'Dim CEP As String
    'Dim Municipio As String
    'Dim Estado As String
    'Dim Endereco As String
    'Dim NumeroRua As String
    'Dim Complemento As String
    'Dim Bairro As String
    'Dim Fone As String
    'Dim NomeProduto As String
    'Dim Quantidade As Double
    'Dim VrUnitario As Double
    'Dim x As Integer
    'Dim xy As Integer = 1

    '' --------------------------------------------------------------
    'Dim connection As SqlConnection
    'connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


    '' ---------------------------------------------------------------------------------------

    'xlApp1 = New Excel.Application
    '' xlWorkBook1 = xlApp1.Workbooks.Open("\\FERNANDO\Disco C\C:\Users\Central\Desktop\Vendas bgugigangas\vendas março\pedidos_venda_501-1020.xlsx")
    'xlWorkBook1 = xlApp1.Workbooks.Open("C:\Users\Central\Desktop\Vendas bgugigangas\vendas março\Cópia de pedidos_venda_501-1000.xls")
    'xlWorkSheet1 = CType(xlWorkBook1.Sheets(1), Excel.Worksheet)

    'For x = 2 To 4 ' VendasMlbDataGridView.RowCount() - 1

    '    NumeroPedido = Trim(xlWorkBook1.Application.Cells(x, 2).Value)
    '    DataPedido = Trim(xlWorkBook1.Application.Cells(x, 3).Value)
    '    NomeContato = Trim(xlWorkBook1.Application.Cells(x, 6).Value)
    '    CEP = Trim(xlWorkBook1.Application.Cells(x, 10).Value)

    '    Municipio = Trim(xlWorkBook1.Application.Cells(x, 11).Value)
    '    Estado = Trim(xlWorkBook1.Application.Cells(x, 12).Value)
    '    Endereco = Trim(xlWorkBook1.Application.Cells(x, 13).Value)
    '    NumeroRua = Trim(xlWorkBook1.Application.Cells(x, 14).Value)

    '    Complemento = Trim(xlWorkBook1.Application.Cells(x, 15).Value)
    '    Bairro = Trim(xlWorkBook1.Application.Cells(x, 16).Value)
    '    Fone = Trim(xlWorkBook1.Application.Cells(x, 17).Value)
    '    NomeProduto = Trim(xlWorkBook1.Application.Cells(x, 25).Value)
    '    Quantidade = Trim(xlWorkBook1.Application.Cells(x, 26).Value)
    '    VrUnitario = Trim(xlWorkBook1.Application.Cells(x, 27).Value)
    '    '---------------------------------------------------------------------------------------------
    '    'REM verifica se o produto já foi cadastrado mas só se for incluir
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand

    '    cmd.Connection = con
    '    cmd.CommandText = "SELECT NomeProduto_VendasMlb  from VendasMlb where NomeProduto_VendasMlb = '" & NomeProduto & "'"




    '    'REM verifica se cdigo prod existe banco do produto na nota para não gravar duas vezes
    '    connection.Open()
    '    Dim lrd As SqlDataReader = cmd.ExecuteReader()



    '    Try

    '        If lrd.Read() = True Then

    '            MessageBox.Show("O código do produto " & NomeProduto & " já foi cadastrado!!!!")
    '            'con.Close()
    '            '   Exit Sub
    '            connection.Close()
    '        Else

    '            ' --------------------------------------------------------------------------------------------
    '            Dim command As SqlCommand
    '            command = connection.CreateCommand()
    '            command.CommandText = "INSERT INTO VendasMlb (NUmeroPedido2_VendasMlb, DataPedido_VendasMlb,NomeContato_VendasMlb,CEP_VendasMlb,Municipio_VendasMlb,Estado_VendasMlb,Endereco_VendasMLb,NumeroRua_VendasMlb, Complemento_VendasMlb, Bairro_VendasMlb, Fone_VendasMlb, NomeProduto_VendasMlb, QuantidadeVendida_VendasMlb, VrUnitario_VendasMlb) Values (@NUmeroPedido2_VendasMlb,@DataPedido_VendasMlb,@NomeContato_VendasMlb,@CEP_VendasMlb,@Municipio_VendasMlb,@Estado_VendasMlb,@Endereco_VendasMLb,@NumeroRua_VendasMlb, @Complemento_VendasMlb,@Bairro_VendasMlb, @Fone_VendasMlb, @NomeProduto_VendasMlb, @QuantidadeVendida_VendasMlb, @VrUnitario_VendasMlb)"
    '            command.CommandType = CommandType.Text

    '            command.Parameters.Clear()
    '            command.Parameters.Add("@NUmeroPedido2_VendasMlb", SqlDbType.VarChar, 50).Value = NumeroPedido
    '            command.Parameters.Add("@DataPedido_VendasMlb", SqlDbType.Date).Value = DataPedido
    '            command.Parameters.Add("@NomeContato_VendasMlb", SqlDbType.VarChar, 50).Value = NomeContato

    '            command.Parameters.Add("@CEP_VendasMlb", SqlDbType.VarChar, 50).Value = CEP
    '            command.Parameters.Add("@Municipio_VendasMlb", SqlDbType.VarChar, 50).Value = Municipio
    '            command.Parameters.Add("@Estado_VendasMlb", SqlDbType.VarChar, 50).Value = Estado
    '            command.Parameters.Add("@Endereco_VendasMLb", SqlDbType.VarChar, 50).Value = Endereco
    '            command.Parameters.Add("@NumeroRua_VendasMlb", SqlDbType.VarChar, 50).Value = NumeroRua

    '            command.Parameters.Add("@Complemento_VendasMlb", SqlDbType.VarChar, 50).Value = Complemento
    '            command.Parameters.Add("@Bairro_VendasMlb", SqlDbType.VarChar, 50).Value = Bairro
    '            command.Parameters.Add("@Fone_VendasMlb", SqlDbType.VarChar, 50).Value = Fone
    '            command.Parameters.Add("@NomeProduto_VendasMlb", SqlDbType.VarChar, 50).Value = NomeProduto
    '            command.Parameters.Add("@QuantidadeVendida_VendasMlb", SqlDbType.Float).Value = Quantidade
    '            command.Parameters.Add("@VrUnitario_VendasMlb", SqlDbType.Float).Value = VrUnitario

    '            ' a seguir comandos para gravar os ítens coletados do formulário ------------------
    '            Try
    '                connection.Open()
    '                command.ExecuteNonQuery()
    '                connection.Close()

    '            Catch ex As Exception
    '                MessageBox.Show("Algo ocorreu errado")
    '                MessageBox.Show(ex.ToString())

    '            Finally
    '                connection.Close()
    '            End Try

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try

    'Next
    'xlWorkBook1.Close()



    ' End Sub

    'Private Sub Button94_Click(sender As Object, e As EventArgs) Handles Button94.Click

    '        Dim connection As SqlConnection
    '        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

    '        Dim command As SqlCommand
    '        Dim xx As Integer
    '        Dim NomeContato2 As String = ""
    '        Dim CodigoAnterior As String = ""





    '        For xx = 0 To VendasMlbDataGridView.RowCount() - 1

    '            command = connection.CreateCommand()
    '            command.CommandText = "SELECT * FROM VendasMlb WHERE NUmeroPedido2_VendasMlb = '" & VendasMlbDataGridView.Item(1, xx).Value & "'and CodigoMlb_VendasMlb = '" & VendasMlbDataGridView.Item(15, xx).Value & "'"
    '            command.CommandType = CommandType.Text


    '            ' -----------------------------------------------------------------
    '            ' Pego o nome do produto no arquivo vendasmlb 
    '            Dim ApelidoProdutoMlb As String = ""
    '            Dim QuantidadeVendidaMlb As Double = 0
    '            Dim DataVendaMlb As Date
    '            Dim CodigoMlb As String = ""
    '            Dim NumeroNota As String = ""
    '            Dim NomeContato As String = ""
    '            ' ------------------------------------------------

    '            connection.Open()
    '            Dim lrd As SqlDataReader = command.ExecuteReader()
    '            While lrd.Read

    '                ApelidoProdutoMlb = lrd("NomeProduto_VendasMlb").ToString
    '                QuantidadeVendidaMlb = lrd("QuantidadeVendida_VendasMlb")
    '                DataVendaMlb = lrd("DataPedido_VendasMlb").ToString
    '                CodigoMlb = lrd("CodigoMlb_VendasMlb").ToString
    '                NumeroNota = lrd("NUmeroPedido2_VendasMlb").ToString
    '                NomeContato = lrd("NomeContato_VendasMlb").ToString

    '            End While
    '            connection.Close()

    '            ' -----------------------------------------------------------------------------
    '            ' Procura o valor no produto
    '            ' Pego o valor do produto no arquivo produtos 
    '            Dim ValorProduto As Double = 0
    '            Dim CodigoProduto As String = ""
    '            Dim FornecedorProduto As String = ""
    '            Dim LinhaProduto As String = ""
    '            Dim CorProduto As String = ""
    '            Dim PrecoAtacadoProduto As Double = 0
    '            Dim NomeProduto As String = ""
    '            Dim CustoProduto As Double = 0
    '            Dim IPIProduto As Double = 0
    '            Dim command2 As SqlCommand
    '            command2 = connection.CreateCommand()
    '            command2.CommandText = "SELECT * from produtos WHERE  cod_prodfor = '" & CodigoMlb & " 'or CodigoMlb_prod = '" & CodigoMlb & "'"
    '            command2.CommandType = CommandType.Text
    '            ' -------------------------------------------------------------------
    '            connection.Open()
    '            Dim lrd2 As SqlDataReader = command2.ExecuteReader()

    '            While lrd2.Read

    '                ValorProduto = lrd2("precoatacado_prod").ToString
    '                CodigoProduto = lrd2("cod_prod").ToString
    '                FornecedorProduto = lrd2("fornecedor_prod").ToString
    '                LinhaProduto = lrd2("linha_prod").ToString
    '                CorProduto = lrd2("cor_prod").ToString
    '                PrecoAtacadoProduto = lrd2("precoatacado_prod").ToString
    '                NomeProduto = lrd2("nome_prod").ToString
    '                CustoProduto = lrd2("custo_prod").ToString
    '                IPIProduto = lrd2("ipi_prod").ToString

    '            End While
    '            connection.Close()
    '            ' -----------------------------------------------------
    '            Dim CodComp1 As String = ""
    '            Dim CodComp2 As String = ""
    '            Dim CodComp3 As String = ""
    '            Dim CodComp4 As String = ""
    '            Dim CodComp5 As String = ""
    '            Dim QtdeComp1 As Double = 0
    '            Dim QtdeComp2 As Double = 0
    '            Dim QtdeComp3 As Double = 0
    '            Dim QtdeComp4 As Double = 0
    '            Dim QtdeComp5 As Double = 0
    '            '--------------------------------


    '            connection.Open()
    '            Dim lrd3 As SqlDataReader = command2.ExecuteReader()
    '            If LinhaProduto = "produto combo/kit" Then

    '                While lrd3.Read

    '                    CodComp1 = lrd3("CodComp1_prod").ToString
    '                    QtdeComp1 = lrd3("QtdeComp1_prod").ToString
    '                    CodComp2 = lrd3("CodComp2_prod").ToString
    '                    QtdeComp2 = lrd3("QtdeComp2_prod").ToString
    '                    CodComp3 = lrd3("CodComp3_prod").ToString
    '                    QtdeComp3 = lrd3("QtdeComp3_prod").ToString
    '                    CodComp4 = lrd3("CodComp4_prod").ToString
    '                    QtdeComp4 = lrd3("QtdeComp4_prod").ToString
    '                    CodComp5 = lrd3("CodComp5_prod").ToString
    '                    QtdeComp5 = lrd3("QtdeComp5_prod").ToString

    '                End While
    '            End If
    '            connection.Close()

    '            If NomeProduto <> "" Then

    '                'REM verifica se o produto já foi cadastrado no arquivo balcão(tem defeito-se a nota tiver vários itens)
    '                Dim cmd As New SqlCommand
    '                cmd.Connection = connection
    '                cmd.CommandText = "SELECT CodigoMlb_balcao  from balcao where CodigoMlb_balcao = '" & NumeroNota & "'"
    '                ' ---------------------------------------------------------------
    '                connection.Open()
    '                'REM verifica se código prod existe no arquivo balcão, para não gravar duas vezes
    '                Dim lrd5 As SqlDataReader = cmd.ExecuteReader()

    '                Try
    '                    If lrd5.Read() = True Then
    '                        ' MessageBox.Show("O código do produto " & NomeProduto & " já foi cadastrado!!!!")
    '                        connection.Close()
    '                        GoTo Proxima

    '                    End If

    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                End Try

    '                connection.Close()

    '                ' -----------------------------------------------------------------------------
    '                ' Faz o lançamento em vendas balcão
    '                Dim command5 As SqlCommand
    '                command5 = connection.CreateCommand()
    '                command5.CommandText = "insert into balcao (Avista_APrazo_balcao,FormaPgto_balcao,totalpedido_prodbalcao,id2_balcao,nomevendedor_balcao,codprod_balcao,forprod_balcao,linhaprod_balcao,corprod_balcao,quantidadeprod_balcao,precoprod_balcao,totalprod_balcao,datavenda_prodbalcao,desconto_balcao,nomeProd_balcao,Custo_balcao,vendaOrcamento_balcao,CodigoMlb_balcao) values (@Avista_APrazo_balcao,@FormaPgto_balcao,@totalpedido_prodbalcao,@id2_balcao,@nomevendedor_balcao,@codprod_balcao,@forprod_balcao,@linhaprod_balcao,@corprod_balcao,@quantidadeprod_balcao,@precoprod_balcao,@totalprod_balcao,@datavenda_prodbalcao,@desconto_balcao,@nomeProd_balcao,@Custo_balcao,@vendaOrcamento_balcao, @CodigoMlb_balcao)"
    '                command5.CommandType = CommandType.Text

    '                command5.Parameters.Clear()
    '                command5.Parameters.Add("@id2_balcao", SqlDbType.VarChar, 50).Value = "1000"
    '                command5.Parameters.Add("@nomevendedor_balcao", SqlDbType.VarChar, 50).Value = "Bee"
    '                command5.Parameters.Add("@codprod_balcao", SqlDbType.VarChar, 50).Value = CodigoProduto
    '                command5.Parameters.Add("@forprod_balcao", SqlDbType.VarChar, 50).Value = FornecedorProduto
    '                command5.Parameters.Add("@linhaprod_balcao", SqlDbType.VarChar, 50).Value = LinhaProduto
    '                command5.Parameters.Add("@corprod_balcao", SqlDbType.VarChar, 50).Value = CorProduto
    '                command5.Parameters.Add("@quantidadeprod_balcao", SqlDbType.Float).Value = QuantidadeVendidaMlb
    '                command5.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoAtacadoProduto
    '                command5.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A prazo"
    '                command5.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Outros"
    '                command5.Parameters.Add("@CodigoMlb_balcao", SqlDbType.VarChar, 50).Value = NumeroNota

    '                ' CALCULANDO O TOTAL DO BALCAO POR ÍTEM
    '                Dim QuantidadeVendidas As Double = QuantidadeVendidaMlb
    '                Dim PrecoAtacado As Double = PrecoAtacadoProduto
    '                Dim TLProdBalcao = QuantidadeVendidas * PrecoAtacado
    '                Dim TLProdBalcao2 As String = TLProdBalcao.ToString
    '                command5.Parameters.Add("@totalprod_balcao", SqlDbType.Float).Value = TLProdBalcao2
    '                command5.Parameters.Add("@totalpedido_prodbalcao", SqlDbType.Float).Value = TLProdBalcao2
    '                command5.Parameters.Add("@datavenda_prodbalcao", SqlDbType.Date).Value = DataVendaMlb
    '                command5.Parameters.Add("@nomeProd_balcao", SqlDbType.VarChar, 50).Value = NomeProduto
    '                command5.Parameters.Add("@desconto_balcao", SqlDbType.Float).Value = "0"

    '                ' calcula o custo dos produtos
    '                Dim Tlpedido_prodbalcao As Double = ((CustoProduto) * (1 + (IPIProduto) / 100)) * QuantidadeVendidaMlb
    '                Dim Tlpedido_prodbalcao2 As String = Tlpedido_prodbalcao.ToString("F2")
    '                command5.Parameters.Add("@Custo_balcao", SqlDbType.Float).Value = Tlpedido_prodbalcao2
    '                ' calcula o lucro da operação
    '                Dim LucroBalcao As Double = (1 - (Tlpedido_prodbalcao / TLProdBalcao2)) * 100
    '                Dim LucroBalcao2 As String = LucroBalcao.ToString("F2")
    '                command5.Parameters.Add("@vendaOrcamento_balcao", SqlDbType.VarChar, 50).Value = LucroBalcao2

    '                Try
    '                    connection.Open()
    '                    command5.ExecuteNonQuery()
    '                    connection.Close()

    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString())
    '                End Try
    '                ' ------------------------------------------------
    '            Else
    '                Dim command15 As SqlCommand
    '                command15 = connection.CreateCommand()
    '                command15.CommandText = "insert into ApelidoErrado (Nome_ApelidoErrado,CodigoMlb_ApelidoErrado) values (@Nome_ApelidoErrado, @CodigoMlb_ApelidoErrado)"
    '                command15.CommandType = CommandType.Text

    '                command15.Parameters.Clear()
    '                command15.Parameters.Add("@Nome_ApelidoErrado", SqlDbType.VarChar, 50).Value = ApelidoProdutoMlb
    '                command15.Parameters.Add("@CodigoMlb_ApelidoErrado", SqlDbType.VarChar, 50).Value = CodigoMlb


    '                Try
    '                    connection.Open()
    '                    command15.ExecuteNonQuery()
    '                    connection.Close()
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString())
    '                End Try
    '            End If
    'Proxima:

    '            NomeContato2 = NomeContato
    '            CodigoAnterior = NumeroNota


    '        Next

    ' End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        VendasMlbDataGridView.DataSource = VendasMlbBindingSource
        VendasMlbBindingSource.Filter = String.Format("NomeContato_VendasMlb LIKE '{0}%'", TextBox2.Text)

    End Sub

    Private Sub TextBox235_TextChanged(sender As Object, e As EventArgs) Handles TextBox235.TextChanged

        ProdutosBindingSource.Filter = String.Format("Apelido_prod LIKE '{0}%'", TextBox235.Text)

    End Sub

    Private Sub TextBox236_TextChanged(sender As Object, e As EventArgs) Handles TextBox236.TextChanged

        ProdutosBindingSource.Filter = String.Format("CodigoMlb_prod LIKE '{0}%'", TextBox236.Text)

    End Sub

    Private Sub TextBox237_TextChanged(sender As Object, e As EventArgs) Handles TextBox237.TextChanged

        ProdutosBindingSource.Filter = String.Format("CodigoMlb_prod LIKE '{0}%'", TextBox237.Text)

    End Sub


    Private Sub TextBox260_DoubleClick(sender As Object, e As EventArgs) Handles TextBox260.DoubleClick

        If FlagProdPesquisa = "0" Then
            FlagProdutos = "1"
            TextBox268.Text = Cod_prodTextBox.Text
            TextBox240.Text = TextBox260.Text
            tabpage_produtos.SelectedIndex = 1
        End If


    End Sub

    Private Sub Button74_Click_1(sender As Object, e As EventArgs) Handles Button74.Click

        TextBox260.Enabled = True
        TextBox261.Enabled = True
        TextBox263.Enabled = True
        TextBox265.Enabled = True
        TextBox267.Enabled = True


    End Sub

    Private Sub TextBox182_TextChanged(sender As Object, e As EventArgs) Handles TextBox182.TextChanged

        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox182.Text)

    End Sub


    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click

        TextBox260.Enabled = False
        TextBox261.Enabled = False
        TextBox263.Enabled = False
        TextBox265.Enabled = False
        TextBox267.Enabled = False

    End Sub

    Private Sub TextBox261_DoubleClick(sender As Object, e As EventArgs) Handles TextBox261.DoubleClick
        If FlagProdPesquisa = "0" Then
            FlagProdutos = "1"
            TextBox268.Text = Cod_prodTextBox.Text
            TextBox240.Text = TextBox261.Text
            tabpage_produtos.SelectedIndex = 1
        End If

    End Sub

    Private Sub TextBox263_DoubleClick(sender As Object, e As EventArgs) Handles TextBox263.DoubleClick
        If FlagProdPesquisa = "0" Then
            FlagProdutos = "1"
            TextBox268.Text = Cod_prodTextBox.Text
            TextBox240.Text = TextBox263.Text
            tabpage_produtos.SelectedIndex = 1
        End If
    End Sub

    Private Sub TextBox265_DoubleClick(sender As Object, e As EventArgs) Handles TextBox265.DoubleClick
        If FlagProdPesquisa = "0" Then
            FlagProdutos = "1"
            TextBox268.Text = Cod_prodTextBox.Text
            TextBox240.Text = TextBox265.Text
            tabpage_produtos.SelectedIndex = 1
        End If

    End Sub

    Private Sub TextBox267_DoubleClick(sender As Object, e As EventArgs) Handles TextBox267.DoubleClick
        If FlagProdPesquisa = "0" Then
            FlagProdutos = "1"
            TextBox268.Text = Cod_prodTextBox.Text
            TextBox240.Text = TextBox267.Text
            tabpage_produtos.SelectedIndex = 1
        End If

    End Sub

    Private Sub btn_trans_Click(sender As Object, e As EventArgs) Handles btn_trans.Click

        Dim senha As String
        senha = InputBox("Coloque a senha")
        If senha <> fernando Then
            Exit Sub
        End If
        ' variáveis externas
        Dim LinhaProduto As String = ""
        Dim EstoqueAtual As Double = 0
        Dim QuantidadeVendidaMlb As Double = 0
        Dim xx As Integer
        Dim NomeContato2 As String = ""
        Dim CodigoAnterior As String = ""
        ' -------------------------------------------

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim command As SqlCommand
       

        For xx = 0 To VendasMlbDataGridView.RowCount() - 1

            command = connection.CreateCommand()
            command.CommandText = "SELECT * FROM VendasMlb WHERE NUmeroPedido2_VendasMlb = '" & VendasMlbDataGridView.Item(1, xx).Value & "'and CodigoMlb_VendasMlb = '" & VendasMlbDataGridView.Item(15, xx).Value & "'and DataPedido_VendasMlb >= '" & DateTimePicker20.Text & "'"
            command.CommandType = CommandType.Text

            ' -----------------------------------------------------------------
            ' Pego o nome do produto no arquivo vendasmlb 
            Dim ApelidoProdutoMlb As String = ""
            Dim DataVendaMlb As Date
            Dim CodigoMlb As String = ""
            Dim NumeroNota As String = ""
            Dim NomeContato As String = ""
            Dim CNPJ As String = ""
            Dim SerieNF As String = ""
            ' ------------------------------------------------

            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()
            While lrd.Read

                ApelidoProdutoMlb = lrd("NomeProduto_VendasMlb").ToString
                QuantidadeVendidaMlb = lrd("QuantidadeVendida_VendasMlb")
                DataVendaMlb = lrd("DataPedido_VendasMlb").ToString
                CodigoMlb = lrd("CodigoMlb_VendasMlb").ToString
                NomeContato = lrd("NomeContato_VendasMlb").ToString
                NumeroNota = lrd("NUmeroPedido2_VendasMlb").ToString
                CNPJ = lrd("CNPJEmitente_VendasMlb").ToString
                SerieNF = lrd("SerieNF_VendasMlb").ToString

            End While
            connection.Close()

            ' -----------------------------------------------------------------------------
            ' Procura o valor no produto
            ' Pego o valor do produto no arquivo produtos 
            Dim ValorProduto As Double = 0
            Dim CodigoProdutoFor As String = ""
            Dim FornecedorProduto As String = ""
            Dim CorProduto As String = ""
            Dim PrecoAtacadoProduto As Double = 0
            Dim PrecoFULLProduto As Double = 0
            Dim NomeProduto As String = ""
            Dim CustoProduto As Double = 0
            Dim IPIProduto As Double = 0
            Dim Raiz As String = ""

            Dim command2 As SqlCommand
            command2 = connection.CreateCommand()
            command2.CommandText = "SELECT * from produtos WHERE  cod_prodfor = '" & CodigoMlb & "'or CodigoMlb_prod = '" & CodigoMlb & "'"
            command2.CommandType = CommandType.Text
            ' -------------------------------------------------------------------
            connection.Open()
            Dim lrd2 As SqlDataReader = command2.ExecuteReader()

            While lrd2.Read

                ValorProduto = lrd2("precoatacado_prod").ToString
                CodigoProdutoFor = lrd2("cod_prodfor").ToString
                FornecedorProduto = lrd2("fornecedor_prod").ToString
                LinhaProduto = lrd2("linha_prod").ToString
                CorProduto = lrd2("cor_prod").ToString
                PrecoAtacadoProduto = lrd2("precoatacado_prod").ToString
                PrecoFULLProduto = lrd2("PrecoMercadoLivreFull_prod").ToString
                NomeProduto = lrd2("nome_prod").ToString
                CustoProduto = lrd2("custo_prod").ToString
                IPIProduto = lrd2("ipi_prod").ToString
                EstoqueAtual = lrd2("estoqueatual_prod").ToString
                Raiz = lrd2("RaizSimNao_prod").ToString


            End While
            connection.Close()

            ' -----------------------------------------------------
            Dim CodComp(5) As String
            Dim QtdeComp(5) As Double
           

            connection.Open()
            If Raiz = "NÃO RAIZ" Then

                Dim lrd3 As SqlDataReader = command2.ExecuteReader()
                While lrd3.Read

                    CodComp(1) = lrd3("CodComp1_prod").ToString
                    QtdeComp(1) = lrd3("QtdeComp1_prod").ToString
                    CodComp(2) = lrd3("CodComp2_prod").ToString
                    QtdeComp(2) = lrd3("QtdeComp2_prod").ToString
                    CodComp(3) = lrd3("CodComp3_prod").ToString
                    QtdeComp(3) = lrd3("QtdeComp3_prod").ToString
                    CodComp(4) = lrd3("CodComp4_prod").ToString
                    QtdeComp(4) = lrd3("QtdeComp4_prod").ToString
                    CodComp(5) = lrd3("CodComp5_prod").ToString
                    QtdeComp(5) = lrd3("QtdeComp5_prod").ToString

                End While

            End If
            connection.Close()
            ' ******************************************************************************
            ' ******************************************************************************
            If NomeProduto <> "" Then

                'REM verifica se o produto já foi cadastrado no arquivo balcão
                Dim cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandText = "SELECT NumeroNotaMlb_balcao  from balcao where NumeroNotaMlb_balcao = '" & NumeroNota & "'"
                connection.Open()
                'REM verifica se código prod existe no arquivo balcão, para não gravar duas vezes
                Dim lrd5 As SqlDataReader = cmd.ExecuteReader()

                Try
                    If lrd5.Read() = True Then
                        'MessageBox.Show("já")
                        connection.Close()
                        GoTo Proxima
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            End If
            connection.Close()

            '********************************************************************************
            '********************************************************************************
            'REM verifica se o produto SE ELA NÃO EXISTE E GRAVA NO ARQUIVO APELIDO ERRADO

            Dim command47 As New SqlCommand
            command47.Connection = connection
            command47.CommandText = "SELECT * from produtos WHERE cod_prodfor = '" & CodigoMlb & "'or CodigoMlb_prod = '" & CodigoMlb & "'"

            connection.Open()
            Dim lrd17 As SqlDataReader = command47.ExecuteReader()
            If lrd17.Read() = False Then
                ' *************************************************************
                ' *************************************************************
                connection.Close()
                Dim cmd19 As New SqlCommand
                cmd19.Connection = connection
                cmd19.CommandText = "SELECT NumeroNota_ApelidoErrado  from ApelidoErrado where NumeroNota_ApelidoErrado = '" & NumeroNota & "'"
                connection.Open()
                'REM verifica se código prod existe no arquivo apelido errado, para não gravar duas vezes
                Dim lrd59 As SqlDataReader = cmd19.ExecuteReader()

                Try
                    If lrd59.Read() = True Then
                        connection.Close()
                        GoTo Proxima
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

                connection.Close()
                '*************************************************************************
                '*************************************************************************
                connection.Open()
                Dim command40 As SqlCommand
                command40 = connection.CreateCommand()
                command40.CommandText = "insert into ApelidoErrado (NumeroNota_ApelidoErrado,Nome_ApelidoErrado,CodigoMlb_ApelidoErrado) values (@NumeroNota_ApelidoErrado,@Nome_ApelidoErrado, @CodigoMlb_ApelidoErrado)"
                command40.CommandType = CommandType.Text

                command40.Parameters.Clear()
                command40.Parameters.Add("@Nome_ApelidoErrado", SqlDbType.VarChar, 50).Value = ApelidoProdutoMlb
                command40.Parameters.Add("@CodigoMlb_ApelidoErrado", SqlDbType.VarChar, 50).Value = CodigoMlb
                command40.Parameters.Add("@NumeroNota_ApelidoErrado", SqlDbType.VarChar, 50).Value = VendasMlbDataGridView.Item(1, xx).Value
                connection.Close()

                Try
                    connection.Open()
                    command40.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    connection.Close()
                End Try

                connection.Close()

            Else
                '********************************************************************************
                '********************************************************************************

                ' Faz o lançamento em vendas balcão para produtos que NÃO SÃO KIT
                Dim NumeroNotaFull As String = ""
                Dim command5 As SqlCommand
                If Raiz = "RAIZ" Then

                    command5 = connection.CreateCommand()
                    command5.CommandText = "insert into balcao (CodigoMlb_balcao,Avista_APrazo_balcao,FormaPgto_balcao,totalpedido_prodbalcao,id2_balcao,nomevendedor_balcao,codprod_balcao,forprod_balcao,linhaprod_balcao,corprod_balcao,quantidadeprod_balcao,precoprod_balcao,totalprod_balcao,datavenda_prodbalcao,desconto_balcao,nomeProd_balcao,Custo_balcao,vendaOrcamento_balcao,NumeroNotaMlb_balcao) values (@CodigoMlb_balcao,@Avista_APrazo_balcao,@FormaPgto_balcao,@totalpedido_prodbalcao,@id2_balcao,@nomevendedor_balcao,@codprod_balcao,@forprod_balcao,@linhaprod_balcao,@corprod_balcao,@quantidadeprod_balcao,@precoprod_balcao,@totalprod_balcao,@datavenda_prodbalcao,@desconto_balcao,@nomeProd_balcao,@Custo_balcao,@vendaOrcamento_balcao, @NumeroNotaMlb_balcao)"
                    command5.CommandType = CommandType.Text

                    command5.Parameters.Clear()
                    command5.Parameters.Add("@id2_balcao", SqlDbType.VarChar, 50).Value = "1300"
                    command5.Parameters.Add("@nomevendedor_balcao", SqlDbType.VarChar, 50).Value = "Bee"
                    command5.Parameters.Add("@codprod_balcao", SqlDbType.VarChar, 50).Value = CodigoProdutoFor
                    command5.Parameters.Add("@forprod_balcao", SqlDbType.VarChar, 50).Value = FornecedorProduto
                    command5.Parameters.Add("@linhaprod_balcao", SqlDbType.VarChar, 50).Value = LinhaProduto
                    command5.Parameters.Add("@corprod_balcao", SqlDbType.VarChar, 50).Value = CorProduto
                    command5.Parameters.Add("@quantidadeprod_balcao", SqlDbType.Float).Value = QuantidadeVendidaMlb
                    'escolhendo entre preço FULL e preço mlb

                    If VendasMlbDataGridView.Item(17, xx).Value = "18623408000266" Then
                        command5.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoFULLProduto
                    Else
                        command5.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoAtacadoProduto
                    End If

                    command5.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A prazo"
                    command5.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Outros"
                    command5.Parameters.Add("@NumeroNotaMlb_balcao", SqlDbType.VarChar, 50).Value = VendasMlbDataGridView.Item(1, xx).Value
                    command5.Parameters.Add("@CodigoMlb_balcao", SqlDbType.VarChar, 50).Value = CodigoMlb

                    ' CALCULANDO O TOTAL DO BALCAO POR ÍTEM
                    Dim QuantidadeVendidas As Double = QuantidadeVendidaMlb
                    Dim PrecoAtacado As Double = PrecoAtacadoProduto
                    Dim TLProdBalcao As Double = 0
                    ' escolhendo o preço do full
                    If VendasMlbDataGridView.Item(17, xx).Value = "18623408000266" Then
                        TLProdBalcao = QuantidadeVendidas * PrecoFULLProduto
                    Else
                        TLProdBalcao = QuantidadeVendidas * PrecoAtacado
                    End If
                    Dim TLProdBalcao2 As String = TLProdBalcao.ToString
                    command5.Parameters.Add("@totalprod_balcao", SqlDbType.Float).Value = TLProdBalcao2
                    command5.Parameters.Add("@totalpedido_prodbalcao", SqlDbType.Float).Value = TLProdBalcao2
                    command5.Parameters.Add("@datavenda_prodbalcao", SqlDbType.Date).Value = DataVendaMlb
                    command5.Parameters.Add("@nomeProd_balcao", SqlDbType.VarChar, 50).Value = NomeProduto
                    command5.Parameters.Add("@desconto_balcao", SqlDbType.Float).Value = TLProdBalcao2

                    ' calcula o custo dos produtos
                    Dim Tlpedido_prodbalcao As Double = ((CustoProduto) * (1 + (IPIProduto) / 100)) * QuantidadeVendidaMlb
                    Dim Tlpedido_prodbalcao2 As String = Tlpedido_prodbalcao.ToString("F2")
                    command5.Parameters.Add("@Custo_balcao", SqlDbType.Float).Value = Tlpedido_prodbalcao2
                    ' calcula o lucro da operação
                    Dim LucroBalcao As Double = (1 - (Tlpedido_prodbalcao / TLProdBalcao2)) * 100
                    Dim LucroBalcao2 As String = LucroBalcao.ToString("F2")
                    command5.Parameters.Add("@vendaOrcamento_balcao", SqlDbType.VarChar, 50).Value = LucroBalcao2
                    connection.Close()

                    Try
                        connection.Open()
                        command5.ExecuteNonQuery()
                        connection.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                        connection.Close()
                    End Try
            End If
                connection.Close()

                ' *****************************************************************************
                ' Faz o lançamento em vendas balcão para produtos que  SÃO KIT
                Dim command50 As SqlCommand
                Dim command28 As SqlCommand

                Dim ValorProduto2 As Double = 0
                Dim CodigoProdutoFor2 As String = ""
                Dim FornecedorProduto2 As String = ""
                Dim LinhaProduto2 As String = ""
                Dim CorProduto2 As String = ""
                Dim PrecoAtacadoProduto2 As Double = 0
                Dim PrecoFULLProduto2 As Double = 0
                Dim NomeProduto2 As String = ""
                Dim CustoProduto2 As Double = 0
                Dim IPIProduto2 As Double = 0
                Dim EstoqueAtual2 As Double = 0


                If Raiz = "NÃO RAIZ" Then

                    For az = 1 To 5

                        If CodComp(az) <> "0" Then

                            command28 = connection.CreateCommand()
                            command28.CommandText = "SELECT * from produtos WHERE  cod_prodfor = '" & CodComp(az) & "'"
                            command28.CommandType = CommandType.Text

                            connection.Open()
                            Dim lrd33 As SqlDataReader = command28.ExecuteReader()
                            While lrd33.Read
                                ValorProduto2 = lrd33("precoatacado_prod").ToString
                                CodigoProdutoFor2 = lrd33("cod_prodfor").ToString
                                FornecedorProduto2 = lrd33("fornecedor_prod").ToString
                                LinhaProduto2 = lrd33("linha_prod").ToString
                                CorProduto2 = lrd33("cor_prod").ToString
                                PrecoAtacadoProduto2 = lrd33("precoatacado_prod").ToString
                                PrecoFULLProduto2 = lrd33("PrecoMercadoLivreFull_prod").ToString
                                NomeProduto2 = lrd33("nome_prod").ToString
                                CustoProduto2 = lrd33("custo_prod").ToString
                                IPIProduto2 = lrd33("ipi_prod").ToString
                                EstoqueAtual2 = lrd33("estoqueatual_prod").ToString
                            End While
                            connection.Close()

                            '***************************************************************************
                            command50 = connection.CreateCommand()
                            command50.CommandText = "insert into balcao (CodigoMlb_balcao,Avista_APrazo_balcao,FormaPgto_balcao,totalpedido_prodbalcao,id2_balcao,nomevendedor_balcao,codprod_balcao,forprod_balcao,linhaprod_balcao,corprod_balcao,quantidadeprod_balcao,precoprod_balcao,totalprod_balcao,datavenda_prodbalcao,desconto_balcao,nomeProd_balcao,Custo_balcao,vendaOrcamento_balcao,NumeroNotaMlb_balcao) values (@CodigoMlb_balcao,@Avista_APrazo_balcao,@FormaPgto_balcao,@totalpedido_prodbalcao,@id2_balcao,@nomevendedor_balcao,@codprod_balcao,@forprod_balcao,@linhaprod_balcao,@corprod_balcao,@quantidadeprod_balcao,@precoprod_balcao,@totalprod_balcao,@datavenda_prodbalcao,@desconto_balcao,@nomeProd_balcao,@Custo_balcao,@vendaOrcamento_balcao, @NumeroNotaMlb_balcao)"
                            command50.CommandType = CommandType.Text
                            For c = 1 To QtdeComp(az)

                                command50.Parameters.Clear()
                                command50.Parameters.Add("@id2_balcao", SqlDbType.VarChar, 50).Value = "1500"
                                command50.Parameters.Add("@nomevendedor_balcao", SqlDbType.VarChar, 50).Value = "Bee"
                                command50.Parameters.Add("@codprod_balcao", SqlDbType.VarChar, 50).Value = CodigoProdutoFor2
                                command50.Parameters.Add("@forprod_balcao", SqlDbType.VarChar, 50).Value = FornecedorProduto2
                                command50.Parameters.Add("@linhaprod_balcao", SqlDbType.VarChar, 50).Value = LinhaProduto2
                                command50.Parameters.Add("@corprod_balcao", SqlDbType.VarChar, 50).Value = CorProduto2
                                command50.Parameters.Add("@quantidadeprod_balcao", SqlDbType.Float).Value = QuantidadeVendidaMlb
                                'escolhendo entre preço FULL e preço mlb
                                If VendasMlbDataGridView.Item(17, xx).Value = "18623408000266" Then
                                    command50.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoFULLProduto2
                                Else
                                    command50.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoAtacadoProduto2
                                End If
                                'command50.Parameters.Add("@precoprod_balcao", SqlDbType.Float).Value = PrecoAtacadoProduto2
                                command50.Parameters.Add("@Avista_APrazo_balcao", SqlDbType.VarChar, 50).Value = "A prazo"
                                command50.Parameters.Add("@FormaPgto_balcao", SqlDbType.VarChar, 50).Value = "Outros"
                                command50.Parameters.Add("@NumeroNotaMlb_balcao", SqlDbType.VarChar, 50).Value = VendasMlbDataGridView.Item(1, xx).Value
                                command50.Parameters.Add("@CodigoMlb_balcao", SqlDbType.VarChar, 50).Value = CodigoMlb

                                ' CALCULANDO O TOTAL DO BALCAO POR ÍTEM
                                Dim QuantidadeVendidas As Double = QuantidadeVendidaMlb
                                Dim PrecoAtacado As Double = PrecoAtacadoProduto2
                                Dim TLProdBalcao = QuantidadeVendidas * PrecoAtacado
                                Dim TLProdBalcao2 As Double = 0
                                ' escolhendo o preço do full
                                If VendasMlbDataGridView.Item(17, xx).Value = "18623408000266" Then
                                    TLProdBalcao2 = QuantidadeVendidas * PrecoFULLProduto2
                                Else
                                    TLProdBalcao2 = QuantidadeVendidas * PrecoAtacado
                                End If
                                Dim TLProdBalcao3 As String = TLProdBalcao2.ToString
                                command50.Parameters.Add("@totalprod_balcao", SqlDbType.Float).Value = TLProdBalcao3
                                command50.Parameters.Add("@totalpedido_prodbalcao", SqlDbType.Float).Value = TLProdBalcao2
                                command50.Parameters.Add("@datavenda_prodbalcao", SqlDbType.Date).Value = DataVendaMlb
                                command50.Parameters.Add("@nomeProd_balcao", SqlDbType.VarChar, 50).Value = NomeProduto2
                                command50.Parameters.Add("@desconto_balcao", SqlDbType.Float).Value = TLProdBalcao2

                                ' calcula o custo dos produtos
                                Dim Tlpedido_prodbalcao As Double = ((CustoProduto2) * (1 + (IPIProduto2) / 100)) * QuantidadeVendidaMlb
                                Dim Tlpedido_prodbalcao2 As String = Tlpedido_prodbalcao.ToString("F2")
                                command50.Parameters.Add("@Custo_balcao", SqlDbType.Float).Value = Tlpedido_prodbalcao2
                                ' calcula o lucro da operação
                                Dim LucroBalcao As Double = (1 - (Tlpedido_prodbalcao / TLProdBalcao2)) * 100
                                Dim LucroBalcao2 As String = LucroBalcao.ToString("F2")
                                command50.Parameters.Add("@vendaOrcamento_balcao", SqlDbType.VarChar, 50).Value = LucroBalcao2

                                Try
                                    connection.Open()
                                    command50.ExecuteNonQuery()
                                    connection.Close()

                                Catch ex As Exception
                                    MessageBox.Show(ex.ToString())
                                    connection.Close()
                                End Try
                            Next

                        End If

                    Next
                End If

            End If


            ' *****************************************************************************
            ' *****************************************************************************
            ' dando baixa nos estoque com produtos composto por vários ítens

            'Dim EstoqueAtualItem As Double = 0
            'Dim SubtraindoEstoqueItem As Integer = 0
            'Dim nome As String = ""

            'Dim command25 As SqlCommand
            'If Raiz = "NÃO RAIZ" Then

            '    For a = 1 To 5

            '        If CodComp(a) <> "" Then

            '            command25 = connection.CreateCommand()
            '            command25.CommandText = "SELECT * from produtos WHERE  cod_prodfor = '" & CodComp(a) & "'"
            '            command25.CommandType = CommandType.Text

            '            connection.Open()
            '            Dim lrd15 As SqlDataReader = command25.ExecuteReader()
            '            While lrd15.Read
            '                EstoqueAtualItem = lrd15("estoqueatual_prod").ToString

            '            End While
            '            connection.Close()

            '            SubtraindoEstoqueItem = EstoqueAtualItem - (QtdeComp(a) * QuantidadeVendidaMlb)
            '            Dim command20 As SqlCommand
            '            command20 = connection.CreateCommand()
            '            command20.CommandText = "update produtos set  estoqueatual_prod = @estoqueatual_prod  where cod_prodfor = @cod_prodfor"
            '            command20.CommandType = CommandType.Text
            '            command20.Parameters.Add("@cod_prodfor", SqlDbType.VarChar, 50).Value = CodComp(a)
            '            command20.Parameters.Add("@estoqueatual_prod", SqlDbType.VarChar, 50).Value = SubtraindoEstoqueItem

            '            Try
            '                connection.Open()
            '                command20.ExecuteNonQuery()
            '                connection.Close()
            '            Catch ex As Exception
            '                MessageBox.Show(ex.ToString())
            '            End Try
            '        End If
            '    Next
            'End If

            'connection.Close()
            ''********************************************************************************
            '' ******************************************************************************
            '' Dando baixa no estoque para produtos com um ítem 
            'Dim SubtraindoEstoqueAtual As Integer = 0
            'If Raiz = "RAIZ" Then

            '    SubtraindoEstoqueAtual = EstoqueAtual - QuantidadeVendidaMlb

            '    Dim command10 As SqlCommand
            '    command10 = connection.CreateCommand()
            '    command10.CommandText = "update produtos set  estoqueatual_prod = @estoqueatual_prod  where cod_prodfor = '" & CodigoMlb & " 'or CodigoMlb_prod = '" & CodigoMlb & "'"
            '    command10.CommandType = CommandType.Text
            '    command10.Parameters.Add("@estoqueatual_prod", SqlDbType.VarChar, 50).Value = SubtraindoEstoqueAtual

            '    Try
            '        connection.Open()
            '        command10.ExecuteNonQuery()
            '        connection.Close()
            '    Catch ex As Exception
            '        MessageBox.Show(ex.ToString())
            '        connection.Close()
            '    End Try
            'End If
Proxima:
            NomeContato2 = NomeContato
            CodigoAnterior = NumeroNota
        Next

        Me.ProdutosTableAdapter1.Fill(Me.DataSetFinal.produtos)
        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)
        Me.ApelidoErradoTableAdapter.Fill(Me.DataSetFinal.ApelidoErrado)

    End Sub

    

    Private Sub TextBox272_TextChanged(sender As Object, e As EventArgs) Handles TextBox272.TextChanged

        TextBox269.Clear()
        TextBox270.Clear()
        TextBox271.Clear()
       
        BalcaoDataGridView1.DataSource = BalcaoBindingSource
        BalcaoBindingSource.Filter = String.Format("NumeroNotaMlb_balcao LIKE '{0}%'", TextBox272.Text)

    End Sub

    Private Sub Button77_Click(sender As Object, e As EventArgs) Handles Button77.Click

        If TextBox269.Text = "" Or TextBox271.Text = "0" Then
            MessageBox.Show("Duplo clique no produto que vc quer apagar")
            Exit Sub
        End If

        If RadioButton26.Checked = False Then
            MessageBox.Show("Habilite o botão deletar")
            Exit Sub
        End If

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Try
            Dim v_SelectRow As Integer
            v_SelectRow = Me.BalcaoDataGridView.CurrentRow.Index

            Dim result = MessageBox.Show("Confirmar a Deleção?", "Atenção!!!", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then

                Dim command As SqlCommand
                command = connection.CreateCommand()
                command.CommandText = "delete from balcao where  NumeroNotaMlb_balcao = @NumeroNotaMlb_balcao"
                command.CommandType = CommandType.Text
                command.Parameters.Add("@NumeroNotaMlb_balcao", SqlDbType.VarChar, 50).Value = BalcaoDataGridView1.Item(15, v_SelectRow).Value
                If BalcaoDataGridView1.Item(15, v_SelectRow).Value = "0" Then
                    MessageBox.Show("Código igual a zero é proibido deletar")
                    Exit Sub
                End If

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        Finally
            connection.Close()
        End Try

        TextBox269.Clear()
        TextBox270.Clear()
        TextBox271.Clear()
        RadioButton25.Checked = True
        Button77.Enabled = False

        Me.BalcaoTableAdapter.Fill(Me.DataSetFinal.balcao)

    End Sub

    Private Sub PedidoCompraDataGridView_DoubleClick(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button86_Click(sender As Object, e As EventArgs) Handles Button86.Click

        btn_relfor.Enabled = True
        Button85.Enabled = True
        Button86.Enabled = False
        TextBox284.Enabled = True
        TextBox284.Clear()
        TextBox246.Clear()
        TextBox247.Clear()
        TextBox248.Clear()
        Button76.Enabled = True

        DateTimePicker37.Text = Today
        TabControl2.TabPages.Remove(Tab_fornecedor)
        RadioButton11.Enabled = True
        RadioButton12.Enabled = True
        Button15.Enabled = True
        TextBox222.Clear()
        Button98.Enabled = True
        ComboBox26.Enabled = True

    End Sub

    Private Sub Button85_Click(sender As Object, e As EventArgs) Handles Button85.Click

        If TextBox246.Text = "" Then
            MessageBox.Show(" Marque o RadioButton Deletar, escolha um produto com duplo clique e clique no botão vermelho/Deletar")
            RadioButton13.Checked = True
            Exit Sub
        End If

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' apaga registro
        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            ' --------------------------------------
            ' apagar os dados da tabela
            Dim v_SelectRow As Integer
            v_SelectRow = Me.PedidoCompraDataGridView.CurrentRow.Index

            command = connection.CreateCommand()
            command.CommandText = "delete from PedidoCompra where  Id_PedidoCompra = @Id_PedidoCompra"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@Id_PedidoCompra", SqlDbType.VarChar, 50).Value = PedidoCompraDataGridView.Item(4, v_SelectRow).Value

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)
                MessageBox.Show("Apagado com sucesso!")

            Catch ex As Exception

                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try
        Else
            'Process No
        End If

        Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)
        TextBox246.Clear()
        TextBox247.Clear()
        TextBox248.Clear()
        DateTimePicker37.Text = Today
        RadioButton13.Checked = True



    End Sub

    Private Sub ProdutosDataGridView6_DoubleClick(sender As Object, e As EventArgs) Handles ProdutosDataGridView6.DoubleClick
       
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' -------------------------------------------------------------------------------------------
        Dim v_SelectRow As Integer
        v_SelectRow = Me.ProdutosDataGridView6.CurrentRow.Index
        ' só permite produtos que são RAIZ
        If ProdutosDataGridView6.Item(47, v_SelectRow).Value <> "RAIZ" Then
            MessageBox.Show("Este não é um produto RAIZ")
            Exit Sub
        End If
        ' ------------------------------------------------------------------------------------------------------------------
        Dim ano As Integer = Today.Year
        Dim mes As Integer = Today.Month
        Dim primeiroDia As DateTime = New DateTime(ano, mes, 1).AddDays(-91)
        Dim ultimoDia As DateTime = New DateTime(ano, mes, 1).AddDays(-1)
        Dim NomeProduto As String = ProdutosDataGridView6.Item(6, v_SelectRow).Value
        Dim CorProduto As String = ProdutosDataGridView6.Item(7, v_SelectRow).Value

        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & primeiroDia & "' ,103)  and convert (datetime, '" & ultimoDia & "' ,103) and nomeProd_balcao = '" & NomeProduto & "' and corprod_balcao = '" & CorProduto & "'"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView8.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' -----------------------------------
        'somar quantidade da coluna da tabela balcão
        Dim quantidadeBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView8.Rows
            quantidadeBalcao += Linha.Cells(7).Value
        Next
        TextBox273.Text = ((quantidadeBalcao / 90) * 30).ToString("F2")
        ' ----------------------------------------------------------------------------------
        ' ****************************************************************************************
        TextBox274.Text = ProdutosDataGridView6.Item(11, v_SelectRow).Value
        TextBox275.Text = ProdutosDataGridView6.Item(13, v_SelectRow).Value
        TextBox276.Text = ProdutosDataGridView6.Item(18, v_SelectRow).Value
        TextBox301.Text = ProdutosDataGridView6.Item(31, v_SelectRow).Value


        If ProdutosDataGridView6.Item(31, v_SelectRow).Value Is DBNull.Value Then
            TextBox286.Text = 0
        Else
            TextBox286.Text = ProdutosDataGridView6.Item(31, v_SelectRow).Value
        End If
        TextBox326.Text = ProdutosDataGridView6.Item(46, v_SelectRow).Value

        ' ****************************************************************************************
        ' Pegar a quantidade de entrada
        Dim QuantidadeEntradaPedido As Double = 0

        Try
            QuantidadeEntradaPedido = InputBox("Digite a quantidade comprada")

        Catch ex As Exception
            Exit Sub
        End Try

        ' --------------------------------------
        ' Gravar od dados da tabela
        Dim command As SqlCommand
        command = connection.CreateCommand()
        command.CommandText = "INSERT INTO PedidoCompra (SomadoEstoque_PedidoCompra,PrecoUnitario_PedidoCompra,Totalitem_PedidoCompra,CodigoProduto_PeidoCompra,Codigo_PedidoCompraString,Fornecedor_PedidoCompra,Codigo_PedidoCompra,Linha_PedidoCompra,Cor_PedidoCompra,CodProdFor_PedidoCompra,NomeProd_PedidoCompra,Quantidade_PedidoCompra,Data_PedidoCompra,EntregueSimNao_PedidoCompra) values (@SomadoEstoque_PedidoCompra,@PrecoUnitario_PedidoCompra,@Totalitem_PedidoCompra,@CodigoProduto_PeidoCompra,@Codigo_PedidoCompraString,@Fornecedor_PedidoCompra,@Codigo_PedidoCompra,@Linha_PedidoCompra,@Cor_PedidoCompra,@CodProdFor_PedidoCompra,@NomeProd_PedidoCompra,@Quantidade_PedidoCompra,@Data_PedidoCompra,@EntregueSimNao_PedidoCompra)"
        command.CommandType = CommandType.Text

        command.Parameters.Add("@Fornecedor_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(4, v_SelectRow).Value
        command.Parameters.Add("@Codigo_PedidoCompra", SqlDbType.Int).Value = TextBox222.Text
        command.Parameters.Add("@Linha_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(5, v_SelectRow).Value
        command.Parameters.Add("@Cor_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(7, v_SelectRow).Value
        command.Parameters.Add("@CodProdFor_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(2, v_SelectRow).Value
        command.Parameters.Add("@NomeProd_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(6, v_SelectRow).Value
        command.Parameters.Add("@Quantidade_PedidoCompra", SqlDbType.Float).Value = QuantidadeEntradaPedido
        command.Parameters.Add("@Data_PedidoCompra", SqlDbType.Date).Value = DateTimePicker37.Text
        command.Parameters.Add("@EntregueSimNao_PedidoCompra", SqlDbType.VarChar, 50).Value = "Não Entregue"
        command.Parameters.Add("@Codigo_PedidoCompraString", SqlDbType.VarChar, 50).Value = TextBox222.Text
        command.Parameters.Add("@CodigoProduto_PeidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(1, v_SelectRow).Value
        command.Parameters.Add("@PrecoUnitario_PedidoCompra", SqlDbType.VarChar, 50).Value = ProdutosDataGridView6.Item(16, v_SelectRow).Value
        Dim Precounitario As Double = ProdutosDataGridView6.Item(16, v_SelectRow).Value
        Dim TLItem As Double = 0
        TLItem = (Precounitario * QuantidadeEntradaPedido) * 1.1
        command.Parameters.Add("@Totalitem_PedidoCompra", SqlDbType.VarChar, 50).Value = TLItem.ToString("F2")
        command.Parameters.Add("@SomadoEstoque_PedidoCompra", SqlDbType.Float).Value = 0


        ' a seguir comandos para gravar os ítens coletados do formulário ------------------
        Try
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()
            'VOlta para a tela de pedidos e atualiza a tabela ....
            TabControl2.SelectedIndex = 0
            Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)
            PedidoCompraBindingSource.Filter = String.Format("Codigo_PedidoCompraString LIKE '{0}%'", TextBox222.Text)

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        'TextBox287.Text = ProdutosDataGridView6.Item(4, v_SelectRow).Value

    End Sub


    Private Sub TextBox277_TextChanged(sender As Object, e As EventArgs) Handles TextBox277.TextChanged
        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox277.Text)
    End Sub

    Private Sub TextBox278_TextChanged(sender As Object, e As EventArgs) Handles TextBox278.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox278.Text)
    End Sub

    Private Sub TextBox279_TextChanged(sender As Object, e As EventArgs) Handles TextBox279.TextChanged
        ProdutosBindingSource.Filter = String.Format("codbarras_prod LIKE '{0}%'", TextBox279.Text)
    End Sub

    Private Sub TextBox280_TextChanged(sender As Object, e As EventArgs) Handles TextBox280.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox280.Text)
    End Sub

    Private Sub TextBox281_TextChanged(sender As Object, e As EventArgs) Handles TextBox281.TextChanged
        ProdutosBindingSource.Filter = String.Format("CodigoMlb_prod LIKE '{0}%'", TextBox281.Text)
    End Sub

    Private Sub TextBox282_TextChanged(sender As Object, e As EventArgs) Handles TextBox282.TextChanged
        ProdutosBindingSource.Filter = String.Format("Apelido_prod LIKE '{0}%'", TextBox282.Text)
    End Sub

    Private Sub Button94_Click(sender As Object, e As EventArgs) Handles Button94.Click
        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}' and fornecedor_prod LIKE '{1}'", ComboBox36.Text, ComboBox35.Text)

    End Sub

    Private Sub Button93_Click(sender As Object, e As EventArgs) Handles Button93.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox35.Text)

    End Sub

    Private Sub Button95_Click(sender As Object, e As EventArgs) Handles Button95.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and linha_prod LIKE '{1}' and Bugiganga_prod LIKE '{2}'", ComboBox35.Text, ComboBox36.Text, "bugiganga")

    End Sub

    Private Sub Button97_Click(sender As Object, e As EventArgs) Handles Button97.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM VendasMlb WHERE DataPedido_VendasMlb BETWEEN   convert (datetime, '" & DateTimePicker39.Text & "' ,103)  and convert (datetime, '" & DateTimePicker40.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "VendasMlb")
            connection.Close()
            VendasMlbDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.VendasMlbDataGridView.Rows
            valor += Linha.Cells(16).Value
        Next
        TextBox283.Text = valor.ToString("F2")

    End Sub

    Private Sub ComboBox13_TextChanged_1(sender As Object, e As EventArgs) Handles ComboBox13.TextChanged
        NotasEntradaBindingSource.Filter = String.Format("FornecedorEntrada LIKE '{0}%'", ComboBox13.Text)
    End Sub

    Private Sub TextBox284_TextChanged(sender As Object, e As EventArgs) Handles TextBox284.TextChanged

        PedidoCompraDataGridView.DataSource = PedidoCompraBindingSource
        PedidoCompraBindingSource.Filter = String.Format("Codigo_PedidoCompraString LIKE '{0}%'", TextBox284.Text)
        Try
            Me.PedidoCompraBindingSource.MoveFirst()
            ComboBox26.Text = PedidoCompraDataGridView.Item(5, 0).Value
        Catch ex As Exception
            Exit Sub
        End Try
       

    End Sub

   
    Private Sub PedidoCompraDataGridView_DoubleClick_1(sender As Object, e As EventArgs) Handles PedidoCompraDataGridView.DoubleClick

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")


        Dim v_SelectRow As Integer
        v_SelectRow = Me.PedidoCompraDataGridView.CurrentRow.Index

        Dim EstoqueAtual As Integer = 0
        Dim CustoAtual As Double = 0
        Dim IpiProduto As Double = 0
        Dim MkProduto As Double = 0
        Dim MarkupNET As Double = 0
        Dim PrecoVendaVarejo As Double = 0
        Dim PrecoVendaAtacado As Double = 0
        Dim SubstTributaria As Double = 0

        ' só passará para os textbox se for para apagar
        If RadioButton11.Checked = True Or RadioButton12.Checked = True Then
            TextBox246.Text = PedidoCompraDataGridView.Item(0, v_SelectRow).Value
            TextBox247.Text = PedidoCompraDataGridView.Item(10, v_SelectRow).Value
            TextBox248.Text = PedidoCompraDataGridView.Item(11, v_SelectRow).Value
        End If

        ' muda de Não Entregue para entregue e vice-versa.
        If RadioButton12.Checked = True Then

            Dim command2 As SqlCommand
            command2 = connection.CreateCommand()
            command2.CommandText = "update PedidoCompra set NumeroNota_PedidoCompra=@NumeroNota_PedidoCompra,EntregueSimNao_PedidoCompra =@EntregueSimNao_PedidoCompra  where id_PedidoCompra  = @id_PedidoCompra"
            command2.CommandType = CommandType.Text

            command2.Parameters.Add("@id_PedidoCompra", SqlDbType.VarChar, 50).Value = PedidoCompraDataGridView.Item(4, v_SelectRow).Value

            If PedidoCompraDataGridView.Item(13, v_SelectRow).Value = "Não Entregue" Then
                command2.Parameters.Add("@EntregueSimNao_PedidoCompra", SqlDbType.VarChar, 50).Value = "Entregue"
            Else
                command2.Parameters.Add("@EntregueSimNao_PedidoCompra", SqlDbType.VarChar, 50).Value = "Não Entregue"
            End If
            If NumeroNotaPedidoCompra = "" Then
                NumeroNotaPedidoCompra = 0
            End If
            command2.Parameters.Add("@NumeroNota_PedidoCompra", SqlDbType.VarChar, 50).Value = NumeroNotaPedidoCompra


            Try
                connection.Open()
                command2.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

            ' -----------------------------------------------------------------------------
            ' -----------------------------------------------------------------------------
            ' lendo o valor da tabela de produtos e dando baixa/alta no estoque
            command = connection.CreateCommand()
            command.CommandText = "select * from produtos where cod_prod = '" & PedidoCompraDataGridView.Item(1, v_SelectRow).Value & "'"
            connection.Open()
            Dim lrd As SqlDataReader = command.ExecuteReader()

            While lrd.Read()
                EstoqueAtual = lrd("estoqueatual_prod")
                CustoAtual = lrd("custo_prod")
                IpiProduto = lrd("ipi_prod")
                MkProduto = lrd("markup_prod")
                If lrd("Subtituicao_tributaria") Is DBNull.Value Then
                    SubstTributaria = 1
                Else
                    SubstTributaria = lrd("Subtituicao_tributaria")
                End If
                MarkupNET = lrd("MarkupNET_prod")
            End While
            connection.Close()
            TextBox246.Text = EstoqueAtual

            Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
        End If

        ' Pegar o preço de entrada
        If RadioButton12.Checked = True Then
            Dim PrecoEntradaNota As Double = 0
            Try
                PrecoEntradaNota = InputBox("Digite o preço de entrada sem ipi", "Digite", 0)
                If PrecoEntradaNota = 0 Then
                    GoTo proxima2
                End If
            Catch ex As Exception
            End Try

            ' calculando o estoque com a nova entrada de material
            PrecoVendaVarejo = (((PrecoEntradaNota * (1 + (IpiProduto / 100))) / (1 - (MkProduto / 100)) * (1 + (SubstTributaria / 100)))).ToString("F2")
            PrecoVendaAtacado = (((PrecoEntradaNota * (1 + (IpiProduto / 100))) / (1 - (MarkupNET / 100)) * (1 + (SubstTributaria / 100)))).ToString("F2")

            If CustoAtual <> PrecoEntradaNota Then
                ' mostrando o resultado para alterar o custo
                Dim result = MessageBox.Show("Custo Atual : " & CustoAtual, "Custo Lançado(se quiser alterar clique em SIM) : " & PrecoEntradaNota, MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Dim command4 As SqlCommand
                    command4 = connection.CreateCommand()
                    command4.CommandText = "update produtos set custo_prod=@custo_prod,precovarejo_prod=@precovarejo_prod, precoatacado_prod = @precoatacado_prod where cod_prod = @cod_prod"
                    command4.CommandType = CommandType.Text
                    command4.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = PedidoCompraDataGridView.Item(1, v_SelectRow).Value
                    command4.Parameters.Add("@custo_prod", SqlDbType.Float).Value = PrecoEntradaNota
                    command4.Parameters.Add("@precovarejo_prod", SqlDbType.Float).Value = PrecoVendaVarejo
                    command4.Parameters.Add("@precoatacado_prod", SqlDbType.Float).Value = PrecoVendaAtacado

                    Try
                        connection.Open()
                        command4.ExecuteNonQuery()
                        connection.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                    Finally
                        connection.Close()
                    End Try
                End If
            End If
            Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
        End If


proxima2:
        If RadioButton12.Checked = True Then
            RadioButton13.Checked = True
            Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)
            Me.PedidoCompraTableAdapter.Fill(Me.DataSetFinal.PedidoCompra)

        End If

    End Sub

    Private Sub Label317_Click(sender As Object, e As EventArgs) Handles Label317.Click

    End Sub

    Private Sub Button76_Click(sender As Object, e As EventArgs) Handles Button76.Click

        If TextBox284.Text = "" Or PedidoCompraDataGridView.RowCount() = 0 Then
            MessageBox.Show("Preencha o campo de 'Pesquisar Numero Pedido'")
            Exit Sub
        End If

        PrintPreviewDialog4.ShowDialog()
    End Sub
    Private Sub Button98_Click(sender As Object, e As EventArgs) Handles Button98.Click



        If TextBox284.Text = "" Then
            MessageBox.Show("escolher um número de pedido")
            Exit Sub
        Else

            
            Try
                PedidoCompraBindingSource.Filter = String.Format("Codigo_PedidoCompraString LIKE '{0}%'", TextBox284.Text)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' soma a coluna dos valores e o põe no campo certo
            Dim valor As Decimal = 0
            For Each Linha As DataGridViewRow In Me.PedidoCompraDataGridView.Rows
                valor += Linha.Cells("Totalitem_PedidoCompra").Value
            Next
            MessageBox.Show(valor)


        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Dim PegaNumeroPedido As String = InputBox("Dê o número do pedido")


        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT *  from PedidoCompra where Codigo_PedidoCompra = '" & PegaNumeroPedido & "'"

        con.Open()


        'REM verifica se cdigo prod existe banco do produto na nota para não gravar duas vezes
        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try
            If lrd.Read() = False Then

                MessageBox.Show("O código do Pdido de conpra " & PegaNumeroPedido & " não foi cadastrado!!!!")
                con.Close()
                Exit Sub

            Else


                ' Ações de abertura para poder modificar o pedido
                TextBox222.Text = PegaNumeroPedido
                btn_relfor.Enabled = False
                Button85.Enabled = False
                Button86.Enabled = True
                Button76.Enabled = False
                TextBox284.Enabled = False
                TextBox284.Clear()
                TabControl2.TabPages.Add(Tab_fornecedor)
                TabControl2.SelectedIndex = 1
                RadioButton11.Enabled = False
                RadioButton12.Enabled = False
                Button15.Enabled = False
                Button98.Enabled = False
                ComboBox26.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()

    End Sub

    Private Sub Button96_Click(sender As Object, e As EventArgs) Handles Button96.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If


        ' calcula os pedidos em aberto que falta entregar
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim v_SelectRow As Integer = 0
        For v_SelectRow = 0 To ProdutosDataGridView3.RowCount() - 1

            Dim sql2 As String = "SELECT * FROM PedidoCompra WHERE CodigoProduto_PeidoCompra = '" & ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString() & "' and EntregueSimNao_PedidoCompra = 'Não Entregue' "
            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
                dataadapter.Fill(ds, "PedidoCompra")
                connection.Close()
                PedidoCompraDataGridView1.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'somar quantidade da coluna da tabela pedido compra de quantidade
            Dim quantidadePedidos As Decimal = 0
            For Each Linha As DataGridViewRow In Me.PedidoCompraDataGridView1.Rows
                quantidadePedidos += Linha.Cells(7).Value
            Next
            TextBox127.Text = (quantidadePedidos).ToString("F2")

            ' ----------------------------------------------------------------------------------
            ' Passando Textbox para integer
            Dim QtdePedidosColocados As Integer = 0
            QtdePedidosColocados = TextBox127.Text

            ' gravando o consumo medio no arquivo de produtos
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "update produtos set pedencomendados_prod=@pedencomendados_prod where cod_prod=@cod_prod "
            command.CommandType = CommandType.Text
            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
            command.Parameters.Add("@pedencomendados_prod", SqlDbType.Int).Value = QtdePedidosColocados

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())

            Finally
                connection.Close()
            End Try

        Next

        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)

    End Sub

    Private Sub Button99_Click(sender As Object, e As EventArgs) Handles Button99.Click

        PedidoCompraDataGridView.DataSource = PedidoCompraBindingSource
        PedidoCompraBindingSource.Filter = String.Format("Fornecedor_PedidoCompra LIKE '{0}%'", ComboBox26.Text)


    End Sub
    Private Sub RadioButton18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton19_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub RadioButton20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton21_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub RadioButton22_Click(sender As Object, e As EventArgs)
       
    End Sub

   
    Private Sub Button106_Click(sender As Object, e As EventArgs)

        Dim result = MessageBox.Show("Confirmar a Deleção?", "Atenção!!!", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then

            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            ' -------------------------------------

            Dim v_SelectRow As Integer
            Try
                v_SelectRow = Me.ItemPedidosDataGridView1.CurrentRow.Index
            Catch ex As Exception
                Exit Sub
            End Try

            'rem GRAVAR DADOS
            Dim command6 As SqlCommand
            command6 = connection.CreateCommand()
            command6.CommandText = "update ItemPedidos set  quantidadeparcialentregue_item = @quantidadeparcialentregue_item  where id_item = @id_cod"
            command6.CommandType = CommandType.Text
            command6.Parameters.Add("@id_cod", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView1.Item(13, v_SelectRow).Value
            command6.Parameters.Add("@quantidadeparcialentregue_item", SqlDbType.Int).Value = ItemPedidosDataGridView1.Item(12, v_SelectRow).Value - ItemPedidosDataGridView1.Item(3, v_SelectRow).Value

            Try
                connection.Open()
                command6.ExecuteNonQuery()
                connection.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())

            End Try

            ' ------------------------------------------------------------

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from ItemNfeEmitida where NomeProd_ItemNfeemitida = @nome and id_ItemNfeEmitida = @id_cod"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@nome", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView1.Item(2, v_SelectRow).Value
            command.Parameters.Add("@id_cod", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView1.Item(0, v_SelectRow).Value

            Try


                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

            Catch ex As Exception

                MessageBox.Show("Impossível apagar campos nulo")

            End Try


            Me.ItemNfeEmitidaTableAdapter.Fill(Me.DataSetFinal.ItemNfeEmitida)
            Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)


        End If


    End Sub

    Private Sub Button108_Click(sender As Object, e As EventArgs) Handles Button108.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}' and linha_prod LIKE '{1}' and RaizSimNao_prod LIKE '{2}'", ComboBox33.Text, ComboBox34.Text, "NÃO RAIZ")

    End Sub

    Private Sub Button109_Click(sender As Object, e As EventArgs) Handles Button109.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}' and linha_prod LIKE '{1}' and RaizSimNao_prod LIKE '{2}'", ComboBox33.Text, ComboBox34.Text, "RAIZ")

    End Sub
 
  
   

    Private Sub Button112_Click(sender As Object, e As EventArgs) Handles Button112.Click

        'REM verifica se o produto já foi cadastrado mas só se for incluir
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim CodFor = InputBox("DIgite o código do fornecedor", "Obrigatório")

        con.ConnectionString = "Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789"
        cmd.Connection = con
        cmd.CommandText = "SELECT cod_prod  from produtos where cod_prodfor = " & "'" & CodFor & "'"

        con.Open()
        'REM verifica se cdigo prod do fornecdor existe em  produto  para não gravar duas vezes
        Dim lrd As SqlDataReader = cmd.ExecuteReader()

        Try
            If lrd.Read() = True Then

                MessageBox.Show("O código do fornecedor " & CodFor & " já foi cadastrado!!!!")
                con.Close()
                Exit Sub

            Else
                destravarCamposprod()
                menu_confirmarprod.Visible = True
                Cod_prodTextBox.Enabled = False
                desabilitatextbox()
                Cod_prodforTextBox.Text = CodFor
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()

        
    End Sub

    Private Sub Button107_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        TextBox376.Text = ""
        PrintPreviewDialog7.ShowDialog()
    End Sub

    Private Sub PrintPreviewDialog7_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog7.Load

        PrintPreviewDialog7.Document = PrintDocument14
        DirectCast(PrintPreviewDialog7, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument14
        PrintDialog1.PrinterSettings.PrinterName = "\\SERVIDOR\EPSON L355 Series (Caixa)"
        CType(PrintPreviewDialog7.Controls(1), ToolStrip).Items.Add(PDB)

    End Sub

    Private Sub PrintDocument14_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument14.PrintPage

        ' primeira linha
        e.Graphics.DrawString(DateTimePicker37.Text, New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Sugestão de compra   ", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 200, 5)
        e.Graphics.DrawString(ProdutosDataGridView5.Item(4, 0).Value, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 550, 5)
        ' cabecalho
        e.Graphics.DrawString("Código Fornecedor", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 50)
        e.Graphics.DrawString("Nome do Produto", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 50)
        e.Graphics.DrawString("Cor  ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 450, 50)
        e.Graphics.DrawString("Estoque Méd", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, 50)
        e.Graphics.DrawString("Consumo Máx", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 650, 50)
        e.Graphics.DrawString("Sugestão", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 740, 50)

        Dim CalculoSugestao As Double = 0
        Dim l As Integer = 0
        Dim ContadorX As Integer = 0
        TextBox376.Text = 0

        Try
            For x = 0 To ProdutosDataGridView5.RowCount() - 1

                If l <= 45 Then
                    ContadorX += 1
                Else
                    GoTo Prosxima50
                End If

                CalculoSugestao = ProdutosDataGridView5.Item(8, x).Value - ProdutosDataGridView5.Item(14, x).Value + ProdutosDataGridView5.Item(15, x).Value
                If ProdutosDataGridView5.Item(8, x).Value > (ProdutosDataGridView5.Item(9, x).Value + ProdutosDataGridView5.Item(14, x).Value - ProdutosDataGridView5.Item(15, x).Value) And CalculoSugestao > 0 Then
                    l += 1
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(2, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(6, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(7, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 450, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(8, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(12, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 650, 100 + (l * 20))
                    e.Graphics.DrawString(CalculoSugestao, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 740, 100 + (l * 20))
                End If
Prosxima50:
            Next
            If l > 45 Then
                e.Graphics.DrawString("FAVOR IMPRIMIR SEGUNDA PÁGINA", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 20, 100 + (48 * 20))
            End If
            TextBox376.Text = ContadorX
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub BalcaoDataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles BalcaoDataGridView1.DoubleClick

        Dim v_SelectRow As Integer
        v_SelectRow = Me.BalcaoDataGridView1.CurrentRow.Index

        If RadioButton25.Checked = True Then
            TextBox32.Text = BalcaoDataGridView1.Item(1, v_SelectRow).Value
            TextBox33.Text = BalcaoDataGridView1.Item(14, v_SelectRow).Value
            TextBox34.Text = BalcaoDataGridView1.Item(12, v_SelectRow).Value
            TextBox3.Text = BalcaoDataGridView1.Item(11, v_SelectRow).Value
            TextBox269.Clear()
            TextBox270.Clear()
            TextBox271.Clear()
        End If

        If RadioButton26.Checked = True Then
            TextBox32.Text = BalcaoDataGridView1.Item(1, v_SelectRow).Value
            TextBox33.Text = BalcaoDataGridView1.Item(14, v_SelectRow).Value
            TextBox34.Text = BalcaoDataGridView1.Item(12, v_SelectRow).Value
            TextBox269.Text = BalcaoDataGridView1.Item(0, v_SelectRow).Value
            TextBox270.Text = BalcaoDataGridView1.Item(4, v_SelectRow).Value
            If BalcaoDataGridView1.Item(15, v_SelectRow).Value Is DBNull.Value Then
                TextBox269.Clear()
                TextBox270.Clear()
                TextBox271.Clear()
                Exit Sub
            Else
                TextBox271.Text = BalcaoDataGridView1.Item(15, v_SelectRow).Value
            End If
        End If

    End Sub

    Private Sub GerarNotaToolStripMenuItem1_Click(sender As Object, e As EventArgs)


        'Dim reply As DialogResult = MessageBox.Show("Confirmar a geração da NOTA FISCAL?", "Atenção!!!", _
        ' MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        'If reply = DialogResult.Yes Then

        '    Dim connection As SqlConnection
        '    connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        '    Dim VrAserLancadoNfe As String
        '    Dim variavel2 As Boolean = False

        '    Try
        '        'coloca o ponteiro onde ele está clicado
        '        Dim v_SelectRow2 As Integer
        '        v_SelectRow2 = Me.PedidoNFEDataGridView4.CurrentRow.Index

        '        Dim command5 As SqlCommand
        '        command5 = connection.CreateCommand()
        '        command5.CommandText = "select * from ItemPedidos where codpedido_item = '" & PedidoNFEDataGridView4.Item(0, v_SelectRow2).Value & "'"

        '        connection.Open()

        '        Dim lrd2 As SqlDataReader = command5.ExecuteReader()
        '        While lrd2.Read

        '            'verifica se tem algum campo de quantidade diferente de zero
        '            If lrd2("qtdeNfe_item") Is DBNull.Value Then
        '                VrAserLancadoNfe = "0"
        '            Else
        '                VrAserLancadoNfe = lrd2("qtdeNfe_item")
        '            End If
        '            'indica se achou algum vr diferente de zero
        '            If VrAserLancadoNfe = 0 Then
        '            Else
        '                variavel2 = True
        '            End If


        '        End While

        '        connection.Close()
        '    Catch ex As Exception
        '        MessageBox.Show("Não foi selecionado nenhum Ítem")
        '        Exit Sub
        '    End Try

        '    ' verifica se achou algum vr diferente de zero nas quantidades lançadas
        '    If variavel2 = False Then
        '        MessageBox.Show("Não foi escolhido nenhum Ítem")
        '        Exit Sub
        '    End If

        '    'coloca o ponteiro onde ele está clicado
        '    Dim v_SelectRow As Integer
        '    v_SelectRow = Me.PedidoNFEDataGridView4.CurrentRow.Index

        '    'BUSCA DADOS NO CLIENTE NO ARQUIVO CLIENTE
        '    'variáveis do arquivo de clientes
        '    Dim endereco As String
        '    Dim numerorua_cliente As String
        '    Dim bairro_cliente As String
        '    Dim cidade_cliente As String
        '    Dim estado_cliente As String
        '    Dim cep_cliente As String
        '    Dim cnpj_cliente As String
        '    Dim insestadual_cliente As String
        '    Dim telefone_cliente As String
        '    Dim email_cliente As String
        '    Dim codIBGE_cliente As String
        '    Dim fj_cliente As String
        '    Dim cpf_cliente As String


        '    Dim command As SqlCommand
        '    command = connection.CreateCommand()
        '    command.CommandText = "select * from cliente where id_cliente = '" & PedidoNFEDataGridView4.Item(6, v_SelectRow).Value & "'"
        '    Try

        '        connection.Open()

        '        Dim lrd As SqlDataReader = command.ExecuteReader()
        '        While lrd.Read


        '            If lrd("cnpj_cliente") Is DBNull.Value Then
        '                cnpj_cliente = "0"
        '            Else
        '                cnpj_cliente = lrd("cnpj_cliente")
        '            End If

        '            If lrd("endereco_cliente") Is DBNull.Value Then
        '                endereco = "0"
        '            Else
        '                endereco = lrd("endereco_cliente")
        '            End If

        '            If lrd("numerorua_cliente") Is DBNull.Value Then
        '                numerorua_cliente = "0"
        '            Else
        '                numerorua_cliente = lrd("numerorua_cliente")
        '            End If

        '            If lrd("bairro_cliente") Is DBNull.Value Then
        '                bairro_cliente = "0"
        '            Else
        '                bairro_cliente = lrd("bairro_cliente")
        '            End If

        '            If lrd("cidade_cliente") Is DBNull.Value Then
        '                cidade_cliente = "0"
        '            Else
        '                cidade_cliente = lrd("cidade_cliente")
        '            End If

        '            If lrd("estado_cliente") Is DBNull.Value Then
        '                estado_cliente = "0"
        '            Else
        '                estado_cliente = lrd("estado_cliente")
        '            End If

        '            If lrd("cep_cliente") Is DBNull.Value Then
        '                cep_cliente = "0"
        '            Else
        '                cep_cliente = lrd("cep_cliente")
        '            End If
        '            If lrd("insestadual_cliente") Is DBNull.Value Then
        '                insestadual_cliente = "0"
        '            Else
        '                insestadual_cliente = lrd("insestadual_cliente")
        '            End If

        '            If lrd("telefone_cliente") Is DBNull.Value Then
        '                telefone_cliente = "0"
        '            Else
        '                telefone_cliente = lrd("telefone_cliente")
        '            End If
        '            If lrd("email_cliente") Is DBNull.Value Then
        '                email_cliente = "0"
        '            Else
        '                email_cliente = lrd("email_cliente")
        '            End If
        '            If lrd("codIBGE_cliente") Is DBNull.Value Then
        '                codIBGE_cliente = "0"
        '            Else
        '                codIBGE_cliente = lrd("codIBGE_cliente")
        '            End If

        '            If lrd("fj_cliente") Is DBNull.Value Then
        '                fj_cliente = "0"
        '            Else
        '                fj_cliente = lrd("fj_cliente")
        '            End If

        '            If lrd("cpf_cliente") Is DBNull.Value Then
        '                cpf_cliente = "0"
        '            Else
        '                cpf_cliente = lrd("cpf_cliente")
        '            End If
        '        End While

        '        connection.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try

        '    'estabelecer um horário que vai funcionar como índice
        '    Dim HorarioNotaEmitida3 As String
        '    Dim date3 As New Date()
        '    date3 = Date.Now
        '    Dim ci3 As CultureInfo = CultureInfo.InvariantCulture
        '    HorarioNotaEmitida3 = date3.ToString("dd.yyyy.hh.mm.ss.FFFFF", ci3)
        '    Dim HorarioNotaEmitida4 As String = Convert.ToString(HorarioNotaEmitida3)

        '    Try
        '        'rem salvar os dados e criar o corpo da NOTA
        '        command = connection.CreateCommand()
        '        command.CommandText = "INSERT INTO NFE_Emitidas (Codigo_nfeemitida,CodigoCliente_nfeemitida,RazaoCliente_nfeemitida,ENderecoCLiente_nfeemitida,NUmeroRuacliente_nfeemitida,BairroCliente_nfeemitida,municipioCliente_nfeemitida,telefoneCLiente_nfeemitida,emailCliente_nfeemitida,estadoCliente_nfeemitida,IBGEcliente_nfeemitida,CEPcliente_nfeemitida,pessoaFouJcliente_nfeemitida,CPFcliente_nfeemitida,CNPJcliente_nfeemitida,IEcliente_nfeemitida,CodigoPedido_nfeemitida,horaEmitida_nfeemitida,NomeTrans_nfeemitida,CodTrans_nfeemitida,Peso_nfeemitida,data_nfeemitidas,vendedor_nfeemitidas) values (@Codigo_nfeemitida,@CodigoCliente_nfeemitida,@RazaoCliente_nfeemitida,@ENderecoCLiente_nfeemitida,@NUmeroRuacliente_nfeemitida,@BairroCliente_nfeemitida,@municipioCliente_nfeemitida,@telefoneCLiente_nfeemitida,@emailCliente_nfeemitida,@estadoCliente_nfeemitida,@IBGEcliente_nfeemitida,@CEPcliente_nfeemitida,@pessoaFouJcliente_nfeemitida,@CPFcliente_nfeemitida,@CNPJcliente_nfeemitida,@IEcliente_nfeemitida,@CodigoPedido_nfeemitid,@horaEmitida_nfeemitida,@NomeTrans_nfeemitida,@CodTrans_nfeemitida,@Peso_nfeemitida,@data_nfeemitidas,@vendedor_nfeemitidas)"
        '        command.CommandType = CommandType.Text

        '        ' rem   SALVAR NA CONFIRMAÇÃO DOS DADOS
        '        command.Parameters.Add("@Codigo_nfeemitida", SqlDbType.VarChar, 50).Value = ""
        '        command.Parameters.Add("@horaEmitida_nfeemitida", SqlDbType.VarChar, 50).Value = HorarioNotaEmitida4
        '        command.Parameters.Add("@CodigoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(6, v_SelectRow).Value
        '        command.Parameters.Add("@RazaoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(7, v_SelectRow).Value
        '        command.Parameters.Add("@ENderecoCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = endereco
        '        command.Parameters.Add("@NUmeroRuacliente_nfeemitida", SqlDbType.VarChar, 50).Value = numerorua_cliente
        '        command.Parameters.Add("@BairroCliente_nfeemitida", SqlDbType.VarChar, 50).Value = bairro_cliente
        '        command.Parameters.Add("@municipioCliente_nfeemitida", SqlDbType.VarChar, 50).Value = cidade_cliente
        '        command.Parameters.Add("@telefoneCLiente_nfeemitida", SqlDbType.VarChar, 50).Value = telefone_cliente
        '        command.Parameters.Add("@emailCliente_nfeemitida", SqlDbType.VarChar, 50).Value = email_cliente
        '        command.Parameters.Add("@estadoCliente_nfeemitida", SqlDbType.VarChar, 50).Value = estado_cliente
        '        command.Parameters.Add("@IBGEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = codIBGE_cliente
        '        command.Parameters.Add("@CEPcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cep_cliente
        '        command.Parameters.Add("@pessoaFouJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = fj_cliente
        '        command.Parameters.Add("@CPFcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cpf_cliente
        '        command.Parameters.Add("@CNPJcliente_nfeemitida", SqlDbType.VarChar, 50).Value = cnpj_cliente
        '        command.Parameters.Add("@IEcliente_nfeemitida", SqlDbType.VarChar, 50).Value = insestadual_cliente
        '        command.Parameters.Add("@CodigoPedido_nfeemitid", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(0, v_SelectRow).Value
        '        command.Parameters.Add("@CodTrans_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(9, v_SelectRow).Value
        '        command.Parameters.Add("@NomeTrans_nfeemitida", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(10, v_SelectRow).Value
        '        command.Parameters.Add("@Peso_nfeemitida", SqlDbType.VarChar, 50).Value = "0"
        '        command.Parameters.Add("@data_nfeemitidas", SqlDbType.Date).Value = Date.Now
        '        command.Parameters.Add("@vendedor_nfeemitidas", SqlDbType.VarChar, 50).Value = PedidoNFEDataGridView4.Item(1, v_SelectRow).Value

        '        connection.Open()
        '        command.ExecuteNonQuery()
        '        connection.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try

        '    ' pegar o último número gravado com datagrid
        '    Me.NFE_EmitidasTableAdapter.Fill(Me.DataSetFinal.NFE_Emitidas)

        '    Dim UltimoID As String
        '    Dim command15 As SqlCommand
        '    command15 = connection.CreateCommand()
        '    command15.CommandText = "select id_nfeemitidas  from NFE_Emitidas  where id_nfeemitidas = (select max(id_nfeemitidas) from NFE_Emitidas) "
        '    Try
        '        connection.Open()

        '        Dim lrd15 As SqlDataReader = command15.ExecuteReader()
        '        While lrd15.Read

        '            If lrd15("id_nfeemitidas") Is DBNull.Value Then
        '                UltimoID = "0"
        '            Else
        '                UltimoID = lrd15("id_nfeemitidas")
        '            End If

        '        End While

        '        connection.Close()
        '    Catch ex As Exception

        '        MessageBox.Show(ex.ToString)

        '    End Try
        '    TextBox289.Text = UltimoID


        '    ' rem buscar os ítens do PEDIDO e transformá-los em ítens da nota
        '    Dim command1 As SqlCommand
        '    command1 = connection.CreateCommand()
        '    Dim yy As Integer
        '    Try

        '        For yy = 0 To ItemPedidosDataGridView10.RowCount() - 1
        '            'If ItemPedidosDataGridView2.Item(10, yy).Value <> "Entregue" Then
        '            command1 = connection.CreateCommand()
        '            command1.CommandText = "INSERT INTO ItemNfeEmitida (IDcod_itemNfeEmitida,NumeroNFe_ItemNfeEmitida,codProd_ItemNfeEmitida,NomeProd_ItemNfeemitida,QtdeProd_ItemNfeEmitida,VrUnitarioProd_ItemNfeEmitida,VrTlProd_itemNfeEmitida,HoraNota_itemNfeEmitida,NumeroPed_itemNfeEmitida,NCM_itemNfeEmitida,tabela_itemNfeEmitida,Peso_itemNfeEmitida,QtdeENtregue_itemNfeEmitida) values (@IDcod_itemNfeEmitida,@NumeroNFe_ItemNfeEmitida,@codProd_ItemNfeEmitida,@NomeProd_ItemNfeemitida,@QtdeProd_ItemNfeEmitida,@VrUnitarioProd_ItemNfeEmitida,@VrTlProd_itemNfeEmitida,@HoraNota_itemNfeEmitida,@NumeroPed_itemNfeEmitida,@NCM_itemNfeEmitida,@tabela_itemNfeEmitida,@Peso_itemNfeEmitida,@QtdeENtregue_itemNfeEmitida)"
        '            'command1.CommandText = "INSERT INTO ItemNfeEmitida (tabela_itemNfeEmitida,Peso_itemNfeEmitida,QtdeENtregue_itemNfeEmitida) values (@tabela_itemNfeEmitida,@Peso_itemNfeEmitida,@QtdeENtregue_itemNfeEmitida)"


        '            command1.CommandType = CommandType.Text
        '            command1.Parameters.Add("@NumeroNFe_ItemNfeEmitida", SqlDbType.VarChar, 50).Value = UltimoID
        '            command1.Parameters.Add("@codProd_ItemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView10.Item(13, yy).Value
        '            command1.Parameters.Add("@NomeProd_ItemNfeemitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView10.Item(1, yy).Value
        '            command1.Parameters.Add("@QtdeProd_ItemNfeEmitida", SqlDbType.Float).Value = ItemPedidosDataGridView10.Item(6, yy).Value
        '            command1.Parameters.Add("@VrUnitarioProd_ItemNfeEmitida", SqlDbType.Float).Value = ItemPedidosDataGridView10.Item(8, yy).Value
        '            Dim arredonda As String = (ItemPedidosDataGridView10.Item(5, yy).Value) * (ItemPedidosDataGridView10.Item(8, yy).Value)
        '            command1.Parameters.Add("@VrTlProd_itemNfeEmitida", SqlDbType.Float).Value = arredonda
        '            command1.Parameters.Add("@HoraNota_itemNfeEmitida", SqlDbType.VarChar, 50).Value = HorarioNotaEmitida4
        '            command1.Parameters.Add("@NumeroPed_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView10.Item(11, yy).Value
        '            command1.Parameters.Add("@NCM_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView10.Item(19, yy).Value
        '            command1.Parameters.Add("@tabela_itemNfeEmitida", SqlDbType.VarChar, 50).Value = ItemPedidosDataGridView10.Item(17, yy).Value
        '            command1.Parameters.Add("@Peso_itemNfeEmitida", SqlDbType.Float).Value = ItemPedidosDataGridView10.Item(18, yy).Value
        '            command1.Parameters.Add("@QtdeENtregue_itemNfeEmitida", SqlDbType.Int).Value = ItemPedidosDataGridView10.Item(7, yy).Value
        '            command1.Parameters.Add("@IDcod_itemNfeEmitida", SqlDbType.VarChar, 50).Value = 0 'PedidoNFEDataGridView4.Item(0, yy).Value

        '            If ItemPedidosDataGridView10.Item(6, yy).Value <> 0 Then
        '                connection.Open()
        '                command1.ExecuteNonQuery()
        '                connection.Close()
        '            End If
        '        Next

        '        Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try
        '    Me.ItemNfeEmitidaTableAdapter.Fill(Me.DataSetFinal.ItemNfeEmitida)

        '    '***********************************************************************
        '    REM zerar os campos do arquivo item pedidos
        '    Dim command2 As SqlCommand
        '    Try
        '        For yy = 0 To ItemPedidosDataGridView10.RowCount() - 1
        '            command2 = connection.CreateCommand()
        '            command2.CommandText = "update ItemPedidos set qtdeNfe_item= @qtdeNfe_item  where id_item = '" & ItemPedidosDataGridView10.Item(20, yy).Value & "'"
        '            command2.CommandType = CommandType.Text
        '            command2.Parameters.Add("@qtdeNfe_item", SqlDbType.Float).Value = 0

        '            connection.Open()
        '            command2.ExecuteNonQuery()
        '            connection.Close()
        '        Next

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString())
        '    End Try

        '    Me.ItemPedidosTableAdapter.Fill(Me.DataSetFinal.ItemPedidos)


        '    ' passar parâmetros para a tela de notas
        '    TextBox294.Text = PedidoNFEDataGridView1.Item(7, v_SelectRow).Value
        '    ' TextBox295.Text = endereco
        '    TextBox295.Text = numerorua_cliente
        '    TextBox300.Text = email_cliente
        '    TextBox16.Text = cep_cliente
        '    TextBox296.Text = bairro_cliente
        '    TextBox323.Text = cidade_cliente
        '    TextBox324.Text = estado_cliente
        '    TextBox297.Text = telefone_cliente
        '    TextBox303.Text = cnpj_cliente
        '    TextBox301.Text = cpf_cliente
        '    TextBox302.Text = insestadual_cliente
        '    TextBox304.Text = codIBGE_cliente
        '    ' Txt_fisicajuridicaNFE.Text = fj_cliente
        '    TextBox293.Text = PedidoNFEDataGridView1.Item(6, v_SelectRow).Value
        '    TextBox325.Text = PedidoNFEDataGridView1.Item(0, v_SelectRow).Value
        '    TextBox316.Text = TextBox249.Text

        '    ' HoraEmitida_nfeemitidaTextBox.Text = HorarioNotaEmitida4
        '    TextBox307.Text = PedidoNFEDataGridView1.Item(9, v_SelectRow).Value
        '    TextBox306.Text = PedidoNFEDataGridView1.Item(10, v_SelectRow).Value
        '    TextBox305.Text = PedidoNFEDataGridView1.Item(1, v_SelectRow).Value
        '    TextBox291.Text = "5102"
        '    'TextBox292.Text = "Vendas"
        '    TextBox292.Text = "saída"
        '    ' ComboBox12.Text = "emitente"

        '    TabControl_NFE.SelectedIndex = 0
        '    ' filtra pelo horário em que foi cadastrado
        '    ItemNfeEmitidaBindingSource.Filter = String.Format("HoraNota_itemNfeEmitida LIKE '{0}%'", HorarioNotaEmitida4)
        '    ' soma  o valor d nota

        '    '    ' -----------------------------------------------------------------------------
        '    '    ' trabalhando com as duplicatas
        '    rdb_vezesduplicata1.Enabled = True
        '    txt_vrduplicata1.Text = TextBox249.Text
        '    txt_vrduplicata1.Enabled = True
        '    '    ' liberando campos

        '    txt_obsNFE.Enabled = True
        '    '    ' habilitar botões
        '    Button4.Enabled = False
        '    Button10.Enabled = True
        '    Button17.Enabled = False
        '    Button20.Enabled = False
        '    Button21.Enabled = True
        '    Button38.Enabled = True

        '    '    ' habilitar duplicatas
        '    txt_vrduplicata1.Enabled = True
        '    txt_vrduplicata2.Enabled = True
        '    txt_vrduplicata3.Enabled = True
        '    txt_vrduplicata4.Enabled = True
        '    txt_vrduplicata5.Enabled = True
        '    date_duplicata1.Enabled = True
        '    date_duplicata2.Enabled = True
        '    date_duplicata3.Enabled = True
        '    date_duplicata4.Enabled = True
        '    date_duplicata5.Enabled = True
        '    ' habilitar dariobutons duplicatas
        '    RadioButton18.Enabled = True
        '    RadioButton19.Enabled = True
        '    RadioButton20.Enabled = True
        '    RadioButton21.Enabled = True
        '    RadioButton22.Enabled = True
        '    ComboBox37.Enabled = True

        '    '    '---------------------------------------------------------------------------
        '    '    '--------------------------------------------------------------------------
        '    '    ' ATUALIZA O ARQUIVO DE NOTAS, PARA RESOLVERCAMPOS EM BRANCO NO BD
        '    '    'gravar dados no arquivo nfe Emitidas

        '    '    Try
        '    '        'rem salvar os dados e criar o corpo da NOTA
        '    '        command = connection.CreateCommand()
        '    '        'command.CommandText = "update  NFE_Emitidas set Codigo_nfeemitida=@Codigo_nfeemitida,CodigoCliente_nfeemitida=@CodigoCliente_nfeemitida,RazaoCliente_nfeemitida=@RazaoCliente_nfeemitida,ENderecoCLiente_nfeemitida=@ENderecoCLiente_nfeemitida,NUmeroRuacliente_nfeemitida=@NUmeroRuacliente_nfeemitida,BairroCliente_nfeemitida=@BairroCliente_nfeemitida,municipioCliente_nfeemitida=@municipioCliente_nfeemitida,telefoneCLiente_nfeemitida=@telefoneCLiente_nfeemitida,emailCliente_nfeemitida=@emailCliente_nfeemitida,estadoCliente_nfeemitida=@estadoCliente_nfeemitida,IBGEcliente_nfeemitida=@IBGEcliente_nfeemitida,CEPcliente_nfeemitida=@CEPcliente_nfeemitida,pessoaFouJcliente_nfeemitida=@pessoaFouJcliente_nfeemitida,CPFcliente_nfeemitida=@CPFcliente_nfeemitida,CNPJcliente_nfeemitida=@CNPJcliente_nfeemitida,IEcliente_nfeemitida=@IEcliente_nfeemitida,CodigoPedido_nfeemitida=@CodigoPedido_nfeemitida,VrFatura_nfeemitida=@VrFatura_nfeemitida,dataduplicata1_nfeemitida=@dataduplicata1_nfeemitida,Vrduplicata1_nfeemitida=@Vrduplicata1_nfeemitida,Vrduplicata2_nfeemitida=@Vrduplicata2_nfeemitida,dataduplicata2_nfeemitida=@dataduplicata2_nfeemitida,dataduplicata3_nfeemitida=@dataduplicata3_nfeemitida,Vrduplicata3_nfeemitida=@Vrduplicata3_nfeemitida,dataduplicata4_nfeemitida=@dataduplicata4_nfeemitida,Vrduplicata4_nfeemitida=@Vrduplicata4_nfeemitida,dataduplicata5_nfeemitida=@dataduplicata5_nfeemitida,Vrduplicata5_nfeemitida=@Vrduplicata5_nfeemitida,CFOP_nfeemitida=@CFOP_nfeemitida,VOlumes_nfeemitida=@VOlumes_nfeemitida,Peso_nfeemitida=@Peso_nfeemitida,emissorNota_nfeemitidas=@emissorNota_nfeemitidas,obsNota_nfeemitida=@obsNota_nfeemitida,obxNCM_nfeemitida=@obxNCM_nfeemitida,ent_saida_nfeemitidas=@ent_saida_nfeemitidas,descOperacao_nfeemitida=@descOperacao_nfeemitida,frete_nfeemitida=@frete_nfeemitida,CodTrans_nfeemitida=@CodTrans_nfeemitida,NomeTrans_nfeemitida=@NomeTrans_nfeemitida where horaEmitida_nfeemitida = '" & HoraEmitida_nfeemitidaTextBox.Text & "'"
        '    '        command.CommandType = CommandType.Text
        '    '        command.Parameters.Add("@Codigo_nfeemitida", SqlDbType.VarChar, 50).Value = txt_nNfe.Text
        '    '        command.Parameters.Add("@CodigoCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@RazaoCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@ENderecoCLiente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@NUmeroRuacliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@BairroCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@municipioCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@telefoneCLiente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@emailCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@estadoCliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@IBGEcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CEPcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@pessoaFouJcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CPFcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CNPJcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@IEcliente_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CodigoPedido_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CFOP_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@VOlumes_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@Peso_nfeemitida", SqlDbType.Float).Value =
        '    '       ' command.Parameters.Add("@emissorNota_nfeemitidas", SqlDbType.VarChar, 50).Value = 
        '    '        command.Parameters.Add("@obsNota_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@obxNCM_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@ent_saida_nfeemitidas", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@descOperacao_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@frete_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@CodTrans_nfeemitida", SqlDbType.VarChar, 50).Value =
        '    '        command.Parameters.Add("@NomeTrans_nfeemitida", SqlDbType.VarChar, 50).Value = 

        '    '        ' aqui grava os dados referentes a ao vr da fatura 
        '    '        command.Parameters.Add("@VrFatura_nfeemitida", SqlDbType.Float).Value = TextBox5.Text
        '    '        command.Parameters.Add("@dataduplicata1_nfeemitida", SqlDbType.Date).Value = date_duplicata1.Text
        '    '        command.Parameters.Add("@Vrduplicata1_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata1.Text


        '    '        If txt_vrduplicata2.Text = "" Then
        '    '            command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '    '            command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = 0

        '    '        Else
        '    '            command.Parameters.Add("@dataduplicata2_nfeemitida", SqlDbType.Date).Value = date_duplicata2.Text
        '    '            command.Parameters.Add("@Vrduplicata2_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata2.Text
        '    '        End If

        '    '        If txt_vrduplicata3.Text = "" Then
        '    '            command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '    '            command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = 0

        '    '        Else
        '    '            command.Parameters.Add("@dataduplicata3_nfeemitida", SqlDbType.Date).Value = date_duplicata3.Text
        '    '            command.Parameters.Add("@Vrduplicata3_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata3.Text
        '    '        End If

        '    '        If txt_vrduplicata4.Text = "" Then
        '    '            command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '    '            command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = 0
        '    '        Else
        '    '            command.Parameters.Add("@dataduplicata4_nfeemitida", SqlDbType.Date).Value = date_duplicata4.Text
        '    '            command.Parameters.Add("@Vrduplicata4_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata4.Text
        '    '        End If
        '    '        If txt_vrduplicata5.Text = "" Then
        '    '            command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = DBNull.Value
        '    '            command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = 0

        '    '        Else
        '    '            command.Parameters.Add("@dataduplicata5_nfeemitida", SqlDbType.Date).Value = date_duplicata5.Text
        '    '            command.Parameters.Add("@Vrduplicata5_nfeemitida", SqlDbType.Float).Value = txt_vrduplicata5.Text
        '    '        End If

        '    '        connection.Open()
        '    '        command.ExecuteNonQuery()
        '    '        connection.Close()

        '    '    Catch ex As Exception

        '    '        MessageBox.Show(ex.ToString)

        '    '    End Try

        '    '    '-------------------------------------------------------------------------------
        '    '    '-----------------------------------------------------------------------------

        'End If
    End Sub

    Private Sub Button113_Click(sender As Object, e As EventArgs) Handles Button113.Click

        If ProdutosDataGridView4.Rows.Count() > 270 Then
            MessageBox.Show("A lista para impressão está com maior do que 270 ítens. Por favor, selecione melhor. Ela tem atualmente : " & ProdutosDataGridView4.Rows.Count() & "  Ítens")
            Exit Sub
        End If

        Dim reply As DialogResult = MessageBox.Show("   Confirma a Impressão?", "Atenção!!!", _
          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            PrintDocument4.Print()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub RadioButton23_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton23.CheckedChanged
        RadioButton8.Enabled = False
        RadioButton10.Enabled = False
        RadioButton23.Enabled = False
       

    End Sub

   

    Private Sub RadioButton10_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        RadioButton8.Enabled = False
        RadioButton10.Enabled = False
        RadioButton23.Enabled = False
       
    End Sub

    Private Sub Button91_Click(sender As Object, e As EventArgs) Handles Button91.Click

        Dim numero As Integer
        Dim GeradorDeNumerosAleatorios As Random = New Random()
        numero = GeradorDeNumerosAleatorios.Next(TextBox333.Text, TextBox334.Text)
        TextBox335.Text = numero

    End Sub



    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click

        variavelImpressao = "4"
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and linha_prod LIKE '{1}%' and RaizSimNao_prod LIKE '{2}%' and Bugiganga_prod LIKE '{3}%'", ComboBox29.Text, ComboBox30.Text, "RAIZ", "bugiganga")
        Label94.Text = ProdutosDataGridView4.Rows.Count()

    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click

        ProdutosBindingSource1.Filter = String.Format("RaizSimNao_prod LIKE '{0}'", "RAIZ")

        Dim custo_prod1 As String = ""
        Dim ipi_prod1 As String = ""
        Dim estoqueatual_prod1 As String = ""
        Dim ValorEstoqueAtual1 As Double = 0
        Dim ValorEstoqueAtual2 As Double = 0


        For x As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            If dataGridPediMarf.Item(11, x).Value.ToString() < 0 Then
            Else
                custo_prod1 = dataGridPediMarf.Item(14, x).Value.ToString()
                ipi_prod1 = dataGridPediMarf.Item(15, x).Value.ToString()
                estoqueatual_prod1 = dataGridPediMarf.Item(11, x).Value.ToString()
                ValorEstoqueAtual1 = (custo_prod1 * (1 + (ipi_prod1 / 100))) * estoqueatual_prod1
                ValorEstoqueAtual2 += ValorEstoqueAtual1
            End If
        Next

        TextBox309.Text = (ValorEstoqueAtual2 / 0.65).ToString("F2")
        TextBox217.Text = ValorEstoqueAtual2

    End Sub

    Private Sub Button110_Click(sender As Object, e As EventArgs) Handles Button110.Click

        If TextBox336.Text = "" Then
            MessageBox.Show("Escolha o ítem a ser apagado")
            Exit Sub
        End If

        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "delete from ApelidoErrado where NumeroNota_ApelidoErrado = @NumeroNota_ApelidoErrado"
            command.CommandType = CommandType.Text

            command.Parameters.Add("@NumeroNota_ApelidoErrado", SqlDbType.VarChar, 50).Value = TextBox338.Text

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Apagado com sucesso!")
                ''#Insert some code here, woo
            Catch ex As Exception
                MessageBox.Show("Algo ocorreu errado")
                MessageBox.Show(ex.ToString())


            Finally
                connection.Close()
            End Try
            Me.ApelidoErradoTableAdapter.Fill(Me.DataSetFinal.ApelidoErrado)
        End If
        TextBox336.Clear()
        TextBox337.Clear()
        TextBox338.Clear()

    End Sub

    Private Sub ApelidoErradoDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles ApelidoErradoDataGridView.DoubleClick

        Dim v_SelectRow As Integer
        v_SelectRow = Me.ApelidoErradoDataGridView.CurrentRow.Index

        TextBox336.Text = ApelidoErradoDataGridView.Item(1, v_SelectRow).Value
        TextBox337.Text = ApelidoErradoDataGridView.Item(2, v_SelectRow).Value
        TextBox338.Text = ApelidoErradoDataGridView.Item(3, v_SelectRow).Value

    End Sub

    Private Sub Button115_Click(sender As Object, e As EventArgs) Handles Button115.Click


        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM VendasMlb WHERE DataPedido_VendasMlb >=   convert (datetime, '" & DateTimePicker20.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "VendasMlb")
            connection.Close()
            VendasMlbDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub TextBox339_TextChanged(sender As Object, e As EventArgs) Handles TextBox339.TextChanged

        ApelidoErradoBindingSource.Filter = String.Format("NumeroNota_ApelidoErrado LIKE '{0}%'", TextBox339.Text)

    End Sub

    Private Sub RadioButton26_Click(sender As Object, e As EventArgs) Handles RadioButton26.Click

        TextBox269.Clear()
        TextBox270.Clear()
        TextBox271.Clear()
        'TextBox272.Clear()
        Button77.Enabled = True
    End Sub

    Private Sub RadioButton25_Click(sender As Object, e As EventArgs) Handles RadioButton25.Click
        TextBox269.Clear()
        TextBox270.Clear()
        TextBox271.Clear()
        TextBox272.Clear()
        Button77.Enabled = False
    End Sub

    Private Sub TextBox341_TextChanged(sender As Object, e As EventArgs) Handles TextBox341.TextChanged

        ProdutosBindingSource.Filter = String.Format("nome_prod LIKE '{0}%'", TextBox341.Text)

    End Sub

    Private Sub TextBox342_TextChanged(sender As Object, e As EventArgs) Handles TextBox342.TextChanged

        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox342.Text)

    End Sub

    Private Sub TextBox343_TextChanged(sender As Object, e As EventArgs) Handles TextBox343.TextChanged
        ProdutosBindingSource.Filter = String.Format("codbarras_prod LIKE '{0}%'", TextBox343.Text)

    End Sub

    Private Sub TextBox344_TextChanged(sender As Object, e As EventArgs) Handles TextBox344.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prod LIKE '{0}%'", TextBox344.Text)

    End Sub

    Private Sub TextBox345_TextChanged(sender As Object, e As EventArgs) Handles TextBox345.TextChanged

        ProdutosBindingSource.Filter = String.Format("CodigoMlb_prod LIKE '{0}%'", TextBox345.Text)

    End Sub

    Private Sub TextBox346_TextChanged(sender As Object, e As EventArgs) Handles TextBox346.TextChanged

        ProdutosBindingSource.Filter = String.Format("Apelido_prod LIKE '{0}%'", TextBox346.Text)

    End Sub

    Private Sub Label414_Click(sender As Object, e As EventArgs) Handles Label414.Click

    End Sub

    Private Sub Button116_Click(sender As Object, e As EventArgs) Handles Button116.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}' and linha_prod LIKE '{1}' and RaizSimNao_prod LIKE '{2}'", ComboBox5.Text, ComboBox42.Text, "RAIZ")
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(12, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(12, x).Value < 40 And ProdutosDataGridView7.Item(12, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(11).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(12).Style.ForeColor = Color.Red
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(14, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(14, x).Value < 25 And ProdutosDataGridView7.Item(14, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(13).Style.ForeColor = Color.Green
                ProdutosDataGridView7.Rows(x).Cells(14).Style.ForeColor = Color.Green
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(16, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(16, x).Value < 25 And ProdutosDataGridView7.Item(16, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(15).Style.ForeColor = Color.Yellow
                ProdutosDataGridView7.Rows(x).Cells(16).Style.ForeColor = Color.Yellow
            End If
        Next
    End Sub

    Private Sub Button117_Click(sender As Object, e As EventArgs) Handles Button117.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and linha_prod LIKE '{1}%' and RaizSimNao_prod LIKE '{2}%' and Bugiganga_prod LIKE '{3}%'", ComboBox5.Text, ComboBox42.Text, "RAIZ", "bugiganga")
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(12, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(12, x).Value < 40 And ProdutosDataGridView7.Item(12, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(11).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(12).Style.ForeColor = Color.Red
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(14, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(14, x).Value < 25 And ProdutosDataGridView7.Item(14, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(13).Style.ForeColor = Color.Green
                ProdutosDataGridView7.Rows(x).Cells(14).Style.ForeColor = Color.Green
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(16, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(16, x).Value < 25 And ProdutosDataGridView7.Item(16, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(15).Style.ForeColor = Color.Yellow
                ProdutosDataGridView7.Rows(x).Cells(16).Style.ForeColor = Color.Yellow
            End If
        Next
    End Sub

    Private Sub Button119_Click(sender As Object, e As EventArgs) Handles Button119.Click
        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox42.Text, ComboBox5.Text)
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(12, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(12, x).Value < 40 And ProdutosDataGridView7.Item(12, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(11).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(12).Style.ForeColor = Color.Red
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(14, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(14, x).Value < 25 And ProdutosDataGridView7.Item(14, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(13).Style.ForeColor = Color.Green
                ProdutosDataGridView7.Rows(x).Cells(14).Style.ForeColor = Color.Green
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(16, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(16, x).Value < 25 And ProdutosDataGridView7.Item(16, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(15).Style.ForeColor = Color.Yellow
                ProdutosDataGridView7.Rows(x).Cells(16).Style.ForeColor = Color.Yellow
            End If
        Next
    End Sub

    Private Sub Button118_Click(sender As Object, e As EventArgs) Handles Button118.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox5.Text)

        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(12, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(12, x).Value < 40 And ProdutosDataGridView7.Item(12, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(11).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(12).Style.ForeColor = Color.Red
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(14, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(14, x).Value < 25 And ProdutosDataGridView7.Item(14, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(13).Style.ForeColor = Color.Green
                ProdutosDataGridView7.Rows(x).Cells(14).Style.ForeColor = Color.Green
            End If
        Next
        For x = 0 To ProdutosDataGridView7.Rows.Count() - 1
            If ProdutosDataGridView7.Item(16, x).Value Is DBNull.Value Then
            ElseIf ProdutosDataGridView7.Item(16, x).Value < 25 And ProdutosDataGridView7.Item(16, x).Value <> 0 Then
                ProdutosDataGridView7.Rows(x).Cells(7).Style.ForeColor = Color.Red
                ProdutosDataGridView7.Rows(x).Cells(15).Style.ForeColor = Color.Yellow
                ProdutosDataGridView7.Rows(x).Cells(16).Style.ForeColor = Color.Yellow
            End If
        Next

    End Sub

    Private Sub ProdutosDataGridView7_DoubleClick(sender As Object, e As EventArgs) Handles ProdutosDataGridView7.DoubleClick
        tabpage_produtos.SelectedIndex = 0
        travarCamposprod()
    End Sub

    Private Sub IncluirToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles IncluirToolStripMenuItem2.Click
        ' enabled
        TextBox347.Enabled = True
        TextBox349.Enabled = True
        RadioButton27.Enabled = True
        RadioButton28.Enabled = True
        RadioButton29.Enabled = True
        RadioButton30.Enabled = True
        RadioButton31.Enabled = True
        RadioButton32.Enabled = True
        Button120.Enabled = False
        ' clear()
        TextBox347.Clear()
        TextBox349.Clear()

    End Sub

    Private Sub ConfirmarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConfirmarToolStripMenuItem1.Click

        Dim reply As DialogResult = MessageBox.Show("Confirmar a alteração?", "Atenção!!!", _
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            ' *************************************************************************
            'REM verifica se o endereço já foi cadastrado no arquivo balcão
            Dim cmd As New SqlCommand
            cmd.Connection = connection
            cmd.CommandText = "SELECT EnderecoEletronico  from EnderecoEletronico where EnderecoEletronico = '" & TextBox347.Text & "'"
            connection.Open()
            'REM verifica se código prod existe no arquivo balcão, para não gravar duas vezes
            Dim lrd5 As SqlDataReader = cmd.ExecuteReader()

            Try
                If lrd5.Read() = True Then
                    MessageBox.Show("já cadastrou este endereço Eletrônico")
                    connection.Close()
                    GoTo FIM

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            connection.Close()
            ' **************************************************************************
            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "INSERT INTO EnderecoEletronico (EmrpesaVendedora_EnderecoEletronico,MeioVendedor_EnderecoEletronico,NomeEnderecoEletronico,EnderecoEletronico) values (@EmrpesaVendedora_EnderecoEletronico,@MeioVendedor_EnderecoEletronico,@NomeEnderecoEletronico,@EnderecoEletronico)"
            command.CommandType = CommandType.Text

            If RadioButton27.Checked = True Then
                command.Parameters.Add("@EmrpesaVendedora_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "Fernando"
            ElseIf RadioButton28.Checked = True Then
                command.Parameters.Add("@EmrpesaVendedora_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "Silvia"
            Else
                MessageBox.Show("Marcar uma empresa")
                Exit Sub
            End If

            If RadioButton29.Checked = True Then
                command.Parameters.Add("@MeioVendedor_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "Mlb"
            ElseIf RadioButton30.Checked = True Then
                command.Parameters.Add("@MeioVendedor_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "FULL"
            ElseIf RadioButton31.Checked = True Then
                command.Parameters.Add("@MeioVendedor_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "ZOOM"
            ElseIf RadioButton32.Checked = True Then
                command.Parameters.Add("@MeioVendedor_EnderecoEletronico", SqlDbType.VarChar, 50).Value = "Site"
            Else
                MessageBox.Show("Marcar um meio vendedor")
                Exit Sub
            End If
            command.Parameters.Add("@EnderecoEletronico", SqlDbType.VarChar, 150).Value = TextBox347.Text
            command.Parameters.Add("@NomeEnderecoEletronico", SqlDbType.VarChar, 150).Value = TextBox349.Text

            ' a seguir comandos para gravar os ítens coletados do formulário ------------------
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Sucesso!")

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

        End If

        Me.EnderecoEletronicoTableAdapter.Fill(Me.DataSetFinal.EnderecoEletronico)
FIM:
        ' arrumando os botões
        TextBox347.Enabled = False
        TextBox349.Enabled = False
        TextBox347.Clear()
        TextBox349.Clear()
        Button120.Enabled = True
        'enabled
        RadioButton27.Enabled = False
        RadioButton28.Enabled = False
        RadioButton29.Enabled = False
        RadioButton30.Enabled = False
        RadioButton31.Enabled = False
        RadioButton32.Enabled = False
        ' desmarcando
        RadioButton27.Checked = False
        RadioButton28.Checked = False
        RadioButton29.Checked = False
        RadioButton30.Checked = False
        RadioButton31.Checked = False
        RadioButton32.Checked = False
        ' contando numero de registros
        Label420.Text = EnderecoEletronicoDataGridView.Rows.Count()
    End Sub

    Private Sub EnderecoEletronicoDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles EnderecoEletronicoDataGridView.DoubleClick

        Dim v_SelectRow As Integer
        v_SelectRow = Me.EnderecoEletronicoDataGridView.CurrentRow.Index

        tabpage_produtos.SelectedIndex = 1
        TextBox252.Text = EnderecoEletronicoDataGridView.Item(4, v_SelectRow).Value

    End Sub

    Private Sub ApagarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ApagarToolStripMenuItem3.Click


        ' verifica se o compo está preenchido

        If TextBox347.Text = "" Then
            MessageBox.Show("Campo a ser apagado em branco !!!")
            Exit Sub
        End If

        ' apaga registro
        Dim reply As DialogResult = MessageBox.Show("Confirmar a exclusão?", "Atenção!!!", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
            Dim command As SqlCommand
            ' apagar os dados da tabela
            Dim v_SelectRow As Integer
            v_SelectRow = Me.EnderecoEletronicoDataGridView.CurrentRow.Index

            command = connection.CreateCommand()
            command.CommandText = "delete from EnderecoEletronico where  Id_EnderecoEletronico = @Id_EnderecoEletronico"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@Id_EnderecoEletronico", SqlDbType.VarChar, 50).Value = EnderecoEletronicoDataGridView.Item(0, v_SelectRow).Value

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Apagado com sucesso!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try
        End If

        Me.EnderecoEletronicoTableAdapter.Fill(Me.DataSetFinal.EnderecoEletronico)
        ' setar os campos
        TextBox347.Clear()
        TextBox349.Clear()
        RadioButton27.Enabled = False
        RadioButton28.Enabled = False
        RadioButton29.Enabled = False
        RadioButton30.Enabled = False
        RadioButton31.Enabled = False
        RadioButton32.Enabled = False
        ' desmarcando
        RadioButton27.Checked = False
        RadioButton28.Checked = False
        RadioButton29.Checked = False
        RadioButton30.Checked = False
        RadioButton31.Checked = False
        RadioButton32.Checked = False

    End Sub

    Private Sub Button120_Click(sender As Object, e As EventArgs) Handles Button120.Click
        If TextBox347.Text = "" Then
            MessageBox.Show("escolher um produto para mostrar")
            Exit Sub
        End If
        Process.Start(TextBox347.Text)

    End Sub



    Private Sub EnderecoEletronicoDataGridView_Click(sender As Object, e As EventArgs) Handles EnderecoEletronicoDataGridView.Click

        Dim v_SelectRow As Integer
        v_SelectRow = Me.EnderecoEletronicoDataGridView.CurrentRow.Index
        TextBox347.Text = EnderecoEletronicoDataGridView.Item(3, v_SelectRow).Value
        TextBox349.Text = EnderecoEletronicoDataGridView.Item(4, v_SelectRow).Value
        ' passando chek para os radiobox empresas
        If EnderecoEletronicoDataGridView.Item(1, v_SelectRow).Value = "Fernando" Then
            RadioButton27.Checked = True
        ElseIf EnderecoEletronicoDataGridView.Item(1, v_SelectRow).Value = "Silvia" Then
            RadioButton28.Checked = True
        End If
        ' passando chek para os radiobox meios vendedores
        If EnderecoEletronicoDataGridView.Item(2, v_SelectRow).Value = "Mlb" Then
            RadioButton29.Checked = True
        ElseIf EnderecoEletronicoDataGridView.Item(2, v_SelectRow).Value = "FULL" Then
            RadioButton30.Checked = True
        ElseIf EnderecoEletronicoDataGridView.Item(2, v_SelectRow).Value = "ZOOM" Then
            RadioButton31.Checked = True
        ElseIf EnderecoEletronicoDataGridView.Item(2, v_SelectRow).Value = "Site" Then
            RadioButton32.Checked = True
        End If
    End Sub

    Private Sub Label423_Click(sender As Object, e As EventArgs) Handles Label423.Click

    End Sub

    Private Sub ComboBox43_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox43.SelectedValueChanged
        EnderecoEletronicoBindingSource.Filter = String.Format("EmrpesaVendedora_EnderecoEletronico LIKE '{0}%'", ComboBox43.Text)
    End Sub

    Private Sub ComboBox44_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox44.SelectedValueChanged
        EnderecoEletronicoBindingSource.Filter = String.Format("MeioVendedor_EnderecoEletronico LIKE '{0}%'", ComboBox44.Text)
    End Sub

    Private Sub TextBox348_TextChanged(sender As Object, e As EventArgs) Handles TextBox348.TextChanged
        EnderecoEletronicoBindingSource.Filter = String.Format("NomeEnderecoEletronico LIKE '{0}%'", TextBox348.Text)
    End Sub

    Private Sub Button121_Click(sender As Object, e As EventArgs) Handles Button121.Click

        variavelImpressao = "1"
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}%' and Bugiganga_prod LIKE '{2}%'", ComboBox29.Text, "RAIZ", "bugiganga")
        Label94.Text = ProdutosDataGridView4.Rows.Count()

    End Sub

    Private Sub Button122_Click(sender As Object, e As EventArgs) Handles Button122.Click
        variavelImpressao = "2"
        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}%' and Bugiganga_prod LIKE '{2}%'", ComboBox30.Text, "RAIZ", "bugiganga")
        Label94.Text = ProdutosDataGridView4.Rows.Count()
    End Sub

    Private Sub Button114_Click(sender As Object, e As EventArgs) Handles Button114.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ***********************************************************************
        Dim sql11 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter11 As New SqlDataAdapter(sql11, connection)
        Dim ds11 As New DataSet()
        Try
            connection.Open()
            dataadapter11.Fill(ds11, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds11.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor11 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor11 += Linha.Cells(8).Value
        Next
        TextBox354.Text = valor11.ToString("f2")
        '************************************************************************
        ' CALCULANDO OS TOTAIS
        Dim sql10 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  linhaprod_balcao = '" & ComboBox4.Text & "'"
        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor10 += Linha.Cells(8).Value
        Next
        TextBox350.Text = valor10.ToString("f2")

        ' calculando o custo
        Dim valorCusto10 As Double
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valorCusto10 += Linha.Cells(11).Value
        Next
        TextBox351.Text = valorCusto10.ToString("f2")
        TextBox352.Text = TextBox350.Text - TextBox351.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem10 As Double = (1 - (valorCusto10 / valor10)) * 100
            TextBox353.Text = VrPorcentagem10.ToString("F2")
        Catch ex As Exception
        End Try
      
        ' ******************************************************************************
        Try
            Dim VrPorcentagem11 As Double = ((valor10 / valor11) * 100)
            TextBox355.Text = VrPorcentagem11.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************************
        ' CALCULANDO OS TOTAIS das linhas

        Dim sql20 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  linha_item = '" & ComboBox4.Text & "'"
        Dim dataadapter20 As New SqlDataAdapter(sql20, connection)
        Dim ds20 As New DataSet()
        Try
            connection.Open()
            dataadapter20.Fill(ds20, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds20.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor20 += Linha.Cells(10).Value
        Next
        TextBox356.Text = valor20.ToString("f2")

        ' calculando o custo
        Dim valorCusto20 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valorCusto20 += Linha.Cells(16).Value
        Next
        TextBox357.Text = valorCusto20.ToString("f2")
        TextBox358.Text = TextBox356.Text - TextBox357.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem20 As Double = (1 - (valorCusto20 / valor20)) * 100
            TextBox361.Text = VrPorcentagem20.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************
        Dim sql21 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter21 As New SqlDataAdapter(sql21, connection)
        Dim ds21 As New DataSet()
        Try
            connection.Open()
            dataadapter21.Fill(ds21, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds21.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor21 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor21 += Linha.Cells(10).Value
        Next
        TextBox359.Text = valor21.ToString("f2")
        ' *******************************************************
        Try
            Dim VrPorcentagem21 As Double = ((valor20 / valor21) * 100)
            TextBox360.Text = VrPorcentagem21.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************************
        ' *************************************************************************************
        ' **************************************************************************************
        ' calculando os totais
        TextBox362.Text = (valor10 + valor20).ToString("F2")
        TextBox363.Text = (valorCusto10 + valorCusto20).ToString("F2")
        TextBox364.Text = ((valor10 + valor20) - (valorCusto10 + valorCusto20)).ToString("F2")
        ' passando valor do taturamento total
        Dim FatTotal As Double = 0
        FatTotal = (valor11 + valor21).ToString("F2")
        TextBox365.Text = FatTotal
        ' calculando a porcentagem da linha ou fornecedor
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem30 As Double = ((1 - ((valorCusto10 + valorCusto20) / (valor10 + valor20))) * 100)

            TextBox367.Text = VrPorcentagem30.ToString("F2")
        Catch ex As Exception
        End Try
        ' calculando a porcentagem total
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem40 As Double = (((valor10 + valor20) / (valor11 + valor21)) * 100)

            TextBox366.Text = VrPorcentagem40.ToString("F2")
        Catch ex As Exception
        End Try


    End Sub

    Private Sub Button123_Click(sender As Object, e As EventArgs) Handles Button123.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ************************************************************************
        Dim sql11 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter11 As New SqlDataAdapter(sql11, connection)
        Dim ds11 As New DataSet()
        Try
            connection.Open()
            dataadapter11.Fill(ds11, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds11.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor11 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor11 += Linha.Cells(8).Value
        Next
        TextBox354.Text = valor11.ToString("f2")
        '*************************************************************************
        ' CALCULANDO OS TOTAIS
        Dim sql10 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  forprod_balcao = '" & ComboBox45.Text & "'"
        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor10 += Linha.Cells(8).Value
        Next
        TextBox350.Text = valor10.ToString("f2")

        ' calculando o custo
        Dim valorCusto10 As Double
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valorCusto10 += Linha.Cells(11).Value
        Next
        TextBox351.Text = valorCusto10.ToString("f2")
        TextBox352.Text = TextBox350.Text - TextBox351.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem10 As Double = (1 - (valorCusto10 / valor10)) * 100
            TextBox353.Text = VrPorcentagem10.ToString("F2")
        Catch ex As Exception
        End Try
       
        ' *******************************************************
        Try
            Dim VrPorcentagem11 As Double = ((valor10 / valor11) * 100)
            TextBox355.Text = VrPorcentagem11.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************************
        ' CALCULANDO OS TOTAIS das linhas

        Dim sql20 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  for_item = '" & ComboBox45.Text & "'"
        Dim dataadapter20 As New SqlDataAdapter(sql20, connection)
        Dim ds20 As New DataSet()
        Try
            connection.Open()
            dataadapter20.Fill(ds20, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds20.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor20 += Linha.Cells(10).Value
        Next
        TextBox356.Text = valor20.ToString("f2")

        ' calculando o custo
        Dim valorCusto20 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valorCusto20 += Linha.Cells(16).Value
        Next
        TextBox357.Text = valorCusto20.ToString("f2")
        TextBox358.Text = TextBox356.Text - TextBox357.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem20 As Double = (1 - (valorCusto20 / valor20)) * 100
            TextBox361.Text = VrPorcentagem20.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************
        Dim sql21 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter21 As New SqlDataAdapter(sql21, connection)
        Dim ds21 As New DataSet()
        Try
            connection.Open()
            dataadapter21.Fill(ds21, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds21.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor21 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor21 += Linha.Cells(10).Value
        Next
        TextBox359.Text = valor21.ToString("f2")
        ' *******************************************************
        Try
            Dim VrPorcentagem21 As Double = ((valor20 / valor21) * 100)
            TextBox360.Text = VrPorcentagem21.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************************
        ' *************************************************************************************
        ' **************************************************************************************
        ' calculando os totais
        TextBox362.Text = (valor10 + valor20).ToString("F2")
        TextBox363.Text = (valorCusto10 + valorCusto20).ToString("F2")
        TextBox364.Text = ((valor10 + valor20) - (valorCusto10 + valorCusto20)).ToString("F2")
        ' passando valor do taturamento total
        Dim FatTotal As Double = 0
        FatTotal = (valor11 + valor21).ToString("F2")
        TextBox365.Text = FatTotal
        ' calculando a porcentagem da linha ou fornecedor
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem30 As Double = ((1 - ((valorCusto10 + valorCusto20) / (valor10 + valor20))) * 100)

            TextBox367.Text = VrPorcentagem30.ToString("F2")
        Catch ex As Exception
        End Try
        ' calculando a porcentagem total
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem40 As Double = (((valor10 + valor20) / (valor11 + valor21)) * 100)

            TextBox366.Text = VrPorcentagem40.ToString("F2")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button124_Click(sender As Object, e As EventArgs) Handles Button124.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "SELECT * FROM PedidoCompra WHERE Data_PedidoCompra >= convert (datetime, '" & DateTimePicker38.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "PedidoCompra")
            connection.Close()
            PedidoCompraDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub PrintPreviewDialog8_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog8.Load
       
    End Sub

    Private Sub Button125_Click(sender As Object, e As EventArgs) Handles Button125.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
        ' **************************************************************************************
        ' copia da media balcão - arrumar
        ' calcula o estoque médio do balcão e grava na tabela de produtos
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' pega uma data de acordo com a última atualização
        Dim v_SelectRow As Integer = 0
        For v_SelectRow = 0 To ProdutosDataGridView3.RowCount() - 1
            Dim DataInicial As Date = ProdutosDataGridView3.Item(11, v_SelectRow).Value
            Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DataInicial & "' ,103)  and convert (datetime, '" & Date.Today & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView3.Item(3, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView3.Item(4, v_SelectRow).Value & "'"

            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
                dataadapter.Fill(ds, "balcao")
                connection.Close()
                BalcaoDataGridView5.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim quantidadeBalcao As Integer = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView5.Rows
                quantidadeBalcao += Linha.Cells(4).Value
            Next

            ' ***********************************************************
            Dim command As SqlCommand
            command = connection.CreateCommand()
            ' gravando o consumo medio no arquivo de produtos
            If ProdutosDataGridView3.Item(14, v_SelectRow).Value = "NÃO RAIZ" Then
                command.CommandText = "update produtos set DataEstoqueInicial_prod=@DataEstoqueInicial_prod,ConsumoDaDataIncial_prod=@ConsumoDaDataIncial_prod,DataAtualizacaoEstoque_prod=@DataAtualizacaoEstoque_prod,EstoqueInicial_prod=@EstoqueInicial_prod,estoqueatual_prod=@estoqueatual_prod where cod_prod=@cod_prod "
                command.CommandType = CommandType.Text
                command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
                command.Parameters.Add("@EstoqueInicial_prod", SqlDbType.Float).Value = 0
                command.Parameters.Add("@DataEstoqueInicial_prod", SqlDbType.Date).Value = Date.Now
                command.Parameters.Add("@ConsumoDaDataIncial_prod", SqlDbType.Float).Value = 0
                command.Parameters.Add("@DataAtualizacaoEstoque_prod", SqlDbType.Date).Value = Date.Now
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = 0
            Else
                command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod,ConsumoDaDataIncial_prod=@ConsumoDaDataIncial_prod,DataAtualizacaoEstoque_prod=@DataAtualizacaoEstoque_prod  where cod_prod=@cod_prod "
                command.CommandType = CommandType.Text
                command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = ProdutosDataGridView3.Item(0, v_SelectRow).Value.ToString()
                command.Parameters.Add("@ConsumoDaDataIncial_prod", SqlDbType.Float).Value = quantidadeBalcao
                command.Parameters.Add("@DataAtualizacaoEstoque_prod", SqlDbType.Date).Value = Date.Now
                Dim CalculoEstoqueAtual As Integer = ProdutosDataGridView3.Item(10, v_SelectRow).Value - quantidadeBalcao
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = CalculoEstoqueAtual


            End If

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        Next

        Me.ProdutosTableAdapter.Fill(Me.DataSetFinal.produtos)


    End Sub

    Private Sub Button126_Click(sender As Object, e As EventArgs) Handles Button126.Click
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        Else
            TextBox368.Enabled = True
            TextBox368.Focus()
        End If

    End Sub

    Private Sub TextBox368_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox368.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            ' e.Handled = True
            Dim connection As SqlConnection
            connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

            Dim reply As DialogResult = MessageBox.Show("Confirmar a inclusão/alteração?", "Atenção!!!", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            'REM se confirmar a alteração ele grava
            If reply = DialogResult.Yes Then

                Dim command As SqlCommand
                command = connection.CreateCommand()
                command.CommandText = "update produtos set estoqueatual_prod=@estoqueatual_prod,EstoqueInicial_prod=@EstoqueInicial_prod,DataEstoqueInicial_prod=@DataEstoqueInicial_prod,ConsumoDaDataIncial_prod=@ConsumoDaDataIncial_prod,DataAtualizacaoEstoque_prod=@DataAtualizacaoEstoque_prod  where cod_prod=@cod_prod "
                command.CommandType = CommandType.Text

                command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = Cod_prodTextBox.Text
                command.Parameters.Add("@EstoqueInicial_prod", SqlDbType.Float).Value = TextBox368.Text
                command.Parameters.Add("@DataEstoqueInicial_prod", SqlDbType.Date).Value = Date.Now.AddDays(1)
                command.Parameters.Add("@ConsumoDaDataIncial_prod", SqlDbType.Float).Value = 0
                command.Parameters.Add("@DataAtualizacaoEstoque_prod", SqlDbType.Date).Value = Date.Now
                command.Parameters.Add("@estoqueatual_prod", SqlDbType.Float).Value = TextBox368.Text

                ' a seguir comandos para gravar os ítens coletados do formulário ------------------
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                Finally
                    connection.Close()
                End Try
                TextBox368.Enabled = False
                Me.ProdutosTableAdapter1.Fill(Me.DataSetFinal.produtos)
            End If
        End If

    End Sub


    Private Sub TextBox370_TextChanged(sender As Object, e As EventArgs) Handles TextBox370.TextChanged
        PedidoCompraDataGridView.DataSource = PedidoCompraBindingSource
        PedidoCompraBindingSource.Filter = String.Format("NumeroNota_PedidoCompra LIKE '{0}%'", TextBox370.Text)
    End Sub

    Private Sub RadioButton12_Click(sender As Object, e As EventArgs) Handles RadioButton12.Click
        Dim v_SelectRow As Integer
        v_SelectRow = Me.PedidoCompraDataGridView.CurrentRow.Index
        If PedidoCompraDataGridView.Item(13, v_SelectRow).Value = "Não Entregue" Then
            NumeroNotaPedidoCompra = "0"
            NumeroNotaPedidoCompra = InputBox("Dê o número da nota")
        End If

    End Sub

    Private Sub TextBox371_TextChanged(sender As Object, e As EventArgs) Handles TextBox371.TextChanged
        ProdutosBindingSource.Filter = String.Format("cod_prodfor LIKE '{0}%'", TextBox371.Text)
    End Sub

    Private Sub ComboBox48_Click(sender As Object, e As EventArgs) Handles ComboBox48.Click

        ProdutosBindingSource1.Filter = String.Format("fornecedor_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}'", ComboBox48.Text, "RAIZ")

        Dim custo_prod1 As String = ""
        Dim ipi_prod1 As String = ""
        Dim estoqueatual_prod1 As String = ""
        Dim ValorEstoqueAtual1 As Double = 0
        Dim ValorEstoqueAtual2 As Double = 0


        For x As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            If dataGridPediMarf.Item(11, x).Value.ToString() < 0 Then
            Else
                custo_prod1 = dataGridPediMarf.Item(14, x).Value.ToString()
                ipi_prod1 = dataGridPediMarf.Item(15, x).Value.ToString()
                estoqueatual_prod1 = dataGridPediMarf.Item(11, x).Value.ToString()
                ValorEstoqueAtual1 = (custo_prod1 * (1 + (ipi_prod1 / 100))) * estoqueatual_prod1
                ValorEstoqueAtual2 += ValorEstoqueAtual1
            End If
        Next
        TextBox309.Text = (ValorEstoqueAtual2 / 0.65).ToString("F2")
        TextBox217.Text = ValorEstoqueAtual2
    End Sub

    Private Sub ComboBox49_Click(sender As Object, e As EventArgs) Handles ComboBox49.Click
        ProdutosBindingSource1.Filter = String.Format("linha_prod LIKE '{0}%' and RaizSimNao_prod LIKE '{1}'", ComboBox49.Text, "RAIZ")

        Dim custo_prod1 As String = ""
        Dim ipi_prod1 As String = ""
        Dim estoqueatual_prod1 As String = ""
        Dim ValorEstoqueAtual1 As Double = 0
        Dim ValorEstoqueAtual2 As Double = 0


        For x As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            If dataGridPediMarf.Item(11, x).Value.ToString() < 0 Then
            Else
                custo_prod1 = dataGridPediMarf.Item(14, x).Value.ToString()
                ipi_prod1 = dataGridPediMarf.Item(15, x).Value.ToString()
                estoqueatual_prod1 = dataGridPediMarf.Item(11, x).Value.ToString()
                ValorEstoqueAtual1 = (custo_prod1 * (1 + (ipi_prod1 / 100))) * estoqueatual_prod1
                ValorEstoqueAtual2 += ValorEstoqueAtual1
            End If
        Next
        TextBox309.Text = (ValorEstoqueAtual2 / 0.65).ToString("F2")
        TextBox217.Text = ValorEstoqueAtual2
    End Sub

    Private Sub Button128_Click(sender As Object, e As EventArgs) Handles Button128.Click

        ProdutosBindingSource1.Filter = String.Format("RaizSimNao_prod LIKE '{0}'", "RAIZ")
        For x As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            If dataGridPediMarf.Item(11, x).Value < 0 Then
                dataGridPediMarf.Rows(x).Cells(6).Style.ForeColor = Color.Red
            End If
        Next


    End Sub

    Private Sub Button130_Click(sender As Object, e As EventArgs) Handles Button130.Click
        Process.Start("http://www.sintegra.gov.br/")
    End Sub

    Private Sub Telefone_clienteLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button129_Click(sender As Object, e As EventArgs) Handles Button129.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        If ComboBox52.Text = "" Then
            MessageBox.Show("Escolher o intervalo de dias de pesquisa abaixo")
            Exit Sub
        End If
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ------------------------------------------------------------------------------------------------------------------
        Dim DataSelecionada As Integer = ComboBox52.Text
        Dim DataSelecionada2 As Integer = DataSelecionada * -1
        For v_SelectRow As Integer = 0 To dataGridPediMarf.Rows.Count() - 1
            Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & Date.Now.AddDays(DataSelecionada2) & "' ,103)  and convert (datetime, '" & Date.Now & "' ,103) and nomeProd_balcao = '" & dataGridPediMarf.Item(6, v_SelectRow).Value & "' and corprod_balcao = '" & dataGridPediMarf.Item(7, v_SelectRow).Value & "'"
            Dim dataadapter As New SqlDataAdapter(sql2, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
                dataadapter.Fill(ds, "balcao")
                connection.Close()
                BalcaoDataGridView10.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'somar quantidade da coluna da tabela balcão
            Dim quantidadeBalcao As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView10.Rows
                quantidadeBalcao += Linha.Cells(7).Value
            Next

            ' Pesquisando dados na tabela de pedidos
            Dim sql3 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN   convert (datetime, '" & Date.Now.AddDays(DataSelecionada2) & "' ,103)  and convert (datetime, '" & Date.Now & "' ,103) and nome_item = '" & dataGridPediMarf.Item(6, v_SelectRow).Value & "' and cor_item = '" & dataGridPediMarf.Item(7, v_SelectRow).Value & "'"
            Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
            Dim ds3 As New DataSet()
            Try
                connection.Open()
                dataadapter3.Fill(ds3, "ItemPedidos")
                connection.Close()
                ItemPedidosDataGridView12.DataSource = ds3.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'somar quantidade da coluna da tabela balcão
            Dim quantidadePedidos As Decimal = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView12.Rows
                quantidadePedidos += Linha.Cells(8).Value
            Next

            Dim TotalVendas As Double = quantidadeBalcao + quantidadePedidos
            If TotalVendas <= 0 Then
                dataGridPediMarf.Rows(v_SelectRow).Cells(6).Style.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub PrintDocument15_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument15.PrintPage
        ' primeira linha
        e.Graphics.DrawString(DateTimePicker37.Text, New Font("arial", 15, FontStyle.Regular), Brushes.Black, 20, 5)
        e.Graphics.DrawString("Sugestão de compra   ", New Font("arial", 12, FontStyle.Bold), Brushes.Black, 200, 5)
        e.Graphics.DrawString(ProdutosDataGridView5.Item(4, 0).Value, New Font("arial", 12, FontStyle.Bold), Brushes.Black, 550, 5)

        ' cabecalho
        e.Graphics.DrawString("Código Fornecedor", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 50)
        e.Graphics.DrawString("Nome do Produto", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 50)
        e.Graphics.DrawString("Cor  ", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 450, 50)
        e.Graphics.DrawString("Estoque Méd", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, 50)
        e.Graphics.DrawString("Consumo Máx", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 650, 50)
        e.Graphics.DrawString("Sugestão", New Font("arial", 10, FontStyle.Regular), Brushes.Black, 740, 50)

        Dim CalculoSugestao As Double = 0
        Dim l As Integer = 0
        Dim ContadorX As Integer = 0
        Integer.TryParse(TextBox376.Text, ContadorX)

        Try
            For x = ContadorX To ProdutosDataGridView5.RowCount() - 1
                CalculoSugestao = ProdutosDataGridView5.Item(8, x).Value - ProdutosDataGridView5.Item(14, x).Value + ProdutosDataGridView5.Item(15, x).Value
                If ProdutosDataGridView5.Item(8, x).Value > (ProdutosDataGridView5.Item(9, x).Value + ProdutosDataGridView5.Item(14, x).Value - ProdutosDataGridView5.Item(15, x).Value) And CalculoSugestao > 0 Then
                    l += 1
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(2, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 20, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(6, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 200, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(7, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 450, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(8, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 550, 100 + (l * 20))
                    e.Graphics.DrawString(ProdutosDataGridView5.Item(12, x).Value, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 650, 100 + (l * 20))
                    e.Graphics.DrawString(CalculoSugestao, New Font("arial", 10, FontStyle.Regular), Brushes.Black, 740, 100 + (l * 20))
                End If

            Next

        Catch ex As Exception
            Exit Sub
        End Try
      
    End Sub

  

    Private Sub ProdutosDataGridView5_DoubleClick(sender As Object, e As EventArgs) Handles ProdutosDataGridView5.DoubleClick
        Dim v_SelectRow As Integer
        v_SelectRow = Me.ProdutosDataGridView5.CurrentRow.Index
        TextBox374.Text = ProdutosDataGridView5.Item(6, v_SelectRow).Value
        'calculo do mínimo de compra
        If ProdutosDataGridView5.Item(8, v_SelectRow).Value > (ProdutosDataGridView5.Item(9, v_SelectRow).Value + ProdutosDataGridView5.Item(14, v_SelectRow).Value - ProdutosDataGridView5.Item(15, v_SelectRow).Value) Then
            TextBox375.Text = ProdutosDataGridView5.Item(11, v_SelectRow).Value - ProdutosDataGridView5.Item(14, v_SelectRow).Value + ProdutosDataGridView5.Item(15, v_SelectRow).Value
        Else
            TextBox375.Text = 0
        End If

    End Sub

    Private Sub PrintPreviewDialog9_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog9.Load
        PrintPreviewDialog9.Document = PrintDocument15
        DirectCast(PrintPreviewDialog9, Form).WindowState = FormWindowState.Maximized
        PrintDialog1.Document = PrintDocument15
        PrintDialog1.PrinterSettings.PrinterName = "\\\\SERVIDOR\EPSON L355 Series (Caixa)"
        CType(PrintPreviewDialog9.Controls(1), ToolStrip).Items.Add(PDB)
    End Sub

    Private Sub Button131_Click(sender As Object, e As EventArgs) Handles Button131.Click
        PrintPreviewDialog9.ShowDialog()
    End Sub

    Private Sub Button132_Click(sender As Object, e As EventArgs) Handles Button132.Click
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "SELECT * FROM PedidoCompra WHERE Data_PedidoCompra > convert (datetime, '" & DateTimePicker38.Text & "' ,103) and Fornecedor_PedidoCompra ='" & ComboBox26.Text & "'"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "PedidoCompra")
            connection.Close()
            PedidoCompraDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button133_Click(sender As Object, e As EventArgs) Handles Button133.Click


        ' posiciona as tabelas entre as datas escolhidas na tela
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        Dim sql2 As String = "SELECT * FROM VendasMlb WHERE DataPedido_VendasMlb BETWEEN   convert (datetime, '" & DateTimePicker39.Text & "' ,103)  and convert (datetime, '" & DateTimePicker40.Text & "' ,103)"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "VendasMlb")
            connection.Close()
            VendasMlbDataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' soma o valor da tabela se tiver um F no código
        Dim SomaTotal As Double = 0
        For x = 0 To VendasMlbDataGridView.RowCount() - 1
            Dim SearchWithinThis As String = VendasMlbDataGridView.Item(1, x).Value
            Dim SearchForThis As String = "F"
            Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(SearchForThis)
            If FirstCharacter = "0" Then
                SomaTotal += VendasMlbDataGridView.Item(16, x).Value
            End If
        Next
        TextBox283.Text = SomaTotal

    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click

        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        'rem passa dados para a planilha excell de pedidos   -------
        Dim xlApp1 As Excel.Application
        Dim xlWorkBook1 As Excel.Workbook
        Dim xlWorkSheet1 As Excel.Worksheet


        xlApp1 = New Excel.Application
        xlWorkBook1 = xlApp1.Workbooks.Open("\\C:\Users\Usuario\Desktop\Planilha Produtos Tiny.xls")
        xlWorkSheet1 = CType(xlWorkBook1.Sheets(1), Excel.Worksheet)

        'Dim xx As Integer
        For xx = 0 To ProdutosDataGridView8.RowCount() - 1
            xlWorkSheet1.Cells(3 + xx, 1) = xx + 1
            xlWorkSheet1.Cells(3 + xx, 2) = ProdutosDataGridView8.Item(1, xx).Value
            xlWorkSheet1.Cells(3 + xx, 3) = ProdutosDataGridView8.Item(2, xx).Value
            xlWorkSheet1.Cells(3 + xx, 4) = "1"
            xlWorkSheet1.Cells(3 + xx, 5) = ProdutosDataGridView8.Item(3, xx).Value
            xlWorkSheet1.Cells(3 + xx, 6) = "0 - Nacional"
            xlWorkSheet1.Cells(3 + xx, 7) = ProdutosDataGridView8.Item(4, xx).Value
            xlWorkSheet1.Cells(3 + xx, 8) = 0
            xlWorkSheet1.Cells(3 + xx, 9) = ""
            xlWorkSheet1.Cells(3 + xx, 10) = "Ativo"
            xlWorkSheet1.Cells(3 + xx, 11) = 0
            xlWorkSheet1.Cells(3 + xx, 12) = 0
            xlWorkSheet1.Cells(3 + xx, 13) = ProdutosDataGridView8.Item(5, xx).Value
            xlWorkSheet1.Cells(3 + xx, 14) = ProdutosDataGridView8.Item(6, xx).Value
            xlWorkSheet1.Cells(3 + xx, 15) = ""
            xlWorkSheet1.Cells(3 + xx, 16) = 0
            xlWorkSheet1.Cells(3 + xx, 17) = 0
            xlWorkSheet1.Cells(3 + xx, 18) = ProdutosDataGridView8.Item(7, xx).Value
            xlWorkSheet1.Cells(3 + xx, 19) = ProdutosDataGridView8.Item(7, xx).Value
            xlWorkSheet1.Cells(3 + xx, 20) = ""
            xlWorkSheet1.Cells(3 + xx, 21) = ""
            xlWorkSheet1.Cells(3 + xx, 22) = ""
            xlWorkSheet1.Cells(3 + xx, 23) = ""
            xlWorkSheet1.Cells(3 + xx, 24) = ""
            xlWorkSheet1.Cells(3 + xx, 25) = ""
            xlWorkSheet1.Cells(3 + xx, 26) = 0
            xlWorkSheet1.Cells(3 + xx, 27) = 0
            xlWorkSheet1.Cells(3 + xx, 28) = 0
            xlWorkSheet1.Cells(3 + xx, 29) = 0
            xlWorkSheet1.Cells(3 + xx, 30) = ""
            xlWorkSheet1.Cells(3 + xx, 31) = ""
            xlWorkSheet1.Cells(3 + xx, 32) = ""
            xlWorkSheet1.Cells(3 + xx, 33) = ""
            xlWorkSheet1.Cells(3 + xx, 34) = ""
            xlWorkSheet1.Cells(3 + xx, 35) = ""
            xlWorkSheet1.Cells(3 + xx, 36) = ""
            xlWorkSheet1.Cells(3 + xx, 37) = ""
            xlWorkSheet1.Cells(3 + xx, 38) = ""
            xlWorkSheet1.Cells(3 + xx, 39) = ""
            xlWorkSheet1.Cells(3 + xx, 40) = ""
            xlWorkSheet1.Cells(3 + xx, 41) = ""
            xlWorkSheet1.Cells(3 + xx, 42) = "Não"
            xlWorkSheet1.Cells(3 + xx, 43) = 0

        Next

        Try
            xlWorkBook1.SaveAs(Filename:="\\C:\Users\Usuario\Desktop\Planilha Produtos Tiny2.xls")
            xlWorkBook1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            xlWorkBook1.Close()
        End Try


    End Sub

    Private Sub Button101_Click(sender As Object, e As EventArgs) Handles Button101.Click
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If

        'rem passa dados para a planilha excell de pedidos   -------
        Dim xlApp1 As Excel.Application
        Dim xlWorkBook1 As Excel.Workbook
        Dim xlWorkSheet1 As Excel.Worksheet


        xlApp1 = New Excel.Application
        xlWorkBook1 = xlApp1.Workbooks.Open("\\C:\Users\Usuario\Desktop\Planilha Tiny Cadastro.xls")
        xlWorkSheet1 = CType(xlWorkBook1.Sheets(1), Excel.Worksheet)

        'Dim xx As Integer
        For xx = 0 To TransportadorasDataGridView2.RowCount() - 1
            xlWorkSheet1.Cells(2 + xx, 1) = xx + 1
            ' xlWorkSheet1.Cells(2 + xx, 2) = ClienteDataGridView.Item(1, xx).Value
            xlWorkSheet1.Cells(2 + xx, 3) = TransportadorasDataGridView2.Item(0, xx).Value
            'xlWorkSheet1.Cells(2 + xx, 4) = ClienteDataGridView.Item(0, xx).Value
            xlWorkSheet1.Cells(2 + xx, 5) = TransportadorasDataGridView2.Item(1, xx).Value
            xlWorkSheet1.Cells(2 + xx, 6) = TransportadorasDataGridView2.Item(2, xx).Value
            xlWorkSheet1.Cells(2 + xx, 7) = ""
            xlWorkSheet1.Cells(2 + xx, 8) = TransportadorasDataGridView2.Item(3, xx).Value
            xlWorkSheet1.Cells(2 + xx, 9) = TransportadorasDataGridView2.Item(4, xx).Value
            xlWorkSheet1.Cells(2 + xx, 10) = TransportadorasDataGridView2.Item(5, xx).Value
            xlWorkSheet1.Cells(2 + xx, 11) = TransportadorasDataGridView2.Item(6, xx).Value
            xlWorkSheet1.Cells(2 + xx, 12) = TransportadorasDataGridView2.Item(7, xx).Value
            xlWorkSheet1.Cells(2 + xx, 13) = TransportadorasDataGridView2.Item(8, xx).Value
            'xlWorkSheet1.Cells(2 + xx, 14) = ClienteDataGridView.Item(6, xx).Value
            xlWorkSheet1.Cells(2 + xx, 15) = ""
            xlWorkSheet1.Cells(2 + xx, 16) = TransportadorasDataGridView2.Item(9, xx).Value
            xlWorkSheet1.Cells(2 + xx, 17) = ""
            xlWorkSheet1.Cells(2 + xx, 18) = TransportadorasDataGridView2.Item(10, xx).Value
            xlWorkSheet1.Cells(2 + xx, 19) = TransportadorasDataGridView2.Item(11, xx).Value
            xlWorkSheet1.Cells(2 + xx, 20) = TransportadorasDataGridView2.Item(12, xx).Value
            xlWorkSheet1.Cells(2 + xx, 21) = ""
            xlWorkSheet1.Cells(2 + xx, 22) = "Ativo"
            xlWorkSheet1.Cells(2 + xx, 23) = ""
            xlWorkSheet1.Cells(2 + xx, 24) = ""
            xlWorkSheet1.Cells(2 + xx, 25) = ""
            xlWorkSheet1.Cells(2 + xx, 26) = ""
            xlWorkSheet1.Cells(2 + xx, 27) = ""
            xlWorkSheet1.Cells(2 + xx, 28) = ""
            xlWorkSheet1.Cells(2 + xx, 29) = ""
            xlWorkSheet1.Cells(2 + xx, 30) = ""
            xlWorkSheet1.Cells(2 + xx, 31) = ""
            xlWorkSheet1.Cells(2 + xx, 32) = ""
            xlWorkSheet1.Cells(2 + xx, 33) = ""
            xlWorkSheet1.Cells(2 + xx, 34) = ""
            xlWorkSheet1.Cells(2 + xx, 35) = ""
            xlWorkSheet1.Cells(2 + xx, 36) = "Transportadora"
        Next

        Try
            xlWorkBook1.SaveAs(Filename:="\\C:\Users\Usuario\Desktop\Planilha Tiny Cadastro2.xls")
            xlWorkBook1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            xlWorkBook1.Close()
        End Try

    End Sub

    Private Sub ComboBox47_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox47.SelectedIndexChanged

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ' Coloca a data na hora de inserir para obrigar o cadastro na data certa
        Dim ano As Integer = Today.Year
        Dim mes As Integer = InputBox("Escolha o mes de 1 a 12")
        If mes < 1 Or mes > 12 Then
            MessageBox.Show("ele aceita somente valores entre 1 e 12")
            Exit Sub
        End If

        Select Case mes
            Case 1
                Label71.Text = "Janeiro"
            Case 2
                Label71.Text = "Fevereiro"
            Case 3
                Label71.Text = "Março"
            Case 4
                Label71.Text = "Abril"
            Case 5
                Label71.Text = "Maio"
            Case 6
                Label71.Text = "Junho"
            Case 7
                Label71.Text = "Julho"
            Case 8
                Label71.Text = "Agosto"
            Case 9
                Label71.Text = "Setembro"
            Case 10
                Label71.Text = "Outubro"
            Case 11
                Label71.Text = "Novembro"
            Case 12
                Label71.Text = "Dezembro"
        End Select
        DateTimePicker35.Value = New DateTime(ano, mes, 1)
    End Sub

    Private Sub TabControl4_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl4.MouseClick

        If TabControl4.SelectedTab.ToString = "TabPage: {Despesas}" Then
            DateTimePicker35.Value = "01/01/2000"
            Label71.Text = "Sem Escolha"
        End If
    End Sub

  
   
    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        RadioButton8.Enabled = False
        RadioButton10.Enabled = False
        RadioButton23.Enabled = False
        

    End Sub

    

    Private Sub Button102_Click(sender As Object, e As EventArgs) Handles Button102.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA dinheiro
        Dim sql As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Dinheiro'"

        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor += Linha.Cells(12).Value
        Next
        TextBox154.Text = valor.ToString("F2")
    End Sub

    Private Sub Button103_Click(sender As Object, e As EventArgs) Handles Button103.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA cartão
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Cartão'"

        Dim dataadapter2 As New SqlDataAdapter(sql2, connection)
        Dim ds2 As New DataSet()
        Try
            connection.Open()
            dataadapter2.Fill(ds2, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor2 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor2 += Linha.Cells(12).Value
        Next
        TextBox155.Text = valor2.ToString("F2")
    End Sub

    Private Sub Button104_Click(sender As Object, e As EventArgs) Handles Button104.Click
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA boleto
        Dim sql3 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Boleto'"

        Dim dataadapter3 As New SqlDataAdapter(sql3, connection)
        Dim ds3 As New DataSet()
        Try
            connection.Open()
            dataadapter3.Fill(ds3, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds3.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor3 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor3 += Linha.Cells(9).Value
        Next
        TextBox156.Text = valor3.ToString("F2")
    End Sub

    Private Sub Button105_Click(sender As Object, e As EventArgs) Handles Button105.Click
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' CALCULANDO AS VENDAS DA outros
        Dim sql4 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao =  convert (datetime, '" & DateTimePicker31.Text & "' ,103) and  FormaPgto_balcao = 'Outros'"

        Dim dataadapter4 As New SqlDataAdapter(sql4, connection)
        Dim ds4 As New DataSet()
        Try
            connection.Open()
            dataadapter4.Fill(ds4, "balcao")
            connection.Close()
            BalcaoDataGridView3.DataSource = ds4.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' soma a coluna dos valores e o põe no campo certo
        Dim valor4 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView3.Rows
            valor4 += Linha.Cells(9).Value
        Next
        TextBox157.Text = valor4.ToString("F2")

    End Sub

    Private Sub Button106_Click_1(sender As Object, e As EventArgs) Handles Button106.Click

        ' Pega autorização para correr o botão
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
        ' ----------------------------------------------------------------------------------
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' **********************************************************************************************
        Dim v_SelectRow As Integer = 0
        Dim VendaPeriodo As Double = 0
        Dim CustoPeriodo As Integer = 0
        Dim TotalLucro As Double = 0

        For v_SelectRow = 0 To ProdutosDataGridView9.RowCount() - 1

            '    Dim sql As String = "SELECT * FROM balcao WHERE  (nomevendedor_balcao ='celso' or  nomevendedor_balcao ='verônica')"
            Dim sql As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView9.Item(6, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView9.Item(7, v_SelectRow).Value & "' and (nomevendedor_balcao = 'verônica' or  nomevendedor_balcao = 'celso')"
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            Try
                connection.Open()
                dataadapter.Fill(ds, "balcao")
                connection.Close()
                BalcaoDataGridView11.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' ****************************************************
            ' calculando soma
            'somar Faturamento da coluna da tabela balcão
            Dim FaturamentoBalcao As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                FaturamentoBalcao += Linha.Cells(12).Value
            Next
            ' -----------------------------------
            'somar Faturamento da coluna da tabela balcão
            Dim CustoBalcao As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                CustoBalcao += Linha.Cells(17).Value
            Next
            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim QuantidadeBalcao As Double = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                QuantidadeBalcao += Linha.Cells(7).Value
            Next
            VendaPeriodo = FaturamentoBalcao
            CustoPeriodo = CustoBalcao
            TotalLucro = VendaPeriodo - CustoPeriodo

            ' ***********************************************************

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.Parameters.Clear()
            command.CommandText = "INSERT INTO VendasBalcaoResultado (Quantidade_VendasBalcaoResultado,Lucro_VendasBalcaoResultado,Custo_VendasBalcaoResultado,Faturamento_VendasBalcaoResultado,Produto_VendasBalcaoResultado,Cor_VendasBalcaoResultado,Linha_VendasBalcaoResultado,Fornecedor_VendasBalcaoResultado,codprod_VendasBalcaoResultado) Values (@Quantidade_VendasBalcaoResultado,@Lucro_VendasBalcaoResultado,@Custo_VendasBalcaoResultado,@Faturamento_VendasBalcaoResultado,@Produto_VendasBalcaoResultado,@Cor_VendasBalcaoResultado,@Linha_VendasBalcaoResultado,@Fornecedor_VendasBalcaoResultado,@codprod_VendasBalcaoResultado)"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@codprod_VendasBalcaoResultado", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(2, v_SelectRow).Value
            command.Parameters.Add("@Fornecedor_VendasBalcaoResultado", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(4, v_SelectRow).Value
            command.Parameters.Add("@Linha_VendasBalcaoResultado", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(5, v_SelectRow).Value
            command.Parameters.Add("@Cor_VendasBalcaoResultado", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(7, v_SelectRow).Value
            command.Parameters.Add("@Produto_VendasBalcaoResultado", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(6, v_SelectRow).Value
            command.Parameters.Add("@Faturamento_VendasBalcaoResultado", SqlDbType.Float).Value = VendaPeriodo
            command.Parameters.Add("@Custo_VendasBalcaoResultado", SqlDbType.Float).Value = CustoPeriodo
            command.Parameters.Add("@Lucro_VendasBalcaoResultado", SqlDbType.Float).Value = TotalLucro
            command.Parameters.Add("@Quantidade_VendasBalcaoResultado", SqlDbType.Float).Value = QuantidadeBalcao
     
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        Next

        Me.VendasBalcaoResultadoTableAdapter.Fill(Me.DataSetFinal.VendasBalcaoResultado)

    End Sub
    Private Sub Button107_Click_1(sender As Object, e As EventArgs) Handles Button107.Click
        ProdutosBindingSource.Filter = String.Format("fornecedor_prod LIKE '{0}%'", ComboBox17.Text)
    End Sub

    Private Sub Button111_Click(sender As Object, e As EventArgs) Handles Button111.Click
        PedidoCompraDataGridView.DataSource = PedidoCompraBindingSource
        PedidoCompraBindingSource.Filter = String.Format("EntregueSimNao_PedidoCompra LIKE '{0}%'", "não entregue")

    End Sub

    Private Sub Button135_Click(sender As Object, e As EventArgs) Handles Button135.Click
        ProdutosBindingSource.Filter = String.Format("linha_prod LIKE '{0}%' and fornecedor_prod LIKE '{1}'", ComboBox39.Text, ComboBox38.Text)

    End Sub

    Private Sub ProdutosDataGridView9_DoubleClick(sender As Object, e As EventArgs) Handles ProdutosDataGridView9.DoubleClick

        Dim v_SelectRow As Integer = 0
        v_SelectRow = Me.ProdutosDataGridView9.CurrentRow.Index

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView9.Item(6, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView9.Item(7, v_SelectRow).Value & "' and (nomevendedor_balcao = 'verônica' or  nomevendedor_balcao = 'celso')"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView11.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' --------------------------------------------------------
        Dim DiferencaData As Single = DateDiff("d", DateTimePicker41.Text, DateTimePicker42.Text)
        Label74.Text = DiferencaData
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim FaturamentoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
            FaturamentoBalcao += Linha.Cells(12).Value
        Next
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim CustoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
            CustoBalcao += Linha.Cells(17).Value
        Next
        ' ***************************************************************************
        ' ***************************************************************************
        Dim sql5 As String = "SELECT * FROM itemPedidos WHERE dataentrega_item BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and  codprod_item = '" & ProdutosDataGridView9.Item(1, v_SelectRow).Value & "' and (vendedor_item = 'verônica' or  vendedor_item = 'celso')"
        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView10.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

         ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim FaturamentoPedidos As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
            FaturamentoPedidos += Linha.Cells(10).Value
        Next
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim CustoPedidos As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
            CustoPedidos += Linha.Cells(16).Value
        Next
        TextBox297.Text = FaturamentoBalcao - CustoBalcao
        TextBox299.Text = FaturamentoPedidos - CustoPedidos
        TextBox300.Text = (FaturamentoPedidos + FaturamentoBalcao) - (CustoPedidos + CustoBalcao)
    End Sub

    Private Sub TabControlPedMarf_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControlPedMarf.MouseClick

        If TabControlPedMarf.SelectedTab.ToString = "TabPage: {Resultado balcão indiv}" Then
            DateTimePicker41.Text = "25/10/2017"
        End If

    End Sub

    Private Sub Button136_Click(sender As Object, e As EventArgs) Handles Button136.Click

        'Fotografias.StartPosition = FormStartPosition.CenterScreen
        ' abre a pasta onde está as fotos
        OpenFileDialog1.Title = "Localizar Fotos"
        Me.StartPosition = FormStartPosition.CenterScreen
        OpenFileDialog1.InitialDirectory = "C:\Users\Usuario\Desktop\Produto\*.*"
        OpenFileDialog1.ShowDialog()
        TextBox302.Text = OpenFileDialog1.FileName
        '*****************************************************
        MessageBox.Show(TextBox302.Text)
        If TextBox302.Text = "OpenFileDialog1" Then
            TextBox302.Text = ""
        End If

    End Sub

    Private Sub Button137_Click(sender As Object, e As EventArgs) Handles Button137.Click
        ' Verifica se textbox302 está vazia
        If TextBox302.Text = "" Then
            MessageBox.Show("Escolher uma foto para poder abrir")
            Exit Sub
        End If
        '*****************************************************
        Fotografias.StartPosition = FormStartPosition.CenterScreen
        Fotografias.PictureBox1.Image = Image.FromFile(TextBox302.Text)
        Fotografias.Show()

    End Sub

   
    Private Sub Button138_Click(sender As Object, e As EventArgs) Handles Button138.Click

        ' Verifica se textbox302 está vazia
        If TextBox302.Text = "" Then
            MessageBox.Show("Escolher uma foto para poder salvar")
            Exit Sub
        End If
       

        ' *******************************************
        ' faz a conexão com o banco de dados sql

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        Dim reply As DialogResult = MessageBox.Show("Confirmar a inclusão/alteração?", "Atenção!!!", _
         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        'REM se confirmar a alteração ele grava
        If reply = DialogResult.Yes Then

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.CommandText = "update produtos set EnderecoFoto2_prod=@EnderecoFoto2_prod  where cod_prod=@cod_prod "
            command.CommandType = CommandType.Text

            command.Parameters.Add("@cod_prod", SqlDbType.VarChar, 50).Value = Cod_prodTextBox.Text
            command.Parameters.Add("@EnderecoFoto2_prod", SqlDbType.VarChar, 100).Value = TextBox302.Text

            ' a seguir comandos para gravar os ítens coletados do formulário ------------------
            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

            Me.ProdutosTableAdapter1.Fill(Me.DataSetFinal.produtos)

        End If

    End Sub

    Private Sub Button134_Click(sender As Object, e As EventArgs) Handles Button134.Click

        Dim v_SelectRow As Integer = 0
        v_SelectRow = Me.ProdutosDataGridView9.CurrentRow.Index

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' ------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView9.Item(6, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView9.Item(7, v_SelectRow).Value & "' and (nomevendedor_balcao = 'verônica' or  nomevendedor_balcao = 'celso')"
        Dim dataadapter As New SqlDataAdapter(sql2, connection)
        Dim ds As New DataSet()
        Try
            connection.Open()
            dataadapter.Fill(ds, "balcao")
            connection.Close()
            BalcaoDataGridView11.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' --------------------------------------------------------
        Dim DiferencaData As Single = DateDiff("d", DateTimePicker41.Text, DateTimePicker42.Text)
        Label74.Text = DiferencaData
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim FaturamentoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
            FaturamentoBalcao += Linha.Cells(12).Value
        Next
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim CustoBalcao As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
            CustoBalcao += Linha.Cells(17).Value
        Next
        ' ***************************************************************************
        Dim sql5 As String = "SELECT * FROM itemPedidos WHERE dataentrega_item BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and  codprod_item = '" & ProdutosDataGridView9.Item(1, v_SelectRow).Value & "' and (vendedor_item = 'verônica' or  vendedor_item = 'celso')"
        Dim dataadapter5 As New SqlDataAdapter(sql5, connection)
        Dim ds5 As New DataSet()
        Try
            connection.Open()
            dataadapter5.Fill(ds5, "itemPedidos")
            connection.Close()
            ItemPedidosDataGridView10.DataSource = ds5.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim FaturamentoPedidos As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
            FaturamentoPedidos += Linha.Cells(10).Value
        Next
        ' -----------------------------------
        'somar Faturamento da coluna da tabela balcão
        Dim CustoPedidos As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
            CustoPedidos += Linha.Cells(16).Value
        Next

    End Sub

    Private Sub TextBox303_TextChanged(sender As Object, e As EventArgs) Handles TextBox303.TextChanged
        VendasBalcaoResultadoBindingSource.Filter = String.Format("Produto_VendasBalcaoResultado LIKE '{0}%'", TextBox303.Text)
    End Sub

    Private Sub Button139_Click(sender As Object, e As EventArgs) Handles Button139.Click
        Dim valor As Decimal

        For Each col As DataGridViewRow In VendasBalcaoResultadoDataGridView.Rows
            valor = valor + col.Cells("Quantidade_VendasBalcaoResultado").Value
        Next
        TextBox304.Text = valor
    End Sub

    Private Sub Button140_Click(sender As Object, e As EventArgs) Handles Button140.Click

        ' Pega autorização para correr o botão
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
        ' ----------------------------------------------------------------------------------
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' **********************************************************************************************
        Dim v_SelectRow As Integer = 0
        Dim VendaPeriodo As Double = 0
        Dim CustoPeriodo As Double = 0
        Dim TotalLucro As Double = 0

        For v_SelectRow = 0 To ProdutosDataGridView9.RowCount() - 1

            '    Dim sql As String = "SELECT * FROM balcao WHERE  (nomevendedor_balcao ='celso' or  nomevendedor_balcao ='verônica')"
            Dim sql As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and  codprod_item = '" & ProdutosDataGridView9.Item(1, v_SelectRow).Value & "' and (vendedor_item = 'verônica' or  vendedor_item = 'celso')"
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            Try
                connection.Open()
                dataadapter.Fill(ds, "itemPedidos")
                connection.Close()
                ItemPedidosDataGridView10.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' ****************************************************
            ' calculando soma
            'somar Faturamento da coluna da tabela balcão
            Dim FaturamentoPedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                FaturamentoPedido += Linha.Cells(10).Value
            Next

            ' -----------------------------------
            'somar Faturamento da coluna da tabela balcão
            Dim CustoPedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                CustoPedido += Linha.Cells(16).Value
            Next
            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim QuantidadePedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                QuantidadePedido += Linha.Cells(8).Value
            Next

            VendaPeriodo = FaturamentoPedido
            CustoPeriodo = CustoPedido
            TotalLucro = FaturamentoPedido - CustoPedido

            ' ***********************************************************

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.Parameters.Clear()
            command.CommandText = "INSERT INTO VendasBalcaoPedidos (codprod2_VendasBalcaoPedidos,Quantidade_VendasBalcaoPedidos,Lucro_VendasBalcaoPedidos,Custo_VendasBalcaoPedidos,Faturamento_VendasBalcaoPedidos,Produto_VendasBalcaoPedidos,Cor_VendasBalcaoPedidos,Linha_VendasBalcaoPedidos,Fornecedor_VendasBalcaoPedidos) Values (@codprod2_VendasBalcaoPedidos,@Quantidade_VendasBalcaoPedidos,@Lucro_VendasBalcaoPedidos,@Custo_VendasBalcaoPedidos,@Faturamento_VendasBalcaoPedidos,@Produto_VendasBalcaoPedidos,@Cor_VendasBalcaoPedidos,@Linha_VendasBalcaoPedidos,@Fornecedor_VendasBalcaoPedidos)"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@codprod2_VendasBalcaoPedidos", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(2, v_SelectRow).Value
            command.Parameters.Add("@Fornecedor_VendasBalcaoPedidos", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(4, v_SelectRow).Value
            command.Parameters.Add("@Linha_VendasBalcaoPedidos", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(5, v_SelectRow).Value
            command.Parameters.Add("@Cor_VendasBalcaoPedidos", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(7, v_SelectRow).Value
            command.Parameters.Add("@Produto_VendasBalcaoPedidos", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(6, v_SelectRow).Value
            command.Parameters.Add("@Faturamento_VendasBalcaoPedidos", SqlDbType.Float).Value = VendaPeriodo
            command.Parameters.Add("@Custo_VendasBalcaoPedidos", SqlDbType.Float).Value = CustoPeriodo
            command.Parameters.Add("@Lucro_VendasBalcaoPedidos", SqlDbType.Float).Value = TotalLucro
            command.Parameters.Add("@Quantidade_VendasBalcaoPedidos", SqlDbType.Float).Value = QuantidadePedido

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        Next

        '  Me.Fill(Me.DataSetFinal.VendasBalcaoPedidos)

    End Sub

    Private Sub TextBox305_TextChanged(sender As Object, e As EventArgs) Handles TextBox305.TextChanged
        VendasBalcaoPedidosBindingSource.Filter = String.Format("Produto_VendasBalcaoPedidos LIKE '{0}%'", TextBox305.Text)
    End Sub

    Private Sub Button141_Click(sender As Object, e As EventArgs) Handles Button141.Click
        Dim valor As Decimal
        For Each col As DataGridViewRow In VendasBalcaoPedidosDataGridView.Rows
            valor = valor + col.Cells("Quantidade_VendasBalcaoPedidos").Value
        Next
        TextBox306.Text = valor
    End Sub

  

   

    Private Sub Button143_Click(sender As Object, e As EventArgs) Handles Button143.Click
        ' Pega autorização para correr o botão
        Dim codigoEntrada = InputBox("Área restrita, por favor digite a senha para acessar:", "Código")
        If codigoEntrada <> fernando Then
            MessageBox.Show("Código inválido")
            Exit Sub
        End If
        ' ----------------------------------------------------------------------------------
        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")
        ' **********************************************************************************************
        Dim v_SelectRow As Integer = 0
        Dim VendaPeriodo As Double = 0
        Dim CustoPeriodo As Integer = 0
        Dim TotalLucro As Double = 0
        Dim QuantidadePeriodo As Double = 0

        For v_SelectRow = 0 To ProdutosDataGridView9.RowCount() - 1

            '    Dim sql As String = "SELECT * FROM balcao WHERE  (nomevendedor_balcao ='celso' or  nomevendedor_balcao ='verônica')"
            Dim sql As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and nomeProd_balcao = '" & ProdutosDataGridView9.Item(6, v_SelectRow).Value & "' and corprod_balcao = '" & ProdutosDataGridView9.Item(7, v_SelectRow).Value & "' and (nomevendedor_balcao = 'verônica' or  nomevendedor_balcao = 'celso')"
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            Try
                connection.Open()
                dataadapter.Fill(ds, "balcao")
                connection.Close()
                BalcaoDataGridView11.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' ****************************************************
            ' calculando soma
            'somar Faturamento da coluna da tabela balcão
            Dim FaturamentoBalcao As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                FaturamentoBalcao += Linha.Cells(12).Value
            Next
            ' -----------------------------------
            'somar custo da coluna da tabela balcão
            Dim CustoBalcao As Decimal = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                CustoBalcao += Linha.Cells(17).Value
            Next
            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim QuantidadeBalcao As Double = 0
            For Each Linha As DataGridViewRow In Me.BalcaoDataGridView11.Rows
                QuantidadeBalcao += Linha.Cells(7).Value
            Next
            ' ***********************************************************

            Dim sql2 As String = "SELECT * FROM itemPedidos WHERE data_item BETWEEN   convert (datetime, '" & DateTimePicker41.Text & "' ,103)  and convert (datetime, '" & DateTimePicker42.Text & "' ,103) and  codprod_item = '" & ProdutosDataGridView9.Item(1, v_SelectRow).Value & "' and (vendedor_item = 'verônica' or  vendedor_item = 'celso')"
            Dim dataadapter2 As New SqlDataAdapter(sql2, connection)
            Dim ds2 As New DataSet()
            Try
                connection.Open()
                dataadapter2.Fill(ds2, "itemPedidos")
                connection.Close()
                ItemPedidosDataGridView10.DataSource = ds2.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' ****************************************************
            ' calculando soma
            'somar Faturamento da coluna da tabela balcão
            Dim FaturamentoPedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                FaturamentoPedido += Linha.Cells(10).Value
            Next

            'somar custo da coluna da tabela balcão
            Dim CustoPedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                CustoPedido += Linha.Cells(16).Value
            Next
            ' -----------------------------------
            'somar quantidade da coluna da tabela balcão
            Dim QuantidadePedido As Double = 0
            For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView10.Rows
                QuantidadePedido += Linha.Cells(8).Value
            Next

            VendaPeriodo = (FaturamentoPedido + FaturamentoBalcao).ToString("F2")
            CustoPeriodo = (CustoPedido + CustoBalcao).ToString("F2")
            TotalLucro = ((FaturamentoPedido + FaturamentoBalcao) - (CustoPedido + CustoBalcao)).ToString("F2")
            QuantidadePeriodo = QuantidadeBalcao + QuantidadePedido
            ' ***********************************************************

            Dim command As SqlCommand
            command = connection.CreateCommand()
            command.Parameters.Clear()
            command.CommandText = "INSERT INTO VendasBalcaoTotal (codprod_VendasBalcaoTotal,Quantidade_VendasBalcaoTotal,Lucro_VendasBalcaoTotal,Custo_VendasBalcaoTotal,Faturamento_VendasBalcaoTotal,Produto_VendasBalcaoTotal,Cor_VendasBalcaoTotal,Linha_VendasBalcaoTotal,Fornecedor_VendasBalcaoTotal) Values (@codprod_VendasBalcaoTotal,@Quantidade_VendasBalcaoTotal,@Lucro_VendasBalcaoTotal,@Custo_VendasBalcaoTotal,@Faturamento_VendasBalcaoTotal,@Produto_VendasBalcaoTotal,@Cor_VendasBalcaoTotal,@Linha_VendasBalcaoTotal,@Fornecedor_VendasBalcaoTotal)"
            command.CommandType = CommandType.Text
            command.Parameters.Add("@codprod_VendasBalcaoTotal", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(2, v_SelectRow).Value
            command.Parameters.Add("@Fornecedor_VendasBalcaoTotal", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(4, v_SelectRow).Value
            command.Parameters.Add("@Linha_VendasBalcaoTotal", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(5, v_SelectRow).Value
            command.Parameters.Add("@Cor_VendasBalcaoTotal", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(7, v_SelectRow).Value
            command.Parameters.Add("@Produto_VendasBalcaoTotal", SqlDbType.VarChar, 50).Value = ProdutosDataGridView9.Item(6, v_SelectRow).Value
            command.Parameters.Add("@Faturamento_VendasBalcaoTotal", SqlDbType.Float).Value = VendaPeriodo
            command.Parameters.Add("@Custo_VendasBalcaoTotal", SqlDbType.Float).Value = CustoPeriodo
            command.Parameters.Add("@Lucro_VendasBalcaoTotal", SqlDbType.Float).Value = TotalLucro
            command.Parameters.Add("@Quantidade_VendasBalcaoTotal", SqlDbType.Float).Value = QuantidadePeriodo

            Try
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
            End Try

        Next
    End Sub

    Private Sub TextBox307_TextChanged(sender As Object, e As EventArgs) Handles TextBox307.TextChanged
        VendasBalcaoTotalBindingSource.Filter = String.Format("Produto_VendasBalcaoTotal LIKE '{0}%'", TextBox307.Text)
    End Sub

    Private Sub Button144_Click(sender As Object, e As EventArgs) Handles Button144.Click
        Dim valor As Decimal
        For Each col As DataGridViewRow In VendasBalcaoTotalDataGridView.Rows
            valor = valor + col.Cells("DataGridViewTextBoxColumn1146").Value
        Next
        TextBox308.Text = valor
    End Sub

    
    Private Sub Button142_Click(sender As Object, e As EventArgs) Handles Button142.Click

        Dim connection As SqlConnection
        connection = New SqlConnection("Data Source=tcp:DESKTOP-TDVS6OS;Initial Catalog=teste;Persist Security Info=True;User ID=user;Password=123456789")

        ' **************************************************************************
        Dim sql11 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter11 As New SqlDataAdapter(sql11, connection)
        Dim ds11 As New DataSet()
        Try
            connection.Open()
            dataadapter11.Fill(ds11, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds11.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor11 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor11 += Linha.Cells(9).Value
        Next
        TextBox354.Text = valor11.ToString("f2")
        ' ***************************************************
        ' CALCULANDO OS TOTAIS
        Dim sql10 As String = "SELECT * FROM balcao WHERE datavenda_prodbalcao BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  forprod_balcao = '" & ComboBox45.Text & "'and  linhaprod_balcao = '" & ComboBox4.Text & "'"
        Dim dataadapter10 As New SqlDataAdapter(sql10, connection)
        Dim ds10 As New DataSet()
        Try
            connection.Open()
            dataadapter10.Fill(ds10, "balcao")
            connection.Close()
            BalcaoDataGridView9.DataSource = ds10.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor10 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valor10 += Linha.Cells(9).Value
        Next
        TextBox350.Text = valor10.ToString("f2")

        ' calculando o custo
        Dim valorCusto10 As Double
        For Each Linha As DataGridViewRow In Me.BalcaoDataGridView9.Rows
            valorCusto10 += Linha.Cells(11).Value
        Next
        TextBox351.Text = valorCusto10.ToString("f2")
        TextBox352.Text = TextBox350.Text - TextBox351.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem10 As Double = (1 - (valorCusto10 / valor10)) * 100
            TextBox353.Text = VrPorcentagem10.ToString("F2")
        Catch ex As Exception
        End Try
       
        ' *******************************************************
        Try
            Dim VrPorcentagem11 As Double = ((valor10 / valor11) * 100)
            TextBox355.Text = VrPorcentagem11.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************
        Dim sql21 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103) "
        Dim dataadapter21 As New SqlDataAdapter(sql21, connection)
        Dim ds21 As New DataSet()
        Try
            connection.Open()
            dataadapter21.Fill(ds21, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds21.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor21 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor21 += Linha.Cells(10).Value
        Next
        TextBox359.Text = valor21.ToString("f2")
       
        ' **************************************************************************************
        ' CALCULANDO OS TOTAIS das linhas

        Dim sql20 As String = "SELECT * FROM ItemPedidos WHERE data_item BETWEEN  convert (datetime, '" & DateTimePicker43.Text & "' ,103)  and convert (datetime, '" & DateTimePicker44.Text & "' ,103)  and  for_item = '" & ComboBox45.Text & "'and linha_item = '" & ComboBox4.Text & "'"
        Dim dataadapter20 As New SqlDataAdapter(sql20, connection)
        Dim ds20 As New DataSet()
        Try
            connection.Open()
            dataadapter20.Fill(ds20, "ItemPedidos")
            connection.Close()
            ItemPedidosDataGridView11.DataSource = ds20.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' calcula faturamento
        Dim valor20 As Decimal = 0
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valor20 += Linha.Cells(10).Value
        Next
        TextBox356.Text = valor20.ToString("f2")

        ' calculando o custo
        Dim valorCusto20 As Double
        For Each Linha As DataGridViewRow In Me.ItemPedidosDataGridView11.Rows
            valorCusto20 += Linha.Cells(16).Value
        Next
        TextBox357.Text = valorCusto20.ToString("f2")
        TextBox358.Text = TextBox356.Text - TextBox357.Text

        'calculando a porcentagem de lucro 
        Try
            Dim VrPorcentagem20 As Double = (1 - (valorCusto20 / valor20)) * 100
            TextBox361.Text = VrPorcentagem20.ToString("F2")
        Catch ex As Exception
        End Try
        ' *****************************************************************
        Try
            Dim VrPorcentagem21 As Double = ((valor20 / valor21) * 100)
            TextBox360.Text = VrPorcentagem21.ToString("F2")
        Catch ex As Exception
        End Try
        ' **************************************************************************************
       
        ' *************************************************************************************
        ' **************************************************************************************
        ' calculando os totais
        TextBox362.Text = (valor10 + valor20).ToString("F2")
        TextBox363.Text = (valorCusto10 + valorCusto20).ToString("F2")
        TextBox364.Text = ((valor10 + valor20) - (valorCusto10 + valorCusto20)).ToString("F2")
        ' passando valor do taturamento total
        Dim FatTotal As Double = 0
        FatTotal = (valor11 + valor21).ToString("F2")
        TextBox365.Text = FatTotal
        ' calculando a porcentagem da linha ou fornecedor
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem30 As Double = ((1 - ((valorCusto10 + valorCusto20) / (valor10 + valor20))) * 100)

            TextBox367.Text = VrPorcentagem30.ToString("F2")
        Catch ex As Exception
        End Try
        ' calculando a porcentagem total
        Try
            '  Dim VrPorcentagem30 As Double = ((1 - ((valor10 + valor20) / (valorCusto10 + valorCusto20))) * 100)
            Dim VrPorcentagem40 As Double = (((valor10 + valor20) / (valor11 + valor21)) * 100)

            TextBox366.Text = VrPorcentagem40.ToString("F2")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GroupBox90_Enter(sender As Object, e As EventArgs) Handles GroupBox90.Enter

    End Sub
End Class





