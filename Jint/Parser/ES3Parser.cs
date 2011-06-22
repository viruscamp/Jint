// $ANTLR 3.3.0.7239 C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g 2011-06-21 20:21:48

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Jint.Expressions;
using Jint.Debugger;


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3.0.7239")]
[System.CLSCompliant(false)]
public partial class ES3Parser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ABSTRACT", "ADD", "ADDASS", "AND", "ANDASS", "ARGS", "ARRAY", "ASSIGN", "BLOCK", "BOOLEAN", "BREAK", "BSLASH", "BYFIELD", "BYINDEX", "BYTE", "BackslashSequence", "CALL", "CASE", "CATCH", "CEXPR", "CHAR", "CLASS", "COLON", "COMMA", "CONST", "CONTINUE", "CR", "CharacterEscapeSequence", "DEBUGGER", "DEC", "DEFAULT", "DELETE", "DIV", "DIVASS", "DO", "DOT", "DOUBLE", "DQUOTE", "DecimalDigit", "DecimalIntegerLiteral", "DecimalLiteral", "ELSE", "ENUM", "EOL", "EQ", "EXPORT", "EXPR", "EXTENDS", "EscapeSequence", "ExponentPart", "FALSE", "FF", "FINAL", "FINALLY", "FLOAT", "FOR", "FORITER", "FORSTEP", "FUNCTION", "GOTO", "GT", "GTE", "HexDigit", "HexEscapeSequence", "HexIntegerLiteral", "IF", "IMPLEMENTS", "IMPORT", "IN", "INC", "INSTANCEOF", "INT", "INTERFACE", "INV", "ITEM", "Identifier", "IdentifierNameASCIIStart", "IdentifierPart", "IdentifierStartASCII", "LABELLED", "LAND", "LBRACE", "LBRACK", "LF", "LONG", "LOR", "LPAREN", "LS", "LT", "LTE", "LineTerminator", "MOD", "MODASS", "MUL", "MULASS", "MultiLineComment", "NAMEDVALUE", "NATIVE", "NBSP", "NEG", "NEQ", "NEW", "NOT", "NSAME", "NULL", "OBJECT", "OR", "ORASS", "OctalDigit", "OctalEscapeSequence", "OctalIntegerLiteral", "PACKAGE", "PAREXPR", "PDEC", "PINC", "POS", "PRIVATE", "PROTECTED", "PS", "PUBLIC", "QUE", "RBRACE", "RBRACK", "RETURN", "RPAREN", "RegularExpressionChar", "RegularExpressionFirstChar", "RegularExpressionLiteral", "SAME", "SEMIC", "SHL", "SHLASS", "SHORT", "SHR", "SHRASS", "SHU", "SHUASS", "SP", "SQUOTE", "STATIC", "SUB", "SUBASS", "SUPER", "SWITCH", "SYNCHRONIZED", "SingleLineComment", "StringLiteral", "TAB", "THIS", "THROW", "THROWS", "TRANSIENT", "TRUE", "TRY", "TYPEOF", "USP", "UnicodeEscapeSequence", "VAR", "VOID", "VOLATILE", "VT", "WHILE", "WITH", "WhiteSpace", "XOR", "XORASS", "ZeroToThree"
	};
	public const int EOF=-1;
	public const int ABSTRACT=4;
	public const int ADD=5;
	public const int ADDASS=6;
	public const int AND=7;
	public const int ANDASS=8;
	public const int ARGS=9;
	public const int ARRAY=10;
	public const int ASSIGN=11;
	public const int BLOCK=12;
	public const int BOOLEAN=13;
	public const int BREAK=14;
	public const int BSLASH=15;
	public const int BYFIELD=16;
	public const int BYINDEX=17;
	public const int BYTE=18;
	public const int BackslashSequence=19;
	public const int CALL=20;
	public const int CASE=21;
	public const int CATCH=22;
	public const int CEXPR=23;
	public const int CHAR=24;
	public const int CLASS=25;
	public const int COLON=26;
	public const int COMMA=27;
	public const int CONST=28;
	public const int CONTINUE=29;
	public const int CR=30;
	public const int CharacterEscapeSequence=31;
	public const int DEBUGGER=32;
	public const int DEC=33;
	public const int DEFAULT=34;
	public const int DELETE=35;
	public const int DIV=36;
	public const int DIVASS=37;
	public const int DO=38;
	public const int DOT=39;
	public const int DOUBLE=40;
	public const int DQUOTE=41;
	public const int DecimalDigit=42;
	public const int DecimalIntegerLiteral=43;
	public const int DecimalLiteral=44;
	public const int ELSE=45;
	public const int ENUM=46;
	public const int EOL=47;
	public const int EQ=48;
	public const int EXPORT=49;
	public const int EXPR=50;
	public const int EXTENDS=51;
	public const int EscapeSequence=52;
	public const int ExponentPart=53;
	public const int FALSE=54;
	public const int FF=55;
	public const int FINAL=56;
	public const int FINALLY=57;
	public const int FLOAT=58;
	public const int FOR=59;
	public const int FORITER=60;
	public const int FORSTEP=61;
	public const int FUNCTION=62;
	public const int GOTO=63;
	public const int GT=64;
	public const int GTE=65;
	public const int HexDigit=66;
	public const int HexEscapeSequence=67;
	public const int HexIntegerLiteral=68;
	public const int IF=69;
	public const int IMPLEMENTS=70;
	public const int IMPORT=71;
	public const int IN=72;
	public const int INC=73;
	public const int INSTANCEOF=74;
	public const int INT=75;
	public const int INTERFACE=76;
	public const int INV=77;
	public const int ITEM=78;
	public const int Identifier=79;
	public const int IdentifierNameASCIIStart=80;
	public const int IdentifierPart=81;
	public const int IdentifierStartASCII=82;
	public const int LABELLED=83;
	public const int LAND=84;
	public const int LBRACE=85;
	public const int LBRACK=86;
	public const int LF=87;
	public const int LONG=88;
	public const int LOR=89;
	public const int LPAREN=90;
	public const int LS=91;
	public const int LT=92;
	public const int LTE=93;
	public const int LineTerminator=94;
	public const int MOD=95;
	public const int MODASS=96;
	public const int MUL=97;
	public const int MULASS=98;
	public const int MultiLineComment=99;
	public const int NAMEDVALUE=100;
	public const int NATIVE=101;
	public const int NBSP=102;
	public const int NEG=103;
	public const int NEQ=104;
	public const int NEW=105;
	public const int NOT=106;
	public const int NSAME=107;
	public const int NULL=108;
	public const int OBJECT=109;
	public const int OR=110;
	public const int ORASS=111;
	public const int OctalDigit=112;
	public const int OctalEscapeSequence=113;
	public const int OctalIntegerLiteral=114;
	public const int PACKAGE=115;
	public const int PAREXPR=116;
	public const int PDEC=117;
	public const int PINC=118;
	public const int POS=119;
	public const int PRIVATE=120;
	public const int PROTECTED=121;
	public const int PS=122;
	public const int PUBLIC=123;
	public const int QUE=124;
	public const int RBRACE=125;
	public const int RBRACK=126;
	public const int RETURN=127;
	public const int RPAREN=128;
	public const int RegularExpressionChar=129;
	public const int RegularExpressionFirstChar=130;
	public const int RegularExpressionLiteral=131;
	public const int SAME=132;
	public const int SEMIC=133;
	public const int SHL=134;
	public const int SHLASS=135;
	public const int SHORT=136;
	public const int SHR=137;
	public const int SHRASS=138;
	public const int SHU=139;
	public const int SHUASS=140;
	public const int SP=141;
	public const int SQUOTE=142;
	public const int STATIC=143;
	public const int SUB=144;
	public const int SUBASS=145;
	public const int SUPER=146;
	public const int SWITCH=147;
	public const int SYNCHRONIZED=148;
	public const int SingleLineComment=149;
	public const int StringLiteral=150;
	public const int TAB=151;
	public const int THIS=152;
	public const int THROW=153;
	public const int THROWS=154;
	public const int TRANSIENT=155;
	public const int TRUE=156;
	public const int TRY=157;
	public const int TYPEOF=158;
	public const int USP=159;
	public const int UnicodeEscapeSequence=160;
	public const int VAR=161;
	public const int VOID=162;
	public const int VOLATILE=163;
	public const int VT=164;
	public const int WHILE=165;
	public const int WITH=166;
	public const int WhiteSpace=167;
	public const int XOR=168;
	public const int XORASS=169;
	public const int ZeroToThree=170;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public ES3Parser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public ES3Parser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return ES3Parser.tokenNames; } }
	public override string GrammarFileName { get { return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g"; } }


	    private const char BS = '\\';
	    private bool IsLeftHandSideAssign(Expression lhs, object[] cached)
	    {
	    	if (cached[0] != null)
	    	{
	    		return System.Convert.ToBoolean(cached[0]);
	    	}
	    	
	    	bool result;
	    	if(IsLeftHandSideExpression(lhs))
	    	{
	    		switch (input.LA(1))
	    		{
	    			case ASSIGN:
	    			case MULASS:
	    			case DIVASS:
	    			case MODASS:
	    			case ADDASS:
	    			case SUBASS:
	    			case SHLASS:
	    			case SHRASS:
	    			case SHUASS:
	    			case ANDASS:
	    			case XORASS:
	    			case ORASS:
	    				result = true;
	    				break;
	    			default:
	    				result = false;
	    				break;
	    		}
	    	}
	    	else
	    	{
	    		result = false;
	    	}
	    	
	    	cached[0] = result;
	    	return result;
	    }

	    private static bool IsLeftHandSideExpression(Expression lhs)
	    {
	        if (lhs == null)
	        {
	            return true;
	        }

	        return lhs is Identifier || lhs is PropertyExpression || lhs is MemberExpression;
	    }
	    	
	    private bool IsLeftHandSideIn(Expression lhs, object[] cached)
	    {
	    	if (cached[0] != null)
	    	{
	    		return System.Convert.ToBoolean(cached[0]);
	    	}
	    	
	    	bool result = IsLeftHandSideExpression(lhs) && (input.LA(1) == IN);
	    	cached[0] = result;
	    	return result;
	    }

	    private void PromoteEOL(ParserRuleReturnScope<IToken> rule)
	    {
	    	// Get current token and its type (the possibly offending token).
	    	IToken lt = input.LT(1);
	    	int la = lt.Type;
	    	
	    	// We only need to promote an EOL when the current token is offending (not a SEMIC, EOF, RBRACE, EOL or MultiLineComment).
	    	// EOL and MultiLineComment are not offending as they're already promoted in a previous call to this method.
	    	// Promoting an EOL means switching it from off channel to on channel.
	    	// A MultiLineComment gets promoted when it contains an EOL.
	    	if (!(la == SEMIC || la == EOF || la == RBRACE || la == EOL || la == MultiLineComment))
	    	{
	    		// Start on the possition before the current token and scan backwards off channel tokens until the previous on channel token.
	    		for (int ix = lt.TokenIndex - 1; ix > 0; ix--)
	    		{
	    			lt = input.Get(ix);
	    			if (lt.Channel == DefaultTokenChannel)
	    			{
	    				// On channel token found: stop scanning.
	    				break;
	    			}
	    			else if (lt.Type == EOL || (lt.Type == MultiLineComment && (lt.Text.EndsWith("\r") || lt.Text.EndsWith("\n"))))
	    			{
	    				// We found our EOL: promote the token to on channel, position the input on it and reset the rule start.
	    				lt.Channel = DefaultTokenChannel;
	    				input.Seek(lt.TokenIndex);
	    				if (rule != null)
	    				{
	    					rule.Start = lt;
	    				}
	    				break;
	    			}
	    		}
	    	}
	    }	
	    
	    private static NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

	    private string extractRegExpPattern(string text) {
	        return text.Substring(1, text.LastIndexOf('/')-1);
	    }

	    private string extractRegExpOption(string text) {
	        if(text[text.Length-1] != '/')
	        {
			return text.Substring(text.LastIndexOf('/')+1);
	        }
	        return String.Empty;
	    }
	    
	    private static Encoding Latin1 = Encoding.GetEncoding("iso-8859-1");
	    
	    private string extractString(string text) {
	    
	    // https://developer.mozilla.org/en/Core_JavaScript_1.5_Guide/Literals#String Literals    
	        StringBuilder sb = new StringBuilder(text.Length);
	        int startIndex = 1; // Skip initial quote
	        int slashIndex = -1;

	        while ((slashIndex = text.IndexOf(BS, startIndex)) != -1)
	        {
                sb.Append(text.Substring(startIndex, slashIndex - startIndex));
	            char escapeType = text[slashIndex + 1];
	            switch (escapeType)
	            {
	                case '0':
	                case '1':
	                case '2':
	                case '3':
	                case '4':
	                case '5':
	                case '6':
	                case '7':
	                case '8':
	                case '9':
                        string octalCode = text.Substring(slashIndex + 1, 3);   
                        char octalChar = Latin1.GetChars(new byte[] { System.Convert.ToByte(octalCode, 8) } )[0]; 
                        // insert decoded char
                        sb.Append(octalChar);
                        // skip encoded char
                        slashIndex += 4;
			          break;                 
	                case 'x':
                        string asciiCode = text.Substring(slashIndex + 2, 2); ;
                        char asciiChar = Latin1.GetChars(new byte[] { System.Convert.ToByte(asciiCode, 16) } )[0];
                        sb.Append(asciiChar);
                        slashIndex += 4;
                        break;   	
	                case 'u':
                        char unicodeChar = System.Convert.ToChar(Int32.Parse(text.Substring(slashIndex + 2, 4), System.Globalization.NumberStyles.AllowHexSpecifier));
                        sb.Append(unicodeChar);
                        slashIndex += 6;
                        break;
                    case 'b': sb.Append('\b'); slashIndex += 2; break;
                    case 'f': sb.Append('\f'); slashIndex += 2; break;
                    case 'n': sb.Append('\n'); slashIndex += 2; break;
                    case 'r': sb.Append('\r'); slashIndex += 2; break;
                    case 't': sb.Append('\t'); slashIndex += 2; break;
                    case 'v': sb.Append('\v'); slashIndex += 2; break;
                    case '\'': sb.Append('\''); slashIndex += 2; break;
                    case '"': sb.Append('"'); slashIndex += 2; break;
                    case '\\': sb.Append('\\'); slashIndex += 2; break;
                    case '\r': if (text[slashIndex + 2] == '\n') slashIndex += 3; break;
                    case '\n': slashIndex += 2; break;
                    default: sb.Append(escapeType); slashIndex += 2; break;
	            }

                startIndex = slashIndex;
	        }

            if (sb.Length == 0)
                return text.Substring(1, text.Length - 2);

            sb.Append(text.Substring(startIndex, text.Length - startIndex - 1));
	        return sb.ToString();
	    }

	    public List<string> Errors { get; private set; }

	    public override void DisplayRecognitionError(String[] tokenNames, RecognitionException e) {
	        
	        base.DisplayRecognitionError(tokenNames, e);
	        
	        if(Errors == null)
	        {
	        	Errors = new List<string>();
	        }
	        
	        String hdr = GetErrorHeader(e);
	        String msg = GetErrorMessage(e, tokenNames);
	        Errors.Add(msg + " at " + hdr);
	    }    

	    private string[] script = new string[0];
	    
	    	public bool DebugMode { get; set; }
	    	
	        private SourceCodeDescriptor ExtractSourceCode(CommonToken start, CommonToken stop)
	        {
	            if(!DebugMode)
	            {
	            	return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
	            }
	            
	            try
	            {
	                StringBuilder source = new StringBuilder();

	                for (int i = start.Line - 1; i <= stop.Line - 1; i++)
	                {
	                    int charStart = 0;
	                    int charStop = script[i].Length;

	                    if (i == start.Line - 1)
	                    {
	                        charStart = start.CharPositionInLine;
	                    }

	                    if (i == stop.Line - 1)
	                    {
	                        charStop = stop.CharPositionInLine;
	                    }

	                    int length = charStop - charStart;

	                    source.Append(script[i].Substring(charStart, length)).Append(Environment.NewLine);
	                }

	                return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, source.ToString());
	            }
	            catch
	            {
	                return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
	            }

	        }

	    public AssignmentOperator ResolveAssignmentOperator(string op)
	    {
	    	switch(op)
	    	{
	    	    case "=" : return AssignmentOperator.Assign;
	    	    case "+=" : return AssignmentOperator.Add;
	    	    case "-=" : return AssignmentOperator.Substract;
	    	    case "*=" : return AssignmentOperator.Multiply;
	    	    case "%=" : return AssignmentOperator.Modulo;
	    	    case "<<=" : return AssignmentOperator.ShiftLeft;
	    	    case ">>=" : return AssignmentOperator.ShiftRight;
	    	    case ">>>=" : return AssignmentOperator.UnsignedRightShift;
	    	    case "&=" : return AssignmentOperator.And;
	    	    case "|=" : return AssignmentOperator.Or;
	    	    case "^=" : return AssignmentOperator.XOr;
	    	    case "/=" : return AssignmentOperator.Divide;
	    	    default : throw new NotSupportedException("Invalid assignment operator: " + op);
	    	}
	    }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class token_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_token();
	partial void Leave_token();

	// $ANTLR start "token"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:647:1: token : ( reservedWord | Identifier | punctuator | numericLiteral | StringLiteral );
	[GrammarRule("token")]
	private ES3Parser.token_return token()
	{
		Enter_token();
		EnterRule("token", 1);
		TraceIn("token", 1);
		ES3Parser.token_return retval = new ES3Parser.token_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken Identifier2=null;
		IToken StringLiteral5=null;
		ES3Parser.reservedWord_return reservedWord1 = default(ES3Parser.reservedWord_return);
		ES3Parser.punctuator_return punctuator3 = default(ES3Parser.punctuator_return);
		ES3Parser.numericLiteral_return numericLiteral4 = default(ES3Parser.numericLiteral_return);

		object Identifier2_tree=null;
		object StringLiteral5_tree=null;

		try { DebugEnterRule(GrammarFileName, "token");
		DebugLocation(647, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:648:2: ( reservedWord | Identifier | punctuator | numericLiteral | StringLiteral )
			int alt1=5;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			switch (input.LA(1))
			{
			case ABSTRACT:
			case BOOLEAN:
			case BREAK:
			case BYTE:
			case CASE:
			case CATCH:
			case CHAR:
			case CLASS:
			case CONST:
			case CONTINUE:
			case DEBUGGER:
			case DEFAULT:
			case DELETE:
			case DO:
			case DOUBLE:
			case ELSE:
			case ENUM:
			case EXPORT:
			case EXTENDS:
			case FALSE:
			case FINAL:
			case FINALLY:
			case FLOAT:
			case FOR:
			case FUNCTION:
			case GOTO:
			case IF:
			case IMPLEMENTS:
			case IMPORT:
			case IN:
			case INSTANCEOF:
			case INT:
			case INTERFACE:
			case LONG:
			case NATIVE:
			case NEW:
			case NULL:
			case PACKAGE:
			case PRIVATE:
			case PROTECTED:
			case PUBLIC:
			case RETURN:
			case SHORT:
			case STATIC:
			case SUPER:
			case SWITCH:
			case SYNCHRONIZED:
			case THIS:
			case THROW:
			case THROWS:
			case TRANSIENT:
			case TRUE:
			case TRY:
			case TYPEOF:
			case VAR:
			case VOID:
			case VOLATILE:
			case WHILE:
			case WITH:
				{
				alt1=1;
				}
				break;
			case Identifier:
				{
				alt1=2;
				}
				break;
			case ADD:
			case ADDASS:
			case AND:
			case ANDASS:
			case ASSIGN:
			case COLON:
			case COMMA:
			case DEC:
			case DIV:
			case DIVASS:
			case DOT:
			case EQ:
			case GT:
			case GTE:
			case INC:
			case INV:
			case LAND:
			case LBRACE:
			case LBRACK:
			case LOR:
			case LPAREN:
			case LT:
			case LTE:
			case MOD:
			case MODASS:
			case MUL:
			case MULASS:
			case NEQ:
			case NOT:
			case NSAME:
			case OR:
			case ORASS:
			case QUE:
			case RBRACE:
			case RBRACK:
			case RPAREN:
			case SAME:
			case SEMIC:
			case SHL:
			case SHLASS:
			case SHR:
			case SHRASS:
			case SHU:
			case SHUASS:
			case SUB:
			case SUBASS:
			case XOR:
			case XORASS:
				{
				alt1=3;
				}
				break;
			case DecimalLiteral:
			case HexIntegerLiteral:
			case OctalIntegerLiteral:
				{
				alt1=4;
				}
				break;
			case StringLiteral:
				{
				alt1=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 1, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:648:4: reservedWord
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(648, 4);
				PushFollow(Follow._reservedWord_in_token1748);
				reservedWord1=reservedWord();
				PopFollow();

				adaptor.AddChild(root_0, reservedWord1.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:649:4: Identifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(649, 4);
				Identifier2=(IToken)Match(input,Identifier,Follow._Identifier_in_token1753); 
				Identifier2_tree = (object)adaptor.Create(Identifier2);
				adaptor.AddChild(root_0, Identifier2_tree);


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:650:4: punctuator
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(650, 4);
				PushFollow(Follow._punctuator_in_token1758);
				punctuator3=punctuator();
				PopFollow();

				adaptor.AddChild(root_0, punctuator3.Tree);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:651:4: numericLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(651, 4);
				PushFollow(Follow._numericLiteral_in_token1763);
				numericLiteral4=numericLiteral();
				PopFollow();

				adaptor.AddChild(root_0, numericLiteral4.Tree);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:652:4: StringLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(652, 4);
				StringLiteral5=(IToken)Match(input,StringLiteral,Follow._StringLiteral_in_token1768); 
				StringLiteral5_tree = (object)adaptor.Create(StringLiteral5);
				adaptor.AddChild(root_0, StringLiteral5_tree);


				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("token", 1);
			LeaveRule("token", 1);
			Leave_token();
		}
		DebugLocation(653, 1);
		} finally { DebugExitRule(GrammarFileName, "token"); }
		return retval;

	}
	// $ANTLR end "token"

	public class reservedWord_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_reservedWord();
	partial void Leave_reservedWord();

	// $ANTLR start "reservedWord"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:657:1: reservedWord : ( keyword | futureReservedWord | NULL | booleanLiteral );
	[GrammarRule("reservedWord")]
	private ES3Parser.reservedWord_return reservedWord()
	{
		Enter_reservedWord();
		EnterRule("reservedWord", 2);
		TraceIn("reservedWord", 2);
		ES3Parser.reservedWord_return retval = new ES3Parser.reservedWord_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken NULL8=null;
		ES3Parser.keyword_return keyword6 = default(ES3Parser.keyword_return);
		ES3Parser.futureReservedWord_return futureReservedWord7 = default(ES3Parser.futureReservedWord_return);
		ES3Parser.booleanLiteral_return booleanLiteral9 = default(ES3Parser.booleanLiteral_return);

		object NULL8_tree=null;

		try { DebugEnterRule(GrammarFileName, "reservedWord");
		DebugLocation(657, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:658:2: ( keyword | futureReservedWord | NULL | booleanLiteral )
			int alt2=4;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			switch (input.LA(1))
			{
			case BREAK:
			case CASE:
			case CATCH:
			case CONTINUE:
			case DEFAULT:
			case DELETE:
			case DO:
			case ELSE:
			case FINALLY:
			case FOR:
			case FUNCTION:
			case IF:
			case IN:
			case INSTANCEOF:
			case NEW:
			case RETURN:
			case SWITCH:
			case THIS:
			case THROW:
			case TRY:
			case TYPEOF:
			case VAR:
			case VOID:
			case WHILE:
			case WITH:
				{
				alt2=1;
				}
				break;
			case ABSTRACT:
			case BOOLEAN:
			case BYTE:
			case CHAR:
			case CLASS:
			case CONST:
			case DEBUGGER:
			case DOUBLE:
			case ENUM:
			case EXPORT:
			case EXTENDS:
			case FINAL:
			case FLOAT:
			case GOTO:
			case IMPLEMENTS:
			case IMPORT:
			case INT:
			case INTERFACE:
			case LONG:
			case NATIVE:
			case PACKAGE:
			case PRIVATE:
			case PROTECTED:
			case PUBLIC:
			case SHORT:
			case STATIC:
			case SUPER:
			case SYNCHRONIZED:
			case THROWS:
			case TRANSIENT:
			case VOLATILE:
				{
				alt2=2;
				}
				break;
			case NULL:
				{
				alt2=3;
				}
				break;
			case FALSE:
			case TRUE:
				{
				alt2=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:658:4: keyword
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(658, 4);
				PushFollow(Follow._keyword_in_reservedWord1781);
				keyword6=keyword();
				PopFollow();

				adaptor.AddChild(root_0, keyword6.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:659:4: futureReservedWord
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(659, 4);
				PushFollow(Follow._futureReservedWord_in_reservedWord1786);
				futureReservedWord7=futureReservedWord();
				PopFollow();

				adaptor.AddChild(root_0, futureReservedWord7.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:660:4: NULL
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(660, 4);
				NULL8=(IToken)Match(input,NULL,Follow._NULL_in_reservedWord1791); 
				NULL8_tree = (object)adaptor.Create(NULL8);
				adaptor.AddChild(root_0, NULL8_tree);


				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:661:4: booleanLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(661, 4);
				PushFollow(Follow._booleanLiteral_in_reservedWord1796);
				booleanLiteral9=booleanLiteral();
				PopFollow();

				adaptor.AddChild(root_0, booleanLiteral9.Tree);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("reservedWord", 2);
			LeaveRule("reservedWord", 2);
			Leave_reservedWord();
		}
		DebugLocation(662, 1);
		} finally { DebugExitRule(GrammarFileName, "reservedWord"); }
		return retval;

	}
	// $ANTLR end "reservedWord"

	public class keyword_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_keyword();
	partial void Leave_keyword();

	// $ANTLR start "keyword"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:668:1: keyword : ( BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH );
	[GrammarRule("keyword")]
	private ES3Parser.keyword_return keyword()
	{
		Enter_keyword();
		EnterRule("keyword", 3);
		TraceIn("keyword", 3);
		ES3Parser.keyword_return retval = new ES3Parser.keyword_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set10=null;

		object set10_tree=null;

		try { DebugEnterRule(GrammarFileName, "keyword");
		DebugLocation(668, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:669:2: ( BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(669, 2);
			set10=(IToken)input.LT(1);
			if (input.LA(1)==BREAK||(input.LA(1)>=CASE && input.LA(1)<=CATCH)||input.LA(1)==CONTINUE||(input.LA(1)>=DEFAULT && input.LA(1)<=DELETE)||input.LA(1)==DO||input.LA(1)==ELSE||input.LA(1)==FINALLY||input.LA(1)==FOR||input.LA(1)==FUNCTION||input.LA(1)==IF||input.LA(1)==IN||input.LA(1)==INSTANCEOF||input.LA(1)==NEW||input.LA(1)==RETURN||input.LA(1)==SWITCH||(input.LA(1)>=THIS && input.LA(1)<=THROW)||(input.LA(1)>=TRY && input.LA(1)<=TYPEOF)||(input.LA(1)>=VAR && input.LA(1)<=VOID)||(input.LA(1)>=WHILE && input.LA(1)<=WITH))
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set10));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("keyword", 3);
			LeaveRule("keyword", 3);
			Leave_keyword();
		}
		DebugLocation(694, 1);
		} finally { DebugExitRule(GrammarFileName, "keyword"); }
		return retval;

	}
	// $ANTLR end "keyword"

	public class futureReservedWord_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_futureReservedWord();
	partial void Leave_futureReservedWord();

	// $ANTLR start "futureReservedWord"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:700:1: futureReservedWord : ( ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE );
	[GrammarRule("futureReservedWord")]
	private ES3Parser.futureReservedWord_return futureReservedWord()
	{
		Enter_futureReservedWord();
		EnterRule("futureReservedWord", 4);
		TraceIn("futureReservedWord", 4);
		ES3Parser.futureReservedWord_return retval = new ES3Parser.futureReservedWord_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set11=null;

		object set11_tree=null;

		try { DebugEnterRule(GrammarFileName, "futureReservedWord");
		DebugLocation(700, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:701:2: ( ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(701, 2);
			set11=(IToken)input.LT(1);
			if (input.LA(1)==ABSTRACT||input.LA(1)==BOOLEAN||input.LA(1)==BYTE||(input.LA(1)>=CHAR && input.LA(1)<=CLASS)||input.LA(1)==CONST||input.LA(1)==DEBUGGER||input.LA(1)==DOUBLE||input.LA(1)==ENUM||input.LA(1)==EXPORT||input.LA(1)==EXTENDS||input.LA(1)==FINAL||input.LA(1)==FLOAT||input.LA(1)==GOTO||(input.LA(1)>=IMPLEMENTS && input.LA(1)<=IMPORT)||(input.LA(1)>=INT && input.LA(1)<=INTERFACE)||input.LA(1)==LONG||input.LA(1)==NATIVE||input.LA(1)==PACKAGE||(input.LA(1)>=PRIVATE && input.LA(1)<=PROTECTED)||input.LA(1)==PUBLIC||input.LA(1)==SHORT||input.LA(1)==STATIC||input.LA(1)==SUPER||input.LA(1)==SYNCHRONIZED||(input.LA(1)>=THROWS && input.LA(1)<=TRANSIENT)||input.LA(1)==VOLATILE)
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set11));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("futureReservedWord", 4);
			LeaveRule("futureReservedWord", 4);
			Leave_futureReservedWord();
		}
		DebugLocation(732, 1);
		} finally { DebugExitRule(GrammarFileName, "futureReservedWord"); }
		return retval;

	}
	// $ANTLR end "futureReservedWord"

	public class punctuator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_punctuator();
	partial void Leave_punctuator();

	// $ANTLR start "punctuator"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:778:1: punctuator : ( LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS );
	[GrammarRule("punctuator")]
	private ES3Parser.punctuator_return punctuator()
	{
		Enter_punctuator();
		EnterRule("punctuator", 5);
		TraceIn("punctuator", 5);
		ES3Parser.punctuator_return retval = new ES3Parser.punctuator_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set12=null;

		object set12_tree=null;

		try { DebugEnterRule(GrammarFileName, "punctuator");
		DebugLocation(778, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:779:2: ( LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(779, 2);
			set12=(IToken)input.LT(1);
			if ((input.LA(1)>=ADD && input.LA(1)<=ANDASS)||input.LA(1)==ASSIGN||(input.LA(1)>=COLON && input.LA(1)<=COMMA)||input.LA(1)==DEC||(input.LA(1)>=DIV && input.LA(1)<=DIVASS)||input.LA(1)==DOT||input.LA(1)==EQ||(input.LA(1)>=GT && input.LA(1)<=GTE)||input.LA(1)==INC||input.LA(1)==INV||(input.LA(1)>=LAND && input.LA(1)<=LBRACK)||(input.LA(1)>=LOR && input.LA(1)<=LPAREN)||(input.LA(1)>=LT && input.LA(1)<=LTE)||(input.LA(1)>=MOD && input.LA(1)<=MULASS)||input.LA(1)==NEQ||(input.LA(1)>=NOT && input.LA(1)<=NSAME)||(input.LA(1)>=OR && input.LA(1)<=ORASS)||(input.LA(1)>=QUE && input.LA(1)<=RBRACK)||input.LA(1)==RPAREN||(input.LA(1)>=SAME && input.LA(1)<=SHLASS)||(input.LA(1)>=SHR && input.LA(1)<=SHUASS)||(input.LA(1)>=SUB && input.LA(1)<=SUBASS)||(input.LA(1)>=XOR && input.LA(1)<=XORASS))
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set12));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("punctuator", 5);
			LeaveRule("punctuator", 5);
			Leave_punctuator();
		}
		DebugLocation(827, 1);
		} finally { DebugExitRule(GrammarFileName, "punctuator"); }
		return retval;

	}
	// $ANTLR end "punctuator"

	public class literal_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_literal();
	partial void Leave_literal();

	// $ANTLR start "literal"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:833:1: literal returns [Expression value] : (exp1= NULL |exp2= booleanLiteral |exp3= numericLiteral |exp4= StringLiteral |exp5= RegularExpressionLiteral );
	[GrammarRule("literal")]
	private ES3Parser.literal_return literal()
	{
		Enter_literal();
		EnterRule("literal", 6);
		TraceIn("literal", 6);
		ES3Parser.literal_return retval = new ES3Parser.literal_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken exp1=null;
		IToken exp4=null;
		IToken exp5=null;
		ES3Parser.booleanLiteral_return exp2 = default(ES3Parser.booleanLiteral_return);
		ES3Parser.numericLiteral_return exp3 = default(ES3Parser.numericLiteral_return);

		object exp1_tree=null;
		object exp4_tree=null;
		object exp5_tree=null;

		try { DebugEnterRule(GrammarFileName, "literal");
		DebugLocation(833, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:834:2: (exp1= NULL |exp2= booleanLiteral |exp3= numericLiteral |exp4= StringLiteral |exp5= RegularExpressionLiteral )
			int alt3=5;
			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
			switch (input.LA(1))
			{
			case NULL:
				{
				alt3=1;
				}
				break;
			case FALSE:
			case TRUE:
				{
				alt3=2;
				}
				break;
			case DecimalLiteral:
			case HexIntegerLiteral:
			case OctalIntegerLiteral:
				{
				alt3=3;
				}
				break;
			case StringLiteral:
				{
				alt3=4;
				}
				break;
			case RegularExpressionLiteral:
				{
				alt3=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:834:4: exp1= NULL
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(834, 8);
				exp1=(IToken)Match(input,NULL,Follow._NULL_in_literal2483); 
				exp1_tree = (object)adaptor.Create(exp1);
				adaptor.AddChild(root_0, exp1_tree);

				DebugLocation(834, 14);
				 retval.value = new Identifier(exp1.Text); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:835:4: exp2= booleanLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(835, 8);
				PushFollow(Follow._booleanLiteral_in_literal2492);
				exp2=booleanLiteral();
				PopFollow();

				adaptor.AddChild(root_0, exp2.Tree);
				DebugLocation(835, 24);
				 retval.value = new ValueExpression(exp2.value, TypeCode.Boolean); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:836:4: exp3= numericLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(836, 8);
				PushFollow(Follow._numericLiteral_in_literal2501);
				exp3=numericLiteral();
				PopFollow();

				adaptor.AddChild(root_0, exp3.Tree);
				DebugLocation(836, 24);
				 retval.value = new ValueExpression(exp3.value, TypeCode.Double); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:837:4: exp4= StringLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(837, 8);
				exp4=(IToken)Match(input,StringLiteral,Follow._StringLiteral_in_literal2510); 
				exp4_tree = (object)adaptor.Create(exp4);
				adaptor.AddChild(root_0, exp4_tree);

				DebugLocation(837, 24);
				 retval.value = new ValueExpression(extractString(exp4.Text), TypeCode.String); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:838:4: exp5= RegularExpressionLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(838, 8);
				exp5=(IToken)Match(input,RegularExpressionLiteral,Follow._RegularExpressionLiteral_in_literal2520); 
				exp5_tree = (object)adaptor.Create(exp5);
				adaptor.AddChild(root_0, exp5_tree);

				DebugLocation(838, 34);
				 retval.value = new RegexpExpression(extractRegExpPattern(exp5.Text), extractRegExpOption(exp5.Text)); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("literal", 6);
			LeaveRule("literal", 6);
			Leave_literal();
		}
		DebugLocation(839, 1);
		} finally { DebugExitRule(GrammarFileName, "literal"); }
		return retval;

	}
	// $ANTLR end "literal"

	public class booleanLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public bool value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_booleanLiteral();
	partial void Leave_booleanLiteral();

	// $ANTLR start "booleanLiteral"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:841:1: booleanLiteral returns [bool value] : ( TRUE | FALSE );
	[GrammarRule("booleanLiteral")]
	private ES3Parser.booleanLiteral_return booleanLiteral()
	{
		Enter_booleanLiteral();
		EnterRule("booleanLiteral", 7);
		TraceIn("booleanLiteral", 7);
		ES3Parser.booleanLiteral_return retval = new ES3Parser.booleanLiteral_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken TRUE13=null;
		IToken FALSE14=null;

		object TRUE13_tree=null;
		object FALSE14_tree=null;

		try { DebugEnterRule(GrammarFileName, "booleanLiteral");
		DebugLocation(841, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:842:2: ( TRUE | FALSE )
			int alt4=2;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if ((LA4_0==TRUE))
			{
				alt4=1;
			}
			else if ((LA4_0==FALSE))
			{
				alt4=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 4, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:842:4: TRUE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(842, 4);
				TRUE13=(IToken)Match(input,TRUE,Follow._TRUE_in_booleanLiteral2537); 
				TRUE13_tree = (object)adaptor.Create(TRUE13);
				adaptor.AddChild(root_0, TRUE13_tree);

				DebugLocation(842, 9);
				 retval.value = true; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:843:4: FALSE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(843, 4);
				FALSE14=(IToken)Match(input,FALSE,Follow._FALSE_in_booleanLiteral2544); 
				FALSE14_tree = (object)adaptor.Create(FALSE14);
				adaptor.AddChild(root_0, FALSE14_tree);

				DebugLocation(843, 10);
				 retval.value = false; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("booleanLiteral", 7);
			LeaveRule("booleanLiteral", 7);
			Leave_booleanLiteral();
		}
		DebugLocation(844, 1);
		} finally { DebugExitRule(GrammarFileName, "booleanLiteral"); }
		return retval;

	}
	// $ANTLR end "booleanLiteral"

	public class numericLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public double value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_numericLiteral();
	partial void Leave_numericLiteral();

	// $ANTLR start "numericLiteral"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:888:1: numericLiteral returns [double value] : (ex1= DecimalLiteral |ex2= OctalIntegerLiteral |ex3= HexIntegerLiteral );
	[GrammarRule("numericLiteral")]
	private ES3Parser.numericLiteral_return numericLiteral()
	{
		Enter_numericLiteral();
		EnterRule("numericLiteral", 8);
		TraceIn("numericLiteral", 8);
		ES3Parser.numericLiteral_return retval = new ES3Parser.numericLiteral_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ex1=null;
		IToken ex2=null;
		IToken ex3=null;

		object ex1_tree=null;
		object ex2_tree=null;
		object ex3_tree=null;

		try { DebugEnterRule(GrammarFileName, "numericLiteral");
		DebugLocation(888, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:889:2: (ex1= DecimalLiteral |ex2= OctalIntegerLiteral |ex3= HexIntegerLiteral )
			int alt5=3;
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			switch (input.LA(1))
			{
			case DecimalLiteral:
				{
				alt5=1;
				}
				break;
			case OctalIntegerLiteral:
				{
				alt5=2;
				}
				break;
			case HexIntegerLiteral:
				{
				alt5=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:889:4: ex1= DecimalLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(889, 7);
				ex1=(IToken)Match(input,DecimalLiteral,Follow._DecimalLiteral_in_numericLiteral2755); 
				ex1_tree = (object)adaptor.Create(ex1);
				adaptor.AddChild(root_0, ex1_tree);

				DebugLocation(889, 23);
				 retval.value = double.Parse(ex1.Text, NumberStyles.Float, numberFormatInfo); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:890:4: ex2= OctalIntegerLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(890, 7);
				ex2=(IToken)Match(input,OctalIntegerLiteral,Follow._OctalIntegerLiteral_in_numericLiteral2764); 
				ex2_tree = (object)adaptor.Create(ex2);
				adaptor.AddChild(root_0, ex2_tree);

				DebugLocation(890, 28);
				 retval.value = System.Convert.ToInt64(ex2.Text, 8); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:891:4: ex3= HexIntegerLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(891, 7);
				ex3=(IToken)Match(input,HexIntegerLiteral,Follow._HexIntegerLiteral_in_numericLiteral2773); 
				ex3_tree = (object)adaptor.Create(ex3);
				adaptor.AddChild(root_0, ex3_tree);

				DebugLocation(891, 26);
				 retval.value = System.Convert.ToInt64(ex3.Text, 16); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("numericLiteral", 8);
			LeaveRule("numericLiteral", 8);
			Leave_numericLiteral();
		}
		DebugLocation(892, 1);
		} finally { DebugExitRule(GrammarFileName, "numericLiteral"); }
		return retval;

	}
	// $ANTLR end "numericLiteral"

	public class primaryExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_primaryExpression();
	partial void Leave_primaryExpression();

	// $ANTLR start "primaryExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:977:1: primaryExpression returns [Expression value] : (ex1= THIS |ex2= Identifier |ex3= literal |ex4= arrayLiteral |ex5= objectLiteral |lpar= LPAREN ex6= expression RPAREN );
	[GrammarRule("primaryExpression")]
	private ES3Parser.primaryExpression_return primaryExpression()
	{
		Enter_primaryExpression();
		EnterRule("primaryExpression", 9);
		TraceIn("primaryExpression", 9);
		ES3Parser.primaryExpression_return retval = new ES3Parser.primaryExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ex1=null;
		IToken ex2=null;
		IToken lpar=null;
		IToken RPAREN15=null;
		ES3Parser.literal_return ex3 = default(ES3Parser.literal_return);
		ES3Parser.arrayLiteral_return ex4 = default(ES3Parser.arrayLiteral_return);
		ES3Parser.objectLiteral_return ex5 = default(ES3Parser.objectLiteral_return);
		ES3Parser.expression_return ex6 = default(ES3Parser.expression_return);

		object ex1_tree=null;
		object ex2_tree=null;
		object lpar_tree=null;
		object RPAREN15_tree=null;

		try { DebugEnterRule(GrammarFileName, "primaryExpression");
		DebugLocation(977, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:978:2: (ex1= THIS |ex2= Identifier |ex3= literal |ex4= arrayLiteral |ex5= objectLiteral |lpar= LPAREN ex6= expression RPAREN )
			int alt6=6;
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			switch (input.LA(1))
			{
			case THIS:
				{
				alt6=1;
				}
				break;
			case Identifier:
				{
				alt6=2;
				}
				break;
			case DecimalLiteral:
			case FALSE:
			case HexIntegerLiteral:
			case NULL:
			case OctalIntegerLiteral:
			case RegularExpressionLiteral:
			case StringLiteral:
			case TRUE:
				{
				alt6=3;
				}
				break;
			case LBRACK:
				{
				alt6=4;
				}
				break;
			case LBRACE:
				{
				alt6=5;
				}
				break;
			case LPAREN:
				{
				alt6=6;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:978:4: ex1= THIS
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(978, 7);
				ex1=(IToken)Match(input,THIS,Follow._THIS_in_primaryExpression3175); 
				ex1_tree = (object)adaptor.Create(ex1);
				adaptor.AddChild(root_0, ex1_tree);

				DebugLocation(978, 13);
				 retval.value = new Identifier(ex1.Text); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:979:4: ex2= Identifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(979, 7);
				ex2=(IToken)Match(input,Identifier,Follow._Identifier_in_primaryExpression3184); 
				ex2_tree = (object)adaptor.Create(ex2);
				adaptor.AddChild(root_0, ex2_tree);

				DebugLocation(979, 19);
				 retval.value = new Identifier(ex2.Text); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:980:4: ex3= literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(980, 7);
				PushFollow(Follow._literal_in_primaryExpression3193);
				ex3=literal();
				PopFollow();

				adaptor.AddChild(root_0, ex3.Tree);
				DebugLocation(980, 16);
				 retval.value = ex3.value; 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:981:4: ex4= arrayLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(981, 7);
				PushFollow(Follow._arrayLiteral_in_primaryExpression3202);
				ex4=arrayLiteral();
				PopFollow();

				adaptor.AddChild(root_0, ex4.Tree);
				DebugLocation(981, 21);
				 retval.value = ex4.value; 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:982:4: ex5= objectLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(982, 7);
				PushFollow(Follow._objectLiteral_in_primaryExpression3211);
				ex5=objectLiteral();
				PopFollow();

				adaptor.AddChild(root_0, ex5.Tree);
				DebugLocation(982, 22);
				 retval.value = ex5.value; 

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:983:4: lpar= LPAREN ex6= expression RPAREN
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(983, 8);
				lpar=(IToken)Match(input,LPAREN,Follow._LPAREN_in_primaryExpression3220); 
				lpar_tree = (object)adaptor.Create(lpar);
				adaptor.AddChild(root_0, lpar_tree);

				DebugLocation(983, 19);
				PushFollow(Follow._expression_in_primaryExpression3224);
				ex6=expression();
				PopFollow();

				adaptor.AddChild(root_0, ex6.Tree);
				DebugLocation(983, 32);
				RPAREN15=(IToken)Match(input,RPAREN,Follow._RPAREN_in_primaryExpression3227); 
				RPAREN15_tree = (object)adaptor.Create(RPAREN15);
				adaptor.AddChild(root_0, RPAREN15_tree);

				DebugLocation(983, 40);
				 retval.value = ex6.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("primaryExpression", 9);
			LeaveRule("primaryExpression", 9);
			Leave_primaryExpression();
		}
		DebugLocation(984, 1);
		} finally { DebugExitRule(GrammarFileName, "primaryExpression"); }
		return retval;

	}
	// $ANTLR end "primaryExpression"

	public class arrayLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public ArrayDeclaration value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arrayLiteral();
	partial void Leave_arrayLiteral();

	// $ANTLR start "arrayLiteral"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:986:1: arrayLiteral returns [ArrayDeclaration value] : lb= LBRACK (first= arrayItem ( COMMA follow= arrayItem )* )? RBRACK ;
	[GrammarRule("arrayLiteral")]
	private ES3Parser.arrayLiteral_return arrayLiteral()
	{
		Enter_arrayLiteral();
		EnterRule("arrayLiteral", 10);
		TraceIn("arrayLiteral", 10);
		ES3Parser.arrayLiteral_return retval = new ES3Parser.arrayLiteral_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken COMMA16=null;
		IToken RBRACK17=null;
		ES3Parser.arrayItem_return first = default(ES3Parser.arrayItem_return);
		ES3Parser.arrayItem_return follow = default(ES3Parser.arrayItem_return);

		object lb_tree=null;
		object COMMA16_tree=null;
		object RBRACK17_tree=null;


			retval.value = new ArrayDeclaration();

		try { DebugEnterRule(GrammarFileName, "arrayLiteral");
		DebugLocation(986, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:2: (lb= LBRACK (first= arrayItem ( COMMA follow= arrayItem )* )? RBRACK )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:4: lb= LBRACK (first= arrayItem ( COMMA follow= arrayItem )* )? RBRACK
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(990, 6);
			lb=(IToken)Match(input,LBRACK,Follow._LBRACK_in_arrayLiteral3253); 
			lb_tree = (object)adaptor.Create(lb);
			adaptor.AddChild(root_0, lb_tree);

			DebugLocation(990, 14);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:14: (first= arrayItem ( COMMA follow= arrayItem )* )?
			int alt8=2;
			try { DebugEnterSubRule(8);
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			int LA8_0 = input.LA(1);

			if ((LA8_0==ADD||LA8_0==COMMA||LA8_0==DEC||LA8_0==DELETE||LA8_0==DecimalLiteral||LA8_0==FALSE||LA8_0==FUNCTION||LA8_0==HexIntegerLiteral||LA8_0==INC||LA8_0==INV||LA8_0==Identifier||(LA8_0>=LBRACE && LA8_0<=LBRACK)||LA8_0==LPAREN||(LA8_0>=NEW && LA8_0<=NOT)||LA8_0==NULL||LA8_0==OctalIntegerLiteral||LA8_0==RegularExpressionLiteral||LA8_0==SUB||LA8_0==StringLiteral||LA8_0==THIS||LA8_0==TRUE||LA8_0==TYPEOF||LA8_0==VOID))
			{
				alt8=1;
			}
			else if ((LA8_0==RBRACK))
			{
				int LA8_2 = input.LA(2);

				if (((( input.LA(1) == COMMA )||( input.LA(1) == RBRACK ))))
				{
					alt8=1;
				}
			}
			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:16: first= arrayItem ( COMMA follow= arrayItem )*
				{
				DebugLocation(990, 21);
				PushFollow(Follow._arrayItem_in_arrayLiteral3259);
				first=arrayItem();
				PopFollow();

				adaptor.AddChild(root_0, first.Tree);
				DebugLocation(990, 32);
				 if(first.value != null) retval.value.Parameters.Add(first.value); 
				DebugLocation(990, 96);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:96: ( COMMA follow= arrayItem )*
				try { DebugEnterSubRule(7);
				while (true)
				{
					int alt7=2;
					try { DebugEnterDecision(7, decisionCanBacktrack[7]);
					int LA7_0 = input.LA(1);

					if ((LA7_0==COMMA))
					{
						alt7=1;
					}


					} finally { DebugExitDecision(7); }
					switch ( alt7 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:990:98: COMMA follow= arrayItem
						{
						DebugLocation(990, 98);
						COMMA16=(IToken)Match(input,COMMA,Follow._COMMA_in_arrayLiteral3265); 
						COMMA16_tree = (object)adaptor.Create(COMMA16);
						adaptor.AddChild(root_0, COMMA16_tree);

						DebugLocation(990, 110);
						PushFollow(Follow._arrayItem_in_arrayLiteral3269);
						follow=arrayItem();
						PopFollow();

						adaptor.AddChild(root_0, follow.Tree);
						DebugLocation(990, 122);
						 if(follow.value != null) retval.value.Parameters.Add(follow.value); 

						}
						break;

					default:
						goto loop7;
					}
				}

				loop7:
					;

				} finally { DebugExitSubRule(7); }


				}
				break;

			}
			} finally { DebugExitSubRule(8); }

			DebugLocation(990, 193);
			RBRACK17=(IToken)Match(input,RBRACK,Follow._RBRACK_in_arrayLiteral3279); 
			RBRACK17_tree = (object)adaptor.Create(RBRACK17);
			adaptor.AddChild(root_0, RBRACK17_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("arrayLiteral", 10);
			LeaveRule("arrayLiteral", 10);
			Leave_arrayLiteral();
		}
		DebugLocation(992, 1);
		} finally { DebugExitRule(GrammarFileName, "arrayLiteral"); }
		return retval;

	}
	// $ANTLR end "arrayLiteral"

	public class arrayItem_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arrayItem();
	partial void Leave_arrayItem();

	// $ANTLR start "arrayItem"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:994:1: arrayItem returns [Statement value] : (expr= assignmentExpression |{...}?|{...}?) ;
	[GrammarRule("arrayItem")]
	private ES3Parser.arrayItem_return arrayItem()
	{
		Enter_arrayItem();
		EnterRule("arrayItem", 11);
		TraceIn("arrayItem", 11);
		ES3Parser.arrayItem_return retval = new ES3Parser.arrayItem_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.assignmentExpression_return expr = default(ES3Parser.assignmentExpression_return);


		try { DebugEnterRule(GrammarFileName, "arrayItem");
		DebugLocation(994, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:2: ( (expr= assignmentExpression |{...}?|{...}?) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:4: (expr= assignmentExpression |{...}?|{...}?)
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(995, 4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:4: (expr= assignmentExpression |{...}?|{...}?)
			int alt9=3;
			try { DebugEnterSubRule(9);
			try { DebugEnterDecision(9, decisionCanBacktrack[9]);
			switch (input.LA(1))
			{
			case ADD:
			case DEC:
			case DELETE:
			case DecimalLiteral:
			case FALSE:
			case FUNCTION:
			case HexIntegerLiteral:
			case INC:
			case INV:
			case Identifier:
			case LBRACE:
			case LBRACK:
			case LPAREN:
			case NEW:
			case NOT:
			case NULL:
			case OctalIntegerLiteral:
			case RegularExpressionLiteral:
			case SUB:
			case StringLiteral:
			case THIS:
			case TRUE:
			case TYPEOF:
			case VOID:
				{
				alt9=1;
				}
				break;
			case COMMA:
				{
				int LA9_2 = input.LA(2);

				if ((( input.LA(1) == COMMA )))
				{
					alt9=2;
				}
				else if ((( input.LA(1) == RBRACK )))
				{
					alt9=3;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 2, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case RBRACK:
				{
				int LA9_3 = input.LA(2);

				if ((( input.LA(1) == COMMA )))
				{
					alt9=2;
				}
				else if ((( input.LA(1) == RBRACK )))
				{
					alt9=3;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 3, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(9); }
			switch (alt9)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:6: expr= assignmentExpression
				{
				DebugLocation(995, 10);
				PushFollow(Follow._assignmentExpression_in_arrayItem3300);
				expr=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, expr.Tree);
				DebugLocation(995, 33);
				 retval.value = expr.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:60: {...}?
				{
				DebugLocation(995, 60);
				if (!(( input.LA(1) == COMMA )))
				{
					throw new FailedPredicateException(input, "arrayItem", " input.LA(1) == COMMA ");
				}
				DebugLocation(995, 86);
				 retval.value = new Identifier("undefined"); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:995:130: {...}?
				{
				DebugLocation(995, 130);
				if (!(( input.LA(1) == RBRACK )))
				{
					throw new FailedPredicateException(input, "arrayItem", " input.LA(1) == RBRACK ");
				}
				DebugLocation(995, 157);
				 retval.value = null; 

				}
				break;

			}
			} finally { DebugExitSubRule(9); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("arrayItem", 11);
			LeaveRule("arrayItem", 11);
			Leave_arrayItem();
		}
		DebugLocation(997, 1);
		} finally { DebugExitRule(GrammarFileName, "arrayItem"); }
		return retval;

	}
	// $ANTLR end "arrayItem"

	public class objectLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public JsonExpression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_objectLiteral();
	partial void Leave_objectLiteral();

	// $ANTLR start "objectLiteral"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:999:1: objectLiteral returns [JsonExpression value] : lb= LBRACE (first= propertyAssignment ( COMMA follow= propertyAssignment )* )? RBRACE ;
	[GrammarRule("objectLiteral")]
	private ES3Parser.objectLiteral_return objectLiteral()
	{
		Enter_objectLiteral();
		EnterRule("objectLiteral", 12);
		TraceIn("objectLiteral", 12);
		ES3Parser.objectLiteral_return retval = new ES3Parser.objectLiteral_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken COMMA18=null;
		IToken RBRACE19=null;
		ES3Parser.propertyAssignment_return first = default(ES3Parser.propertyAssignment_return);
		ES3Parser.propertyAssignment_return follow = default(ES3Parser.propertyAssignment_return);

		object lb_tree=null;
		object COMMA18_tree=null;
		object RBRACE19_tree=null;


			retval.value = new JsonExpression();

		try { DebugEnterRule(GrammarFileName, "objectLiteral");
		DebugLocation(999, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:2: (lb= LBRACE (first= propertyAssignment ( COMMA follow= propertyAssignment )* )? RBRACE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:4: lb= LBRACE (first= propertyAssignment ( COMMA follow= propertyAssignment )* )? RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1003, 6);
			lb=(IToken)Match(input,LBRACE,Follow._LBRACE_in_objectLiteral3341); 
			lb_tree = (object)adaptor.Create(lb);
			adaptor.AddChild(root_0, lb_tree);

			DebugLocation(1003, 14);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:14: (first= propertyAssignment ( COMMA follow= propertyAssignment )* )?
			int alt11=2;
			try { DebugEnterSubRule(11);
			try { DebugEnterDecision(11, decisionCanBacktrack[11]);
			int LA11_0 = input.LA(1);

			if ((LA11_0==DecimalLiteral||LA11_0==HexIntegerLiteral||LA11_0==Identifier||LA11_0==OctalIntegerLiteral||LA11_0==StringLiteral))
			{
				alt11=1;
			}
			} finally { DebugExitDecision(11); }
			switch (alt11)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:16: first= propertyAssignment ( COMMA follow= propertyAssignment )*
				{
				DebugLocation(1003, 21);
				PushFollow(Follow._propertyAssignment_in_objectLiteral3347);
				first=propertyAssignment();
				PopFollow();

				adaptor.AddChild(root_0, first.Tree);
				DebugLocation(1003, 41);
				 retval.value.Push(first.value); 
				DebugLocation(1003, 72);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:72: ( COMMA follow= propertyAssignment )*
				try { DebugEnterSubRule(10);
				while (true)
				{
					int alt10=2;
					try { DebugEnterDecision(10, decisionCanBacktrack[10]);
					int LA10_0 = input.LA(1);

					if ((LA10_0==COMMA))
					{
						alt10=1;
					}


					} finally { DebugExitDecision(10); }
					switch ( alt10 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1003:74: COMMA follow= propertyAssignment
						{
						DebugLocation(1003, 74);
						COMMA18=(IToken)Match(input,COMMA,Follow._COMMA_in_objectLiteral3354); 
						COMMA18_tree = (object)adaptor.Create(COMMA18);
						adaptor.AddChild(root_0, COMMA18_tree);

						DebugLocation(1003, 86);
						PushFollow(Follow._propertyAssignment_in_objectLiteral3358);
						follow=propertyAssignment();
						PopFollow();

						adaptor.AddChild(root_0, follow.Tree);
						DebugLocation(1003, 106);
						 retval.value.Push(follow.value); 

						}
						break;

					default:
						goto loop10;
					}
				}

				loop10:
					;

				} finally { DebugExitSubRule(10); }


				}
				break;

			}
			} finally { DebugExitSubRule(11); }

			DebugLocation(1003, 143);
			RBRACE19=(IToken)Match(input,RBRACE,Follow._RBRACE_in_objectLiteral3368); 
			RBRACE19_tree = (object)adaptor.Create(RBRACE19);
			adaptor.AddChild(root_0, RBRACE19_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("objectLiteral", 12);
			LeaveRule("objectLiteral", 12);
			Leave_objectLiteral();
		}
		DebugLocation(1004, 1);
		} finally { DebugExitRule(GrammarFileName, "objectLiteral"); }
		return retval;

	}
	// $ANTLR end "objectLiteral"

	public class propertyAssignment_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public PropertyDeclarationExpression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_propertyAssignment();
	partial void Leave_propertyAssignment();

	// $ANTLR start "propertyAssignment"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1006:1: propertyAssignment returns [PropertyDeclarationExpression value] : (acc= accessor prop2= propertyName (parameters= formalParameterList )? statements= functionBody |prop1= propertyName COLON ass= assignmentExpression );
	[GrammarRule("propertyAssignment")]
	private ES3Parser.propertyAssignment_return propertyAssignment()
	{
		Enter_propertyAssignment();
		EnterRule("propertyAssignment", 13);
		TraceIn("propertyAssignment", 13);
		ES3Parser.propertyAssignment_return retval = new ES3Parser.propertyAssignment_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken COLON20=null;
		ES3Parser.accessor_return acc = default(ES3Parser.accessor_return);
		ES3Parser.propertyName_return prop2 = default(ES3Parser.propertyName_return);
		ES3Parser.formalParameterList_return parameters = default(ES3Parser.formalParameterList_return);
		ES3Parser.functionBody_return statements = default(ES3Parser.functionBody_return);
		ES3Parser.propertyName_return prop1 = default(ES3Parser.propertyName_return);
		ES3Parser.assignmentExpression_return ass = default(ES3Parser.assignmentExpression_return);

		object COLON20_tree=null;


			retval.value = new PropertyDeclarationExpression();
			FunctionExpression func=new FunctionExpression();

		try { DebugEnterRule(GrammarFileName, "propertyAssignment");
		DebugLocation(1006, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1011:2: (acc= accessor prop2= propertyName (parameters= formalParameterList )? statements= functionBody |prop1= propertyName COLON ass= assignmentExpression )
			int alt13=2;
			try { DebugEnterDecision(13, decisionCanBacktrack[13]);
			int LA13_0 = input.LA(1);

			if ((LA13_0==Identifier))
			{
				int LA13_1 = input.LA(2);

				if ((LA13_1==DecimalLiteral||LA13_1==HexIntegerLiteral||LA13_1==Identifier||LA13_1==OctalIntegerLiteral||LA13_1==StringLiteral))
				{
					alt13=1;
				}
				else if ((LA13_1==COLON))
				{
					alt13=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 13, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else if ((LA13_0==DecimalLiteral||LA13_0==HexIntegerLiteral||LA13_0==OctalIntegerLiteral||LA13_0==StringLiteral))
			{
				alt13=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 13, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(13); }
			switch (alt13)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1011:4: acc= accessor prop2= propertyName (parameters= formalParameterList )? statements= functionBody
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1011, 7);
				PushFollow(Follow._accessor_in_propertyAssignment3391);
				acc=accessor();
				PopFollow();

				adaptor.AddChild(root_0, acc.Tree);
				DebugLocation(1011, 17);
				 retval.value.Mode=acc.value; 
				DebugLocation(1011, 44);
				 retval.value.Expression=func; 
				DebugLocation(1011, 77);
				PushFollow(Follow._propertyName_in_propertyAssignment3399);
				prop2=propertyName();
				PopFollow();

				adaptor.AddChild(root_0, prop2.Tree);
				DebugLocation(1011, 91);
				 retval.value.Name=func.Name=prop2.value; 
				DebugLocation(1011, 130);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1011:130: (parameters= formalParameterList )?
				int alt12=2;
				try { DebugEnterSubRule(12);
				try { DebugEnterDecision(12, decisionCanBacktrack[12]);
				int LA12_0 = input.LA(1);

				if ((LA12_0==LPAREN))
				{
					alt12=1;
				}
				} finally { DebugExitDecision(12); }
				switch (alt12)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1011:131: parameters= formalParameterList
					{
					DebugLocation(1011, 141);
					PushFollow(Follow._formalParameterList_in_propertyAssignment3406);
					parameters=formalParameterList();
					PopFollow();

					adaptor.AddChild(root_0, parameters.Tree);
					DebugLocation(1011, 162);
					 func.Parameters.AddRange(parameters.value); 

					}
					break;

				}
				} finally { DebugExitSubRule(12); }

				DebugLocation(1011, 222);
				PushFollow(Follow._functionBody_in_propertyAssignment3414);
				statements=functionBody();
				PopFollow();

				adaptor.AddChild(root_0, statements.Tree);
				DebugLocation(1011, 236);
				 func.Statement=statements.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1012:4: prop1= propertyName COLON ass= assignmentExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1012, 9);
				PushFollow(Follow._propertyName_in_propertyAssignment3424);
				prop1=propertyName();
				PopFollow();

				adaptor.AddChild(root_0, prop1.Tree);
				DebugLocation(1012, 23);
				 retval.value.Name=prop1.value; 
				DebugLocation(1012, 52);
				COLON20=(IToken)Match(input,COLON,Follow._COLON_in_propertyAssignment3428); 
				COLON20_tree = (object)adaptor.Create(COLON20);
				adaptor.AddChild(root_0, COLON20_tree);

				DebugLocation(1012, 61);
				PushFollow(Follow._assignmentExpression_in_propertyAssignment3432);
				ass=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, ass.Tree);
				DebugLocation(1012, 83);
				 retval.value.Expression=ass.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("propertyAssignment", 13);
			LeaveRule("propertyAssignment", 13);
			Leave_propertyAssignment();
		}
		DebugLocation(1013, 1);
		} finally { DebugExitRule(GrammarFileName, "propertyAssignment"); }
		return retval;

	}
	// $ANTLR end "propertyAssignment"

	public class accessor_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public PropertyExpressionType value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_accessor();
	partial void Leave_accessor();

	// $ANTLR start "accessor"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1015:1: accessor returns [PropertyExpressionType value] : ex1= Identifier {...}? =>;
	[GrammarRule("accessor")]
	private ES3Parser.accessor_return accessor()
	{
		Enter_accessor();
		EnterRule("accessor", 14);
		TraceIn("accessor", 14);
		ES3Parser.accessor_return retval = new ES3Parser.accessor_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ex1=null;

		object ex1_tree=null;

		try { DebugEnterRule(GrammarFileName, "accessor");
		DebugLocation(1015, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1016:2: (ex1= Identifier {...}? =>)
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1016:4: ex1= Identifier {...}? =>
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1016, 7);
			ex1=(IToken)Match(input,Identifier,Follow._Identifier_in_accessor3452); 
			ex1_tree = (object)adaptor.Create(ex1);
			adaptor.AddChild(root_0, ex1_tree);

			DebugLocation(1016, 19);
			if (!(( ex1.Text=="get" || ex1.Text=="set" )))
			{
				throw new FailedPredicateException(input, "accessor", " ex1.Text==\"get\" || ex1.Text==\"set\" ");
			}
			DebugLocation(1016, 61);
			 if(ex1.Text=="get") retval.value = PropertyExpressionType.Get; if(ex1.Text=="set") retval.value =PropertyExpressionType.Set; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("accessor", 14);
			LeaveRule("accessor", 14);
			Leave_accessor();
		}
		DebugLocation(1017, 1);
		} finally { DebugExitRule(GrammarFileName, "accessor"); }
		return retval;

	}
	// $ANTLR end "accessor"

	public class propertyName_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public string value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_propertyName();
	partial void Leave_propertyName();

	// $ANTLR start "propertyName"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1019:1: propertyName returns [string value] : (ex1= Identifier |ex2= StringLiteral |ex3= numericLiteral );
	[GrammarRule("propertyName")]
	private ES3Parser.propertyName_return propertyName()
	{
		Enter_propertyName();
		EnterRule("propertyName", 15);
		TraceIn("propertyName", 15);
		ES3Parser.propertyName_return retval = new ES3Parser.propertyName_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ex1=null;
		IToken ex2=null;
		ES3Parser.numericLiteral_return ex3 = default(ES3Parser.numericLiteral_return);

		object ex1_tree=null;
		object ex2_tree=null;

		try { DebugEnterRule(GrammarFileName, "propertyName");
		DebugLocation(1019, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1020:2: (ex1= Identifier |ex2= StringLiteral |ex3= numericLiteral )
			int alt14=3;
			try { DebugEnterDecision(14, decisionCanBacktrack[14]);
			switch (input.LA(1))
			{
			case Identifier:
				{
				alt14=1;
				}
				break;
			case StringLiteral:
				{
				alt14=2;
				}
				break;
			case DecimalLiteral:
			case HexIntegerLiteral:
			case OctalIntegerLiteral:
				{
				alt14=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 14, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(14); }
			switch (alt14)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1020:4: ex1= Identifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1020, 7);
				ex1=(IToken)Match(input,Identifier,Follow._Identifier_in_propertyName3474); 
				ex1_tree = (object)adaptor.Create(ex1);
				adaptor.AddChild(root_0, ex1_tree);

				DebugLocation(1020, 19);
				 retval.value = ex1.Text; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1021:4: ex2= StringLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1021, 7);
				ex2=(IToken)Match(input,StringLiteral,Follow._StringLiteral_in_propertyName3483); 
				ex2_tree = (object)adaptor.Create(ex2);
				adaptor.AddChild(root_0, ex2_tree);

				DebugLocation(1021, 22);
				 retval.value = extractString(ex2.Text); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1022:4: ex3= numericLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1022, 7);
				PushFollow(Follow._numericLiteral_in_propertyName3492);
				ex3=numericLiteral();
				PopFollow();

				adaptor.AddChild(root_0, ex3.Tree);
				DebugLocation(1022, 23);
				 retval.value = ex3.value.ToString(); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("propertyName", 15);
			LeaveRule("propertyName", 15);
			Leave_propertyName();
		}
		DebugLocation(1023, 1);
		} finally { DebugExitRule(GrammarFileName, "propertyName"); }
		return retval;

	}
	// $ANTLR end "propertyName"

	public class memberExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_memberExpression();
	partial void Leave_memberExpression();

	// $ANTLR start "memberExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1034:1: memberExpression returns [Expression value] : (prim= primaryExpression |func= functionExpression |exp= newExpression );
	[GrammarRule("memberExpression")]
	private ES3Parser.memberExpression_return memberExpression()
	{
		Enter_memberExpression();
		EnterRule("memberExpression", 16);
		TraceIn("memberExpression", 16);
		ES3Parser.memberExpression_return retval = new ES3Parser.memberExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.primaryExpression_return prim = default(ES3Parser.primaryExpression_return);
		ES3Parser.functionExpression_return func = default(ES3Parser.functionExpression_return);
		ES3Parser.newExpression_return exp = default(ES3Parser.newExpression_return);


		try { DebugEnterRule(GrammarFileName, "memberExpression");
		DebugLocation(1034, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1035:2: (prim= primaryExpression |func= functionExpression |exp= newExpression )
			int alt15=3;
			try { DebugEnterDecision(15, decisionCanBacktrack[15]);
			switch (input.LA(1))
			{
			case DecimalLiteral:
			case FALSE:
			case HexIntegerLiteral:
			case Identifier:
			case LBRACE:
			case LBRACK:
			case LPAREN:
			case NULL:
			case OctalIntegerLiteral:
			case RegularExpressionLiteral:
			case StringLiteral:
			case THIS:
			case TRUE:
				{
				alt15=1;
				}
				break;
			case FUNCTION:
				{
				alt15=2;
				}
				break;
			case NEW:
				{
				alt15=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 15, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(15); }
			switch (alt15)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1035:4: prim= primaryExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1035, 8);
				PushFollow(Follow._primaryExpression_in_memberExpression3518);
				prim=primaryExpression();
				PopFollow();

				adaptor.AddChild(root_0, prim.Tree);
				DebugLocation(1035, 27);
				 retval.value = prim.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1036:4: func= functionExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1036, 8);
				PushFollow(Follow._functionExpression_in_memberExpression3527);
				func=functionExpression();
				PopFollow();

				adaptor.AddChild(root_0, func.Tree);
				DebugLocation(1036, 28);
				 retval.value = func.value; 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1037:4: exp= newExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1037, 7);
				PushFollow(Follow._newExpression_in_memberExpression3536);
				exp=newExpression();
				PopFollow();

				adaptor.AddChild(root_0, exp.Tree);
				DebugLocation(1037, 22);
				 retval.value = exp.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("memberExpression", 16);
			LeaveRule("memberExpression", 16);
			Leave_memberExpression();
		}
		DebugLocation(1038, 1);
		} finally { DebugExitRule(GrammarFileName, "memberExpression"); }
		return retval;

	}
	// $ANTLR end "memberExpression"

	public class newExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public NewExpression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_newExpression();
	partial void Leave_newExpression();

	// $ANTLR start "newExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1040:1: newExpression returns [NewExpression value] : NEW first= memberExpression ;
	[GrammarRule("newExpression")]
	private ES3Parser.newExpression_return newExpression()
	{
		Enter_newExpression();
		EnterRule("newExpression", 17);
		TraceIn("newExpression", 17);
		ES3Parser.newExpression_return retval = new ES3Parser.newExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken NEW21=null;
		ES3Parser.memberExpression_return first = default(ES3Parser.memberExpression_return);

		object NEW21_tree=null;

		try { DebugEnterRule(GrammarFileName, "newExpression");
		DebugLocation(1040, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1041:2: ( NEW first= memberExpression )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1041:4: NEW first= memberExpression
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1041, 7);
			NEW21=(IToken)Match(input,NEW,Follow._NEW_in_newExpression3553); 
			NEW21_tree = (object)adaptor.Create(NEW21);
			root_0 = (object)adaptor.BecomeRoot(NEW21_tree, root_0);

			DebugLocation(1041, 14);
			PushFollow(Follow._memberExpression_in_newExpression3558);
			first=memberExpression();
			PopFollow();

			adaptor.AddChild(root_0, first.Tree);
			DebugLocation(1041, 32);
			 retval.value = new NewExpression(first.value); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("newExpression", 17);
			LeaveRule("newExpression", 17);
			Leave_newExpression();
		}
		DebugLocation(1042, 1);
		} finally { DebugExitRule(GrammarFileName, "newExpression"); }
		return retval;

	}
	// $ANTLR end "newExpression"

	public class arguments_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public List<Expression> value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arguments();
	partial void Leave_arguments();

	// $ANTLR start "arguments"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1044:1: arguments returns [List<Expression> value] : LPAREN (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RPAREN ;
	[GrammarRule("arguments")]
	private ES3Parser.arguments_return arguments()
	{
		Enter_arguments();
		EnterRule("arguments", 18);
		TraceIn("arguments", 18);
		ES3Parser.arguments_return retval = new ES3Parser.arguments_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LPAREN22=null;
		IToken COMMA23=null;
		IToken RPAREN24=null;
		ES3Parser.assignmentExpression_return first = default(ES3Parser.assignmentExpression_return);
		ES3Parser.assignmentExpression_return follow = default(ES3Parser.assignmentExpression_return);

		object LPAREN22_tree=null;
		object COMMA23_tree=null;
		object RPAREN24_tree=null;


			retval.value = new List<Expression>();

		try { DebugEnterRule(GrammarFileName, "arguments");
		DebugLocation(1044, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:2: ( LPAREN (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RPAREN )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:4: LPAREN (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RPAREN
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1048, 4);
			LPAREN22=(IToken)Match(input,LPAREN,Follow._LPAREN_in_arguments3581); 
			LPAREN22_tree = (object)adaptor.Create(LPAREN22);
			adaptor.AddChild(root_0, LPAREN22_tree);

			DebugLocation(1048, 11);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:11: (first= assignmentExpression ( COMMA follow= assignmentExpression )* )?
			int alt17=2;
			try { DebugEnterSubRule(17);
			try { DebugEnterDecision(17, decisionCanBacktrack[17]);
			int LA17_0 = input.LA(1);

			if ((LA17_0==ADD||LA17_0==DEC||LA17_0==DELETE||LA17_0==DecimalLiteral||LA17_0==FALSE||LA17_0==FUNCTION||LA17_0==HexIntegerLiteral||LA17_0==INC||LA17_0==INV||LA17_0==Identifier||(LA17_0>=LBRACE && LA17_0<=LBRACK)||LA17_0==LPAREN||(LA17_0>=NEW && LA17_0<=NOT)||LA17_0==NULL||LA17_0==OctalIntegerLiteral||LA17_0==RegularExpressionLiteral||LA17_0==SUB||LA17_0==StringLiteral||LA17_0==THIS||LA17_0==TRUE||LA17_0==TYPEOF||LA17_0==VOID))
			{
				alt17=1;
			}
			} finally { DebugExitDecision(17); }
			switch (alt17)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:13: first= assignmentExpression ( COMMA follow= assignmentExpression )*
				{
				DebugLocation(1048, 18);
				PushFollow(Follow._assignmentExpression_in_arguments3587);
				first=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, first.Tree);
				DebugLocation(1048, 40);
				 retval.value.Add(first.value); 
				DebugLocation(1048, 69);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:69: ( COMMA follow= assignmentExpression )*
				try { DebugEnterSubRule(16);
				while (true)
				{
					int alt16=2;
					try { DebugEnterDecision(16, decisionCanBacktrack[16]);
					int LA16_0 = input.LA(1);

					if ((LA16_0==COMMA))
					{
						alt16=1;
					}


					} finally { DebugExitDecision(16); }
					switch ( alt16 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1048:71: COMMA follow= assignmentExpression
						{
						DebugLocation(1048, 71);
						COMMA23=(IToken)Match(input,COMMA,Follow._COMMA_in_arguments3593); 
						COMMA23_tree = (object)adaptor.Create(COMMA23);
						adaptor.AddChild(root_0, COMMA23_tree);

						DebugLocation(1048, 83);
						PushFollow(Follow._assignmentExpression_in_arguments3597);
						follow=assignmentExpression();
						PopFollow();

						adaptor.AddChild(root_0, follow.Tree);
						DebugLocation(1048, 105);
						 retval.value.Add(follow.value); 

						}
						break;

					default:
						goto loop16;
					}
				}

				loop16:
					;

				} finally { DebugExitSubRule(16); }


				}
				break;

			}
			} finally { DebugExitSubRule(17); }

			DebugLocation(1048, 140);
			RPAREN24=(IToken)Match(input,RPAREN,Follow._RPAREN_in_arguments3606); 
			RPAREN24_tree = (object)adaptor.Create(RPAREN24);
			adaptor.AddChild(root_0, RPAREN24_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("arguments", 18);
			LeaveRule("arguments", 18);
			Leave_arguments();
		}
		DebugLocation(1050, 1);
		} finally { DebugExitRule(GrammarFileName, "arguments"); }
		return retval;

	}
	// $ANTLR end "arguments"

	public class generics_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public List<Expression> value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_generics();
	partial void Leave_generics();

	// $ANTLR start "generics"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1052:1: generics returns [List<Expression> value] : LBRACE (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RBRACE ;
	[GrammarRule("generics")]
	private ES3Parser.generics_return generics()
	{
		Enter_generics();
		EnterRule("generics", 19);
		TraceIn("generics", 19);
		ES3Parser.generics_return retval = new ES3Parser.generics_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LBRACE25=null;
		IToken COMMA26=null;
		IToken RBRACE27=null;
		ES3Parser.assignmentExpression_return first = default(ES3Parser.assignmentExpression_return);
		ES3Parser.assignmentExpression_return follow = default(ES3Parser.assignmentExpression_return);

		object LBRACE25_tree=null;
		object COMMA26_tree=null;
		object RBRACE27_tree=null;


			retval.value = new List<Expression>();

		try { DebugEnterRule(GrammarFileName, "generics");
		DebugLocation(1052, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:2: ( LBRACE (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RBRACE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:4: LBRACE (first= assignmentExpression ( COMMA follow= assignmentExpression )* )? RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1056, 4);
			LBRACE25=(IToken)Match(input,LBRACE,Follow._LBRACE_in_generics3628); 
			LBRACE25_tree = (object)adaptor.Create(LBRACE25);
			adaptor.AddChild(root_0, LBRACE25_tree);

			DebugLocation(1056, 11);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:11: (first= assignmentExpression ( COMMA follow= assignmentExpression )* )?
			int alt19=2;
			try { DebugEnterSubRule(19);
			try { DebugEnterDecision(19, decisionCanBacktrack[19]);
			int LA19_0 = input.LA(1);

			if ((LA19_0==ADD||LA19_0==DEC||LA19_0==DELETE||LA19_0==DecimalLiteral||LA19_0==FALSE||LA19_0==FUNCTION||LA19_0==HexIntegerLiteral||LA19_0==INC||LA19_0==INV||LA19_0==Identifier||(LA19_0>=LBRACE && LA19_0<=LBRACK)||LA19_0==LPAREN||(LA19_0>=NEW && LA19_0<=NOT)||LA19_0==NULL||LA19_0==OctalIntegerLiteral||LA19_0==RegularExpressionLiteral||LA19_0==SUB||LA19_0==StringLiteral||LA19_0==THIS||LA19_0==TRUE||LA19_0==TYPEOF||LA19_0==VOID))
			{
				alt19=1;
			}
			} finally { DebugExitDecision(19); }
			switch (alt19)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:13: first= assignmentExpression ( COMMA follow= assignmentExpression )*
				{
				DebugLocation(1056, 18);
				PushFollow(Follow._assignmentExpression_in_generics3634);
				first=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, first.Tree);
				DebugLocation(1056, 40);
				 retval.value.Add(first.value); 
				DebugLocation(1056, 69);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:69: ( COMMA follow= assignmentExpression )*
				try { DebugEnterSubRule(18);
				while (true)
				{
					int alt18=2;
					try { DebugEnterDecision(18, decisionCanBacktrack[18]);
					int LA18_0 = input.LA(1);

					if ((LA18_0==COMMA))
					{
						alt18=1;
					}


					} finally { DebugExitDecision(18); }
					switch ( alt18 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1056:71: COMMA follow= assignmentExpression
						{
						DebugLocation(1056, 71);
						COMMA26=(IToken)Match(input,COMMA,Follow._COMMA_in_generics3640); 
						COMMA26_tree = (object)adaptor.Create(COMMA26);
						adaptor.AddChild(root_0, COMMA26_tree);

						DebugLocation(1056, 83);
						PushFollow(Follow._assignmentExpression_in_generics3644);
						follow=assignmentExpression();
						PopFollow();

						adaptor.AddChild(root_0, follow.Tree);
						DebugLocation(1056, 105);
						 retval.value.Add(follow.value); 

						}
						break;

					default:
						goto loop18;
					}
				}

				loop18:
					;

				} finally { DebugExitSubRule(18); }


				}
				break;

			}
			} finally { DebugExitSubRule(19); }

			DebugLocation(1056, 140);
			RBRACE27=(IToken)Match(input,RBRACE,Follow._RBRACE_in_generics3653); 
			RBRACE27_tree = (object)adaptor.Create(RBRACE27);
			adaptor.AddChild(root_0, RBRACE27_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("generics", 19);
			LeaveRule("generics", 19);
			Leave_generics();
		}
		DebugLocation(1058, 1);
		} finally { DebugExitRule(GrammarFileName, "generics"); }
		return retval;

	}
	// $ANTLR end "generics"

	public class leftHandSideExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_leftHandSideExpression();
	partial void Leave_leftHandSideExpression();

	// $ANTLR start "leftHandSideExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1061:1: leftHandSideExpression returns [Expression value] : (mem= memberExpression ) ( (gen= generics )? arg= arguments | LBRACK exp= expression RBRACK | DOT id= Identifier )* ;
	[GrammarRule("leftHandSideExpression")]
	private ES3Parser.leftHandSideExpression_return leftHandSideExpression()
	{
		Enter_leftHandSideExpression();
		EnterRule("leftHandSideExpression", 20);
		TraceIn("leftHandSideExpression", 20);
		ES3Parser.leftHandSideExpression_return retval = new ES3Parser.leftHandSideExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken id=null;
		IToken LBRACK28=null;
		IToken RBRACK29=null;
		IToken DOT30=null;
		ES3Parser.memberExpression_return mem = default(ES3Parser.memberExpression_return);
		ES3Parser.generics_return gen = default(ES3Parser.generics_return);
		ES3Parser.arguments_return arg = default(ES3Parser.arguments_return);
		ES3Parser.expression_return exp = default(ES3Parser.expression_return);

		object id_tree=null;
		object LBRACK28_tree=null;
		object RBRACK29_tree=null;
		object DOT30_tree=null;


			List<Expression> gens = new List<Expression>();

		try { DebugEnterRule(GrammarFileName, "leftHandSideExpression");
		DebugLocation(1061, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1068:2: ( (mem= memberExpression ) ( (gen= generics )? arg= arguments | LBRACK exp= expression RBRACK | DOT id= Identifier )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1069:2: (mem= memberExpression ) ( (gen= generics )? arg= arguments | LBRACK exp= expression RBRACK | DOT id= Identifier )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1069, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1069:2: (mem= memberExpression )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1070:3: mem= memberExpression
			{
			DebugLocation(1070, 6);
			PushFollow(Follow._memberExpression_in_leftHandSideExpression3689);
			mem=memberExpression();
			PopFollow();

			adaptor.AddChild(root_0, mem.Tree);
			DebugLocation(1070, 24);
			 retval.value = mem.value; 

			}

			DebugLocation(1072, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1072:2: ( (gen= generics )? arg= arguments | LBRACK exp= expression RBRACK | DOT id= Identifier )*
			try { DebugEnterSubRule(21);
			while (true)
			{
				int alt21=4;
				try { DebugEnterDecision(21, decisionCanBacktrack[21]);
				switch (input.LA(1))
				{
				case LBRACE:
				case LPAREN:
					{
					alt21=1;
					}
					break;
				case LBRACK:
					{
					alt21=2;
					}
					break;
				case DOT:
					{
					alt21=3;
					}
					break;

				}

				} finally { DebugExitDecision(21); }
				switch ( alt21 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1073:3: (gen= generics )? arg= arguments
					{
					DebugLocation(1073, 3);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1073:3: (gen= generics )?
					int alt20=2;
					try { DebugEnterSubRule(20);
					try { DebugEnterDecision(20, decisionCanBacktrack[20]);
					int LA20_0 = input.LA(1);

					if ((LA20_0==LBRACE))
					{
						alt20=1;
					}
					} finally { DebugExitDecision(20); }
					switch (alt20)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1073:4: gen= generics
						{
						DebugLocation(1073, 7);
						PushFollow(Follow._generics_in_leftHandSideExpression3705);
						gen=generics();
						PopFollow();

						adaptor.AddChild(root_0, gen.Tree);
						DebugLocation(1073, 17);
						 gens = gen.value; 

						}
						break;

					}
					} finally { DebugExitSubRule(20); }

					DebugLocation(1073, 45);
					PushFollow(Follow._arguments_in_leftHandSideExpression3714);
					arg=arguments();
					PopFollow();

					adaptor.AddChild(root_0, arg.Tree);
					DebugLocation(1073, 56);
					 if(retval.value is NewExpression) { ((NewExpression)retval.value).Generics = gens; ((NewExpression)retval.value).Arguments = arg.value; retval.value = new MemberExpression(retval.value, null); } else { retval.value = new MemberExpression(new MethodCall(arg.value) { Generics = gens }, retval.value); } 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1075:5: LBRACK exp= expression RBRACK
					{
					DebugLocation(1075, 5);
					LBRACK28=(IToken)Match(input,LBRACK,Follow._LBRACK_in_leftHandSideExpression3725); 
					LBRACK28_tree = (object)adaptor.Create(LBRACK28);
					adaptor.AddChild(root_0, LBRACK28_tree);

					DebugLocation(1075, 15);
					PushFollow(Follow._expression_in_leftHandSideExpression3729);
					exp=expression();
					PopFollow();

					adaptor.AddChild(root_0, exp.Tree);
					DebugLocation(1075, 27);
					RBRACK29=(IToken)Match(input,RBRACK,Follow._RBRACK_in_leftHandSideExpression3731); 
					RBRACK29_tree = (object)adaptor.Create(RBRACK29);
					adaptor.AddChild(root_0, RBRACK29_tree);

					DebugLocation(1075, 34);
					 retval.value = new MemberExpression(new Indexer(exp.value), retval.value); 

					}
					break;
				case 3:
					DebugEnterAlt(3);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1077:5: DOT id= Identifier
					{
					DebugLocation(1077, 5);
					DOT30=(IToken)Match(input,DOT,Follow._DOT_in_leftHandSideExpression3744); 
					DOT30_tree = (object)adaptor.Create(DOT30);
					adaptor.AddChild(root_0, DOT30_tree);

					DebugLocation(1077, 11);
					id=(IToken)Match(input,Identifier,Follow._Identifier_in_leftHandSideExpression3748); 
					id_tree = (object)adaptor.Create(id);
					adaptor.AddChild(root_0, id_tree);

					DebugLocation(1077, 23);
					  if(retval.value is NewExpression) { ((NewExpression)retval.value).Expression = new MemberExpression(new PropertyExpression(id.Text), ((NewExpression)retval.value).Expression); } else { retval.value = new MemberExpression(new PropertyExpression(id.Text), retval.value); } 

					}
					break;

				default:
					goto loop21;
				}
			}

			loop21:
				;

			} finally { DebugExitSubRule(21); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);


				retval.value.Source = ExtractSourceCode((CommonToken)retval.Start, (CommonToken)retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("leftHandSideExpression", 20);
			LeaveRule("leftHandSideExpression", 20);
			Leave_leftHandSideExpression();
		}
		DebugLocation(1080, 1);
		} finally { DebugExitRule(GrammarFileName, "leftHandSideExpression"); }
		return retval;

	}
	// $ANTLR end "leftHandSideExpression"

	public class postfixExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_postfixExpression();
	partial void Leave_postfixExpression();

	// $ANTLR start "postfixExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1092:1: postfixExpression returns [Expression value] : left= leftHandSideExpression (post= postfixOperator )? ;
	[GrammarRule("postfixExpression")]
	private ES3Parser.postfixExpression_return postfixExpression()
	{
		Enter_postfixExpression();
		EnterRule("postfixExpression", 21);
		TraceIn("postfixExpression", 21);
		ES3Parser.postfixExpression_return retval = new ES3Parser.postfixExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.leftHandSideExpression_return left = default(ES3Parser.leftHandSideExpression_return);
		ES3Parser.postfixOperator_return post = default(ES3Parser.postfixOperator_return);


		try { DebugEnterRule(GrammarFileName, "postfixExpression");
		DebugLocation(1092, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1093:2: (left= leftHandSideExpression (post= postfixOperator )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1093:4: left= leftHandSideExpression (post= postfixOperator )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1093, 8);
			PushFollow(Follow._leftHandSideExpression_in_postfixExpression3782);
			left=leftHandSideExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1093, 32);
			 retval.value = left.value; if (input.LA(1) == INC || input.LA(1) == DEC) PromoteEOL(null);  
			DebugLocation(1093, 122);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1093:122: (post= postfixOperator )?
			int alt22=2;
			try { DebugEnterSubRule(22);
			try { DebugEnterDecision(22, decisionCanBacktrack[22]);
			int LA22_0 = input.LA(1);

			if ((LA22_0==DEC||LA22_0==INC))
			{
				alt22=1;
			}
			} finally { DebugExitDecision(22); }
			switch (alt22)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1093:124: post= postfixOperator
				{
				DebugLocation(1093, 128);
				PushFollow(Follow._postfixOperator_in_postfixExpression3790);
				post=postfixOperator();
				PopFollow();

				root_0 = (object)adaptor.BecomeRoot(post.Tree, root_0);
				DebugLocation(1093, 146);
				 retval.value = new UnaryExpression(post.value, retval.value); 

				}
				break;

			}
			} finally { DebugExitSubRule(22); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("postfixExpression", 21);
			LeaveRule("postfixExpression", 21);
			Leave_postfixExpression();
		}
		DebugLocation(1094, 1);
		} finally { DebugExitRule(GrammarFileName, "postfixExpression"); }
		return retval;

	}
	// $ANTLR end "postfixExpression"

	public class postfixOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public UnaryExpressionType value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_postfixOperator();
	partial void Leave_postfixOperator();

	// $ANTLR start "postfixOperator"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1096:1: postfixOperator returns [UnaryExpressionType value] : (op= INC |op= DEC );
	[GrammarRule("postfixOperator")]
	private ES3Parser.postfixOperator_return postfixOperator()
	{
		Enter_postfixOperator();
		EnterRule("postfixOperator", 22);
		TraceIn("postfixOperator", 22);
		ES3Parser.postfixOperator_return retval = new ES3Parser.postfixOperator_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken op=null;

		object op_tree=null;

		try { DebugEnterRule(GrammarFileName, "postfixOperator");
		DebugLocation(1096, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1097:2: (op= INC |op= DEC )
			int alt23=2;
			try { DebugEnterDecision(23, decisionCanBacktrack[23]);
			int LA23_0 = input.LA(1);

			if ((LA23_0==INC))
			{
				alt23=1;
			}
			else if ((LA23_0==DEC))
			{
				alt23=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 23, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(23); }
			switch (alt23)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1097:4: op= INC
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1097, 6);
				op=(IToken)Match(input,INC,Follow._INC_in_postfixOperator3813); 
				op_tree = (object)adaptor.Create(op);
				adaptor.AddChild(root_0, op_tree);

				DebugLocation(1097, 11);
				 op.Type = PINC; retval.value = UnaryExpressionType.PostfixPlusPlus; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1098:4: op= DEC
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1098, 6);
				op=(IToken)Match(input,DEC,Follow._DEC_in_postfixOperator3822); 
				op_tree = (object)adaptor.Create(op);
				adaptor.AddChild(root_0, op_tree);

				DebugLocation(1098, 11);
				 op.Type = PDEC; retval.value = UnaryExpressionType.PostfixMinusMinus; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("postfixOperator", 22);
			LeaveRule("postfixOperator", 22);
			Leave_postfixOperator();
		}
		DebugLocation(1099, 1);
		} finally { DebugExitRule(GrammarFileName, "postfixOperator"); }
		return retval;

	}
	// $ANTLR end "postfixOperator"

	public class unaryExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_unaryExpression();
	partial void Leave_unaryExpression();

	// $ANTLR start "unaryExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1105:1: unaryExpression returns [Expression value] : (post= postfixExpression |op= unaryOperator exp= unaryExpression );
	[GrammarRule("unaryExpression")]
	private ES3Parser.unaryExpression_return unaryExpression()
	{
		Enter_unaryExpression();
		EnterRule("unaryExpression", 23);
		TraceIn("unaryExpression", 23);
		ES3Parser.unaryExpression_return retval = new ES3Parser.unaryExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.postfixExpression_return post = default(ES3Parser.postfixExpression_return);
		ES3Parser.unaryOperator_return op = default(ES3Parser.unaryOperator_return);
		ES3Parser.unaryExpression_return exp = default(ES3Parser.unaryExpression_return);


		try { DebugEnterRule(GrammarFileName, "unaryExpression");
		DebugLocation(1105, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1106:2: (post= postfixExpression |op= unaryOperator exp= unaryExpression )
			int alt24=2;
			try { DebugEnterDecision(24, decisionCanBacktrack[24]);
			int LA24_0 = input.LA(1);

			if ((LA24_0==DecimalLiteral||LA24_0==FALSE||LA24_0==FUNCTION||LA24_0==HexIntegerLiteral||LA24_0==Identifier||(LA24_0>=LBRACE && LA24_0<=LBRACK)||LA24_0==LPAREN||LA24_0==NEW||LA24_0==NULL||LA24_0==OctalIntegerLiteral||LA24_0==RegularExpressionLiteral||LA24_0==StringLiteral||LA24_0==THIS||LA24_0==TRUE))
			{
				alt24=1;
			}
			else if ((LA24_0==ADD||LA24_0==DEC||LA24_0==DELETE||LA24_0==INC||LA24_0==INV||LA24_0==NOT||LA24_0==SUB||LA24_0==TYPEOF||LA24_0==VOID))
			{
				alt24=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 24, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(24); }
			switch (alt24)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1106:4: post= postfixExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1106, 8);
				PushFollow(Follow._postfixExpression_in_unaryExpression3845);
				post=postfixExpression();
				PopFollow();

				adaptor.AddChild(root_0, post.Tree);
				DebugLocation(1106, 27);
				 retval.value = post.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1107:4: op= unaryOperator exp= unaryExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1107, 6);
				PushFollow(Follow._unaryOperator_in_unaryExpression3854);
				op=unaryOperator();
				PopFollow();

				root_0 = (object)adaptor.BecomeRoot(op.Tree, root_0);
				DebugLocation(1107, 25);
				PushFollow(Follow._unaryExpression_in_unaryExpression3859);
				exp=unaryExpression();
				PopFollow();

				adaptor.AddChild(root_0, exp.Tree);
				DebugLocation(1107, 42);
				 retval.value = new UnaryExpression(op.value, exp.value); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("unaryExpression", 23);
			LeaveRule("unaryExpression", 23);
			Leave_unaryExpression();
		}
		DebugLocation(1108, 1);
		} finally { DebugExitRule(GrammarFileName, "unaryExpression"); }
		return retval;

	}
	// $ANTLR end "unaryExpression"

	public class unaryOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public UnaryExpressionType value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_unaryOperator();
	partial void Leave_unaryOperator();

	// $ANTLR start "unaryOperator"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1110:1: unaryOperator returns [UnaryExpressionType value] : ( DELETE | VOID | TYPEOF | INC | DEC |op= ADD |op= SUB | INV | NOT );
	[GrammarRule("unaryOperator")]
	private ES3Parser.unaryOperator_return unaryOperator()
	{
		Enter_unaryOperator();
		EnterRule("unaryOperator", 24);
		TraceIn("unaryOperator", 24);
		ES3Parser.unaryOperator_return retval = new ES3Parser.unaryOperator_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken op=null;
		IToken DELETE31=null;
		IToken VOID32=null;
		IToken TYPEOF33=null;
		IToken INC34=null;
		IToken DEC35=null;
		IToken INV36=null;
		IToken NOT37=null;

		object op_tree=null;
		object DELETE31_tree=null;
		object VOID32_tree=null;
		object TYPEOF33_tree=null;
		object INC34_tree=null;
		object DEC35_tree=null;
		object INV36_tree=null;
		object NOT37_tree=null;

		try { DebugEnterRule(GrammarFileName, "unaryOperator");
		DebugLocation(1110, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1111:2: ( DELETE | VOID | TYPEOF | INC | DEC |op= ADD |op= SUB | INV | NOT )
			int alt25=9;
			try { DebugEnterDecision(25, decisionCanBacktrack[25]);
			switch (input.LA(1))
			{
			case DELETE:
				{
				alt25=1;
				}
				break;
			case VOID:
				{
				alt25=2;
				}
				break;
			case TYPEOF:
				{
				alt25=3;
				}
				break;
			case INC:
				{
				alt25=4;
				}
				break;
			case DEC:
				{
				alt25=5;
				}
				break;
			case ADD:
				{
				alt25=6;
				}
				break;
			case SUB:
				{
				alt25=7;
				}
				break;
			case INV:
				{
				alt25=8;
				}
				break;
			case NOT:
				{
				alt25=9;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 25, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(25); }
			switch (alt25)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1111:4: DELETE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1111, 4);
				DELETE31=(IToken)Match(input,DELETE,Follow._DELETE_in_unaryOperator3877); 
				DELETE31_tree = (object)adaptor.Create(DELETE31);
				adaptor.AddChild(root_0, DELETE31_tree);

				DebugLocation(1111, 11);
				 retval.value = UnaryExpressionType.Delete; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1112:4: VOID
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1112, 4);
				VOID32=(IToken)Match(input,VOID,Follow._VOID_in_unaryOperator3884); 
				VOID32_tree = (object)adaptor.Create(VOID32);
				adaptor.AddChild(root_0, VOID32_tree);

				DebugLocation(1112, 9);
				 retval.value = UnaryExpressionType.Void; 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1113:4: TYPEOF
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1113, 4);
				TYPEOF33=(IToken)Match(input,TYPEOF,Follow._TYPEOF_in_unaryOperator3891); 
				TYPEOF33_tree = (object)adaptor.Create(TYPEOF33);
				adaptor.AddChild(root_0, TYPEOF33_tree);

				DebugLocation(1113, 11);
				 retval.value = UnaryExpressionType.TypeOf; 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1114:4: INC
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1114, 4);
				INC34=(IToken)Match(input,INC,Follow._INC_in_unaryOperator3898); 
				INC34_tree = (object)adaptor.Create(INC34);
				adaptor.AddChild(root_0, INC34_tree);

				DebugLocation(1114, 8);
				 retval.value = UnaryExpressionType.PrefixPlusPlus; 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1115:4: DEC
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1115, 4);
				DEC35=(IToken)Match(input,DEC,Follow._DEC_in_unaryOperator3905); 
				DEC35_tree = (object)adaptor.Create(DEC35);
				adaptor.AddChild(root_0, DEC35_tree);

				DebugLocation(1115, 8);
				 retval.value = UnaryExpressionType.PrefixMinusMinus; 

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1116:4: op= ADD
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1116, 6);
				op=(IToken)Match(input,ADD,Follow._ADD_in_unaryOperator3914); 
				op_tree = (object)adaptor.Create(op);
				adaptor.AddChild(root_0, op_tree);

				DebugLocation(1116, 11);
				 op.Type = POS; retval.value = UnaryExpressionType.Positive; 

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1117:4: op= SUB
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1117, 6);
				op=(IToken)Match(input,SUB,Follow._SUB_in_unaryOperator3923); 
				op_tree = (object)adaptor.Create(op);
				adaptor.AddChild(root_0, op_tree);

				DebugLocation(1117, 11);
				 op.Type = NEG; retval.value = UnaryExpressionType.Negate; 

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1118:4: INV
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1118, 4);
				INV36=(IToken)Match(input,INV,Follow._INV_in_unaryOperator3930); 
				INV36_tree = (object)adaptor.Create(INV36);
				adaptor.AddChild(root_0, INV36_tree);

				DebugLocation(1118, 8);
				 retval.value = UnaryExpressionType.Inv; 

				}
				break;
			case 9:
				DebugEnterAlt(9);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1119:4: NOT
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1119, 4);
				NOT37=(IToken)Match(input,NOT,Follow._NOT_in_unaryOperator3937); 
				NOT37_tree = (object)adaptor.Create(NOT37);
				adaptor.AddChild(root_0, NOT37_tree);

				DebugLocation(1119, 8);
				 retval.value = UnaryExpressionType.Not; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("unaryOperator", 24);
			LeaveRule("unaryOperator", 24);
			Leave_unaryOperator();
		}
		DebugLocation(1120, 1);
		} finally { DebugExitRule(GrammarFileName, "unaryOperator"); }
		return retval;

	}
	// $ANTLR end "unaryOperator"

	public class multiplicativeExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_multiplicativeExpression();
	partial void Leave_multiplicativeExpression();

	// $ANTLR start "multiplicativeExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1126:1: multiplicativeExpression returns [Expression value] : left= unaryExpression ( ( MUL | DIV | MOD ) right= unaryExpression )* ;
	[GrammarRule("multiplicativeExpression")]
	private ES3Parser.multiplicativeExpression_return multiplicativeExpression()
	{
		Enter_multiplicativeExpression();
		EnterRule("multiplicativeExpression", 25);
		TraceIn("multiplicativeExpression", 25);
		ES3Parser.multiplicativeExpression_return retval = new ES3Parser.multiplicativeExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken MUL38=null;
		IToken DIV39=null;
		IToken MOD40=null;
		ES3Parser.unaryExpression_return left = default(ES3Parser.unaryExpression_return);
		ES3Parser.unaryExpression_return right = default(ES3Parser.unaryExpression_return);

		object MUL38_tree=null;
		object DIV39_tree=null;
		object MOD40_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "multiplicativeExpression");
		DebugLocation(1126, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1130:2: (left= unaryExpression ( ( MUL | DIV | MOD ) right= unaryExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1130:4: left= unaryExpression ( ( MUL | DIV | MOD ) right= unaryExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1130, 8);
			PushFollow(Follow._unaryExpression_in_multiplicativeExpression3965);
			left=unaryExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1130, 25);
			 retval.value = left.value; 
			DebugLocation(1130, 50);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1130:50: ( ( MUL | DIV | MOD ) right= unaryExpression )*
			try { DebugEnterSubRule(27);
			while (true)
			{
				int alt27=2;
				try { DebugEnterDecision(27, decisionCanBacktrack[27]);
				int LA27_0 = input.LA(1);

				if ((LA27_0==DIV||LA27_0==MOD||LA27_0==MUL))
				{
					alt27=1;
				}


				} finally { DebugExitDecision(27); }
				switch ( alt27 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1131:3: ( MUL | DIV | MOD ) right= unaryExpression
					{
					DebugLocation(1133, 48);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1131:3: ( MUL | DIV | MOD )
					int alt26=3;
					try { DebugEnterSubRule(26);
					try { DebugEnterDecision(26, decisionCanBacktrack[26]);
					switch (input.LA(1))
					{
					case MUL:
						{
						alt26=1;
						}
						break;
					case DIV:
						{
						alt26=2;
						}
						break;
					case MOD:
						{
						alt26=3;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 26, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(26); }
					switch (alt26)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1131:5: MUL
						{
						DebugLocation(1131, 5);
						MUL38=(IToken)Match(input,MUL,Follow._MUL_in_multiplicativeExpression3976); 
						MUL38_tree = (object)adaptor.Create(MUL38);
						adaptor.AddChild(root_0, MUL38_tree);

						DebugLocation(1131, 9);
						 type= BinaryExpressionType.Times; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1132:5: DIV
						{
						DebugLocation(1132, 5);
						DIV39=(IToken)Match(input,DIV,Follow._DIV_in_multiplicativeExpression3985); 
						DIV39_tree = (object)adaptor.Create(DIV39);
						adaptor.AddChild(root_0, DIV39_tree);

						DebugLocation(1132, 9);
						 type= BinaryExpressionType.Div; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1133:5: MOD
						{
						DebugLocation(1133, 5);
						MOD40=(IToken)Match(input,MOD,Follow._MOD_in_multiplicativeExpression3993); 
						MOD40_tree = (object)adaptor.Create(MOD40);
						adaptor.AddChild(root_0, MOD40_tree);

						DebugLocation(1133, 9);
						 type= BinaryExpressionType.Modulo; 

						}
						break;

					}
					} finally { DebugExitSubRule(26); }

					DebugLocation(1134, 8);
					PushFollow(Follow._unaryExpression_in_multiplicativeExpression4004);
					right=unaryExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1134, 25);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop27;
				}
			}

			loop27:
				;

			} finally { DebugExitSubRule(27); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("multiplicativeExpression", 25);
			LeaveRule("multiplicativeExpression", 25);
			Leave_multiplicativeExpression();
		}
		DebugLocation(1135, 1);
		} finally { DebugExitRule(GrammarFileName, "multiplicativeExpression"); }
		return retval;

	}
	// $ANTLR end "multiplicativeExpression"

	public class additiveExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_additiveExpression();
	partial void Leave_additiveExpression();

	// $ANTLR start "additiveExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1141:1: additiveExpression returns [Expression value] : left= multiplicativeExpression ( ( ADD | SUB ) right= multiplicativeExpression )* ;
	[GrammarRule("additiveExpression")]
	private ES3Parser.additiveExpression_return additiveExpression()
	{
		Enter_additiveExpression();
		EnterRule("additiveExpression", 26);
		TraceIn("additiveExpression", 26);
		ES3Parser.additiveExpression_return retval = new ES3Parser.additiveExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ADD41=null;
		IToken SUB42=null;
		ES3Parser.multiplicativeExpression_return left = default(ES3Parser.multiplicativeExpression_return);
		ES3Parser.multiplicativeExpression_return right = default(ES3Parser.multiplicativeExpression_return);

		object ADD41_tree=null;
		object SUB42_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "additiveExpression");
		DebugLocation(1141, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1145:2: (left= multiplicativeExpression ( ( ADD | SUB ) right= multiplicativeExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1145:4: left= multiplicativeExpression ( ( ADD | SUB ) right= multiplicativeExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1145, 8);
			PushFollow(Follow._multiplicativeExpression_in_additiveExpression4034);
			left=multiplicativeExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1145, 34);
			 retval.value = left.value; 
			DebugLocation(1145, 59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1145:59: ( ( ADD | SUB ) right= multiplicativeExpression )*
			try { DebugEnterSubRule(29);
			while (true)
			{
				int alt29=2;
				try { DebugEnterDecision(29, decisionCanBacktrack[29]);
				int LA29_0 = input.LA(1);

				if ((LA29_0==ADD||LA29_0==SUB))
				{
					alt29=1;
				}


				} finally { DebugExitDecision(29); }
				switch ( alt29 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1146:3: ( ADD | SUB ) right= multiplicativeExpression
					{
					DebugLocation(1147, 47);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1146:3: ( ADD | SUB )
					int alt28=2;
					try { DebugEnterSubRule(28);
					try { DebugEnterDecision(28, decisionCanBacktrack[28]);
					int LA28_0 = input.LA(1);

					if ((LA28_0==ADD))
					{
						alt28=1;
					}
					else if ((LA28_0==SUB))
					{
						alt28=2;
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

						DebugRecognitionException(nvae);
						throw nvae;
					}
					} finally { DebugExitDecision(28); }
					switch (alt28)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1146:5: ADD
						{
						DebugLocation(1146, 5);
						ADD41=(IToken)Match(input,ADD,Follow._ADD_in_additiveExpression4045); 
						ADD41_tree = (object)adaptor.Create(ADD41);
						adaptor.AddChild(root_0, ADD41_tree);

						DebugLocation(1146, 9);
						 type= BinaryExpressionType.Plus; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1147:5: SUB
						{
						DebugLocation(1147, 5);
						SUB42=(IToken)Match(input,SUB,Follow._SUB_in_additiveExpression4053); 
						SUB42_tree = (object)adaptor.Create(SUB42);
						adaptor.AddChild(root_0, SUB42_tree);

						DebugLocation(1147, 9);
						 type= BinaryExpressionType.Minus; 

						}
						break;

					}
					} finally { DebugExitSubRule(28); }

					DebugLocation(1148, 8);
					PushFollow(Follow._multiplicativeExpression_in_additiveExpression4064);
					right=multiplicativeExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1148, 34);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop29;
				}
			}

			loop29:
				;

			} finally { DebugExitSubRule(29); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("additiveExpression", 26);
			LeaveRule("additiveExpression", 26);
			Leave_additiveExpression();
		}
		DebugLocation(1149, 1);
		} finally { DebugExitRule(GrammarFileName, "additiveExpression"); }
		return retval;

	}
	// $ANTLR end "additiveExpression"

	public class shiftExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_shiftExpression();
	partial void Leave_shiftExpression();

	// $ANTLR start "shiftExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1155:1: shiftExpression returns [Expression value] : left= additiveExpression ( ( SHL | SHR | SHU ) right= additiveExpression )* ;
	[GrammarRule("shiftExpression")]
	private ES3Parser.shiftExpression_return shiftExpression()
	{
		Enter_shiftExpression();
		EnterRule("shiftExpression", 27);
		TraceIn("shiftExpression", 27);
		ES3Parser.shiftExpression_return retval = new ES3Parser.shiftExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken SHL43=null;
		IToken SHR44=null;
		IToken SHU45=null;
		ES3Parser.additiveExpression_return left = default(ES3Parser.additiveExpression_return);
		ES3Parser.additiveExpression_return right = default(ES3Parser.additiveExpression_return);

		object SHL43_tree=null;
		object SHR44_tree=null;
		object SHU45_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "shiftExpression");
		DebugLocation(1155, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1159:2: (left= additiveExpression ( ( SHL | SHR | SHU ) right= additiveExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1159:4: left= additiveExpression ( ( SHL | SHR | SHU ) right= additiveExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1159, 8);
			PushFollow(Follow._additiveExpression_in_shiftExpression4095);
			left=additiveExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1159, 28);
			 retval.value = left.value; 
			DebugLocation(1159, 53);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1159:53: ( ( SHL | SHR | SHU ) right= additiveExpression )*
			try { DebugEnterSubRule(31);
			while (true)
			{
				int alt31=2;
				try { DebugEnterDecision(31, decisionCanBacktrack[31]);
				int LA31_0 = input.LA(1);

				if ((LA31_0==SHL||LA31_0==SHR||LA31_0==SHU))
				{
					alt31=1;
				}


				} finally { DebugExitDecision(31); }
				switch ( alt31 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1160:3: ( SHL | SHR | SHU ) right= additiveExpression
					{
					DebugLocation(1162, 60);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1160:3: ( SHL | SHR | SHU )
					int alt30=3;
					try { DebugEnterSubRule(30);
					try { DebugEnterDecision(30, decisionCanBacktrack[30]);
					switch (input.LA(1))
					{
					case SHL:
						{
						alt30=1;
						}
						break;
					case SHR:
						{
						alt30=2;
						}
						break;
					case SHU:
						{
						alt30=3;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 30, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(30); }
					switch (alt30)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1160:5: SHL
						{
						DebugLocation(1160, 5);
						SHL43=(IToken)Match(input,SHL,Follow._SHL_in_shiftExpression4106); 
						SHL43_tree = (object)adaptor.Create(SHL43);
						adaptor.AddChild(root_0, SHL43_tree);

						DebugLocation(1160, 9);
						 type= BinaryExpressionType.LeftShift; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1161:5: SHR
						{
						DebugLocation(1161, 5);
						SHR44=(IToken)Match(input,SHR,Follow._SHR_in_shiftExpression4114); 
						SHR44_tree = (object)adaptor.Create(SHR44);
						adaptor.AddChild(root_0, SHR44_tree);

						DebugLocation(1161, 9);
						 type= BinaryExpressionType.RightShift; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1162:5: SHU
						{
						DebugLocation(1162, 5);
						SHU45=(IToken)Match(input,SHU,Follow._SHU_in_shiftExpression4122); 
						SHU45_tree = (object)adaptor.Create(SHU45);
						adaptor.AddChild(root_0, SHU45_tree);

						DebugLocation(1162, 9);
						 type= BinaryExpressionType.UnsignedRightShift; 

						}
						break;

					}
					} finally { DebugExitSubRule(30); }

					DebugLocation(1163, 8);
					PushFollow(Follow._additiveExpression_in_shiftExpression4133);
					right=additiveExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1163, 28);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop31;
				}
			}

			loop31:
				;

			} finally { DebugExitSubRule(31); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("shiftExpression", 27);
			LeaveRule("shiftExpression", 27);
			Leave_shiftExpression();
		}
		DebugLocation(1164, 1);
		} finally { DebugExitRule(GrammarFileName, "shiftExpression"); }
		return retval;

	}
	// $ANTLR end "shiftExpression"

	public class relationalExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_relationalExpression();
	partial void Leave_relationalExpression();

	// $ANTLR start "relationalExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1170:1: relationalExpression returns [Expression value] : left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) right= shiftExpression )* ;
	[GrammarRule("relationalExpression")]
	private ES3Parser.relationalExpression_return relationalExpression()
	{
		Enter_relationalExpression();
		EnterRule("relationalExpression", 28);
		TraceIn("relationalExpression", 28);
		ES3Parser.relationalExpression_return retval = new ES3Parser.relationalExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LT46=null;
		IToken GT47=null;
		IToken LTE48=null;
		IToken GTE49=null;
		IToken INSTANCEOF50=null;
		IToken IN51=null;
		ES3Parser.shiftExpression_return left = default(ES3Parser.shiftExpression_return);
		ES3Parser.shiftExpression_return right = default(ES3Parser.shiftExpression_return);

		object LT46_tree=null;
		object GT47_tree=null;
		object LTE48_tree=null;
		object GTE49_tree=null;
		object INSTANCEOF50_tree=null;
		object IN51_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "relationalExpression");
		DebugLocation(1170, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1174:2: (left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) right= shiftExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1174:4: left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) right= shiftExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1174, 8);
			PushFollow(Follow._shiftExpression_in_relationalExpression4164);
			left=shiftExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1174, 25);
			 retval.value = left.value; 
			DebugLocation(1174, 50);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1174:50: ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) right= shiftExpression )*
			try { DebugEnterSubRule(33);
			while (true)
			{
				int alt33=2;
				try { DebugEnterDecision(33, decisionCanBacktrack[33]);
				int LA33_0 = input.LA(1);

				if (((LA33_0>=GT && LA33_0<=GTE)||LA33_0==IN||LA33_0==INSTANCEOF||(LA33_0>=LT && LA33_0<=LTE)))
				{
					alt33=1;
				}


				} finally { DebugExitDecision(33); }
				switch ( alt33 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1175:3: ( LT | GT | LTE | GTE | INSTANCEOF | IN ) right= shiftExpression
					{
					DebugLocation(1180, 44);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1175:3: ( LT | GT | LTE | GTE | INSTANCEOF | IN )
					int alt32=6;
					try { DebugEnterSubRule(32);
					try { DebugEnterDecision(32, decisionCanBacktrack[32]);
					switch (input.LA(1))
					{
					case LT:
						{
						alt32=1;
						}
						break;
					case GT:
						{
						alt32=2;
						}
						break;
					case LTE:
						{
						alt32=3;
						}
						break;
					case GTE:
						{
						alt32=4;
						}
						break;
					case INSTANCEOF:
						{
						alt32=5;
						}
						break;
					case IN:
						{
						alt32=6;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 32, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(32); }
					switch (alt32)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1175:5: LT
						{
						DebugLocation(1175, 5);
						LT46=(IToken)Match(input,LT,Follow._LT_in_relationalExpression4175); 
						LT46_tree = (object)adaptor.Create(LT46);
						adaptor.AddChild(root_0, LT46_tree);

						DebugLocation(1175, 8);
						 type= BinaryExpressionType.Lesser; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1176:5: GT
						{
						DebugLocation(1176, 5);
						GT47=(IToken)Match(input,GT,Follow._GT_in_relationalExpression4183); 
						GT47_tree = (object)adaptor.Create(GT47);
						adaptor.AddChild(root_0, GT47_tree);

						DebugLocation(1176, 8);
						 type= BinaryExpressionType.Greater; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1177:5: LTE
						{
						DebugLocation(1177, 5);
						LTE48=(IToken)Match(input,LTE,Follow._LTE_in_relationalExpression4191); 
						LTE48_tree = (object)adaptor.Create(LTE48);
						adaptor.AddChild(root_0, LTE48_tree);

						DebugLocation(1177, 9);
						 type= BinaryExpressionType.LesserOrEqual; 

						}
						break;
					case 4:
						DebugEnterAlt(4);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1178:5: GTE
						{
						DebugLocation(1178, 5);
						GTE49=(IToken)Match(input,GTE,Follow._GTE_in_relationalExpression4199); 
						GTE49_tree = (object)adaptor.Create(GTE49);
						adaptor.AddChild(root_0, GTE49_tree);

						DebugLocation(1178, 9);
						 type= BinaryExpressionType.GreaterOrEqual; 

						}
						break;
					case 5:
						DebugEnterAlt(5);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1179:5: INSTANCEOF
						{
						DebugLocation(1179, 5);
						INSTANCEOF50=(IToken)Match(input,INSTANCEOF,Follow._INSTANCEOF_in_relationalExpression4207); 
						INSTANCEOF50_tree = (object)adaptor.Create(INSTANCEOF50);
						adaptor.AddChild(root_0, INSTANCEOF50_tree);

						DebugLocation(1179, 16);
						 type= BinaryExpressionType.InstanceOf;  

						}
						break;
					case 6:
						DebugEnterAlt(6);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1180:5: IN
						{
						DebugLocation(1180, 5);
						IN51=(IToken)Match(input,IN,Follow._IN_in_relationalExpression4215); 
						IN51_tree = (object)adaptor.Create(IN51);
						adaptor.AddChild(root_0, IN51_tree);

						DebugLocation(1180, 8);
						 type= BinaryExpressionType.In;  

						}
						break;

					}
					} finally { DebugExitSubRule(32); }

					DebugLocation(1181, 8);
					PushFollow(Follow._shiftExpression_in_relationalExpression4226);
					right=shiftExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1181, 25);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop33;
				}
			}

			loop33:
				;

			} finally { DebugExitSubRule(33); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("relationalExpression", 28);
			LeaveRule("relationalExpression", 28);
			Leave_relationalExpression();
		}
		DebugLocation(1182, 1);
		} finally { DebugExitRule(GrammarFileName, "relationalExpression"); }
		return retval;

	}
	// $ANTLR end "relationalExpression"

	public class relationalExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_relationalExpressionNoIn();
	partial void Leave_relationalExpressionNoIn();

	// $ANTLR start "relationalExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1184:1: relationalExpressionNoIn returns [Expression value] : left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) right= shiftExpression )* ;
	[GrammarRule("relationalExpressionNoIn")]
	private ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn()
	{
		Enter_relationalExpressionNoIn();
		EnterRule("relationalExpressionNoIn", 29);
		TraceIn("relationalExpressionNoIn", 29);
		ES3Parser.relationalExpressionNoIn_return retval = new ES3Parser.relationalExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LT52=null;
		IToken GT53=null;
		IToken LTE54=null;
		IToken GTE55=null;
		IToken INSTANCEOF56=null;
		ES3Parser.shiftExpression_return left = default(ES3Parser.shiftExpression_return);
		ES3Parser.shiftExpression_return right = default(ES3Parser.shiftExpression_return);

		object LT52_tree=null;
		object GT53_tree=null;
		object LTE54_tree=null;
		object GTE55_tree=null;
		object INSTANCEOF56_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "relationalExpressionNoIn");
		DebugLocation(1184, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1188:2: (left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) right= shiftExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1188:4: left= shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) right= shiftExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1188, 8);
			PushFollow(Follow._shiftExpression_in_relationalExpressionNoIn4252);
			left=shiftExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1188, 25);
			 retval.value = left.value; 
			DebugLocation(1188, 50);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1188:50: ( ( LT | GT | LTE | GTE | INSTANCEOF ) right= shiftExpression )*
			try { DebugEnterSubRule(35);
			while (true)
			{
				int alt35=2;
				try { DebugEnterDecision(35, decisionCanBacktrack[35]);
				int LA35_0 = input.LA(1);

				if (((LA35_0>=GT && LA35_0<=GTE)||LA35_0==INSTANCEOF||(LA35_0>=LT && LA35_0<=LTE)))
				{
					alt35=1;
				}


				} finally { DebugExitDecision(35); }
				switch ( alt35 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1189:3: ( LT | GT | LTE | GTE | INSTANCEOF ) right= shiftExpression
					{
					DebugLocation(1193, 61);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1189:3: ( LT | GT | LTE | GTE | INSTANCEOF )
					int alt34=5;
					try { DebugEnterSubRule(34);
					try { DebugEnterDecision(34, decisionCanBacktrack[34]);
					switch (input.LA(1))
					{
					case LT:
						{
						alt34=1;
						}
						break;
					case GT:
						{
						alt34=2;
						}
						break;
					case LTE:
						{
						alt34=3;
						}
						break;
					case GTE:
						{
						alt34=4;
						}
						break;
					case INSTANCEOF:
						{
						alt34=5;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 34, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(34); }
					switch (alt34)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1189:5: LT
						{
						DebugLocation(1189, 5);
						LT52=(IToken)Match(input,LT,Follow._LT_in_relationalExpressionNoIn4263); 
						LT52_tree = (object)adaptor.Create(LT52);
						adaptor.AddChild(root_0, LT52_tree);

						DebugLocation(1189, 8);
						 type= BinaryExpressionType.Lesser; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1190:5: GT
						{
						DebugLocation(1190, 5);
						GT53=(IToken)Match(input,GT,Follow._GT_in_relationalExpressionNoIn4271); 
						GT53_tree = (object)adaptor.Create(GT53);
						adaptor.AddChild(root_0, GT53_tree);

						DebugLocation(1190, 8);
						 type= BinaryExpressionType.Greater; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1191:5: LTE
						{
						DebugLocation(1191, 5);
						LTE54=(IToken)Match(input,LTE,Follow._LTE_in_relationalExpressionNoIn4279); 
						LTE54_tree = (object)adaptor.Create(LTE54);
						adaptor.AddChild(root_0, LTE54_tree);

						DebugLocation(1191, 9);
						 type= BinaryExpressionType.LesserOrEqual; 

						}
						break;
					case 4:
						DebugEnterAlt(4);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1192:5: GTE
						{
						DebugLocation(1192, 5);
						GTE55=(IToken)Match(input,GTE,Follow._GTE_in_relationalExpressionNoIn4287); 
						GTE55_tree = (object)adaptor.Create(GTE55);
						adaptor.AddChild(root_0, GTE55_tree);

						DebugLocation(1192, 9);
						 type= BinaryExpressionType.GreaterOrEqual; 

						}
						break;
					case 5:
						DebugEnterAlt(5);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1193:5: INSTANCEOF
						{
						DebugLocation(1193, 5);
						INSTANCEOF56=(IToken)Match(input,INSTANCEOF,Follow._INSTANCEOF_in_relationalExpressionNoIn4295); 
						INSTANCEOF56_tree = (object)adaptor.Create(INSTANCEOF56);
						adaptor.AddChild(root_0, INSTANCEOF56_tree);

						DebugLocation(1193, 16);
						 type= BinaryExpressionType.InstanceOf;  

						}
						break;

					}
					} finally { DebugExitSubRule(34); }

					DebugLocation(1194, 8);
					PushFollow(Follow._shiftExpression_in_relationalExpressionNoIn4307);
					right=shiftExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1194, 25);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop35;
				}
			}

			loop35:
				;

			} finally { DebugExitSubRule(35); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("relationalExpressionNoIn", 29);
			LeaveRule("relationalExpressionNoIn", 29);
			Leave_relationalExpressionNoIn();
		}
		DebugLocation(1195, 1);
		} finally { DebugExitRule(GrammarFileName, "relationalExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "relationalExpressionNoIn"

	public class equalityExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_equalityExpression();
	partial void Leave_equalityExpression();

	// $ANTLR start "equalityExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1201:1: equalityExpression returns [Expression value] : left= relationalExpression ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpression )* ;
	[GrammarRule("equalityExpression")]
	private ES3Parser.equalityExpression_return equalityExpression()
	{
		Enter_equalityExpression();
		EnterRule("equalityExpression", 30);
		TraceIn("equalityExpression", 30);
		ES3Parser.equalityExpression_return retval = new ES3Parser.equalityExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken EQ57=null;
		IToken NEQ58=null;
		IToken SAME59=null;
		IToken NSAME60=null;
		ES3Parser.relationalExpression_return left = default(ES3Parser.relationalExpression_return);
		ES3Parser.relationalExpression_return right = default(ES3Parser.relationalExpression_return);

		object EQ57_tree=null;
		object NEQ58_tree=null;
		object SAME59_tree=null;
		object NSAME60_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "equalityExpression");
		DebugLocation(1201, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1205:2: (left= relationalExpression ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1205:4: left= relationalExpression ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1205, 8);
			PushFollow(Follow._relationalExpression_in_equalityExpression4338);
			left=relationalExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1205, 30);
			 retval.value = left.value; 
			DebugLocation(1205, 55);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1205:55: ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpression )*
			try { DebugEnterSubRule(37);
			while (true)
			{
				int alt37=2;
				try { DebugEnterDecision(37, decisionCanBacktrack[37]);
				int LA37_0 = input.LA(1);

				if ((LA37_0==EQ||LA37_0==NEQ||LA37_0==NSAME||LA37_0==SAME))
				{
					alt37=1;
				}


				} finally { DebugExitDecision(37); }
				switch ( alt37 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1206:3: ( EQ | NEQ | SAME | NSAME ) right= relationalExpression
					{
					DebugLocation(1209, 51);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1206:3: ( EQ | NEQ | SAME | NSAME )
					int alt36=4;
					try { DebugEnterSubRule(36);
					try { DebugEnterDecision(36, decisionCanBacktrack[36]);
					switch (input.LA(1))
					{
					case EQ:
						{
						alt36=1;
						}
						break;
					case NEQ:
						{
						alt36=2;
						}
						break;
					case SAME:
						{
						alt36=3;
						}
						break;
					case NSAME:
						{
						alt36=4;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 36, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(36); }
					switch (alt36)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1206:5: EQ
						{
						DebugLocation(1206, 5);
						EQ57=(IToken)Match(input,EQ,Follow._EQ_in_equalityExpression4349); 
						EQ57_tree = (object)adaptor.Create(EQ57);
						adaptor.AddChild(root_0, EQ57_tree);

						DebugLocation(1206, 8);
						 type= BinaryExpressionType.Equal; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1207:5: NEQ
						{
						DebugLocation(1207, 5);
						NEQ58=(IToken)Match(input,NEQ,Follow._NEQ_in_equalityExpression4357); 
						NEQ58_tree = (object)adaptor.Create(NEQ58);
						adaptor.AddChild(root_0, NEQ58_tree);

						DebugLocation(1207, 9);
						 type= BinaryExpressionType.NotEqual; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1208:5: SAME
						{
						DebugLocation(1208, 5);
						SAME59=(IToken)Match(input,SAME,Follow._SAME_in_equalityExpression4365); 
						SAME59_tree = (object)adaptor.Create(SAME59);
						adaptor.AddChild(root_0, SAME59_tree);

						DebugLocation(1208, 10);
						 type= BinaryExpressionType.Same; 

						}
						break;
					case 4:
						DebugEnterAlt(4);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1209:5: NSAME
						{
						DebugLocation(1209, 5);
						NSAME60=(IToken)Match(input,NSAME,Follow._NSAME_in_equalityExpression4373); 
						NSAME60_tree = (object)adaptor.Create(NSAME60);
						adaptor.AddChild(root_0, NSAME60_tree);

						DebugLocation(1209, 11);
						 type= BinaryExpressionType.NotSame; 

						}
						break;

					}
					} finally { DebugExitSubRule(36); }

					DebugLocation(1210, 8);
					PushFollow(Follow._relationalExpression_in_equalityExpression4384);
					right=relationalExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1210, 30);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop37;
				}
			}

			loop37:
				;

			} finally { DebugExitSubRule(37); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("equalityExpression", 30);
			LeaveRule("equalityExpression", 30);
			Leave_equalityExpression();
		}
		DebugLocation(1211, 1);
		} finally { DebugExitRule(GrammarFileName, "equalityExpression"); }
		return retval;

	}
	// $ANTLR end "equalityExpression"

	public class equalityExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_equalityExpressionNoIn();
	partial void Leave_equalityExpressionNoIn();

	// $ANTLR start "equalityExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1213:1: equalityExpressionNoIn returns [Expression value] : left= relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpressionNoIn )* ;
	[GrammarRule("equalityExpressionNoIn")]
	private ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn()
	{
		Enter_equalityExpressionNoIn();
		EnterRule("equalityExpressionNoIn", 31);
		TraceIn("equalityExpressionNoIn", 31);
		ES3Parser.equalityExpressionNoIn_return retval = new ES3Parser.equalityExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken EQ61=null;
		IToken NEQ62=null;
		IToken SAME63=null;
		IToken NSAME64=null;
		ES3Parser.relationalExpressionNoIn_return left = default(ES3Parser.relationalExpressionNoIn_return);
		ES3Parser.relationalExpressionNoIn_return right = default(ES3Parser.relationalExpressionNoIn_return);

		object EQ61_tree=null;
		object NEQ62_tree=null;
		object SAME63_tree=null;
		object NSAME64_tree=null;


			BinaryExpressionType type = BinaryExpressionType.Unknown;

		try { DebugEnterRule(GrammarFileName, "equalityExpressionNoIn");
		DebugLocation(1213, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1217:2: (left= relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1217:4: left= relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1217, 8);
			PushFollow(Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4410);
			left=relationalExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1217, 34);
			 retval.value = left.value; 
			DebugLocation(1217, 59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1217:59: ( ( EQ | NEQ | SAME | NSAME ) right= relationalExpressionNoIn )*
			try { DebugEnterSubRule(39);
			while (true)
			{
				int alt39=2;
				try { DebugEnterDecision(39, decisionCanBacktrack[39]);
				int LA39_0 = input.LA(1);

				if ((LA39_0==EQ||LA39_0==NEQ||LA39_0==NSAME||LA39_0==SAME))
				{
					alt39=1;
				}


				} finally { DebugExitDecision(39); }
				switch ( alt39 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1218:3: ( EQ | NEQ | SAME | NSAME ) right= relationalExpressionNoIn
					{
					DebugLocation(1221, 51);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1218:3: ( EQ | NEQ | SAME | NSAME )
					int alt38=4;
					try { DebugEnterSubRule(38);
					try { DebugEnterDecision(38, decisionCanBacktrack[38]);
					switch (input.LA(1))
					{
					case EQ:
						{
						alt38=1;
						}
						break;
					case NEQ:
						{
						alt38=2;
						}
						break;
					case SAME:
						{
						alt38=3;
						}
						break;
					case NSAME:
						{
						alt38=4;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 38, 0, input);

							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(38); }
					switch (alt38)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1218:5: EQ
						{
						DebugLocation(1218, 5);
						EQ61=(IToken)Match(input,EQ,Follow._EQ_in_equalityExpressionNoIn4421); 
						EQ61_tree = (object)adaptor.Create(EQ61);
						adaptor.AddChild(root_0, EQ61_tree);

						DebugLocation(1218, 8);
						 type= BinaryExpressionType.Equal; 

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1219:5: NEQ
						{
						DebugLocation(1219, 5);
						NEQ62=(IToken)Match(input,NEQ,Follow._NEQ_in_equalityExpressionNoIn4429); 
						NEQ62_tree = (object)adaptor.Create(NEQ62);
						adaptor.AddChild(root_0, NEQ62_tree);

						DebugLocation(1219, 9);
						 type= BinaryExpressionType.NotEqual; 

						}
						break;
					case 3:
						DebugEnterAlt(3);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1220:5: SAME
						{
						DebugLocation(1220, 5);
						SAME63=(IToken)Match(input,SAME,Follow._SAME_in_equalityExpressionNoIn4437); 
						SAME63_tree = (object)adaptor.Create(SAME63);
						adaptor.AddChild(root_0, SAME63_tree);

						DebugLocation(1220, 10);
						 type= BinaryExpressionType.Same; 

						}
						break;
					case 4:
						DebugEnterAlt(4);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1221:5: NSAME
						{
						DebugLocation(1221, 5);
						NSAME64=(IToken)Match(input,NSAME,Follow._NSAME_in_equalityExpressionNoIn4445); 
						NSAME64_tree = (object)adaptor.Create(NSAME64);
						adaptor.AddChild(root_0, NSAME64_tree);

						DebugLocation(1221, 11);
						 type= BinaryExpressionType.NotSame; 

						}
						break;

					}
					} finally { DebugExitSubRule(38); }

					DebugLocation(1222, 8);
					PushFollow(Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4456);
					right=relationalExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1222, 34);
					 retval.value = new BinaryExpression(type, retval.value, right.value); 

					}
					break;

				default:
					goto loop39;
				}
			}

			loop39:
				;

			} finally { DebugExitSubRule(39); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("equalityExpressionNoIn", 31);
			LeaveRule("equalityExpressionNoIn", 31);
			Leave_equalityExpressionNoIn();
		}
		DebugLocation(1223, 1);
		} finally { DebugExitRule(GrammarFileName, "equalityExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "equalityExpressionNoIn"

	public class bitwiseANDExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseANDExpression();
	partial void Leave_bitwiseANDExpression();

	// $ANTLR start "bitwiseANDExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1229:1: bitwiseANDExpression returns [Expression value] : left= equalityExpression ( AND right= equalityExpression )* ;
	[GrammarRule("bitwiseANDExpression")]
	private ES3Parser.bitwiseANDExpression_return bitwiseANDExpression()
	{
		Enter_bitwiseANDExpression();
		EnterRule("bitwiseANDExpression", 32);
		TraceIn("bitwiseANDExpression", 32);
		ES3Parser.bitwiseANDExpression_return retval = new ES3Parser.bitwiseANDExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken AND65=null;
		ES3Parser.equalityExpression_return left = default(ES3Parser.equalityExpression_return);
		ES3Parser.equalityExpression_return right = default(ES3Parser.equalityExpression_return);

		object AND65_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseANDExpression");
		DebugLocation(1229, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1230:2: (left= equalityExpression ( AND right= equalityExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1230:4: left= equalityExpression ( AND right= equalityExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1230, 8);
			PushFollow(Follow._equalityExpression_in_bitwiseANDExpression4483);
			left=equalityExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1230, 28);
			 retval.value = left.value; 
			DebugLocation(1230, 53);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1230:53: ( AND right= equalityExpression )*
			try { DebugEnterSubRule(40);
			while (true)
			{
				int alt40=2;
				try { DebugEnterDecision(40, decisionCanBacktrack[40]);
				int LA40_0 = input.LA(1);

				if ((LA40_0==AND))
				{
					alt40=1;
				}


				} finally { DebugExitDecision(40); }
				switch ( alt40 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1230:55: AND right= equalityExpression
					{
					DebugLocation(1230, 58);
					AND65=(IToken)Match(input,AND,Follow._AND_in_bitwiseANDExpression4489); 
					AND65_tree = (object)adaptor.Create(AND65);
					root_0 = (object)adaptor.BecomeRoot(AND65_tree, root_0);

					DebugLocation(1230, 65);
					PushFollow(Follow._equalityExpression_in_bitwiseANDExpression4494);
					right=equalityExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1230, 85);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseAnd, retval.value, right.value); 

					}
					break;

				default:
					goto loop40;
				}
			}

			loop40:
				;

			} finally { DebugExitSubRule(40); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseANDExpression", 32);
			LeaveRule("bitwiseANDExpression", 32);
			Leave_bitwiseANDExpression();
		}
		DebugLocation(1231, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseANDExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseANDExpression"

	public class bitwiseANDExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseANDExpressionNoIn();
	partial void Leave_bitwiseANDExpressionNoIn();

	// $ANTLR start "bitwiseANDExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1233:1: bitwiseANDExpressionNoIn returns [Expression value] : left= equalityExpressionNoIn ( AND right= equalityExpressionNoIn )* ;
	[GrammarRule("bitwiseANDExpressionNoIn")]
	private ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
	{
		Enter_bitwiseANDExpressionNoIn();
		EnterRule("bitwiseANDExpressionNoIn", 33);
		TraceIn("bitwiseANDExpressionNoIn", 33);
		ES3Parser.bitwiseANDExpressionNoIn_return retval = new ES3Parser.bitwiseANDExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken AND66=null;
		ES3Parser.equalityExpressionNoIn_return left = default(ES3Parser.equalityExpressionNoIn_return);
		ES3Parser.equalityExpressionNoIn_return right = default(ES3Parser.equalityExpressionNoIn_return);

		object AND66_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseANDExpressionNoIn");
		DebugLocation(1233, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1234:2: (left= equalityExpressionNoIn ( AND right= equalityExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1234:4: left= equalityExpressionNoIn ( AND right= equalityExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1234, 8);
			PushFollow(Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515);
			left=equalityExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1234, 32);
			 retval.value = left.value; 
			DebugLocation(1234, 57);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1234:57: ( AND right= equalityExpressionNoIn )*
			try { DebugEnterSubRule(41);
			while (true)
			{
				int alt41=2;
				try { DebugEnterDecision(41, decisionCanBacktrack[41]);
				int LA41_0 = input.LA(1);

				if ((LA41_0==AND))
				{
					alt41=1;
				}


				} finally { DebugExitDecision(41); }
				switch ( alt41 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1234:59: AND right= equalityExpressionNoIn
					{
					DebugLocation(1234, 62);
					AND66=(IToken)Match(input,AND,Follow._AND_in_bitwiseANDExpressionNoIn4521); 
					AND66_tree = (object)adaptor.Create(AND66);
					root_0 = (object)adaptor.BecomeRoot(AND66_tree, root_0);

					DebugLocation(1234, 69);
					PushFollow(Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526);
					right=equalityExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1234, 93);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseAnd, retval.value, right.value); 

					}
					break;

				default:
					goto loop41;
				}
			}

			loop41:
				;

			} finally { DebugExitSubRule(41); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseANDExpressionNoIn", 33);
			LeaveRule("bitwiseANDExpressionNoIn", 33);
			Leave_bitwiseANDExpressionNoIn();
		}
		DebugLocation(1235, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseANDExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseANDExpressionNoIn"

	public class bitwiseXORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseXORExpression();
	partial void Leave_bitwiseXORExpression();

	// $ANTLR start "bitwiseXORExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1237:1: bitwiseXORExpression returns [Expression value] : left= bitwiseANDExpression ( XOR right= bitwiseANDExpression )* ;
	[GrammarRule("bitwiseXORExpression")]
	private ES3Parser.bitwiseXORExpression_return bitwiseXORExpression()
	{
		Enter_bitwiseXORExpression();
		EnterRule("bitwiseXORExpression", 34);
		TraceIn("bitwiseXORExpression", 34);
		ES3Parser.bitwiseXORExpression_return retval = new ES3Parser.bitwiseXORExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken XOR67=null;
		ES3Parser.bitwiseANDExpression_return left = default(ES3Parser.bitwiseANDExpression_return);
		ES3Parser.bitwiseANDExpression_return right = default(ES3Parser.bitwiseANDExpression_return);

		object XOR67_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseXORExpression");
		DebugLocation(1237, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1238:2: (left= bitwiseANDExpression ( XOR right= bitwiseANDExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1238:4: left= bitwiseANDExpression ( XOR right= bitwiseANDExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1238, 8);
			PushFollow(Follow._bitwiseANDExpression_in_bitwiseXORExpression4549);
			left=bitwiseANDExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1238, 30);
			 retval.value = left.value; 
			DebugLocation(1238, 55);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1238:55: ( XOR right= bitwiseANDExpression )*
			try { DebugEnterSubRule(42);
			while (true)
			{
				int alt42=2;
				try { DebugEnterDecision(42, decisionCanBacktrack[42]);
				int LA42_0 = input.LA(1);

				if ((LA42_0==XOR))
				{
					alt42=1;
				}


				} finally { DebugExitDecision(42); }
				switch ( alt42 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1238:57: XOR right= bitwiseANDExpression
					{
					DebugLocation(1238, 60);
					XOR67=(IToken)Match(input,XOR,Follow._XOR_in_bitwiseXORExpression4555); 
					XOR67_tree = (object)adaptor.Create(XOR67);
					root_0 = (object)adaptor.BecomeRoot(XOR67_tree, root_0);

					DebugLocation(1238, 67);
					PushFollow(Follow._bitwiseANDExpression_in_bitwiseXORExpression4560);
					right=bitwiseANDExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1238, 89);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseXOr, retval.value, right.value); 

					}
					break;

				default:
					goto loop42;
				}
			}

			loop42:
				;

			} finally { DebugExitSubRule(42); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseXORExpression", 34);
			LeaveRule("bitwiseXORExpression", 34);
			Leave_bitwiseXORExpression();
		}
		DebugLocation(1239, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseXORExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseXORExpression"

	public class bitwiseXORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseXORExpressionNoIn();
	partial void Leave_bitwiseXORExpressionNoIn();

	// $ANTLR start "bitwiseXORExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1241:1: bitwiseXORExpressionNoIn returns [Expression value] : left= bitwiseANDExpressionNoIn ( XOR right= bitwiseANDExpressionNoIn )* ;
	[GrammarRule("bitwiseXORExpressionNoIn")]
	private ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
	{
		Enter_bitwiseXORExpressionNoIn();
		EnterRule("bitwiseXORExpressionNoIn", 35);
		TraceIn("bitwiseXORExpressionNoIn", 35);
		ES3Parser.bitwiseXORExpressionNoIn_return retval = new ES3Parser.bitwiseXORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken XOR68=null;
		ES3Parser.bitwiseANDExpressionNoIn_return left = default(ES3Parser.bitwiseANDExpressionNoIn_return);
		ES3Parser.bitwiseANDExpressionNoIn_return right = default(ES3Parser.bitwiseANDExpressionNoIn_return);

		object XOR68_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseXORExpressionNoIn");
		DebugLocation(1241, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1242:2: (left= bitwiseANDExpressionNoIn ( XOR right= bitwiseANDExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1242:4: left= bitwiseANDExpressionNoIn ( XOR right= bitwiseANDExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1242, 8);
			PushFollow(Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583);
			left=bitwiseANDExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1242, 34);
			 retval.value = left.value; 
			DebugLocation(1242, 59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1242:59: ( XOR right= bitwiseANDExpressionNoIn )*
			try { DebugEnterSubRule(43);
			while (true)
			{
				int alt43=2;
				try { DebugEnterDecision(43, decisionCanBacktrack[43]);
				int LA43_0 = input.LA(1);

				if ((LA43_0==XOR))
				{
					alt43=1;
				}


				} finally { DebugExitDecision(43); }
				switch ( alt43 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1242:61: XOR right= bitwiseANDExpressionNoIn
					{
					DebugLocation(1242, 64);
					XOR68=(IToken)Match(input,XOR,Follow._XOR_in_bitwiseXORExpressionNoIn4589); 
					XOR68_tree = (object)adaptor.Create(XOR68);
					root_0 = (object)adaptor.BecomeRoot(XOR68_tree, root_0);

					DebugLocation(1242, 71);
					PushFollow(Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594);
					right=bitwiseANDExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1242, 97);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseXOr, retval.value, right.value); 

					}
					break;

				default:
					goto loop43;
				}
			}

			loop43:
				;

			} finally { DebugExitSubRule(43); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseXORExpressionNoIn", 35);
			LeaveRule("bitwiseXORExpressionNoIn", 35);
			Leave_bitwiseXORExpressionNoIn();
		}
		DebugLocation(1243, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseXORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseXORExpressionNoIn"

	public class bitwiseORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseORExpression();
	partial void Leave_bitwiseORExpression();

	// $ANTLR start "bitwiseORExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1245:1: bitwiseORExpression returns [Expression value] : left= bitwiseXORExpression ( OR right= bitwiseXORExpression )* ;
	[GrammarRule("bitwiseORExpression")]
	private ES3Parser.bitwiseORExpression_return bitwiseORExpression()
	{
		Enter_bitwiseORExpression();
		EnterRule("bitwiseORExpression", 36);
		TraceIn("bitwiseORExpression", 36);
		ES3Parser.bitwiseORExpression_return retval = new ES3Parser.bitwiseORExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken OR69=null;
		ES3Parser.bitwiseXORExpression_return left = default(ES3Parser.bitwiseXORExpression_return);
		ES3Parser.bitwiseXORExpression_return right = default(ES3Parser.bitwiseXORExpression_return);

		object OR69_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseORExpression");
		DebugLocation(1245, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1246:2: (left= bitwiseXORExpression ( OR right= bitwiseXORExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1246:4: left= bitwiseXORExpression ( OR right= bitwiseXORExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1246, 8);
			PushFollow(Follow._bitwiseXORExpression_in_bitwiseORExpression4616);
			left=bitwiseXORExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1246, 30);
			 retval.value = left.value; 
			DebugLocation(1246, 55);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1246:55: ( OR right= bitwiseXORExpression )*
			try { DebugEnterSubRule(44);
			while (true)
			{
				int alt44=2;
				try { DebugEnterDecision(44, decisionCanBacktrack[44]);
				int LA44_0 = input.LA(1);

				if ((LA44_0==OR))
				{
					alt44=1;
				}


				} finally { DebugExitDecision(44); }
				switch ( alt44 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1246:57: OR right= bitwiseXORExpression
					{
					DebugLocation(1246, 59);
					OR69=(IToken)Match(input,OR,Follow._OR_in_bitwiseORExpression4622); 
					OR69_tree = (object)adaptor.Create(OR69);
					root_0 = (object)adaptor.BecomeRoot(OR69_tree, root_0);

					DebugLocation(1246, 66);
					PushFollow(Follow._bitwiseXORExpression_in_bitwiseORExpression4627);
					right=bitwiseXORExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1246, 88);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseOr, retval.value, right.value); 

					}
					break;

				default:
					goto loop44;
				}
			}

			loop44:
				;

			} finally { DebugExitSubRule(44); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseORExpression", 36);
			LeaveRule("bitwiseORExpression", 36);
			Leave_bitwiseORExpression();
		}
		DebugLocation(1247, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseORExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseORExpression"

	public class bitwiseORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseORExpressionNoIn();
	partial void Leave_bitwiseORExpressionNoIn();

	// $ANTLR start "bitwiseORExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1249:1: bitwiseORExpressionNoIn returns [Expression value] : left= bitwiseXORExpressionNoIn ( OR right= bitwiseXORExpressionNoIn )* ;
	[GrammarRule("bitwiseORExpressionNoIn")]
	private ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
	{
		Enter_bitwiseORExpressionNoIn();
		EnterRule("bitwiseORExpressionNoIn", 37);
		TraceIn("bitwiseORExpressionNoIn", 37);
		ES3Parser.bitwiseORExpressionNoIn_return retval = new ES3Parser.bitwiseORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken OR70=null;
		ES3Parser.bitwiseXORExpressionNoIn_return left = default(ES3Parser.bitwiseXORExpressionNoIn_return);
		ES3Parser.bitwiseXORExpressionNoIn_return right = default(ES3Parser.bitwiseXORExpressionNoIn_return);

		object OR70_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseORExpressionNoIn");
		DebugLocation(1249, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1250:2: (left= bitwiseXORExpressionNoIn ( OR right= bitwiseXORExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1250:4: left= bitwiseXORExpressionNoIn ( OR right= bitwiseXORExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1250, 8);
			PushFollow(Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649);
			left=bitwiseXORExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1250, 34);
			 retval.value = left.value; 
			DebugLocation(1250, 59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1250:59: ( OR right= bitwiseXORExpressionNoIn )*
			try { DebugEnterSubRule(45);
			while (true)
			{
				int alt45=2;
				try { DebugEnterDecision(45, decisionCanBacktrack[45]);
				int LA45_0 = input.LA(1);

				if ((LA45_0==OR))
				{
					alt45=1;
				}


				} finally { DebugExitDecision(45); }
				switch ( alt45 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1250:61: OR right= bitwiseXORExpressionNoIn
					{
					DebugLocation(1250, 63);
					OR70=(IToken)Match(input,OR,Follow._OR_in_bitwiseORExpressionNoIn4655); 
					OR70_tree = (object)adaptor.Create(OR70);
					root_0 = (object)adaptor.BecomeRoot(OR70_tree, root_0);

					DebugLocation(1250, 70);
					PushFollow(Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660);
					right=bitwiseXORExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1250, 96);
					 retval.value = new BinaryExpression(BinaryExpressionType.BitwiseOr, retval.value, right.value); 

					}
					break;

				default:
					goto loop45;
				}
			}

			loop45:
				;

			} finally { DebugExitSubRule(45); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseORExpressionNoIn", 37);
			LeaveRule("bitwiseORExpressionNoIn", 37);
			Leave_bitwiseORExpressionNoIn();
		}
		DebugLocation(1251, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseORExpressionNoIn"

	public class logicalANDExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalANDExpression();
	partial void Leave_logicalANDExpression();

	// $ANTLR start "logicalANDExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1257:1: logicalANDExpression returns [Expression value] : left= bitwiseORExpression ( LAND right= bitwiseORExpression )* ;
	[GrammarRule("logicalANDExpression")]
	private ES3Parser.logicalANDExpression_return logicalANDExpression()
	{
		Enter_logicalANDExpression();
		EnterRule("logicalANDExpression", 38);
		TraceIn("logicalANDExpression", 38);
		ES3Parser.logicalANDExpression_return retval = new ES3Parser.logicalANDExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LAND71=null;
		ES3Parser.bitwiseORExpression_return left = default(ES3Parser.bitwiseORExpression_return);
		ES3Parser.bitwiseORExpression_return right = default(ES3Parser.bitwiseORExpression_return);

		object LAND71_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalANDExpression");
		DebugLocation(1257, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1258:2: (left= bitwiseORExpression ( LAND right= bitwiseORExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1258:3: left= bitwiseORExpression ( LAND right= bitwiseORExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1258, 7);
			PushFollow(Follow._bitwiseORExpression_in_logicalANDExpression4686);
			left=bitwiseORExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1258, 29);
			 retval.value = left.value; 
			DebugLocation(1258, 54);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1258:54: ( LAND right= bitwiseORExpression )*
			try { DebugEnterSubRule(46);
			while (true)
			{
				int alt46=2;
				try { DebugEnterDecision(46, decisionCanBacktrack[46]);
				int LA46_0 = input.LA(1);

				if ((LA46_0==LAND))
				{
					alt46=1;
				}


				} finally { DebugExitDecision(46); }
				switch ( alt46 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1258:56: LAND right= bitwiseORExpression
					{
					DebugLocation(1258, 60);
					LAND71=(IToken)Match(input,LAND,Follow._LAND_in_logicalANDExpression4692); 
					LAND71_tree = (object)adaptor.Create(LAND71);
					root_0 = (object)adaptor.BecomeRoot(LAND71_tree, root_0);

					DebugLocation(1258, 67);
					PushFollow(Follow._bitwiseORExpression_in_logicalANDExpression4697);
					right=bitwiseORExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1258, 88);
					 retval.value = new BinaryExpression(BinaryExpressionType.And, retval.value, right.value); 

					}
					break;

				default:
					goto loop46;
				}
			}

			loop46:
				;

			} finally { DebugExitSubRule(46); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalANDExpression", 38);
			LeaveRule("logicalANDExpression", 38);
			Leave_logicalANDExpression();
		}
		DebugLocation(1259, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalANDExpression"); }
		return retval;

	}
	// $ANTLR end "logicalANDExpression"

	public class logicalANDExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalANDExpressionNoIn();
	partial void Leave_logicalANDExpressionNoIn();

	// $ANTLR start "logicalANDExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1261:1: logicalANDExpressionNoIn returns [Expression value] : left= bitwiseORExpressionNoIn ( LAND right= bitwiseORExpressionNoIn )* ;
	[GrammarRule("logicalANDExpressionNoIn")]
	private ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
	{
		Enter_logicalANDExpressionNoIn();
		EnterRule("logicalANDExpressionNoIn", 39);
		TraceIn("logicalANDExpressionNoIn", 39);
		ES3Parser.logicalANDExpressionNoIn_return retval = new ES3Parser.logicalANDExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LAND72=null;
		ES3Parser.bitwiseORExpressionNoIn_return left = default(ES3Parser.bitwiseORExpressionNoIn_return);
		ES3Parser.bitwiseORExpressionNoIn_return right = default(ES3Parser.bitwiseORExpressionNoIn_return);

		object LAND72_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalANDExpressionNoIn");
		DebugLocation(1261, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1262:2: (left= bitwiseORExpressionNoIn ( LAND right= bitwiseORExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1262:3: left= bitwiseORExpressionNoIn ( LAND right= bitwiseORExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1262, 7);
			PushFollow(Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718);
			left=bitwiseORExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1262, 33);
			 retval.value = left.value; 
			DebugLocation(1262, 58);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1262:58: ( LAND right= bitwiseORExpressionNoIn )*
			try { DebugEnterSubRule(47);
			while (true)
			{
				int alt47=2;
				try { DebugEnterDecision(47, decisionCanBacktrack[47]);
				int LA47_0 = input.LA(1);

				if ((LA47_0==LAND))
				{
					alt47=1;
				}


				} finally { DebugExitDecision(47); }
				switch ( alt47 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1262:60: LAND right= bitwiseORExpressionNoIn
					{
					DebugLocation(1262, 64);
					LAND72=(IToken)Match(input,LAND,Follow._LAND_in_logicalANDExpressionNoIn4724); 
					LAND72_tree = (object)adaptor.Create(LAND72);
					root_0 = (object)adaptor.BecomeRoot(LAND72_tree, root_0);

					DebugLocation(1262, 71);
					PushFollow(Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729);
					right=bitwiseORExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1262, 96);
					 retval.value = new BinaryExpression(BinaryExpressionType.And, retval.value, right.value); 

					}
					break;

				default:
					goto loop47;
				}
			}

			loop47:
				;

			} finally { DebugExitSubRule(47); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalANDExpressionNoIn", 39);
			LeaveRule("logicalANDExpressionNoIn", 39);
			Leave_logicalANDExpressionNoIn();
		}
		DebugLocation(1263, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalANDExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "logicalANDExpressionNoIn"

	public class logicalORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalORExpression();
	partial void Leave_logicalORExpression();

	// $ANTLR start "logicalORExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1265:1: logicalORExpression returns [Expression value] : left= logicalANDExpression ( LOR right= logicalANDExpression )* ;
	[GrammarRule("logicalORExpression")]
	private ES3Parser.logicalORExpression_return logicalORExpression()
	{
		Enter_logicalORExpression();
		EnterRule("logicalORExpression", 40);
		TraceIn("logicalORExpression", 40);
		ES3Parser.logicalORExpression_return retval = new ES3Parser.logicalORExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LOR73=null;
		ES3Parser.logicalANDExpression_return left = default(ES3Parser.logicalANDExpression_return);
		ES3Parser.logicalANDExpression_return right = default(ES3Parser.logicalANDExpression_return);

		object LOR73_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalORExpression");
		DebugLocation(1265, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1266:2: (left= logicalANDExpression ( LOR right= logicalANDExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1266:4: left= logicalANDExpression ( LOR right= logicalANDExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1266, 8);
			PushFollow(Follow._logicalANDExpression_in_logicalORExpression4751);
			left=logicalANDExpression();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1266, 30);
			 retval.value = left.value; 
			DebugLocation(1266, 55);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1266:55: ( LOR right= logicalANDExpression )*
			try { DebugEnterSubRule(48);
			while (true)
			{
				int alt48=2;
				try { DebugEnterDecision(48, decisionCanBacktrack[48]);
				int LA48_0 = input.LA(1);

				if ((LA48_0==LOR))
				{
					alt48=1;
				}


				} finally { DebugExitDecision(48); }
				switch ( alt48 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1266:57: LOR right= logicalANDExpression
					{
					DebugLocation(1266, 60);
					LOR73=(IToken)Match(input,LOR,Follow._LOR_in_logicalORExpression4757); 
					LOR73_tree = (object)adaptor.Create(LOR73);
					root_0 = (object)adaptor.BecomeRoot(LOR73_tree, root_0);

					DebugLocation(1266, 67);
					PushFollow(Follow._logicalANDExpression_in_logicalORExpression4762);
					right=logicalANDExpression();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1266, 89);
					 retval.value = new BinaryExpression(BinaryExpressionType.Or, retval.value, right.value); 

					}
					break;

				default:
					goto loop48;
				}
			}

			loop48:
				;

			} finally { DebugExitSubRule(48); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalORExpression", 40);
			LeaveRule("logicalORExpression", 40);
			Leave_logicalORExpression();
		}
		DebugLocation(1267, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalORExpression"); }
		return retval;

	}
	// $ANTLR end "logicalORExpression"

	public class logicalORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalORExpressionNoIn();
	partial void Leave_logicalORExpressionNoIn();

	// $ANTLR start "logicalORExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1269:1: logicalORExpressionNoIn returns [Expression value] : left= logicalANDExpressionNoIn ( LOR right= logicalANDExpressionNoIn )* ;
	[GrammarRule("logicalORExpressionNoIn")]
	private ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
	{
		Enter_logicalORExpressionNoIn();
		EnterRule("logicalORExpressionNoIn", 41);
		TraceIn("logicalORExpressionNoIn", 41);
		ES3Parser.logicalORExpressionNoIn_return retval = new ES3Parser.logicalORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken LOR74=null;
		ES3Parser.logicalANDExpressionNoIn_return left = default(ES3Parser.logicalANDExpressionNoIn_return);
		ES3Parser.logicalANDExpressionNoIn_return right = default(ES3Parser.logicalANDExpressionNoIn_return);

		object LOR74_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalORExpressionNoIn");
		DebugLocation(1269, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1270:2: (left= logicalANDExpressionNoIn ( LOR right= logicalANDExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1270:4: left= logicalANDExpressionNoIn ( LOR right= logicalANDExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1270, 8);
			PushFollow(Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784);
			left=logicalANDExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, left.Tree);
			DebugLocation(1270, 34);
			 retval.value = left.value; 
			DebugLocation(1270, 59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1270:59: ( LOR right= logicalANDExpressionNoIn )*
			try { DebugEnterSubRule(49);
			while (true)
			{
				int alt49=2;
				try { DebugEnterDecision(49, decisionCanBacktrack[49]);
				int LA49_0 = input.LA(1);

				if ((LA49_0==LOR))
				{
					alt49=1;
				}


				} finally { DebugExitDecision(49); }
				switch ( alt49 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1270:61: LOR right= logicalANDExpressionNoIn
					{
					DebugLocation(1270, 64);
					LOR74=(IToken)Match(input,LOR,Follow._LOR_in_logicalORExpressionNoIn4790); 
					LOR74_tree = (object)adaptor.Create(LOR74);
					root_0 = (object)adaptor.BecomeRoot(LOR74_tree, root_0);

					DebugLocation(1270, 71);
					PushFollow(Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795);
					right=logicalANDExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, right.Tree);
					DebugLocation(1270, 97);
					 retval.value = new BinaryExpression(BinaryExpressionType.Or, retval.value, right.value); 

					}
					break;

				default:
					goto loop49;
				}
			}

			loop49:
				;

			} finally { DebugExitSubRule(49); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalORExpressionNoIn", 41);
			LeaveRule("logicalORExpressionNoIn", 41);
			Leave_logicalORExpressionNoIn();
		}
		DebugLocation(1271, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "logicalORExpressionNoIn"

	public class conditionalExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_conditionalExpression();
	partial void Leave_conditionalExpression();

	// $ANTLR start "conditionalExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1277:1: conditionalExpression returns [Expression value] : expr1= logicalORExpression ( QUE expr2= assignmentExpression COLON expr3= assignmentExpression )? ;
	[GrammarRule("conditionalExpression")]
	private ES3Parser.conditionalExpression_return conditionalExpression()
	{
		Enter_conditionalExpression();
		EnterRule("conditionalExpression", 42);
		TraceIn("conditionalExpression", 42);
		ES3Parser.conditionalExpression_return retval = new ES3Parser.conditionalExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken QUE75=null;
		IToken COLON76=null;
		ES3Parser.logicalORExpression_return expr1 = default(ES3Parser.logicalORExpression_return);
		ES3Parser.assignmentExpression_return expr2 = default(ES3Parser.assignmentExpression_return);
		ES3Parser.assignmentExpression_return expr3 = default(ES3Parser.assignmentExpression_return);

		object QUE75_tree=null;
		object COLON76_tree=null;

		try { DebugEnterRule(GrammarFileName, "conditionalExpression");
		DebugLocation(1277, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1278:2: (expr1= logicalORExpression ( QUE expr2= assignmentExpression COLON expr3= assignmentExpression )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1278:4: expr1= logicalORExpression ( QUE expr2= assignmentExpression COLON expr3= assignmentExpression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1278, 9);
			PushFollow(Follow._logicalORExpression_in_conditionalExpression4822);
			expr1=logicalORExpression();
			PopFollow();

			adaptor.AddChild(root_0, expr1.Tree);
			DebugLocation(1278, 30);
			 retval.value = expr1.value; 
			DebugLocation(1278, 56);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1278:56: ( QUE expr2= assignmentExpression COLON expr3= assignmentExpression )?
			int alt50=2;
			try { DebugEnterSubRule(50);
			try { DebugEnterDecision(50, decisionCanBacktrack[50]);
			int LA50_0 = input.LA(1);

			if ((LA50_0==QUE))
			{
				alt50=1;
			}
			} finally { DebugExitDecision(50); }
			switch (alt50)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1278:58: QUE expr2= assignmentExpression COLON expr3= assignmentExpression
				{
				DebugLocation(1278, 61);
				QUE75=(IToken)Match(input,QUE,Follow._QUE_in_conditionalExpression4828); 
				QUE75_tree = (object)adaptor.Create(QUE75);
				root_0 = (object)adaptor.BecomeRoot(QUE75_tree, root_0);

				DebugLocation(1278, 68);
				PushFollow(Follow._assignmentExpression_in_conditionalExpression4833);
				expr2=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, expr2.Tree);
				DebugLocation(1278, 95);
				COLON76=(IToken)Match(input,COLON,Follow._COLON_in_conditionalExpression4835); 
				DebugLocation(1278, 102);
				PushFollow(Follow._assignmentExpression_in_conditionalExpression4840);
				expr3=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, expr3.Tree);
				DebugLocation(1278, 124);
				 retval.value = new TernaryExpression(expr1.value, expr2.value, expr3.value); 

				}
				break;

			}
			} finally { DebugExitSubRule(50); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("conditionalExpression", 42);
			LeaveRule("conditionalExpression", 42);
			Leave_conditionalExpression();
		}
		DebugLocation(1279, 1);
		} finally { DebugExitRule(GrammarFileName, "conditionalExpression"); }
		return retval;

	}
	// $ANTLR end "conditionalExpression"

	public class conditionalExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_conditionalExpressionNoIn();
	partial void Leave_conditionalExpressionNoIn();

	// $ANTLR start "conditionalExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1281:1: conditionalExpressionNoIn returns [Expression value] : expr1= logicalORExpressionNoIn ( QUE expr2= assignmentExpressionNoIn COLON expr3= assignmentExpressionNoIn )? ;
	[GrammarRule("conditionalExpressionNoIn")]
	private ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
	{
		Enter_conditionalExpressionNoIn();
		EnterRule("conditionalExpressionNoIn", 43);
		TraceIn("conditionalExpressionNoIn", 43);
		ES3Parser.conditionalExpressionNoIn_return retval = new ES3Parser.conditionalExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken QUE77=null;
		IToken COLON78=null;
		ES3Parser.logicalORExpressionNoIn_return expr1 = default(ES3Parser.logicalORExpressionNoIn_return);
		ES3Parser.assignmentExpressionNoIn_return expr2 = default(ES3Parser.assignmentExpressionNoIn_return);
		ES3Parser.assignmentExpressionNoIn_return expr3 = default(ES3Parser.assignmentExpressionNoIn_return);

		object QUE77_tree=null;
		object COLON78_tree=null;

		try { DebugEnterRule(GrammarFileName, "conditionalExpressionNoIn");
		DebugLocation(1281, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1282:2: (expr1= logicalORExpressionNoIn ( QUE expr2= assignmentExpressionNoIn COLON expr3= assignmentExpressionNoIn )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1282:4: expr1= logicalORExpressionNoIn ( QUE expr2= assignmentExpressionNoIn COLON expr3= assignmentExpressionNoIn )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1282, 9);
			PushFollow(Follow._logicalORExpressionNoIn_in_conditionalExpressionNoIn4861);
			expr1=logicalORExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, expr1.Tree);
			DebugLocation(1282, 34);
			 retval.value = expr1.value; 
			DebugLocation(1282, 60);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1282:60: ( QUE expr2= assignmentExpressionNoIn COLON expr3= assignmentExpressionNoIn )?
			int alt51=2;
			try { DebugEnterSubRule(51);
			try { DebugEnterDecision(51, decisionCanBacktrack[51]);
			int LA51_0 = input.LA(1);

			if ((LA51_0==QUE))
			{
				alt51=1;
			}
			} finally { DebugExitDecision(51); }
			switch (alt51)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1282:62: QUE expr2= assignmentExpressionNoIn COLON expr3= assignmentExpressionNoIn
				{
				DebugLocation(1282, 65);
				QUE77=(IToken)Match(input,QUE,Follow._QUE_in_conditionalExpressionNoIn4867); 
				QUE77_tree = (object)adaptor.Create(QUE77);
				root_0 = (object)adaptor.BecomeRoot(QUE77_tree, root_0);

				DebugLocation(1282, 72);
				PushFollow(Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4872);
				expr2=assignmentExpressionNoIn();
				PopFollow();

				adaptor.AddChild(root_0, expr2.Tree);
				DebugLocation(1282, 103);
				COLON78=(IToken)Match(input,COLON,Follow._COLON_in_conditionalExpressionNoIn4874); 
				DebugLocation(1282, 110);
				PushFollow(Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4879);
				expr3=assignmentExpressionNoIn();
				PopFollow();

				adaptor.AddChild(root_0, expr3.Tree);
				DebugLocation(1282, 136);
				 retval.value = new TernaryExpression(expr1.value, expr2.value, expr3.value); 

				}
				break;

			}
			} finally { DebugExitSubRule(51); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("conditionalExpressionNoIn", 43);
			LeaveRule("conditionalExpressionNoIn", 43);
			Leave_conditionalExpressionNoIn();
		}
		DebugLocation(1283, 1);
		} finally { DebugExitRule(GrammarFileName, "conditionalExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "conditionalExpressionNoIn"

	public class assignmentExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentExpression();
	partial void Leave_assignmentExpression();

	// $ANTLR start "assignmentExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1311:1: assignmentExpression returns [Expression value] : lhs= conditionalExpression ({...}?ass= assignmentOperator exp= assignmentExpression )? ;
	[GrammarRule("assignmentExpression")]
	private ES3Parser.assignmentExpression_return assignmentExpression()
	{
		Enter_assignmentExpression();
		EnterRule("assignmentExpression", 44);
		TraceIn("assignmentExpression", 44);
		ES3Parser.assignmentExpression_return retval = new ES3Parser.assignmentExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.conditionalExpression_return lhs = default(ES3Parser.conditionalExpression_return);
		ES3Parser.assignmentOperator_return ass = default(ES3Parser.assignmentOperator_return);
		ES3Parser.assignmentExpression_return exp = default(ES3Parser.assignmentExpression_return);



			Object[] isLhs = new Object[1];
			var assignment = new AssignmentExpression();

		try { DebugEnterRule(GrammarFileName, "assignmentExpression");
		DebugLocation(1311, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1317:2: (lhs= conditionalExpression ({...}?ass= assignmentOperator exp= assignmentExpression )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1317:4: lhs= conditionalExpression ({...}?ass= assignmentOperator exp= assignmentExpression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1317, 7);
			PushFollow(Follow._conditionalExpression_in_assignmentExpression4912);
			lhs=conditionalExpression();
			PopFollow();

			adaptor.AddChild(root_0, lhs.Tree);
			DebugLocation(1317, 30);
			 retval.value = assignment.Left = lhs.value; 
			DebugLocation(1318, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1318:2: ({...}?ass= assignmentOperator exp= assignmentExpression )?
			int alt52=2;
			try { DebugEnterSubRule(52);
			try { DebugEnterDecision(52, decisionCanBacktrack[52]);
			int LA52_0 = input.LA(1);

			if ((LA52_0==ADDASS||LA52_0==ANDASS||LA52_0==ASSIGN||LA52_0==DIVASS||LA52_0==MODASS||LA52_0==MULASS||LA52_0==ORASS||LA52_0==SHLASS||LA52_0==SHRASS||LA52_0==SHUASS||LA52_0==SUBASS||LA52_0==XORASS))
			{
				int LA52_1 = input.LA(2);

				if ((( IsLeftHandSideAssign(lhs.value, isLhs) )))
				{
					alt52=1;
				}
			}
			} finally { DebugExitDecision(52); }
			switch (alt52)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1318:5: {...}?ass= assignmentOperator exp= assignmentExpression
				{
				DebugLocation(1318, 5);
				if (!(( IsLeftHandSideAssign(lhs.value, isLhs) )))
				{
					throw new FailedPredicateException(input, "assignmentExpression", " IsLeftHandSideAssign(lhs.value, isLhs) ");
				}
				DebugLocation(1318, 52);
				PushFollow(Follow._assignmentOperator_in_assignmentExpression4924);
				ass=assignmentOperator();
				PopFollow();

				root_0 = (object)adaptor.BecomeRoot(ass.Tree, root_0);
				DebugLocation(1318, 73);
				 assignment.AssignmentOperator = ResolveAssignmentOperator((ass!=null?input.ToString(ass.Start,ass.Stop):null)); 
				DebugLocation(1318, 150);
				PushFollow(Follow._assignmentExpression_in_assignmentExpression4931);
				exp=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, exp.Tree);
				DebugLocation(1318, 172);
				  assignment.Right = exp.value; retval.value = assignment; 

				}
				break;

			}
			} finally { DebugExitSubRule(52); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentExpression", 44);
			LeaveRule("assignmentExpression", 44);
			Leave_assignmentExpression();
		}
		DebugLocation(1319, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentExpression"); }
		return retval;

	}
	// $ANTLR end "assignmentExpression"

	public class assignmentOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentOperator();
	partial void Leave_assignmentOperator();

	// $ANTLR start "assignmentOperator"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1321:1: assignmentOperator : ( ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS );
	[GrammarRule("assignmentOperator")]
	private ES3Parser.assignmentOperator_return assignmentOperator()
	{
		Enter_assignmentOperator();
		EnterRule("assignmentOperator", 45);
		TraceIn("assignmentOperator", 45);
		ES3Parser.assignmentOperator_return retval = new ES3Parser.assignmentOperator_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set79=null;

		object set79_tree=null;

		try { DebugEnterRule(GrammarFileName, "assignmentOperator");
		DebugLocation(1321, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1322:2: ( ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1322, 2);
			set79=(IToken)input.LT(1);
			if (input.LA(1)==ADDASS||input.LA(1)==ANDASS||input.LA(1)==ASSIGN||input.LA(1)==DIVASS||input.LA(1)==MODASS||input.LA(1)==MULASS||input.LA(1)==ORASS||input.LA(1)==SHLASS||input.LA(1)==SHRASS||input.LA(1)==SHUASS||input.LA(1)==SUBASS||input.LA(1)==XORASS)
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set79));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentOperator", 45);
			LeaveRule("assignmentOperator", 45);
			Leave_assignmentOperator();
		}
		DebugLocation(1334, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentOperator"); }
		return retval;

	}
	// $ANTLR end "assignmentOperator"

	public class assignmentExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentExpressionNoIn();
	partial void Leave_assignmentExpressionNoIn();

	// $ANTLR start "assignmentExpressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1336:1: assignmentExpressionNoIn returns [Expression value] : lhs= conditionalExpressionNoIn ({...}?ass= assignmentOperator exp= assignmentExpressionNoIn )? ;
	[GrammarRule("assignmentExpressionNoIn")]
	private ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
	{
		Enter_assignmentExpressionNoIn();
		EnterRule("assignmentExpressionNoIn", 46);
		TraceIn("assignmentExpressionNoIn", 46);
		ES3Parser.assignmentExpressionNoIn_return retval = new ES3Parser.assignmentExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.conditionalExpressionNoIn_return lhs = default(ES3Parser.conditionalExpressionNoIn_return);
		ES3Parser.assignmentOperator_return ass = default(ES3Parser.assignmentOperator_return);
		ES3Parser.assignmentExpressionNoIn_return exp = default(ES3Parser.assignmentExpressionNoIn_return);



			object[] isLhs = new object[1];
			var assignment = new AssignmentExpression();

		try { DebugEnterRule(GrammarFileName, "assignmentExpressionNoIn");
		DebugLocation(1336, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1342:2: (lhs= conditionalExpressionNoIn ({...}?ass= assignmentOperator exp= assignmentExpressionNoIn )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1342:4: lhs= conditionalExpressionNoIn ({...}?ass= assignmentOperator exp= assignmentExpressionNoIn )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1342, 7);
			PushFollow(Follow._conditionalExpressionNoIn_in_assignmentExpressionNoIn5026);
			lhs=conditionalExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, lhs.Tree);
			DebugLocation(1342, 34);
			  assignment.Left = retval.value = (lhs!=null?lhs.value:default(Expression)); 
			DebugLocation(1343, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1343:2: ({...}?ass= assignmentOperator exp= assignmentExpressionNoIn )?
			int alt53=2;
			try { DebugEnterSubRule(53);
			try { DebugEnterDecision(53, decisionCanBacktrack[53]);
			int LA53_0 = input.LA(1);

			if ((LA53_0==ADDASS||LA53_0==ANDASS||LA53_0==ASSIGN||LA53_0==DIVASS||LA53_0==MODASS||LA53_0==MULASS||LA53_0==ORASS||LA53_0==SHLASS||LA53_0==SHRASS||LA53_0==SHUASS||LA53_0==SUBASS||LA53_0==XORASS))
			{
				int LA53_1 = input.LA(2);

				if ((( IsLeftHandSideAssign(lhs.value, isLhs) )))
				{
					alt53=1;
				}
			}
			} finally { DebugExitDecision(53); }
			switch (alt53)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1343:4: {...}?ass= assignmentOperator exp= assignmentExpressionNoIn
				{
				DebugLocation(1343, 4);
				if (!(( IsLeftHandSideAssign(lhs.value, isLhs) )))
				{
					throw new FailedPredicateException(input, "assignmentExpressionNoIn", " IsLeftHandSideAssign(lhs.value, isLhs) ");
				}
				DebugLocation(1343, 51);
				PushFollow(Follow._assignmentOperator_in_assignmentExpressionNoIn5038);
				ass=assignmentOperator();
				PopFollow();

				root_0 = (object)adaptor.BecomeRoot(ass.Tree, root_0);
				DebugLocation(1343, 72);
				 assignment.AssignmentOperator = ResolveAssignmentOperator((ass!=null?input.ToString(ass.Start,ass.Stop):null)); 
				DebugLocation(1343, 149);
				PushFollow(Follow._assignmentExpressionNoIn_in_assignmentExpressionNoIn5045);
				exp=assignmentExpressionNoIn();
				PopFollow();

				adaptor.AddChild(root_0, exp.Tree);
				DebugLocation(1343, 175);
				  assignment.Right = exp.value; retval.value = assignment; 

				}
				break;

			}
			} finally { DebugExitSubRule(53); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentExpressionNoIn", 46);
			LeaveRule("assignmentExpressionNoIn", 46);
			Leave_assignmentExpressionNoIn();
		}
		DebugLocation(1344, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "assignmentExpressionNoIn"

	public class expression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expression();
	partial void Leave_expression();

	// $ANTLR start "expression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1350:1: expression returns [Expression value] : first= assignmentExpression ( COMMA follow= assignmentExpression )* ;
	[GrammarRule("expression")]
	private ES3Parser.expression_return expression()
	{
		Enter_expression();
		EnterRule("expression", 47);
		TraceIn("expression", 47);
		ES3Parser.expression_return retval = new ES3Parser.expression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken COMMA80=null;
		ES3Parser.assignmentExpression_return first = default(ES3Parser.assignmentExpression_return);
		ES3Parser.assignmentExpression_return follow = default(ES3Parser.assignmentExpression_return);

		object COMMA80_tree=null;


			var cs = new CommaOperatorStatement();

		try { DebugEnterRule(GrammarFileName, "expression");
		DebugLocation(1350, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1354:2: (first= assignmentExpression ( COMMA follow= assignmentExpression )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1354:4: first= assignmentExpression ( COMMA follow= assignmentExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1354, 9);
			PushFollow(Follow._assignmentExpression_in_expression5077);
			first=assignmentExpression();
			PopFollow();

			adaptor.AddChild(root_0, first.Tree);
			DebugLocation(1354, 31);
			 retval.value = first.value; 
			DebugLocation(1354, 57);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1354:57: ( COMMA follow= assignmentExpression )*
			try { DebugEnterSubRule(54);
			while (true)
			{
				int alt54=2;
				try { DebugEnterDecision(54, decisionCanBacktrack[54]);
				int LA54_0 = input.LA(1);

				if ((LA54_0==COMMA))
				{
					alt54=1;
				}


				} finally { DebugExitDecision(54); }
				switch ( alt54 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1354:59: COMMA follow= assignmentExpression
					{
					DebugLocation(1354, 59);
					COMMA80=(IToken)Match(input,COMMA,Follow._COMMA_in_expression5083); 
					COMMA80_tree = (object)adaptor.Create(COMMA80);
					adaptor.AddChild(root_0, COMMA80_tree);

					DebugLocation(1354, 65);
					 if(cs.Statements.Count == 0) { cs.Statements.Add(retval.value); retval.value = cs; } 
					DebugLocation(1354, 148);
					PushFollow(Follow._assignmentExpression_in_expression5089);
					follow=assignmentExpression();
					PopFollow();

					adaptor.AddChild(root_0, follow.Tree);
					DebugLocation(1354, 171);
					 cs.Statements.Add(follow.value); 

					}
					break;

				default:
					goto loop54;
				}
			}

			loop54:
				;

			} finally { DebugExitSubRule(54); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expression", 47);
			LeaveRule("expression", 47);
			Leave_expression();
		}
		DebugLocation(1355, 1);
		} finally { DebugExitRule(GrammarFileName, "expression"); }
		return retval;

	}
	// $ANTLR end "expression"

	public class expressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Expression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expressionNoIn();
	partial void Leave_expressionNoIn();

	// $ANTLR start "expressionNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1357:1: expressionNoIn returns [Expression value] : first= assignmentExpressionNoIn ( COMMA follow= assignmentExpressionNoIn )* ;
	[GrammarRule("expressionNoIn")]
	private ES3Parser.expressionNoIn_return expressionNoIn()
	{
		Enter_expressionNoIn();
		EnterRule("expressionNoIn", 48);
		TraceIn("expressionNoIn", 48);
		ES3Parser.expressionNoIn_return retval = new ES3Parser.expressionNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken COMMA81=null;
		ES3Parser.assignmentExpressionNoIn_return first = default(ES3Parser.assignmentExpressionNoIn_return);
		ES3Parser.assignmentExpressionNoIn_return follow = default(ES3Parser.assignmentExpressionNoIn_return);

		object COMMA81_tree=null;


			var cs = new CommaOperatorStatement();

		try { DebugEnterRule(GrammarFileName, "expressionNoIn");
		DebugLocation(1357, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1361:2: (first= assignmentExpressionNoIn ( COMMA follow= assignmentExpressionNoIn )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1361:4: first= assignmentExpressionNoIn ( COMMA follow= assignmentExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1361, 9);
			PushFollow(Follow._assignmentExpressionNoIn_in_expressionNoIn5117);
			first=assignmentExpressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, first.Tree);
			DebugLocation(1361, 35);
			 retval.value = first.value; 
			DebugLocation(1361, 61);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1361:61: ( COMMA follow= assignmentExpressionNoIn )*
			try { DebugEnterSubRule(55);
			while (true)
			{
				int alt55=2;
				try { DebugEnterDecision(55, decisionCanBacktrack[55]);
				int LA55_0 = input.LA(1);

				if ((LA55_0==COMMA))
				{
					alt55=1;
				}


				} finally { DebugExitDecision(55); }
				switch ( alt55 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1361:63: COMMA follow= assignmentExpressionNoIn
					{
					DebugLocation(1361, 63);
					COMMA81=(IToken)Match(input,COMMA,Follow._COMMA_in_expressionNoIn5123); 
					COMMA81_tree = (object)adaptor.Create(COMMA81);
					adaptor.AddChild(root_0, COMMA81_tree);

					DebugLocation(1361, 69);
					if(cs.Statements.Count == 0) { cs.Statements.Add(retval.value); retval.value = cs; } 
					DebugLocation(1361, 151);
					PushFollow(Follow._assignmentExpressionNoIn_in_expressionNoIn5129);
					follow=assignmentExpressionNoIn();
					PopFollow();

					adaptor.AddChild(root_0, follow.Tree);
					DebugLocation(1361, 178);
					 cs.Statements.Add(follow.value); 

					}
					break;

				default:
					goto loop55;
				}
			}

			loop55:
				;

			} finally { DebugExitSubRule(55); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expressionNoIn", 48);
			LeaveRule("expressionNoIn", 48);
			Leave_expressionNoIn();
		}
		DebugLocation(1362, 1);
		} finally { DebugExitRule(GrammarFileName, "expressionNoIn"); }
		return retval;

	}
	// $ANTLR end "expressionNoIn"

	public class semic_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_semic();
	partial void Leave_semic();

	// $ANTLR start "semic"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1386:1: semic : ( SEMIC | EOF | RBRACE | EOL | MultiLineComment );
	[GrammarRule("semic")]
	private ES3Parser.semic_return semic()
	{
		Enter_semic();
		EnterRule("semic", 49);
		TraceIn("semic", 49);
		ES3Parser.semic_return retval = new ES3Parser.semic_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken SEMIC82=null;
		IToken EOF83=null;
		IToken RBRACE84=null;
		IToken EOL85=null;
		IToken MultiLineComment86=null;

		object SEMIC82_tree=null;
		object EOF83_tree=null;
		object RBRACE84_tree=null;
		object EOL85_tree=null;
		object MultiLineComment86_tree=null;


			// Mark current position so we can unconsume a RBRACE.
			int marker = input.Mark();
			// Promote EOL if appropriate	
			PromoteEOL(retval);

		try { DebugEnterRule(GrammarFileName, "semic");
		DebugLocation(1386, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1394:2: ( SEMIC | EOF | RBRACE | EOL | MultiLineComment )
			int alt56=5;
			try { DebugEnterDecision(56, decisionCanBacktrack[56]);
			switch (input.LA(1))
			{
			case SEMIC:
				{
				alt56=1;
				}
				break;
			case EOF:
				{
				alt56=2;
				}
				break;
			case RBRACE:
				{
				alt56=3;
				}
				break;
			case EOL:
				{
				alt56=4;
				}
				break;
			case MultiLineComment:
				{
				alt56=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 56, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(56); }
			switch (alt56)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1394:4: SEMIC
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1394, 4);
				SEMIC82=(IToken)Match(input,SEMIC,Follow._SEMIC_in_semic5163); 
				SEMIC82_tree = (object)adaptor.Create(SEMIC82);
				adaptor.AddChild(root_0, SEMIC82_tree);


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1395:4: EOF
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1395, 4);
				EOF83=(IToken)Match(input,EOF,Follow._EOF_in_semic5168); 
				EOF83_tree = (object)adaptor.Create(EOF83);
				adaptor.AddChild(root_0, EOF83_tree);


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1396:4: RBRACE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1396, 4);
				RBRACE84=(IToken)Match(input,RBRACE,Follow._RBRACE_in_semic5173); 
				RBRACE84_tree = (object)adaptor.Create(RBRACE84);
				adaptor.AddChild(root_0, RBRACE84_tree);

				DebugLocation(1396, 11);
				 input.Rewind(marker); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1397:4: EOL
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1397, 4);
				EOL85=(IToken)Match(input,EOL,Follow._EOL_in_semic5180); 
				EOL85_tree = (object)adaptor.Create(EOL85);
				adaptor.AddChild(root_0, EOL85_tree);


				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1397:10: MultiLineComment
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1397, 10);
				MultiLineComment86=(IToken)Match(input,MultiLineComment,Follow._MultiLineComment_in_semic5184); 
				MultiLineComment86_tree = (object)adaptor.Create(MultiLineComment86);
				adaptor.AddChild(root_0, MultiLineComment86_tree);


				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("semic", 49);
			LeaveRule("semic", 49);
			Leave_semic();
		}
		DebugLocation(1398, 1);
		} finally { DebugExitRule(GrammarFileName, "semic"); }
		return retval;

	}
	// $ANTLR end "semic"

	public class statement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statement();
	partial void Leave_statement();

	// $ANTLR start "statement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1405:1: statement returns [Statement value] options {k=1; } : ({...}? block |{...}?func= functionDeclaration | statementTail );
	[GrammarRule("statement")]
	private ES3Parser.statement_return statement()
	{
		Enter_statement();
		EnterRule("statement", 50);
		TraceIn("statement", 50);
		ES3Parser.statement_return retval = new ES3Parser.statement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.functionDeclaration_return func = default(ES3Parser.functionDeclaration_return);
		ES3Parser.block_return block87 = default(ES3Parser.block_return);
		ES3Parser.statementTail_return statementTail88 = default(ES3Parser.statementTail_return);


		try { DebugEnterRule(GrammarFileName, "statement");
		DebugLocation(1405, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1411:2: ({...}? block |{...}?func= functionDeclaration | statementTail )
			int alt57=3;
			try { DebugEnterDecision(57, decisionCanBacktrack[57]);
			try
			{
				alt57 = dfa57.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(57); }
			switch (alt57)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1411:4: {...}? block
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1411, 4);
				if (!(( input.LA(1) == LBRACE )))
				{
					throw new FailedPredicateException(input, "statement", " input.LA(1) == LBRACE ");
				}
				DebugLocation(1411, 31);
				PushFollow(Follow._block_in_statement5218);
				block87=block();
				PopFollow();

				adaptor.AddChild(root_0, block87.Tree);
				DebugLocation(1411, 37);
				 retval.value = (block87!=null?block87.value:default(BlockStatement)); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1412:4: {...}?func= functionDeclaration
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1412, 4);
				if (!(( input.LA(1) == FUNCTION )))
				{
					throw new FailedPredicateException(input, "statement", " input.LA(1) == FUNCTION ");
				}
				DebugLocation(1412, 37);
				PushFollow(Follow._functionDeclaration_in_statement5229);
				func=functionDeclaration();
				PopFollow();

				adaptor.AddChild(root_0, func.Tree);
				DebugLocation(1412, 58);
				 retval.value = func.value; 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1413:4: statementTail
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1413, 4);
				PushFollow(Follow._statementTail_in_statement5236);
				statementTail88=statementTail();
				PopFollow();

				adaptor.AddChild(root_0, statementTail88.Tree);
				DebugLocation(1413, 18);
				 retval.value = (statementTail88!=null?statementTail88.value:default(Statement)); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statement", 50);
			LeaveRule("statement", 50);
			Leave_statement();
		}
		DebugLocation(1414, 1);
		} finally { DebugExitRule(GrammarFileName, "statement"); }
		return retval;

	}
	// $ANTLR end "statement"

	public class statementTail_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statementTail();
	partial void Leave_statementTail();

	// $ANTLR start "statementTail"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1416:1: statementTail returns [Statement value] : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );
	[GrammarRule("statementTail")]
	private ES3Parser.statementTail_return statementTail()
	{
		Enter_statementTail();
		EnterRule("statementTail", 51);
		TraceIn("statementTail", 51);
		ES3Parser.statementTail_return retval = new ES3Parser.statementTail_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.variableStatement_return variableStatement89 = default(ES3Parser.variableStatement_return);
		ES3Parser.emptyStatement_return emptyStatement90 = default(ES3Parser.emptyStatement_return);
		ES3Parser.expressionStatement_return expressionStatement91 = default(ES3Parser.expressionStatement_return);
		ES3Parser.ifStatement_return ifStatement92 = default(ES3Parser.ifStatement_return);
		ES3Parser.iterationStatement_return iterationStatement93 = default(ES3Parser.iterationStatement_return);
		ES3Parser.continueStatement_return continueStatement94 = default(ES3Parser.continueStatement_return);
		ES3Parser.breakStatement_return breakStatement95 = default(ES3Parser.breakStatement_return);
		ES3Parser.returnStatement_return returnStatement96 = default(ES3Parser.returnStatement_return);
		ES3Parser.withStatement_return withStatement97 = default(ES3Parser.withStatement_return);
		ES3Parser.labelledStatement_return labelledStatement98 = default(ES3Parser.labelledStatement_return);
		ES3Parser.switchStatement_return switchStatement99 = default(ES3Parser.switchStatement_return);
		ES3Parser.throwStatement_return throwStatement100 = default(ES3Parser.throwStatement_return);
		ES3Parser.tryStatement_return tryStatement101 = default(ES3Parser.tryStatement_return);


		try { DebugEnterRule(GrammarFileName, "statementTail");
		DebugLocation(1416, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1428:2: ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement )
			int alt58=13;
			try { DebugEnterDecision(58, decisionCanBacktrack[58]);
			try
			{
				alt58 = dfa58.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(58); }
			switch (alt58)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1428:4: variableStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1428, 4);
				PushFollow(Follow._variableStatement_in_statementTail5259);
				variableStatement89=variableStatement();
				PopFollow();

				adaptor.AddChild(root_0, variableStatement89.Tree);
				DebugLocation(1428, 22);
				 retval.value = (variableStatement89!=null?variableStatement89.value:default(Statement)); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1429:4: emptyStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1429, 4);
				PushFollow(Follow._emptyStatement_in_statementTail5266);
				emptyStatement90=emptyStatement();
				PopFollow();

				adaptor.AddChild(root_0, emptyStatement90.Tree);
				DebugLocation(1429, 19);
				 retval.value = (emptyStatement90!=null?emptyStatement90.value:default(Statement)); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1430:4: expressionStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1430, 4);
				PushFollow(Follow._expressionStatement_in_statementTail5273);
				expressionStatement91=expressionStatement();
				PopFollow();

				adaptor.AddChild(root_0, expressionStatement91.Tree);
				DebugLocation(1430, 24);
				 retval.value = (expressionStatement91!=null?expressionStatement91.value:default(Statement)); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1431:4: ifStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1431, 4);
				PushFollow(Follow._ifStatement_in_statementTail5280);
				ifStatement92=ifStatement();
				PopFollow();

				adaptor.AddChild(root_0, ifStatement92.Tree);
				DebugLocation(1431, 16);
				 retval.value = (ifStatement92!=null?ifStatement92.value:default(Statement)); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1432:4: iterationStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1432, 4);
				PushFollow(Follow._iterationStatement_in_statementTail5287);
				iterationStatement93=iterationStatement();
				PopFollow();

				adaptor.AddChild(root_0, iterationStatement93.Tree);
				DebugLocation(1432, 23);
				 retval.value = (iterationStatement93!=null?iterationStatement93.value:default(Statement)); 

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1433:4: continueStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1433, 4);
				PushFollow(Follow._continueStatement_in_statementTail5294);
				continueStatement94=continueStatement();
				PopFollow();

				adaptor.AddChild(root_0, continueStatement94.Tree);
				DebugLocation(1433, 22);
				 retval.value = (continueStatement94!=null?continueStatement94.value:default(Statement)); 

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1434:4: breakStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1434, 4);
				PushFollow(Follow._breakStatement_in_statementTail5301);
				breakStatement95=breakStatement();
				PopFollow();

				adaptor.AddChild(root_0, breakStatement95.Tree);
				DebugLocation(1434, 19);
				 retval.value = (breakStatement95!=null?breakStatement95.value:default(Statement)); 

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1435:4: returnStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1435, 4);
				PushFollow(Follow._returnStatement_in_statementTail5308);
				returnStatement96=returnStatement();
				PopFollow();

				adaptor.AddChild(root_0, returnStatement96.Tree);
				DebugLocation(1435, 20);
				 retval.value = (returnStatement96!=null?returnStatement96.value:default(ReturnStatement)); 

				}
				break;
			case 9:
				DebugEnterAlt(9);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1436:4: withStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1436, 4);
				PushFollow(Follow._withStatement_in_statementTail5315);
				withStatement97=withStatement();
				PopFollow();

				adaptor.AddChild(root_0, withStatement97.Tree);
				DebugLocation(1436, 18);
				 retval.value = (withStatement97!=null?withStatement97.value:default(Statement)); 

				}
				break;
			case 10:
				DebugEnterAlt(10);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1437:4: labelledStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1437, 4);
				PushFollow(Follow._labelledStatement_in_statementTail5322);
				labelledStatement98=labelledStatement();
				PopFollow();

				adaptor.AddChild(root_0, labelledStatement98.Tree);
				DebugLocation(1437, 22);
				 retval.value = (labelledStatement98!=null?labelledStatement98.value:default(Statement)); 

				}
				break;
			case 11:
				DebugEnterAlt(11);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1438:4: switchStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1438, 4);
				PushFollow(Follow._switchStatement_in_statementTail5329);
				switchStatement99=switchStatement();
				PopFollow();

				adaptor.AddChild(root_0, switchStatement99.Tree);
				DebugLocation(1438, 20);
				 retval.value = (switchStatement99!=null?switchStatement99.value:default(Statement)); 

				}
				break;
			case 12:
				DebugEnterAlt(12);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1439:4: throwStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1439, 4);
				PushFollow(Follow._throwStatement_in_statementTail5336);
				throwStatement100=throwStatement();
				PopFollow();

				adaptor.AddChild(root_0, throwStatement100.Tree);
				DebugLocation(1439, 19);
				 retval.value = (throwStatement100!=null?throwStatement100.value:default(Statement)); 

				}
				break;
			case 13:
				DebugEnterAlt(13);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1440:4: tryStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1440, 4);
				PushFollow(Follow._tryStatement_in_statementTail5343);
				tryStatement101=tryStatement();
				PopFollow();

				adaptor.AddChild(root_0, tryStatement101.Tree);
				DebugLocation(1440, 17);
				 retval.value = (tryStatement101!=null?tryStatement101.value:default(TryStatement)); 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);


			        if (!(retval.value is ForStatement ||
			            retval.value is BlockStatement ||
			            retval.value is WhileStatement ||
			            retval.value is DoWhileStatement ||
			            retval.value is SwitchStatement ||
			            retval.value is TryStatement ||
			            retval.value is IfStatement)) {
			            retval.value.Source = ExtractSourceCode((CommonToken)retval.Start, (CommonToken)retval.Stop);
			        }

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statementTail", 51);
			LeaveRule("statementTail", 51);
			Leave_statementTail();
		}
		DebugLocation(1441, 1);
		} finally { DebugExitRule(GrammarFileName, "statementTail"); }
		return retval;

	}
	// $ANTLR end "statementTail"

	public class block_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public BlockStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_block();
	partial void Leave_block();

	// $ANTLR start "block"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1445:1: block returns [BlockStatement value] : lb= LBRACE ( statement )* RBRACE ;
	[GrammarRule("block")]
	private ES3Parser.block_return block()
	{
		Enter_block();
		EnterRule("block", 52);
		TraceIn("block", 52);
		ES3Parser.block_return retval = new ES3Parser.block_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken RBRACE103=null;
		ES3Parser.statement_return statement102 = default(ES3Parser.statement_return);

		object lb_tree=null;
		object RBRACE103_tree=null;


			retval.value = new BlockStatement();

		try { DebugEnterRule(GrammarFileName, "block");
		DebugLocation(1445, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1452:2: (lb= LBRACE ( statement )* RBRACE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1452:4: lb= LBRACE ( statement )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1452, 6);
			lb=(IToken)Match(input,LBRACE,Follow._LBRACE_in_block5373); 
			lb_tree = (object)adaptor.Create(lb);
			adaptor.AddChild(root_0, lb_tree);

			DebugLocation(1452, 14);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1452:14: ( statement )*
			try { DebugEnterSubRule(59);
			while (true)
			{
				int alt59=2;
				try { DebugEnterDecision(59, decisionCanBacktrack[59]);
				int LA59_0 = input.LA(1);

				if ((LA59_0==ADD||LA59_0==BREAK||LA59_0==CONTINUE||LA59_0==DEC||LA59_0==DELETE||LA59_0==DO||LA59_0==DecimalLiteral||LA59_0==FALSE||LA59_0==FOR||LA59_0==FUNCTION||(LA59_0>=HexIntegerLiteral && LA59_0<=IF)||LA59_0==INC||LA59_0==INV||LA59_0==Identifier||(LA59_0>=LBRACE && LA59_0<=LBRACK)||LA59_0==LPAREN||(LA59_0>=NEW && LA59_0<=NOT)||LA59_0==NULL||LA59_0==OctalIntegerLiteral||LA59_0==RETURN||LA59_0==RegularExpressionLiteral||LA59_0==SEMIC||LA59_0==SUB||LA59_0==SWITCH||LA59_0==StringLiteral||(LA59_0>=THIS && LA59_0<=THROW)||(LA59_0>=TRUE && LA59_0<=TYPEOF)||(LA59_0>=VAR && LA59_0<=VOID)||(LA59_0>=WHILE && LA59_0<=WITH)))
				{
					alt59=1;
				}


				} finally { DebugExitDecision(59); }
				switch ( alt59 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1452:15: statement
					{
					DebugLocation(1452, 15);
					PushFollow(Follow._statement_in_block5376);
					statement102=statement();
					PopFollow();

					adaptor.AddChild(root_0, statement102.Tree);
					DebugLocation(1452, 25);
					 retval.value.Statements.AddLast((statement102!=null?statement102.value:default(Statement))); 

					}
					break;

				default:
					goto loop59;
				}
			}

			loop59:
				;

			} finally { DebugExitSubRule(59); }

			DebugLocation(1452, 76);
			RBRACE103=(IToken)Match(input,RBRACE,Follow._RBRACE_in_block5382); 
			RBRACE103_tree = (object)adaptor.Create(RBRACE103);
			adaptor.AddChild(root_0, RBRACE103_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);


				retval.value.Source = ExtractSourceCode((CommonToken)retval.Start, (CommonToken)retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("block", 52);
			LeaveRule("block", 52);
			Leave_block();
		}
		DebugLocation(1454, 1);
		} finally { DebugExitRule(GrammarFileName, "block"); }
		return retval;

	}
	// $ANTLR end "block"

	public class variableStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableStatement();
	partial void Leave_variableStatement();

	// $ANTLR start "variableStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1460:1: variableStatement returns [Statement value] : VAR first= variableDeclaration ( COMMA follow= variableDeclaration )* semic ;
	[GrammarRule("variableStatement")]
	private ES3Parser.variableStatement_return variableStatement()
	{
		Enter_variableStatement();
		EnterRule("variableStatement", 53);
		TraceIn("variableStatement", 53);
		ES3Parser.variableStatement_return retval = new ES3Parser.variableStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken VAR104=null;
		IToken COMMA105=null;
		ES3Parser.variableDeclaration_return first = default(ES3Parser.variableDeclaration_return);
		ES3Parser.variableDeclaration_return follow = default(ES3Parser.variableDeclaration_return);
		ES3Parser.semic_return semic106 = default(ES3Parser.semic_return);

		object VAR104_tree=null;
		object COMMA105_tree=null;


			var cs = new CommaOperatorStatement();

		try { DebugEnterRule(GrammarFileName, "variableStatement");
		DebugLocation(1460, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1464:2: ( VAR first= variableDeclaration ( COMMA follow= variableDeclaration )* semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1464:4: VAR first= variableDeclaration ( COMMA follow= variableDeclaration )* semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1464, 4);
			VAR104=(IToken)Match(input,VAR,Follow._VAR_in_variableStatement5408); 
			VAR104_tree = (object)adaptor.Create(VAR104);
			adaptor.AddChild(root_0, VAR104_tree);

			DebugLocation(1464, 13);
			PushFollow(Follow._variableDeclaration_in_variableStatement5412);
			first=variableDeclaration();
			PopFollow();

			adaptor.AddChild(root_0, first.Tree);
			DebugLocation(1464, 34);
			 first.value.Global = false; retval.value = first.value; 
			DebugLocation(1464, 88);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1464:88: ( COMMA follow= variableDeclaration )*
			try { DebugEnterSubRule(60);
			while (true)
			{
				int alt60=2;
				try { DebugEnterDecision(60, decisionCanBacktrack[60]);
				int LA60_0 = input.LA(1);

				if ((LA60_0==COMMA))
				{
					alt60=1;
				}


				} finally { DebugExitDecision(60); }
				switch ( alt60 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1464:90: COMMA follow= variableDeclaration
					{
					DebugLocation(1464, 90);
					COMMA105=(IToken)Match(input,COMMA,Follow._COMMA_in_variableStatement5418); 
					COMMA105_tree = (object)adaptor.Create(COMMA105);
					adaptor.AddChild(root_0, COMMA105_tree);

					DebugLocation(1464, 96);
					 if( cs.Statements.Count == 0) { cs.Statements.Add(retval.value); retval.value = cs; } 
					DebugLocation(1464, 180);
					PushFollow(Follow._variableDeclaration_in_variableStatement5424);
					follow=variableDeclaration();
					PopFollow();

					adaptor.AddChild(root_0, follow.Tree);
					DebugLocation(1464, 202);
					 cs.Statements.Add(follow.value); follow.value.Global = false; 

					}
					break;

				default:
					goto loop60;
				}
			}

			loop60:
				;

			} finally { DebugExitSubRule(60); }

			DebugLocation(1464, 271);
			PushFollow(Follow._semic_in_variableStatement5432);
			semic106=semic();
			PopFollow();

			adaptor.AddChild(root_0, semic106.Tree);

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableStatement", 53);
			LeaveRule("variableStatement", 53);
			Leave_variableStatement();
		}
		DebugLocation(1466, 1);
		} finally { DebugExitRule(GrammarFileName, "variableStatement"); }
		return retval;

	}
	// $ANTLR end "variableStatement"

	public class variableDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public VariableDeclarationStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclaration();
	partial void Leave_variableDeclaration();

	// $ANTLR start "variableDeclaration"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1468:1: variableDeclaration returns [VariableDeclarationStatement value] : id= Identifier ( ASSIGN ass= assignmentExpression )? ;
	[GrammarRule("variableDeclaration")]
	private ES3Parser.variableDeclaration_return variableDeclaration()
	{
		Enter_variableDeclaration();
		EnterRule("variableDeclaration", 54);
		TraceIn("variableDeclaration", 54);
		ES3Parser.variableDeclaration_return retval = new ES3Parser.variableDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken id=null;
		IToken ASSIGN107=null;
		ES3Parser.assignmentExpression_return ass = default(ES3Parser.assignmentExpression_return);

		object id_tree=null;
		object ASSIGN107_tree=null;


			retval.value = new VariableDeclarationStatement();
			retval.value.Global = true;

		try { DebugEnterRule(GrammarFileName, "variableDeclaration");
		DebugLocation(1468, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1473:2: (id= Identifier ( ASSIGN ass= assignmentExpression )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1473:4: id= Identifier ( ASSIGN ass= assignmentExpression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1473, 6);
			id=(IToken)Match(input,Identifier,Follow._Identifier_in_variableDeclaration5456); 
			id_tree = (object)adaptor.Create(id);
			adaptor.AddChild(root_0, id_tree);

			DebugLocation(1473, 18);
			 retval.value.Identifier = id.Text; 
			DebugLocation(1473, 51);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1473:51: ( ASSIGN ass= assignmentExpression )?
			int alt61=2;
			try { DebugEnterSubRule(61);
			try { DebugEnterDecision(61, decisionCanBacktrack[61]);
			int LA61_0 = input.LA(1);

			if ((LA61_0==ASSIGN))
			{
				alt61=1;
			}
			} finally { DebugExitDecision(61); }
			switch (alt61)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1473:53: ASSIGN ass= assignmentExpression
				{
				DebugLocation(1473, 59);
				ASSIGN107=(IToken)Match(input,ASSIGN,Follow._ASSIGN_in_variableDeclaration5462); 
				ASSIGN107_tree = (object)adaptor.Create(ASSIGN107);
				root_0 = (object)adaptor.BecomeRoot(ASSIGN107_tree, root_0);

				DebugLocation(1473, 64);
				PushFollow(Follow._assignmentExpression_in_variableDeclaration5467);
				ass=assignmentExpression();
				PopFollow();

				adaptor.AddChild(root_0, ass.Tree);
				DebugLocation(1473, 86);
				 retval.value.Expression = ass.value; 

				}
				break;

			}
			} finally { DebugExitSubRule(61); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclaration", 54);
			LeaveRule("variableDeclaration", 54);
			Leave_variableDeclaration();
		}
		DebugLocation(1474, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclaration"); }
		return retval;

	}
	// $ANTLR end "variableDeclaration"

	public class variableDeclarationNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public VariableDeclarationStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclarationNoIn();
	partial void Leave_variableDeclarationNoIn();

	// $ANTLR start "variableDeclarationNoIn"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1476:1: variableDeclarationNoIn returns [VariableDeclarationStatement value] : id= Identifier ( ASSIGN ass= assignmentExpressionNoIn )? ;
	[GrammarRule("variableDeclarationNoIn")]
	private ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn()
	{
		Enter_variableDeclarationNoIn();
		EnterRule("variableDeclarationNoIn", 55);
		TraceIn("variableDeclarationNoIn", 55);
		ES3Parser.variableDeclarationNoIn_return retval = new ES3Parser.variableDeclarationNoIn_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken id=null;
		IToken ASSIGN108=null;
		ES3Parser.assignmentExpressionNoIn_return ass = default(ES3Parser.assignmentExpressionNoIn_return);

		object id_tree=null;
		object ASSIGN108_tree=null;


			retval.value = new VariableDeclarationStatement();
			retval.value.Global = true;

		try { DebugEnterRule(GrammarFileName, "variableDeclarationNoIn");
		DebugLocation(1476, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1481:2: (id= Identifier ( ASSIGN ass= assignmentExpressionNoIn )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1481:4: id= Identifier ( ASSIGN ass= assignmentExpressionNoIn )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1481, 6);
			id=(IToken)Match(input,Identifier,Follow._Identifier_in_variableDeclarationNoIn5495); 
			id_tree = (object)adaptor.Create(id);
			adaptor.AddChild(root_0, id_tree);

			DebugLocation(1481, 18);
			 retval.value.Identifier = id.Text; 
			DebugLocation(1481, 51);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1481:51: ( ASSIGN ass= assignmentExpressionNoIn )?
			int alt62=2;
			try { DebugEnterSubRule(62);
			try { DebugEnterDecision(62, decisionCanBacktrack[62]);
			int LA62_0 = input.LA(1);

			if ((LA62_0==ASSIGN))
			{
				alt62=1;
			}
			} finally { DebugExitDecision(62); }
			switch (alt62)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1481:53: ASSIGN ass= assignmentExpressionNoIn
				{
				DebugLocation(1481, 59);
				ASSIGN108=(IToken)Match(input,ASSIGN,Follow._ASSIGN_in_variableDeclarationNoIn5501); 
				ASSIGN108_tree = (object)adaptor.Create(ASSIGN108);
				root_0 = (object)adaptor.BecomeRoot(ASSIGN108_tree, root_0);

				DebugLocation(1481, 64);
				PushFollow(Follow._assignmentExpressionNoIn_in_variableDeclarationNoIn5506);
				ass=assignmentExpressionNoIn();
				PopFollow();

				adaptor.AddChild(root_0, ass.Tree);
				DebugLocation(1481, 90);
				 retval.value.Expression = ass.value; 

				}
				break;

			}
			} finally { DebugExitSubRule(62); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclarationNoIn", 55);
			LeaveRule("variableDeclarationNoIn", 55);
			Leave_variableDeclarationNoIn();
		}
		DebugLocation(1482, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclarationNoIn"); }
		return retval;

	}
	// $ANTLR end "variableDeclarationNoIn"

	public class emptyStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_emptyStatement();
	partial void Leave_emptyStatement();

	// $ANTLR start "emptyStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1488:1: emptyStatement returns [Statement value] : SEMIC ;
	[GrammarRule("emptyStatement")]
	private ES3Parser.emptyStatement_return emptyStatement()
	{
		Enter_emptyStatement();
		EnterRule("emptyStatement", 56);
		TraceIn("emptyStatement", 56);
		ES3Parser.emptyStatement_return retval = new ES3Parser.emptyStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken SEMIC109=null;

		object SEMIC109_tree=null;

		try { DebugEnterRule(GrammarFileName, "emptyStatement");
		DebugLocation(1488, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1489:2: ( SEMIC )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1489:4: SEMIC
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1489, 9);
			SEMIC109=(IToken)Match(input,SEMIC,Follow._SEMIC_in_emptyStatement5531); 
			DebugLocation(1489, 11);
			 retval.value = new EmptyStatement(); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("emptyStatement", 56);
			LeaveRule("emptyStatement", 56);
			Leave_emptyStatement();
		}
		DebugLocation(1490, 1);
		} finally { DebugExitRule(GrammarFileName, "emptyStatement"); }
		return retval;

	}
	// $ANTLR end "emptyStatement"

	public class expressionStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expressionStatement();
	partial void Leave_expressionStatement();

	// $ANTLR start "expressionStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1502:1: expressionStatement returns [Statement value] : expression semic ;
	[GrammarRule("expressionStatement")]
	private ES3Parser.expressionStatement_return expressionStatement()
	{
		Enter_expressionStatement();
		EnterRule("expressionStatement", 57);
		TraceIn("expressionStatement", 57);
		ES3Parser.expressionStatement_return retval = new ES3Parser.expressionStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.expression_return expression110 = default(ES3Parser.expression_return);
		ES3Parser.semic_return semic111 = default(ES3Parser.semic_return);


		try { DebugEnterRule(GrammarFileName, "expressionStatement");
		DebugLocation(1502, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1503:2: ( expression semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1503:4: expression semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1503, 4);
			PushFollow(Follow._expression_in_expressionStatement5556);
			expression110=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression110.Tree);
			DebugLocation(1503, 20);
			PushFollow(Follow._semic_in_expressionStatement5558);
			semic111=semic();
			PopFollow();

			DebugLocation(1503, 22);
			 retval.value = new ExpressionStatement((expression110!=null?expression110.value:default(Expression))); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expressionStatement", 57);
			LeaveRule("expressionStatement", 57);
			Leave_expressionStatement();
		}
		DebugLocation(1504, 1);
		} finally { DebugExitRule(GrammarFileName, "expressionStatement"); }
		return retval;

	}
	// $ANTLR end "expressionStatement"

	public class ifStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_ifStatement();
	partial void Leave_ifStatement();

	// $ANTLR start "ifStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1510:1: ifStatement returns [Statement value] : IF LPAREN expression RPAREN then= statement ({...}? ELSE els= statement )? ;
	[GrammarRule("ifStatement")]
	private ES3Parser.ifStatement_return ifStatement()
	{
		Enter_ifStatement();
		EnterRule("ifStatement", 58);
		TraceIn("ifStatement", 58);
		ES3Parser.ifStatement_return retval = new ES3Parser.ifStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IF112=null;
		IToken LPAREN113=null;
		IToken RPAREN115=null;
		IToken ELSE116=null;
		ES3Parser.statement_return then = default(ES3Parser.statement_return);
		ES3Parser.statement_return els = default(ES3Parser.statement_return);
		ES3Parser.expression_return expression114 = default(ES3Parser.expression_return);

		object IF112_tree=null;
		object LPAREN113_tree=null;
		object RPAREN115_tree=null;
		object ELSE116_tree=null;


		var st = new IfStatement();
		retval.value = st;

		try { DebugEnterRule(GrammarFileName, "ifStatement");
		DebugLocation(1510, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1516:2: ( IF LPAREN expression RPAREN then= statement ({...}? ELSE els= statement )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1516:4: IF LPAREN expression RPAREN then= statement ({...}? ELSE els= statement )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1516, 4);
			IF112=(IToken)Match(input,IF,Follow._IF_in_ifStatement5587); 
			IF112_tree = (object)adaptor.Create(IF112);
			adaptor.AddChild(root_0, IF112_tree);

			DebugLocation(1516, 7);
			LPAREN113=(IToken)Match(input,LPAREN,Follow._LPAREN_in_ifStatement5589); 
			LPAREN113_tree = (object)adaptor.Create(LPAREN113);
			adaptor.AddChild(root_0, LPAREN113_tree);

			DebugLocation(1516, 14);
			PushFollow(Follow._expression_in_ifStatement5591);
			expression114=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression114.Tree);
			DebugLocation(1516, 25);
			 st.Expression = (expression114!=null?expression114.value:default(Expression)); 
			DebugLocation(1516, 64);
			RPAREN115=(IToken)Match(input,RPAREN,Follow._RPAREN_in_ifStatement5595); 
			RPAREN115_tree = (object)adaptor.Create(RPAREN115);
			adaptor.AddChild(root_0, RPAREN115_tree);

			DebugLocation(1516, 75);
			PushFollow(Follow._statement_in_ifStatement5599);
			then=statement();
			PopFollow();

			adaptor.AddChild(root_0, then.Tree);
			DebugLocation(1516, 86);
			 st.Then = (then!=null?then.value:default(Statement)); 
			DebugLocation(1516, 113);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1516:113: ({...}? ELSE els= statement )?
			int alt63=2;
			try { DebugEnterSubRule(63);
			try { DebugEnterDecision(63, decisionCanBacktrack[63]);
			int LA63_0 = input.LA(1);

			if ((LA63_0==ELSE))
			{
				int LA63_1 = input.LA(2);

				if ((( input.LA(1) == ELSE )))
				{
					alt63=1;
				}
			}
			} finally { DebugExitDecision(63); }
			switch (alt63)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1516:115: {...}? ELSE els= statement
				{
				DebugLocation(1516, 115);
				if (!(( input.LA(1) == ELSE )))
				{
					throw new FailedPredicateException(input, "ifStatement", " input.LA(1) == ELSE ");
				}
				DebugLocation(1516, 140);
				ELSE116=(IToken)Match(input,ELSE,Follow._ELSE_in_ifStatement5607); 
				ELSE116_tree = (object)adaptor.Create(ELSE116);
				adaptor.AddChild(root_0, ELSE116_tree);

				DebugLocation(1516, 148);
				PushFollow(Follow._statement_in_ifStatement5611);
				els=statement();
				PopFollow();

				adaptor.AddChild(root_0, els.Tree);
				DebugLocation(1516, 159);
				 st.Else = (els!=null?els.value:default(Statement)); 

				}
				break;

			}
			} finally { DebugExitSubRule(63); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("ifStatement", 58);
			LeaveRule("ifStatement", 58);
			Leave_ifStatement();
		}
		DebugLocation(1519, 1);
		} finally { DebugExitRule(GrammarFileName, "ifStatement"); }
		return retval;

	}
	// $ANTLR end "ifStatement"

	public class iterationStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_iterationStatement();
	partial void Leave_iterationStatement();

	// $ANTLR start "iterationStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1525:1: iterationStatement returns [Statement value] : (dos= doStatement |wh= whileStatement |fo= forStatement );
	[GrammarRule("iterationStatement")]
	private ES3Parser.iterationStatement_return iterationStatement()
	{
		Enter_iterationStatement();
		EnterRule("iterationStatement", 59);
		TraceIn("iterationStatement", 59);
		ES3Parser.iterationStatement_return retval = new ES3Parser.iterationStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.doStatement_return dos = default(ES3Parser.doStatement_return);
		ES3Parser.whileStatement_return wh = default(ES3Parser.whileStatement_return);
		ES3Parser.forStatement_return fo = default(ES3Parser.forStatement_return);


		try { DebugEnterRule(GrammarFileName, "iterationStatement");
		DebugLocation(1525, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1526:2: (dos= doStatement |wh= whileStatement |fo= forStatement )
			int alt64=3;
			try { DebugEnterDecision(64, decisionCanBacktrack[64]);
			switch (input.LA(1))
			{
			case DO:
				{
				alt64=1;
				}
				break;
			case WHILE:
				{
				alt64=2;
				}
				break;
			case FOR:
				{
				alt64=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 64, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(64); }
			switch (alt64)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1526:4: dos= doStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1526, 7);
				PushFollow(Follow._doStatement_in_iterationStatement5641);
				dos=doStatement();
				PopFollow();

				adaptor.AddChild(root_0, dos.Tree);
				DebugLocation(1526, 20);
				 retval.value = dos.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1527:4: wh= whileStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1527, 6);
				PushFollow(Follow._whileStatement_in_iterationStatement5650);
				wh=whileStatement();
				PopFollow();

				adaptor.AddChild(root_0, wh.Tree);
				DebugLocation(1527, 23);
				 retval.value = wh.value; 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1528:4: fo= forStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1528, 6);
				PushFollow(Follow._forStatement_in_iterationStatement5660);
				fo=forStatement();
				PopFollow();

				adaptor.AddChild(root_0, fo.Tree);
				DebugLocation(1528, 21);
				 retval.value = (Statement)fo.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("iterationStatement", 59);
			LeaveRule("iterationStatement", 59);
			Leave_iterationStatement();
		}
		DebugLocation(1529, 1);
		} finally { DebugExitRule(GrammarFileName, "iterationStatement"); }
		return retval;

	}
	// $ANTLR end "iterationStatement"

	public class doStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_doStatement();
	partial void Leave_doStatement();

	// $ANTLR start "doStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1531:1: doStatement returns [Statement value] : DO statement WHILE LPAREN expression RPAREN semic ;
	[GrammarRule("doStatement")]
	private ES3Parser.doStatement_return doStatement()
	{
		Enter_doStatement();
		EnterRule("doStatement", 60);
		TraceIn("doStatement", 60);
		ES3Parser.doStatement_return retval = new ES3Parser.doStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken DO117=null;
		IToken WHILE119=null;
		IToken LPAREN120=null;
		IToken RPAREN122=null;
		ES3Parser.statement_return statement118 = default(ES3Parser.statement_return);
		ES3Parser.expression_return expression121 = default(ES3Parser.expression_return);
		ES3Parser.semic_return semic123 = default(ES3Parser.semic_return);

		object DO117_tree=null;
		object WHILE119_tree=null;
		object LPAREN120_tree=null;
		object RPAREN122_tree=null;

		try { DebugEnterRule(GrammarFileName, "doStatement");
		DebugLocation(1531, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1532:2: ( DO statement WHILE LPAREN expression RPAREN semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1532:4: DO statement WHILE LPAREN expression RPAREN semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1532, 4);
			DO117=(IToken)Match(input,DO,Follow._DO_in_doStatement5679); 
			DO117_tree = (object)adaptor.Create(DO117);
			adaptor.AddChild(root_0, DO117_tree);

			DebugLocation(1532, 7);
			PushFollow(Follow._statement_in_doStatement5681);
			statement118=statement();
			PopFollow();

			adaptor.AddChild(root_0, statement118.Tree);
			DebugLocation(1532, 17);
			WHILE119=(IToken)Match(input,WHILE,Follow._WHILE_in_doStatement5683); 
			WHILE119_tree = (object)adaptor.Create(WHILE119);
			adaptor.AddChild(root_0, WHILE119_tree);

			DebugLocation(1532, 23);
			LPAREN120=(IToken)Match(input,LPAREN,Follow._LPAREN_in_doStatement5685); 
			LPAREN120_tree = (object)adaptor.Create(LPAREN120);
			adaptor.AddChild(root_0, LPAREN120_tree);

			DebugLocation(1532, 30);
			PushFollow(Follow._expression_in_doStatement5687);
			expression121=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression121.Tree);
			DebugLocation(1532, 41);
			RPAREN122=(IToken)Match(input,RPAREN,Follow._RPAREN_in_doStatement5689); 
			RPAREN122_tree = (object)adaptor.Create(RPAREN122);
			adaptor.AddChild(root_0, RPAREN122_tree);

			DebugLocation(1532, 48);
			PushFollow(Follow._semic_in_doStatement5691);
			semic123=semic();
			PopFollow();

			adaptor.AddChild(root_0, semic123.Tree);
			DebugLocation(1532, 54);
			 retval.value = new DoWhileStatement((expression121!=null?expression121.value:default(Expression)), (statement118!=null?statement118.value:default(Statement))); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("doStatement", 60);
			LeaveRule("doStatement", 60);
			Leave_doStatement();
		}
		DebugLocation(1534, 1);
		} finally { DebugExitRule(GrammarFileName, "doStatement"); }
		return retval;

	}
	// $ANTLR end "doStatement"

	public class whileStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_whileStatement();
	partial void Leave_whileStatement();

	// $ANTLR start "whileStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1536:1: whileStatement returns [Statement value] : WHILE LPAREN expression RPAREN statement ;
	[GrammarRule("whileStatement")]
	private ES3Parser.whileStatement_return whileStatement()
	{
		Enter_whileStatement();
		EnterRule("whileStatement", 61);
		TraceIn("whileStatement", 61);
		ES3Parser.whileStatement_return retval = new ES3Parser.whileStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken WHILE124=null;
		IToken LPAREN125=null;
		IToken RPAREN127=null;
		ES3Parser.expression_return expression126 = default(ES3Parser.expression_return);
		ES3Parser.statement_return statement128 = default(ES3Parser.statement_return);

		object WHILE124_tree=null;
		object LPAREN125_tree=null;
		object RPAREN127_tree=null;

		try { DebugEnterRule(GrammarFileName, "whileStatement");
		DebugLocation(1536, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1537:2: ( WHILE LPAREN expression RPAREN statement )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1537:4: WHILE LPAREN expression RPAREN statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1537, 9);
			WHILE124=(IToken)Match(input,WHILE,Follow._WHILE_in_whileStatement5711); 
			WHILE124_tree = (object)adaptor.Create(WHILE124);
			root_0 = (object)adaptor.BecomeRoot(WHILE124_tree, root_0);

			DebugLocation(1537, 17);
			LPAREN125=(IToken)Match(input,LPAREN,Follow._LPAREN_in_whileStatement5714); 
			DebugLocation(1537, 19);
			PushFollow(Follow._expression_in_whileStatement5717);
			expression126=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression126.Tree);
			DebugLocation(1537, 36);
			RPAREN127=(IToken)Match(input,RPAREN,Follow._RPAREN_in_whileStatement5719); 
			DebugLocation(1537, 38);
			PushFollow(Follow._statement_in_whileStatement5722);
			statement128=statement();
			PopFollow();

			adaptor.AddChild(root_0, statement128.Tree);
			DebugLocation(1537, 48);
			 retval.value = new WhileStatement((expression126!=null?expression126.value:default(Expression)), (statement128!=null?statement128.value:default(Statement))); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("whileStatement", 61);
			LeaveRule("whileStatement", 61);
			Leave_whileStatement();
		}
		DebugLocation(1538, 1);
		} finally { DebugExitRule(GrammarFileName, "whileStatement"); }
		return retval;

	}
	// $ANTLR end "whileStatement"

	public class forStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public IForStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forStatement();
	partial void Leave_forStatement();

	// $ANTLR start "forStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1581:1: forStatement returns [IForStatement value] : FOR LPAREN fo= forControl RPAREN st= statement ;
	[GrammarRule("forStatement")]
	private ES3Parser.forStatement_return forStatement()
	{
		Enter_forStatement();
		EnterRule("forStatement", 62);
		TraceIn("forStatement", 62);
		ES3Parser.forStatement_return retval = new ES3Parser.forStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken FOR129=null;
		IToken LPAREN130=null;
		IToken RPAREN131=null;
		ES3Parser.forControl_return fo = default(ES3Parser.forControl_return);
		ES3Parser.statement_return st = default(ES3Parser.statement_return);

		object FOR129_tree=null;
		object LPAREN130_tree=null;
		object RPAREN131_tree=null;

		try { DebugEnterRule(GrammarFileName, "forStatement");
		DebugLocation(1581, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1582:2: ( FOR LPAREN fo= forControl RPAREN st= statement )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1582:4: FOR LPAREN fo= forControl RPAREN st= statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1582, 7);
			FOR129=(IToken)Match(input,FOR,Follow._FOR_in_forStatement5741); 
			FOR129_tree = (object)adaptor.Create(FOR129);
			root_0 = (object)adaptor.BecomeRoot(FOR129_tree, root_0);

			DebugLocation(1582, 15);
			LPAREN130=(IToken)Match(input,LPAREN,Follow._LPAREN_in_forStatement5744); 
			DebugLocation(1582, 19);
			PushFollow(Follow._forControl_in_forStatement5749);
			fo=forControl();
			PopFollow();

			adaptor.AddChild(root_0, fo.Tree);
			DebugLocation(1582, 31);
			 retval.value = fo.value; 
			DebugLocation(1582, 61);
			RPAREN131=(IToken)Match(input,RPAREN,Follow._RPAREN_in_forStatement5754); 
			DebugLocation(1582, 65);
			PushFollow(Follow._statement_in_forStatement5759);
			st=statement();
			PopFollow();

			adaptor.AddChild(root_0, st.Tree);
			DebugLocation(1582, 76);
			  retval.value.Statement = st.value; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forStatement", 62);
			LeaveRule("forStatement", 62);
			Leave_forStatement();
		}
		DebugLocation(1583, 1);
		} finally { DebugExitRule(GrammarFileName, "forStatement"); }
		return retval;

	}
	// $ANTLR end "forStatement"

	public class forControl_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public IForStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forControl();
	partial void Leave_forControl();

	// $ANTLR start "forControl"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1585:1: forControl returns [IForStatement value] : (ex1= forControlVar |ex2= forControlExpression |ex3= forControlSemic );
	[GrammarRule("forControl")]
	private ES3Parser.forControl_return forControl()
	{
		Enter_forControl();
		EnterRule("forControl", 63);
		TraceIn("forControl", 63);
		ES3Parser.forControl_return retval = new ES3Parser.forControl_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.forControlVar_return ex1 = default(ES3Parser.forControlVar_return);
		ES3Parser.forControlExpression_return ex2 = default(ES3Parser.forControlExpression_return);
		ES3Parser.forControlSemic_return ex3 = default(ES3Parser.forControlSemic_return);


		try { DebugEnterRule(GrammarFileName, "forControl");
		DebugLocation(1585, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1586:2: (ex1= forControlVar |ex2= forControlExpression |ex3= forControlSemic )
			int alt65=3;
			try { DebugEnterDecision(65, decisionCanBacktrack[65]);
			switch (input.LA(1))
			{
			case VAR:
				{
				alt65=1;
				}
				break;
			case ADD:
			case DEC:
			case DELETE:
			case DecimalLiteral:
			case FALSE:
			case FUNCTION:
			case HexIntegerLiteral:
			case INC:
			case INV:
			case Identifier:
			case LBRACE:
			case LBRACK:
			case LPAREN:
			case NEW:
			case NOT:
			case NULL:
			case OctalIntegerLiteral:
			case RegularExpressionLiteral:
			case SUB:
			case StringLiteral:
			case THIS:
			case TRUE:
			case TYPEOF:
			case VOID:
				{
				alt65=2;
				}
				break;
			case SEMIC:
				{
				alt65=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 65, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(65); }
			switch (alt65)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1586:4: ex1= forControlVar
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1586, 7);
				PushFollow(Follow._forControlVar_in_forControl5778);
				ex1=forControlVar();
				PopFollow();

				adaptor.AddChild(root_0, ex1.Tree);
				DebugLocation(1586, 22);
				 retval.value = ex1.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1587:4: ex2= forControlExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1587, 7);
				PushFollow(Follow._forControlExpression_in_forControl5787);
				ex2=forControlExpression();
				PopFollow();

				adaptor.AddChild(root_0, ex2.Tree);
				DebugLocation(1587, 29);
				 retval.value = ex2.value; 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1588:4: ex3= forControlSemic
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1588, 7);
				PushFollow(Follow._forControlSemic_in_forControl5796);
				ex3=forControlSemic();
				PopFollow();

				adaptor.AddChild(root_0, ex3.Tree);
				DebugLocation(1588, 24);
				 retval.value = ex3.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forControl", 63);
			LeaveRule("forControl", 63);
			Leave_forControl();
		}
		DebugLocation(1589, 1);
		} finally { DebugExitRule(GrammarFileName, "forControl"); }
		return retval;

	}
	// $ANTLR end "forControl"

	public class forControlVar_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public IForStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forControlVar();
	partial void Leave_forControlVar();

	// $ANTLR start "forControlVar"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1591:1: forControlVar returns [IForStatement value] : VAR first= variableDeclarationNoIn ( ( IN ex= expression ) | ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) ) ;
	[GrammarRule("forControlVar")]
	private ES3Parser.forControlVar_return forControlVar()
	{
		Enter_forControlVar();
		EnterRule("forControlVar", 64);
		TraceIn("forControlVar", 64);
		ES3Parser.forControlVar_return retval = new ES3Parser.forControlVar_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken VAR132=null;
		IToken IN133=null;
		IToken COMMA134=null;
		IToken SEMIC135=null;
		IToken SEMIC136=null;
		ES3Parser.variableDeclarationNoIn_return first = default(ES3Parser.variableDeclarationNoIn_return);
		ES3Parser.expression_return ex = default(ES3Parser.expression_return);
		ES3Parser.variableDeclarationNoIn_return follow = default(ES3Parser.variableDeclarationNoIn_return);
		ES3Parser.expression_return ex1 = default(ES3Parser.expression_return);
		ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);

		object VAR132_tree=null;
		object IN133_tree=null;
		object COMMA134_tree=null;
		object SEMIC135_tree=null;
		object SEMIC136_tree=null;


			var forStatement = new ForStatement();
			var foreachStatement = new ForEachInStatement();
			var cs = new CommaOperatorStatement();

		try { DebugEnterRule(GrammarFileName, "forControlVar");
		DebugLocation(1591, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1598:2: ( VAR first= variableDeclarationNoIn ( ( IN ex= expression ) | ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1598:4: VAR first= variableDeclarationNoIn ( ( IN ex= expression ) | ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1598, 4);
			VAR132=(IToken)Match(input,VAR,Follow._VAR_in_forControlVar5819); 
			VAR132_tree = (object)adaptor.Create(VAR132);
			adaptor.AddChild(root_0, VAR132_tree);

			DebugLocation(1598, 13);
			PushFollow(Follow._variableDeclarationNoIn_in_forControlVar5823);
			first=variableDeclarationNoIn();
			PopFollow();

			adaptor.AddChild(root_0, first.Tree);
			DebugLocation(1598, 38);
			 foreachStatement.InitialisationStatement = forStatement.InitialisationStatement = first.value; first.value.Global = false;  
			DebugLocation(1599, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1599:2: ( ( IN ex= expression ) | ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) )
			int alt69=2;
			try { DebugEnterSubRule(69);
			try { DebugEnterDecision(69, decisionCanBacktrack[69]);
			int LA69_0 = input.LA(1);

			if ((LA69_0==IN))
			{
				alt69=1;
			}
			else if ((LA69_0==COMMA||LA69_0==SEMIC))
			{
				alt69=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 69, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(69); }
			switch (alt69)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1600:3: ( IN ex= expression )
				{
				DebugLocation(1600, 3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1600:3: ( IN ex= expression )
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1601:4: IN ex= expression
				{
				DebugLocation(1601, 4);
				IN133=(IToken)Match(input,IN,Follow._IN_in_forControlVar5837); 
				IN133_tree = (object)adaptor.Create(IN133);
				adaptor.AddChild(root_0, IN133_tree);

				DebugLocation(1601, 9);
				PushFollow(Follow._expression_in_forControlVar5841);
				ex=expression();
				PopFollow();

				adaptor.AddChild(root_0, ex.Tree);
				DebugLocation(1601, 21);
				 retval.value = foreachStatement; foreachStatement.Expression = (ex!=null?ex.value:default(Expression)); 

				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1605:3: ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
				{
				DebugLocation(1605, 3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1605:3: ( ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1606:4: ( COMMA follow= variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )?
				{
				DebugLocation(1606, 4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1606:4: ( COMMA follow= variableDeclarationNoIn )*
				try { DebugEnterSubRule(66);
				while (true)
				{
					int alt66=2;
					try { DebugEnterDecision(66, decisionCanBacktrack[66]);
					int LA66_0 = input.LA(1);

					if ((LA66_0==COMMA))
					{
						alt66=1;
					}


					} finally { DebugExitDecision(66); }
					switch ( alt66 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1606:6: COMMA follow= variableDeclarationNoIn
						{
						DebugLocation(1606, 6);
						COMMA134=(IToken)Match(input,COMMA,Follow._COMMA_in_forControlVar5866); 
						COMMA134_tree = (object)adaptor.Create(COMMA134);
						adaptor.AddChild(root_0, COMMA134_tree);

						DebugLocation(1606, 12);
						 if( cs.Statements.Count == 0) { foreachStatement.InitialisationStatement = forStatement.InitialisationStatement = cs; cs.Statements.Add(first.value); } 
						DebugLocation(1606, 174);
						PushFollow(Follow._variableDeclarationNoIn_in_forControlVar5872);
						follow=variableDeclarationNoIn();
						PopFollow();

						adaptor.AddChild(root_0, follow.Tree);
						DebugLocation(1606, 199);
						  follow.value.Global = false; cs.Statements.Add(follow.value); 

						}
						break;

					default:
						goto loop66;
					}
				}

				loop66:
					;

				} finally { DebugExitSubRule(66); }

				DebugLocation(1607, 4);
				SEMIC135=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlVar5883); 
				SEMIC135_tree = (object)adaptor.Create(SEMIC135);
				adaptor.AddChild(root_0, SEMIC135_tree);

				DebugLocation(1607, 10);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1607:10: (ex1= expression )?
				int alt67=2;
				try { DebugEnterSubRule(67);
				try { DebugEnterDecision(67, decisionCanBacktrack[67]);
				int LA67_0 = input.LA(1);

				if ((LA67_0==ADD||LA67_0==DEC||LA67_0==DELETE||LA67_0==DecimalLiteral||LA67_0==FALSE||LA67_0==FUNCTION||LA67_0==HexIntegerLiteral||LA67_0==INC||LA67_0==INV||LA67_0==Identifier||(LA67_0>=LBRACE && LA67_0<=LBRACK)||LA67_0==LPAREN||(LA67_0>=NEW && LA67_0<=NOT)||LA67_0==NULL||LA67_0==OctalIntegerLiteral||LA67_0==RegularExpressionLiteral||LA67_0==SUB||LA67_0==StringLiteral||LA67_0==THIS||LA67_0==TRUE||LA67_0==TYPEOF||LA67_0==VOID))
				{
					alt67=1;
				}
				} finally { DebugExitDecision(67); }
				switch (alt67)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1607:12: ex1= expression
					{
					DebugLocation(1607, 15);
					PushFollow(Follow._expression_in_forControlVar5889);
					ex1=expression();
					PopFollow();

					adaptor.AddChild(root_0, ex1.Tree);
					DebugLocation(1607, 27);
					 forStatement.ConditionExpression = (ex1!=null?ex1.value:default(Expression));

					}
					break;

				}
				} finally { DebugExitSubRule(67); }

				DebugLocation(1607, 81);
				SEMIC136=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlVar5897); 
				SEMIC136_tree = (object)adaptor.Create(SEMIC136);
				adaptor.AddChild(root_0, SEMIC136_tree);

				DebugLocation(1607, 87);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1607:87: (ex2= expression )?
				int alt68=2;
				try { DebugEnterSubRule(68);
				try { DebugEnterDecision(68, decisionCanBacktrack[68]);
				int LA68_0 = input.LA(1);

				if ((LA68_0==ADD||LA68_0==DEC||LA68_0==DELETE||LA68_0==DecimalLiteral||LA68_0==FALSE||LA68_0==FUNCTION||LA68_0==HexIntegerLiteral||LA68_0==INC||LA68_0==INV||LA68_0==Identifier||(LA68_0>=LBRACE && LA68_0<=LBRACK)||LA68_0==LPAREN||(LA68_0>=NEW && LA68_0<=NOT)||LA68_0==NULL||LA68_0==OctalIntegerLiteral||LA68_0==RegularExpressionLiteral||LA68_0==SUB||LA68_0==StringLiteral||LA68_0==THIS||LA68_0==TRUE||LA68_0==TYPEOF||LA68_0==VOID))
				{
					alt68=1;
				}
				} finally { DebugExitDecision(68); }
				switch (alt68)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1607:88: ex2= expression
					{
					DebugLocation(1607, 91);
					PushFollow(Follow._expression_in_forControlVar5902);
					ex2=expression();
					PopFollow();

					adaptor.AddChild(root_0, ex2.Tree);
					DebugLocation(1607, 103);
					  forStatement.IncrementExpression = (ex2!=null?ex2.value:default(Expression)); 

					}
					break;

				}
				} finally { DebugExitSubRule(68); }

				DebugLocation(1607, 157);
				 retval.value = forStatement; 

				}


				}
				break;

			}
			} finally { DebugExitSubRule(69); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forControlVar", 64);
			LeaveRule("forControlVar", 64);
			Leave_forControlVar();
		}
		DebugLocation(1611, 1);
		} finally { DebugExitRule(GrammarFileName, "forControlVar"); }
		return retval;

	}
	// $ANTLR end "forControlVar"

	public class forControlExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public IForStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forControlExpression();
	partial void Leave_forControlExpression();

	// $ANTLR start "forControlExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1613:1: forControlExpression returns [IForStatement value] : ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) ) ;
	[GrammarRule("forControlExpression")]
	private ES3Parser.forControlExpression_return forControlExpression()
	{
		Enter_forControlExpression();
		EnterRule("forControlExpression", 65);
		TraceIn("forControlExpression", 65);
		ES3Parser.forControlExpression_return retval = new ES3Parser.forControlExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IN137=null;
		IToken SEMIC138=null;
		IToken SEMIC139=null;
		ES3Parser.expressionNoIn_return ex1 = default(ES3Parser.expressionNoIn_return);
		ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);
		ES3Parser.expression_return ex3 = default(ES3Parser.expression_return);

		object IN137_tree=null;
		object SEMIC138_tree=null;
		object SEMIC139_tree=null;


			var forStatement = new ForStatement();
			var foreachStatement = new ForEachInStatement();

			object[] isLhs = new object[1];

		try { DebugEnterRule(GrammarFileName, "forControlExpression");
		DebugLocation(1613, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1621:2: (ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1621:4: ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1621, 7);
			PushFollow(Follow._expressionNoIn_in_forControlExpression5941);
			ex1=expressionNoIn();
			PopFollow();

			adaptor.AddChild(root_0, ex1.Tree);
			DebugLocation(1621, 23);
			 foreachStatement.InitialisationStatement = forStatement.InitialisationStatement = ex1.value; 
			DebugLocation(1622, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1622:2: ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) )
			int alt72=2;
			try { DebugEnterSubRule(72);
			try { DebugEnterDecision(72, decisionCanBacktrack[72]);
			int LA72_0 = input.LA(1);

			if ((LA72_0==IN))
			{
				alt72=1;
			}
			else if ((LA72_0==SEMIC))
			{
				alt72=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 72, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(72); }
			switch (alt72)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1623:3: {...}? ( IN ex2= expression )
				{
				DebugLocation(1623, 3);
				if (!(( IsLeftHandSideIn(ex1.value, isLhs) )))
				{
					throw new FailedPredicateException(input, "forControlExpression", " IsLeftHandSideIn(ex1.value, isLhs) ");
				}
				DebugLocation(1623, 43);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1623:43: ( IN ex2= expression )
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1624:4: IN ex2= expression
				{
				DebugLocation(1624, 4);
				IN137=(IToken)Match(input,IN,Follow._IN_in_forControlExpression5958); 
				IN137_tree = (object)adaptor.Create(IN137);
				adaptor.AddChild(root_0, IN137_tree);

				DebugLocation(1624, 10);
				PushFollow(Follow._expression_in_forControlExpression5962);
				ex2=expression();
				PopFollow();

				adaptor.AddChild(root_0, ex2.Tree);
				DebugLocation(1624, 22);
				 retval.value = foreachStatement; foreachStatement.Expression = ex2.value; 

				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1628:3: ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? )
				{
				DebugLocation(1628, 3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1628:3: ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? )
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1629:4: SEMIC (ex2= expression )? SEMIC (ex3= expression )?
				{
				DebugLocation(1629, 4);
				SEMIC138=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlExpression5985); 
				SEMIC138_tree = (object)adaptor.Create(SEMIC138);
				adaptor.AddChild(root_0, SEMIC138_tree);

				DebugLocation(1629, 10);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1629:10: (ex2= expression )?
				int alt70=2;
				try { DebugEnterSubRule(70);
				try { DebugEnterDecision(70, decisionCanBacktrack[70]);
				int LA70_0 = input.LA(1);

				if ((LA70_0==ADD||LA70_0==DEC||LA70_0==DELETE||LA70_0==DecimalLiteral||LA70_0==FALSE||LA70_0==FUNCTION||LA70_0==HexIntegerLiteral||LA70_0==INC||LA70_0==INV||LA70_0==Identifier||(LA70_0>=LBRACE && LA70_0<=LBRACK)||LA70_0==LPAREN||(LA70_0>=NEW && LA70_0<=NOT)||LA70_0==NULL||LA70_0==OctalIntegerLiteral||LA70_0==RegularExpressionLiteral||LA70_0==SUB||LA70_0==StringLiteral||LA70_0==THIS||LA70_0==TRUE||LA70_0==TYPEOF||LA70_0==VOID))
				{
					alt70=1;
				}
				} finally { DebugExitDecision(70); }
				switch (alt70)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1629:12: ex2= expression
					{
					DebugLocation(1629, 15);
					PushFollow(Follow._expression_in_forControlExpression5991);
					ex2=expression();
					PopFollow();

					adaptor.AddChild(root_0, ex2.Tree);
					DebugLocation(1629, 27);
					 forStatement.ConditionExpression = ex2.value;

					}
					break;

				}
				} finally { DebugExitSubRule(70); }

				DebugLocation(1629, 80);
				SEMIC139=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlExpression5999); 
				SEMIC139_tree = (object)adaptor.Create(SEMIC139);
				adaptor.AddChild(root_0, SEMIC139_tree);

				DebugLocation(1629, 86);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1629:86: (ex3= expression )?
				int alt71=2;
				try { DebugEnterSubRule(71);
				try { DebugEnterDecision(71, decisionCanBacktrack[71]);
				int LA71_0 = input.LA(1);

				if ((LA71_0==ADD||LA71_0==DEC||LA71_0==DELETE||LA71_0==DecimalLiteral||LA71_0==FALSE||LA71_0==FUNCTION||LA71_0==HexIntegerLiteral||LA71_0==INC||LA71_0==INV||LA71_0==Identifier||(LA71_0>=LBRACE && LA71_0<=LBRACK)||LA71_0==LPAREN||(LA71_0>=NEW && LA71_0<=NOT)||LA71_0==NULL||LA71_0==OctalIntegerLiteral||LA71_0==RegularExpressionLiteral||LA71_0==SUB||LA71_0==StringLiteral||LA71_0==THIS||LA71_0==TRUE||LA71_0==TYPEOF||LA71_0==VOID))
				{
					alt71=1;
				}
				} finally { DebugExitDecision(71); }
				switch (alt71)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1629:87: ex3= expression
					{
					DebugLocation(1629, 90);
					PushFollow(Follow._expression_in_forControlExpression6004);
					ex3=expression();
					PopFollow();

					adaptor.AddChild(root_0, ex3.Tree);
					DebugLocation(1629, 102);
					  forStatement.IncrementExpression = ex3.value; 

					}
					break;

				}
				} finally { DebugExitSubRule(71); }

				DebugLocation(1629, 155);
				 retval.value = forStatement; 

				}


				}
				break;

			}
			} finally { DebugExitSubRule(72); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forControlExpression", 65);
			LeaveRule("forControlExpression", 65);
			Leave_forControlExpression();
		}
		DebugLocation(1633, 1);
		} finally { DebugExitRule(GrammarFileName, "forControlExpression"); }
		return retval;

	}
	// $ANTLR end "forControlExpression"

	public class forControlSemic_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public ForStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forControlSemic();
	partial void Leave_forControlSemic();

	// $ANTLR start "forControlSemic"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1635:1: forControlSemic returns [ForStatement value] : SEMIC (ex1= expression )? SEMIC (ex2= expression )? ;
	[GrammarRule("forControlSemic")]
	private ES3Parser.forControlSemic_return forControlSemic()
	{
		Enter_forControlSemic();
		EnterRule("forControlSemic", 66);
		TraceIn("forControlSemic", 66);
		ES3Parser.forControlSemic_return retval = new ES3Parser.forControlSemic_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken SEMIC140=null;
		IToken SEMIC141=null;
		ES3Parser.expression_return ex1 = default(ES3Parser.expression_return);
		ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);

		object SEMIC140_tree=null;
		object SEMIC141_tree=null;


			retval.value = new ForStatement();

		try { DebugEnterRule(GrammarFileName, "forControlSemic");
		DebugLocation(1635, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:2: ( SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:4: SEMIC (ex1= expression )? SEMIC (ex2= expression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1639, 4);
			SEMIC140=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlSemic6040); 
			SEMIC140_tree = (object)adaptor.Create(SEMIC140);
			adaptor.AddChild(root_0, SEMIC140_tree);

			DebugLocation(1639, 10);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:10: (ex1= expression )?
			int alt73=2;
			try { DebugEnterSubRule(73);
			try { DebugEnterDecision(73, decisionCanBacktrack[73]);
			int LA73_0 = input.LA(1);

			if ((LA73_0==ADD||LA73_0==DEC||LA73_0==DELETE||LA73_0==DecimalLiteral||LA73_0==FALSE||LA73_0==FUNCTION||LA73_0==HexIntegerLiteral||LA73_0==INC||LA73_0==INV||LA73_0==Identifier||(LA73_0>=LBRACE && LA73_0<=LBRACK)||LA73_0==LPAREN||(LA73_0>=NEW && LA73_0<=NOT)||LA73_0==NULL||LA73_0==OctalIntegerLiteral||LA73_0==RegularExpressionLiteral||LA73_0==SUB||LA73_0==StringLiteral||LA73_0==THIS||LA73_0==TRUE||LA73_0==TYPEOF||LA73_0==VOID))
			{
				alt73=1;
			}
			} finally { DebugExitDecision(73); }
			switch (alt73)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:12: ex1= expression
				{
				DebugLocation(1639, 15);
				PushFollow(Follow._expression_in_forControlSemic6046);
				ex1=expression();
				PopFollow();

				adaptor.AddChild(root_0, ex1.Tree);
				DebugLocation(1639, 27);
				 retval.value.ConditionExpression = ex1.value;

				}
				break;

			}
			} finally { DebugExitSubRule(73); }

			DebugLocation(1639, 74);
			SEMIC141=(IToken)Match(input,SEMIC,Follow._SEMIC_in_forControlSemic6054); 
			SEMIC141_tree = (object)adaptor.Create(SEMIC141);
			adaptor.AddChild(root_0, SEMIC141_tree);

			DebugLocation(1639, 80);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:80: (ex2= expression )?
			int alt74=2;
			try { DebugEnterSubRule(74);
			try { DebugEnterDecision(74, decisionCanBacktrack[74]);
			int LA74_0 = input.LA(1);

			if ((LA74_0==ADD||LA74_0==DEC||LA74_0==DELETE||LA74_0==DecimalLiteral||LA74_0==FALSE||LA74_0==FUNCTION||LA74_0==HexIntegerLiteral||LA74_0==INC||LA74_0==INV||LA74_0==Identifier||(LA74_0>=LBRACE && LA74_0<=LBRACK)||LA74_0==LPAREN||(LA74_0>=NEW && LA74_0<=NOT)||LA74_0==NULL||LA74_0==OctalIntegerLiteral||LA74_0==RegularExpressionLiteral||LA74_0==SUB||LA74_0==StringLiteral||LA74_0==THIS||LA74_0==TRUE||LA74_0==TYPEOF||LA74_0==VOID))
			{
				alt74=1;
			}
			} finally { DebugExitDecision(74); }
			switch (alt74)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1639:81: ex2= expression
				{
				DebugLocation(1639, 84);
				PushFollow(Follow._expression_in_forControlSemic6059);
				ex2=expression();
				PopFollow();

				adaptor.AddChild(root_0, ex2.Tree);
				DebugLocation(1639, 96);
				  retval.value.IncrementExpression = ex2.value; 

				}
				break;

			}
			} finally { DebugExitSubRule(74); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forControlSemic", 66);
			LeaveRule("forControlSemic", 66);
			Leave_forControlSemic();
		}
		DebugLocation(1641, 1);
		} finally { DebugExitRule(GrammarFileName, "forControlSemic"); }
		return retval;

	}
	// $ANTLR end "forControlSemic"

	public class continueStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_continueStatement();
	partial void Leave_continueStatement();

	// $ANTLR start "continueStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1652:1: continueStatement returns [Statement value] : CONTINUE (lb= Identifier )? semic ;
	[GrammarRule("continueStatement")]
	private ES3Parser.continueStatement_return continueStatement()
	{
		Enter_continueStatement();
		EnterRule("continueStatement", 67);
		TraceIn("continueStatement", 67);
		ES3Parser.continueStatement_return retval = new ES3Parser.continueStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken CONTINUE142=null;
		ES3Parser.semic_return semic143 = default(ES3Parser.semic_return);

		object lb_tree=null;
		object CONTINUE142_tree=null;

		 
			string label = String.Empty; 

		try { DebugEnterRule(GrammarFileName, "continueStatement");
		DebugLocation(1652, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1656:2: ( CONTINUE (lb= Identifier )? semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1656:4: CONTINUE (lb= Identifier )? semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1656, 12);
			CONTINUE142=(IToken)Match(input,CONTINUE,Follow._CONTINUE_in_continueStatement6093); 
			CONTINUE142_tree = (object)adaptor.Create(CONTINUE142);
			root_0 = (object)adaptor.BecomeRoot(CONTINUE142_tree, root_0);

			DebugLocation(1656, 14);
			 if (input.LA(1) == Identifier) PromoteEOL(null); 
			DebugLocation(1656, 67);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1656:67: (lb= Identifier )?
			int alt75=2;
			try { DebugEnterSubRule(75);
			try { DebugEnterDecision(75, decisionCanBacktrack[75]);
			int LA75_0 = input.LA(1);

			if ((LA75_0==Identifier))
			{
				alt75=1;
			}
			} finally { DebugExitDecision(75); }
			switch (alt75)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1656:68: lb= Identifier
				{
				DebugLocation(1656, 70);
				lb=(IToken)Match(input,Identifier,Follow._Identifier_in_continueStatement6101); 
				lb_tree = (object)adaptor.Create(lb);
				adaptor.AddChild(root_0, lb_tree);

				DebugLocation(1656, 82);
				 label = lb.Text; 

				}
				break;

			}
			} finally { DebugExitSubRule(75); }

			DebugLocation(1656, 111);
			PushFollow(Follow._semic_in_continueStatement6108);
			semic143=semic();
			PopFollow();

			DebugLocation(1656, 113);
			 retval.value = new ContinueStatement() { Label = label }; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("continueStatement", 67);
			LeaveRule("continueStatement", 67);
			Leave_continueStatement();
		}
		DebugLocation(1657, 1);
		} finally { DebugExitRule(GrammarFileName, "continueStatement"); }
		return retval;

	}
	// $ANTLR end "continueStatement"

	public class breakStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_breakStatement();
	partial void Leave_breakStatement();

	// $ANTLR start "breakStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1668:1: breakStatement returns [Statement value] : BREAK (lb= Identifier )? semic ;
	[GrammarRule("breakStatement")]
	private ES3Parser.breakStatement_return breakStatement()
	{
		Enter_breakStatement();
		EnterRule("breakStatement", 68);
		TraceIn("breakStatement", 68);
		ES3Parser.breakStatement_return retval = new ES3Parser.breakStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken BREAK144=null;
		ES3Parser.semic_return semic145 = default(ES3Parser.semic_return);

		object lb_tree=null;
		object BREAK144_tree=null;

		 
			string label = String.Empty; 

		try { DebugEnterRule(GrammarFileName, "breakStatement");
		DebugLocation(1668, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1672:2: ( BREAK (lb= Identifier )? semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1672:4: BREAK (lb= Identifier )? semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1672, 9);
			BREAK144=(IToken)Match(input,BREAK,Follow._BREAK_in_breakStatement6138); 
			BREAK144_tree = (object)adaptor.Create(BREAK144);
			root_0 = (object)adaptor.BecomeRoot(BREAK144_tree, root_0);

			DebugLocation(1672, 11);
			 if (input.LA(1) == Identifier) PromoteEOL(null); 
			DebugLocation(1672, 64);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1672:64: (lb= Identifier )?
			int alt76=2;
			try { DebugEnterSubRule(76);
			try { DebugEnterDecision(76, decisionCanBacktrack[76]);
			int LA76_0 = input.LA(1);

			if ((LA76_0==Identifier))
			{
				alt76=1;
			}
			} finally { DebugExitDecision(76); }
			switch (alt76)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1672:65: lb= Identifier
				{
				DebugLocation(1672, 67);
				lb=(IToken)Match(input,Identifier,Follow._Identifier_in_breakStatement6146); 
				lb_tree = (object)adaptor.Create(lb);
				adaptor.AddChild(root_0, lb_tree);

				DebugLocation(1672, 79);
				 label = lb.Text; 

				}
				break;

			}
			} finally { DebugExitSubRule(76); }

			DebugLocation(1672, 108);
			PushFollow(Follow._semic_in_breakStatement6153);
			semic145=semic();
			PopFollow();

			DebugLocation(1672, 110);
			 retval.value = new BreakStatement() { Label = label }; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("breakStatement", 68);
			LeaveRule("breakStatement", 68);
			Leave_breakStatement();
		}
		DebugLocation(1673, 1);
		} finally { DebugExitRule(GrammarFileName, "breakStatement"); }
		return retval;

	}
	// $ANTLR end "breakStatement"

	public class returnStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public ReturnStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_returnStatement();
	partial void Leave_returnStatement();

	// $ANTLR start "returnStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1692:1: returnStatement returns [ReturnStatement value] : RETURN (expr= expression )? semic ;
	[GrammarRule("returnStatement")]
	private ES3Parser.returnStatement_return returnStatement()
	{
		Enter_returnStatement();
		EnterRule("returnStatement", 69);
		TraceIn("returnStatement", 69);
		ES3Parser.returnStatement_return retval = new ES3Parser.returnStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken RETURN146=null;
		ES3Parser.expression_return expr = default(ES3Parser.expression_return);
		ES3Parser.semic_return semic147 = default(ES3Parser.semic_return);

		object RETURN146_tree=null;


			retval.value = new ReturnStatement();

		try { DebugEnterRule(GrammarFileName, "returnStatement");
		DebugLocation(1692, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1696:2: ( RETURN (expr= expression )? semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1696:4: RETURN (expr= expression )? semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1696, 10);
			RETURN146=(IToken)Match(input,RETURN,Follow._RETURN_in_returnStatement6183); 
			RETURN146_tree = (object)adaptor.Create(RETURN146);
			root_0 = (object)adaptor.BecomeRoot(RETURN146_tree, root_0);

			DebugLocation(1696, 12);
			 PromoteEOL(null); 
			DebugLocation(1696, 34);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1696:34: (expr= expression )?
			int alt77=2;
			try { DebugEnterSubRule(77);
			try { DebugEnterDecision(77, decisionCanBacktrack[77]);
			int LA77_0 = input.LA(1);

			if ((LA77_0==ADD||LA77_0==DEC||LA77_0==DELETE||LA77_0==DecimalLiteral||LA77_0==FALSE||LA77_0==FUNCTION||LA77_0==HexIntegerLiteral||LA77_0==INC||LA77_0==INV||LA77_0==Identifier||(LA77_0>=LBRACE && LA77_0<=LBRACK)||LA77_0==LPAREN||(LA77_0>=NEW && LA77_0<=NOT)||LA77_0==NULL||LA77_0==OctalIntegerLiteral||LA77_0==RegularExpressionLiteral||LA77_0==SUB||LA77_0==StringLiteral||LA77_0==THIS||LA77_0==TRUE||LA77_0==TYPEOF||LA77_0==VOID))
			{
				alt77=1;
			}
			} finally { DebugExitDecision(77); }
			switch (alt77)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1696:35: expr= expression
				{
				DebugLocation(1696, 39);
				PushFollow(Follow._expression_in_returnStatement6191);
				expr=expression();
				PopFollow();

				adaptor.AddChild(root_0, expr.Tree);
				DebugLocation(1696, 51);
				 retval.value.Expression = expr.value; 

				}
				break;

			}
			} finally { DebugExitSubRule(77); }

			DebugLocation(1696, 94);
			PushFollow(Follow._semic_in_returnStatement6197);
			semic147=semic();
			PopFollow();


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("returnStatement", 69);
			LeaveRule("returnStatement", 69);
			Leave_returnStatement();
		}
		DebugLocation(1697, 1);
		} finally { DebugExitRule(GrammarFileName, "returnStatement"); }
		return retval;

	}
	// $ANTLR end "returnStatement"

	public class withStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_withStatement();
	partial void Leave_withStatement();

	// $ANTLR start "withStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1703:1: withStatement returns [Statement value] : WITH LPAREN exp= expression RPAREN smt= statement ;
	[GrammarRule("withStatement")]
	private ES3Parser.withStatement_return withStatement()
	{
		Enter_withStatement();
		EnterRule("withStatement", 70);
		TraceIn("withStatement", 70);
		ES3Parser.withStatement_return retval = new ES3Parser.withStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken WITH148=null;
		IToken LPAREN149=null;
		IToken RPAREN150=null;
		ES3Parser.expression_return exp = default(ES3Parser.expression_return);
		ES3Parser.statement_return smt = default(ES3Parser.statement_return);

		object WITH148_tree=null;
		object LPAREN149_tree=null;
		object RPAREN150_tree=null;

		try { DebugEnterRule(GrammarFileName, "withStatement");
		DebugLocation(1703, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1704:2: ( WITH LPAREN exp= expression RPAREN smt= statement )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1704:4: WITH LPAREN exp= expression RPAREN smt= statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1704, 8);
			WITH148=(IToken)Match(input,WITH,Follow._WITH_in_withStatement6218); 
			WITH148_tree = (object)adaptor.Create(WITH148);
			root_0 = (object)adaptor.BecomeRoot(WITH148_tree, root_0);

			DebugLocation(1704, 16);
			LPAREN149=(IToken)Match(input,LPAREN,Follow._LPAREN_in_withStatement6221); 
			DebugLocation(1704, 21);
			PushFollow(Follow._expression_in_withStatement6226);
			exp=expression();
			PopFollow();

			adaptor.AddChild(root_0, exp.Tree);
			DebugLocation(1704, 39);
			RPAREN150=(IToken)Match(input,RPAREN,Follow._RPAREN_in_withStatement6228); 
			DebugLocation(1704, 44);
			PushFollow(Follow._statement_in_withStatement6233);
			smt=statement();
			PopFollow();

			adaptor.AddChild(root_0, smt.Tree);
			DebugLocation(1704, 55);
			 retval.value = new WithStatement(exp.value, smt.value); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("withStatement", 70);
			LeaveRule("withStatement", 70);
			Leave_withStatement();
		}
		DebugLocation(1705, 1);
		} finally { DebugExitRule(GrammarFileName, "withStatement"); }
		return retval;

	}
	// $ANTLR end "withStatement"

	public class switchStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_switchStatement();
	partial void Leave_switchStatement();

	// $ANTLR start "switchStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1711:1: switchStatement returns [Statement value] : SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE ;
	[GrammarRule("switchStatement")]
	private ES3Parser.switchStatement_return switchStatement()
	{
		Enter_switchStatement();
		EnterRule("switchStatement", 71);
		TraceIn("switchStatement", 71);
		ES3Parser.switchStatement_return retval = new ES3Parser.switchStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken SWITCH151=null;
		IToken LPAREN152=null;
		IToken RPAREN154=null;
		IToken LBRACE155=null;
		IToken RBRACE158=null;
		ES3Parser.expression_return expression153 = default(ES3Parser.expression_return);
		ES3Parser.defaultClause_return defaultClause156 = default(ES3Parser.defaultClause_return);
		ES3Parser.caseClause_return caseClause157 = default(ES3Parser.caseClause_return);

		object SWITCH151_tree=null;
		object LPAREN152_tree=null;
		object RPAREN154_tree=null;
		object LBRACE155_tree=null;
		object RBRACE158_tree=null;


			SwitchStatement switchStatement = new SwitchStatement();
			retval.value = switchStatement;
			int defaultClauseCount = 0;

		try { DebugEnterRule(GrammarFileName, "switchStatement");
		DebugLocation(1711, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1717:2: ( SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1717:4: SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1717, 4);
			SWITCH151=(IToken)Match(input,SWITCH,Follow._SWITCH_in_switchStatement6260); 
			SWITCH151_tree = (object)adaptor.Create(SWITCH151);
			adaptor.AddChild(root_0, SWITCH151_tree);

			DebugLocation(1717, 11);
			LPAREN152=(IToken)Match(input,LPAREN,Follow._LPAREN_in_switchStatement6262); 
			LPAREN152_tree = (object)adaptor.Create(LPAREN152);
			adaptor.AddChild(root_0, LPAREN152_tree);

			DebugLocation(1717, 18);
			PushFollow(Follow._expression_in_switchStatement6264);
			expression153=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression153.Tree);
			DebugLocation(1717, 29);
			 switchStatement.Expression = (expression153!=null?expression153.value:default(Expression)); 
			DebugLocation(1717, 81);
			RPAREN154=(IToken)Match(input,RPAREN,Follow._RPAREN_in_switchStatement6268); 
			RPAREN154_tree = (object)adaptor.Create(RPAREN154);
			adaptor.AddChild(root_0, RPAREN154_tree);

			DebugLocation(1718, 3);
			LBRACE155=(IToken)Match(input,LBRACE,Follow._LBRACE_in_switchStatement6273); 
			LBRACE155_tree = (object)adaptor.Create(LBRACE155);
			adaptor.AddChild(root_0, LBRACE155_tree);

			DebugLocation(1718, 10);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1718:10: ({...}? => defaultClause | caseClause )*
			try { DebugEnterSubRule(78);
			while (true)
			{
				int alt78=3;
				try { DebugEnterDecision(78, decisionCanBacktrack[78]);
				int LA78_0 = input.LA(1);

				if ((LA78_0==DEFAULT) && (( defaultClauseCount == 0 )))
				{
					alt78=1;
				}
				else if ((LA78_0==CASE))
				{
					alt78=2;
				}


				} finally { DebugExitDecision(78); }
				switch ( alt78 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1718:12: {...}? => defaultClause
					{
					DebugLocation(1718, 12);
					if (!(( defaultClauseCount == 0 )))
					{
						throw new FailedPredicateException(input, "switchStatement", " defaultClauseCount == 0 ");
					}
					DebugLocation(1718, 43);
					PushFollow(Follow._defaultClause_in_switchStatement6280);
					defaultClause156=defaultClause();
					PopFollow();

					adaptor.AddChild(root_0, defaultClause156.Tree);
					DebugLocation(1718, 57);
					 defaultClauseCount++; switchStatement.DefaultStatements=(defaultClause156!=null?defaultClause156.value:default(BlockStatement)); 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1718:141: caseClause
					{
					DebugLocation(1718, 141);
					PushFollow(Follow._caseClause_in_switchStatement6286);
					caseClause157=caseClause();
					PopFollow();

					adaptor.AddChild(root_0, caseClause157.Tree);
					DebugLocation(1718, 152);
					 switchStatement.CaseClauses.Add((caseClause157!=null?caseClause157.value:default(CaseClause))); 

					}
					break;

				default:
					goto loop78;
				}
			}

			loop78:
				;

			} finally { DebugExitSubRule(78); }

			DebugLocation(1718, 211);
			RBRACE158=(IToken)Match(input,RBRACE,Follow._RBRACE_in_switchStatement6293); 
			RBRACE158_tree = (object)adaptor.Create(RBRACE158);
			adaptor.AddChild(root_0, RBRACE158_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("switchStatement", 71);
			LeaveRule("switchStatement", 71);
			Leave_switchStatement();
		}
		DebugLocation(1720, 1);
		} finally { DebugExitRule(GrammarFileName, "switchStatement"); }
		return retval;

	}
	// $ANTLR end "switchStatement"

	public class caseClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public CaseClause value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_caseClause();
	partial void Leave_caseClause();

	// $ANTLR start "caseClause"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1722:1: caseClause returns [CaseClause value] : CASE expression COLON ( statement )* ;
	[GrammarRule("caseClause")]
	private ES3Parser.caseClause_return caseClause()
	{
		Enter_caseClause();
		EnterRule("caseClause", 72);
		TraceIn("caseClause", 72);
		ES3Parser.caseClause_return retval = new ES3Parser.caseClause_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken CASE159=null;
		IToken COLON161=null;
		ES3Parser.expression_return expression160 = default(ES3Parser.expression_return);
		ES3Parser.statement_return statement162 = default(ES3Parser.statement_return);

		object CASE159_tree=null;
		object COLON161_tree=null;


			retval.value = new CaseClause();

		try { DebugEnterRule(GrammarFileName, "caseClause");
		DebugLocation(1722, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1726:2: ( CASE expression COLON ( statement )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1726:4: CASE expression COLON ( statement )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1726, 8);
			CASE159=(IToken)Match(input,CASE,Follow._CASE_in_caseClause6316); 
			CASE159_tree = (object)adaptor.Create(CASE159);
			root_0 = (object)adaptor.BecomeRoot(CASE159_tree, root_0);

			DebugLocation(1726, 10);
			PushFollow(Follow._expression_in_caseClause6319);
			expression160=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression160.Tree);
			DebugLocation(1726, 21);
			 retval.value.Expression = (expression160!=null?expression160.value:default(Expression)); 
			DebugLocation(1726, 69);
			COLON161=(IToken)Match(input,COLON,Follow._COLON_in_caseClause6323); 
			DebugLocation(1726, 70);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1726:70: ( statement )*
			try { DebugEnterSubRule(79);
			while (true)
			{
				int alt79=2;
				try { DebugEnterDecision(79, decisionCanBacktrack[79]);
				int LA79_0 = input.LA(1);

				if ((LA79_0==ADD||LA79_0==BREAK||LA79_0==CONTINUE||LA79_0==DEC||LA79_0==DELETE||LA79_0==DO||LA79_0==DecimalLiteral||LA79_0==FALSE||LA79_0==FOR||LA79_0==FUNCTION||(LA79_0>=HexIntegerLiteral && LA79_0<=IF)||LA79_0==INC||LA79_0==INV||LA79_0==Identifier||(LA79_0>=LBRACE && LA79_0<=LBRACK)||LA79_0==LPAREN||(LA79_0>=NEW && LA79_0<=NOT)||LA79_0==NULL||LA79_0==OctalIntegerLiteral||LA79_0==RETURN||LA79_0==RegularExpressionLiteral||LA79_0==SEMIC||LA79_0==SUB||LA79_0==SWITCH||LA79_0==StringLiteral||(LA79_0>=THIS && LA79_0<=THROW)||(LA79_0>=TRUE && LA79_0<=TYPEOF)||(LA79_0>=VAR && LA79_0<=VOID)||(LA79_0>=WHILE && LA79_0<=WITH)))
				{
					alt79=1;
				}


				} finally { DebugExitDecision(79); }
				switch ( alt79 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1726:72: statement
					{
					DebugLocation(1726, 72);
					PushFollow(Follow._statement_in_caseClause6327);
					statement162=statement();
					PopFollow();

					adaptor.AddChild(root_0, statement162.Tree);
					DebugLocation(1726, 82);
					 retval.value.Statements.Statements.AddLast((statement162!=null?statement162.value:default(Statement))); 

					}
					break;

				default:
					goto loop79;
				}
			}

			loop79:
				;

			} finally { DebugExitSubRule(79); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("caseClause", 72);
			LeaveRule("caseClause", 72);
			Leave_caseClause();
		}
		DebugLocation(1727, 1);
		} finally { DebugExitRule(GrammarFileName, "caseClause"); }
		return retval;

	}
	// $ANTLR end "caseClause"

	public class defaultClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public BlockStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_defaultClause();
	partial void Leave_defaultClause();

	// $ANTLR start "defaultClause"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1729:1: defaultClause returns [BlockStatement value] : DEFAULT COLON ( statement )* ;
	[GrammarRule("defaultClause")]
	private ES3Parser.defaultClause_return defaultClause()
	{
		Enter_defaultClause();
		EnterRule("defaultClause", 73);
		TraceIn("defaultClause", 73);
		ES3Parser.defaultClause_return retval = new ES3Parser.defaultClause_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken DEFAULT163=null;
		IToken COLON164=null;
		ES3Parser.statement_return statement165 = default(ES3Parser.statement_return);

		object DEFAULT163_tree=null;
		object COLON164_tree=null;


			retval.value = new BlockStatement();

		try { DebugEnterRule(GrammarFileName, "defaultClause");
		DebugLocation(1729, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1733:2: ( DEFAULT COLON ( statement )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1733:4: DEFAULT COLON ( statement )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1733, 11);
			DEFAULT163=(IToken)Match(input,DEFAULT,Follow._DEFAULT_in_defaultClause6352); 
			DEFAULT163_tree = (object)adaptor.Create(DEFAULT163);
			root_0 = (object)adaptor.BecomeRoot(DEFAULT163_tree, root_0);

			DebugLocation(1733, 18);
			COLON164=(IToken)Match(input,COLON,Follow._COLON_in_defaultClause6355); 
			DebugLocation(1733, 20);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1733:20: ( statement )*
			try { DebugEnterSubRule(80);
			while (true)
			{
				int alt80=2;
				try { DebugEnterDecision(80, decisionCanBacktrack[80]);
				int LA80_0 = input.LA(1);

				if ((LA80_0==ADD||LA80_0==BREAK||LA80_0==CONTINUE||LA80_0==DEC||LA80_0==DELETE||LA80_0==DO||LA80_0==DecimalLiteral||LA80_0==FALSE||LA80_0==FOR||LA80_0==FUNCTION||(LA80_0>=HexIntegerLiteral && LA80_0<=IF)||LA80_0==INC||LA80_0==INV||LA80_0==Identifier||(LA80_0>=LBRACE && LA80_0<=LBRACK)||LA80_0==LPAREN||(LA80_0>=NEW && LA80_0<=NOT)||LA80_0==NULL||LA80_0==OctalIntegerLiteral||LA80_0==RETURN||LA80_0==RegularExpressionLiteral||LA80_0==SEMIC||LA80_0==SUB||LA80_0==SWITCH||LA80_0==StringLiteral||(LA80_0>=THIS && LA80_0<=THROW)||(LA80_0>=TRUE && LA80_0<=TYPEOF)||(LA80_0>=VAR && LA80_0<=VOID)||(LA80_0>=WHILE && LA80_0<=WITH)))
				{
					alt80=1;
				}


				} finally { DebugExitDecision(80); }
				switch ( alt80 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1733:21: statement
					{
					DebugLocation(1733, 21);
					PushFollow(Follow._statement_in_defaultClause6359);
					statement165=statement();
					PopFollow();

					adaptor.AddChild(root_0, statement165.Tree);
					DebugLocation(1733, 31);
					 retval.value.Statements.AddLast((statement165!=null?statement165.value:default(Statement))); 

					}
					break;

				default:
					goto loop80;
				}
			}

			loop80:
				;

			} finally { DebugExitSubRule(80); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("defaultClause", 73);
			LeaveRule("defaultClause", 73);
			Leave_defaultClause();
		}
		DebugLocation(1734, 1);
		} finally { DebugExitRule(GrammarFileName, "defaultClause"); }
		return retval;

	}
	// $ANTLR end "defaultClause"

	public class labelledStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_labelledStatement();
	partial void Leave_labelledStatement();

	// $ANTLR start "labelledStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1740:1: labelledStatement returns [Statement value] : lb= Identifier COLON st= statement ;
	[GrammarRule("labelledStatement")]
	private ES3Parser.labelledStatement_return labelledStatement()
	{
		Enter_labelledStatement();
		EnterRule("labelledStatement", 74);
		TraceIn("labelledStatement", 74);
		ES3Parser.labelledStatement_return retval = new ES3Parser.labelledStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken COLON166=null;
		ES3Parser.statement_return st = default(ES3Parser.statement_return);

		object lb_tree=null;
		object COLON166_tree=null;

		try { DebugEnterRule(GrammarFileName, "labelledStatement");
		DebugLocation(1740, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1741:2: (lb= Identifier COLON st= statement )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1741:4: lb= Identifier COLON st= statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1741, 6);
			lb=(IToken)Match(input,Identifier,Follow._Identifier_in_labelledStatement6386); 
			lb_tree = (object)adaptor.Create(lb);
			adaptor.AddChild(root_0, lb_tree);

			DebugLocation(1741, 18);
			COLON166=(IToken)Match(input,COLON,Follow._COLON_in_labelledStatement6388); 
			COLON166_tree = (object)adaptor.Create(COLON166);
			adaptor.AddChild(root_0, COLON166_tree);

			DebugLocation(1741, 26);
			PushFollow(Follow._statement_in_labelledStatement6392);
			st=statement();
			PopFollow();

			adaptor.AddChild(root_0, st.Tree);
			DebugLocation(1741, 37);
			 retval.value = st.value;  retval.value.Label = lb.Text; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("labelledStatement", 74);
			LeaveRule("labelledStatement", 74);
			Leave_labelledStatement();
		}
		DebugLocation(1743, 1);
		} finally { DebugExitRule(GrammarFileName, "labelledStatement"); }
		return retval;

	}
	// $ANTLR end "labelledStatement"

	public class throwStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_throwStatement();
	partial void Leave_throwStatement();

	// $ANTLR start "throwStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1764:1: throwStatement returns [Statement value] : THROW exp= expression semic ;
	[GrammarRule("throwStatement")]
	private ES3Parser.throwStatement_return throwStatement()
	{
		Enter_throwStatement();
		EnterRule("throwStatement", 75);
		TraceIn("throwStatement", 75);
		ES3Parser.throwStatement_return retval = new ES3Parser.throwStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken THROW167=null;
		ES3Parser.expression_return exp = default(ES3Parser.expression_return);
		ES3Parser.semic_return semic168 = default(ES3Parser.semic_return);

		object THROW167_tree=null;

		try { DebugEnterRule(GrammarFileName, "throwStatement");
		DebugLocation(1764, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1765:2: ( THROW exp= expression semic )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1765:4: THROW exp= expression semic
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1765, 9);
			THROW167=(IToken)Match(input,THROW,Follow._THROW_in_throwStatement6418); 
			THROW167_tree = (object)adaptor.Create(THROW167);
			root_0 = (object)adaptor.BecomeRoot(THROW167_tree, root_0);

			DebugLocation(1765, 11);
			 PromoteEOL(null); 
			DebugLocation(1765, 36);
			PushFollow(Follow._expression_in_throwStatement6425);
			exp=expression();
			PopFollow();

			adaptor.AddChild(root_0, exp.Tree);
			DebugLocation(1765, 48);
			 retval.value = new ThrowStatement(exp.value); 
			DebugLocation(1765, 97);
			PushFollow(Follow._semic_in_throwStatement6429);
			semic168=semic();
			PopFollow();


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("throwStatement", 75);
			LeaveRule("throwStatement", 75);
			Leave_throwStatement();
		}
		DebugLocation(1766, 1);
		} finally { DebugExitRule(GrammarFileName, "throwStatement"); }
		return retval;

	}
	// $ANTLR end "throwStatement"

	public class tryStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public TryStatement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_tryStatement();
	partial void Leave_tryStatement();

	// $ANTLR start "tryStatement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1772:1: tryStatement returns [TryStatement value] : TRY b= block (c= catchClause (first= finallyClause )? |last= finallyClause ) ;
	[GrammarRule("tryStatement")]
	private ES3Parser.tryStatement_return tryStatement()
	{
		Enter_tryStatement();
		EnterRule("tryStatement", 76);
		TraceIn("tryStatement", 76);
		ES3Parser.tryStatement_return retval = new ES3Parser.tryStatement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken TRY169=null;
		ES3Parser.block_return b = default(ES3Parser.block_return);
		ES3Parser.catchClause_return c = default(ES3Parser.catchClause_return);
		ES3Parser.finallyClause_return first = default(ES3Parser.finallyClause_return);
		ES3Parser.finallyClause_return last = default(ES3Parser.finallyClause_return);

		object TRY169_tree=null;


			retval.value = new TryStatement();

		try { DebugEnterRule(GrammarFileName, "tryStatement");
		DebugLocation(1772, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:2: ( TRY b= block (c= catchClause (first= finallyClause )? |last= finallyClause ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:4: TRY b= block (c= catchClause (first= finallyClause )? |last= finallyClause )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1776, 7);
			TRY169=(IToken)Match(input,TRY,Follow._TRY_in_tryStatement6454); 
			TRY169_tree = (object)adaptor.Create(TRY169);
			root_0 = (object)adaptor.BecomeRoot(TRY169_tree, root_0);

			DebugLocation(1776, 10);
			PushFollow(Follow._block_in_tryStatement6459);
			b=block();
			PopFollow();

			adaptor.AddChild(root_0, b.Tree);
			DebugLocation(1776, 18);
			 retval.value.Statement = b.value; 
			DebugLocation(1776, 50);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:50: (c= catchClause (first= finallyClause )? |last= finallyClause )
			int alt82=2;
			try { DebugEnterSubRule(82);
			try { DebugEnterDecision(82, decisionCanBacktrack[82]);
			int LA82_0 = input.LA(1);

			if ((LA82_0==CATCH))
			{
				alt82=1;
			}
			else if ((LA82_0==FINALLY))
			{
				alt82=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 82, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(82); }
			switch (alt82)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:52: c= catchClause (first= finallyClause )?
				{
				DebugLocation(1776, 53);
				PushFollow(Follow._catchClause_in_tryStatement6468);
				c=catchClause();
				PopFollow();

				adaptor.AddChild(root_0, c.Tree);
				DebugLocation(1776, 66);
				 retval.value.Catch = c.value; 
				DebugLocation(1776, 94);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:94: (first= finallyClause )?
				int alt81=2;
				try { DebugEnterSubRule(81);
				try { DebugEnterDecision(81, decisionCanBacktrack[81]);
				int LA81_0 = input.LA(1);

				if ((LA81_0==FINALLY))
				{
					alt81=1;
				}
				} finally { DebugExitDecision(81); }
				switch (alt81)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:95: first= finallyClause
					{
					DebugLocation(1776, 100);
					PushFollow(Follow._finallyClause_in_tryStatement6475);
					first=finallyClause();
					PopFollow();

					adaptor.AddChild(root_0, first.Tree);
					DebugLocation(1776, 115);
					 retval.value.Finally = first.value; 

					}
					break;

				}
				} finally { DebugExitSubRule(81); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1776:153: last= finallyClause
				{
				DebugLocation(1776, 157);
				PushFollow(Follow._finallyClause_in_tryStatement6485);
				last=finallyClause();
				PopFollow();

				adaptor.AddChild(root_0, last.Tree);
				DebugLocation(1776, 172);
				 retval.value.Finally = last.value; 

				}
				break;

			}
			} finally { DebugExitSubRule(82); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("tryStatement", 76);
			LeaveRule("tryStatement", 76);
			Leave_tryStatement();
		}
		DebugLocation(1777, 1);
		} finally { DebugExitRule(GrammarFileName, "tryStatement"); }
		return retval;

	}
	// $ANTLR end "tryStatement"

	public class catchClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public CatchClause value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_catchClause();
	partial void Leave_catchClause();

	// $ANTLR start "catchClause"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1779:1: catchClause returns [CatchClause value] : CATCH LPAREN id= Identifier RPAREN block ;
	[GrammarRule("catchClause")]
	private ES3Parser.catchClause_return catchClause()
	{
		Enter_catchClause();
		EnterRule("catchClause", 77);
		TraceIn("catchClause", 77);
		ES3Parser.catchClause_return retval = new ES3Parser.catchClause_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken id=null;
		IToken CATCH170=null;
		IToken LPAREN171=null;
		IToken RPAREN172=null;
		ES3Parser.block_return block173 = default(ES3Parser.block_return);

		object id_tree=null;
		object CATCH170_tree=null;
		object LPAREN171_tree=null;
		object RPAREN172_tree=null;

		try { DebugEnterRule(GrammarFileName, "catchClause");
		DebugLocation(1779, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1780:2: ( CATCH LPAREN id= Identifier RPAREN block )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1780:4: CATCH LPAREN id= Identifier RPAREN block
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1780, 9);
			CATCH170=(IToken)Match(input,CATCH,Follow._CATCH_in_catchClause6505); 
			CATCH170_tree = (object)adaptor.Create(CATCH170);
			root_0 = (object)adaptor.BecomeRoot(CATCH170_tree, root_0);

			DebugLocation(1780, 17);
			LPAREN171=(IToken)Match(input,LPAREN,Follow._LPAREN_in_catchClause6508); 
			DebugLocation(1780, 21);
			id=(IToken)Match(input,Identifier,Follow._Identifier_in_catchClause6513); 
			id_tree = (object)adaptor.Create(id);
			adaptor.AddChild(root_0, id_tree);

			DebugLocation(1780, 39);
			RPAREN172=(IToken)Match(input,RPAREN,Follow._RPAREN_in_catchClause6515); 
			DebugLocation(1780, 41);
			PushFollow(Follow._block_in_catchClause6518);
			block173=block();
			PopFollow();

			adaptor.AddChild(root_0, block173.Tree);
			DebugLocation(1780, 47);
			 retval.value = new CatchClause((id!=null?id.Text:null), (block173!=null?block173.value:default(BlockStatement))); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("catchClause", 77);
			LeaveRule("catchClause", 77);
			Leave_catchClause();
		}
		DebugLocation(1781, 1);
		} finally { DebugExitRule(GrammarFileName, "catchClause"); }
		return retval;

	}
	// $ANTLR end "catchClause"

	public class finallyClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public FinallyClause value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_finallyClause();
	partial void Leave_finallyClause();

	// $ANTLR start "finallyClause"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1783:1: finallyClause returns [FinallyClause value] : FINALLY block ;
	[GrammarRule("finallyClause")]
	private ES3Parser.finallyClause_return finallyClause()
	{
		Enter_finallyClause();
		EnterRule("finallyClause", 78);
		TraceIn("finallyClause", 78);
		ES3Parser.finallyClause_return retval = new ES3Parser.finallyClause_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken FINALLY174=null;
		ES3Parser.block_return block175 = default(ES3Parser.block_return);

		object FINALLY174_tree=null;

		try { DebugEnterRule(GrammarFileName, "finallyClause");
		DebugLocation(1783, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1784:2: ( FINALLY block )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1784:4: FINALLY block
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1784, 11);
			FINALLY174=(IToken)Match(input,FINALLY,Follow._FINALLY_in_finallyClause6536); 
			FINALLY174_tree = (object)adaptor.Create(FINALLY174);
			root_0 = (object)adaptor.BecomeRoot(FINALLY174_tree, root_0);

			DebugLocation(1784, 13);
			PushFollow(Follow._block_in_finallyClause6539);
			block175=block();
			PopFollow();

			adaptor.AddChild(root_0, block175.Tree);
			DebugLocation(1784, 19);
			 retval.value = new FinallyClause((block175!=null?block175.value:default(BlockStatement))); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("finallyClause", 78);
			LeaveRule("finallyClause", 78);
			Leave_finallyClause();
		}
		DebugLocation(1785, 1);
		} finally { DebugExitRule(GrammarFileName, "finallyClause"); }
		return retval;

	}
	// $ANTLR end "finallyClause"

	public class functionDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionDeclaration();
	partial void Leave_functionDeclaration();

	// $ANTLR start "functionDeclaration"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1797:1: functionDeclaration returns [Statement value] : FUNCTION name= Identifier parameters= formalParameterList body= functionBody ;
	[GrammarRule("functionDeclaration")]
	private ES3Parser.functionDeclaration_return functionDeclaration()
	{
		Enter_functionDeclaration();
		EnterRule("functionDeclaration", 79);
		TraceIn("functionDeclaration", 79);
		ES3Parser.functionDeclaration_return retval = new ES3Parser.functionDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken name=null;
		IToken FUNCTION176=null;
		ES3Parser.formalParameterList_return parameters = default(ES3Parser.formalParameterList_return);
		ES3Parser.functionBody_return body = default(ES3Parser.functionBody_return);

		object name_tree=null;
		object FUNCTION176_tree=null;


		FunctionDeclarationStatement statement = new FunctionDeclarationStatement();
		retval.value = statement;

		try { DebugEnterRule(GrammarFileName, "functionDeclaration");
		DebugLocation(1797, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1802:2: ( FUNCTION name= Identifier parameters= formalParameterList body= functionBody )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1802:4: FUNCTION name= Identifier parameters= formalParameterList body= functionBody
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1802, 4);
			FUNCTION176=(IToken)Match(input,FUNCTION,Follow._FUNCTION_in_functionDeclaration6571); 
			FUNCTION176_tree = (object)adaptor.Create(FUNCTION176);
			adaptor.AddChild(root_0, FUNCTION176_tree);

			DebugLocation(1802, 18);
			name=(IToken)Match(input,Identifier,Follow._Identifier_in_functionDeclaration6576); 
			name_tree = (object)adaptor.Create(name);
			adaptor.AddChild(root_0, name_tree);

			DebugLocation(1802, 30);
			 statement.Name = name.Text; 
			DebugLocation(1803, 14);
			PushFollow(Follow._formalParameterList_in_functionDeclaration6586);
			parameters=formalParameterList();
			PopFollow();

			adaptor.AddChild(root_0, parameters.Tree);
			DebugLocation(1803, 35);
			 statement.Parameters.AddRange(parameters.value); 
			DebugLocation(1804, 8);
			PushFollow(Follow._functionBody_in_functionDeclaration6595);
			body=functionBody();
			PopFollow();

			adaptor.AddChild(root_0, body.Tree);
			DebugLocation(1804, 22);
			 statement.Statement = body.value; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionDeclaration", 79);
			LeaveRule("functionDeclaration", 79);
			Leave_functionDeclaration();
		}
		DebugLocation(1807, 1);
		} finally { DebugExitRule(GrammarFileName, "functionDeclaration"); }
		return retval;

	}
	// $ANTLR end "functionDeclaration"

	public class functionExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public FunctionExpression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionExpression();
	partial void Leave_functionExpression();

	// $ANTLR start "functionExpression"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1809:1: functionExpression returns [FunctionExpression value] : FUNCTION (name= Identifier )? formalParameterList functionBody ;
	[GrammarRule("functionExpression")]
	private ES3Parser.functionExpression_return functionExpression()
	{
		Enter_functionExpression();
		EnterRule("functionExpression", 80);
		TraceIn("functionExpression", 80);
		ES3Parser.functionExpression_return retval = new ES3Parser.functionExpression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken name=null;
		IToken FUNCTION177=null;
		ES3Parser.formalParameterList_return formalParameterList178 = default(ES3Parser.formalParameterList_return);
		ES3Parser.functionBody_return functionBody179 = default(ES3Parser.functionBody_return);

		object name_tree=null;
		object FUNCTION177_tree=null;


			retval.value = new FunctionExpression();

		try { DebugEnterRule(GrammarFileName, "functionExpression");
		DebugLocation(1809, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1813:2: ( FUNCTION (name= Identifier )? formalParameterList functionBody )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1813:4: FUNCTION (name= Identifier )? formalParameterList functionBody
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1813, 4);
			FUNCTION177=(IToken)Match(input,FUNCTION,Follow._FUNCTION_in_functionExpression6622); 
			FUNCTION177_tree = (object)adaptor.Create(FUNCTION177);
			adaptor.AddChild(root_0, FUNCTION177_tree);

			DebugLocation(1813, 13);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1813:13: (name= Identifier )?
			int alt83=2;
			try { DebugEnterSubRule(83);
			try { DebugEnterDecision(83, decisionCanBacktrack[83]);
			int LA83_0 = input.LA(1);

			if ((LA83_0==Identifier))
			{
				alt83=1;
			}
			} finally { DebugExitDecision(83); }
			switch (alt83)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1813:14: name= Identifier
				{
				DebugLocation(1813, 18);
				name=(IToken)Match(input,Identifier,Follow._Identifier_in_functionExpression6627); 
				name_tree = (object)adaptor.Create(name);
				adaptor.AddChild(root_0, name_tree);

				DebugLocation(1813, 30);
				 retval.value.Name = name.Text; 

				}
				break;

			}
			} finally { DebugExitSubRule(83); }

			DebugLocation(1813, 62);
			PushFollow(Follow._formalParameterList_in_functionExpression6634);
			formalParameterList178=formalParameterList();
			PopFollow();

			adaptor.AddChild(root_0, formalParameterList178.Tree);
			DebugLocation(1813, 82);
			 retval.value.Parameters.AddRange((formalParameterList178!=null?formalParameterList178.value:default(List<string>))) ;
			DebugLocation(1813, 142);
			PushFollow(Follow._functionBody_in_functionExpression6638);
			functionBody179=functionBody();
			PopFollow();

			adaptor.AddChild(root_0, functionBody179.Tree);
			DebugLocation(1813, 155);
			 retval.value.Statement = (functionBody179!=null?functionBody179.value:default(Statement)); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionExpression", 80);
			LeaveRule("functionExpression", 80);
			Leave_functionExpression();
		}
		DebugLocation(1816, 1);
		} finally { DebugExitRule(GrammarFileName, "functionExpression"); }
		return retval;

	}
	// $ANTLR end "functionExpression"

	public class formalParameterList_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public List<string> value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_formalParameterList();
	partial void Leave_formalParameterList();

	// $ANTLR start "formalParameterList"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1818:1: formalParameterList returns [List<string> value] : LPAREN (first= Identifier ( COMMA follow= Identifier )* )? RPAREN ;
	[GrammarRule("formalParameterList")]
	private ES3Parser.formalParameterList_return formalParameterList()
	{
		Enter_formalParameterList();
		EnterRule("formalParameterList", 81);
		TraceIn("formalParameterList", 81);
		ES3Parser.formalParameterList_return retval = new ES3Parser.formalParameterList_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken first=null;
		IToken follow=null;
		IToken LPAREN180=null;
		IToken COMMA181=null;
		IToken RPAREN182=null;

		object first_tree=null;
		object follow_tree=null;
		object LPAREN180_tree=null;
		object COMMA181_tree=null;
		object RPAREN182_tree=null;


		List<string> identifiers = new List<string>();
		retval.value = identifiers;

		try { DebugEnterRule(GrammarFileName, "formalParameterList");
		DebugLocation(1818, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:2: ( LPAREN (first= Identifier ( COMMA follow= Identifier )* )? RPAREN )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:4: LPAREN (first= Identifier ( COMMA follow= Identifier )* )? RPAREN
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1823, 4);
			LPAREN180=(IToken)Match(input,LPAREN,Follow._LPAREN_in_formalParameterList6663); 
			LPAREN180_tree = (object)adaptor.Create(LPAREN180);
			adaptor.AddChild(root_0, LPAREN180_tree);

			DebugLocation(1823, 11);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:11: (first= Identifier ( COMMA follow= Identifier )* )?
			int alt85=2;
			try { DebugEnterSubRule(85);
			try { DebugEnterDecision(85, decisionCanBacktrack[85]);
			int LA85_0 = input.LA(1);

			if ((LA85_0==Identifier))
			{
				alt85=1;
			}
			} finally { DebugExitDecision(85); }
			switch (alt85)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:13: first= Identifier ( COMMA follow= Identifier )*
				{
				DebugLocation(1823, 18);
				first=(IToken)Match(input,Identifier,Follow._Identifier_in_formalParameterList6669); 
				first_tree = (object)adaptor.Create(first);
				adaptor.AddChild(root_0, first_tree);

				DebugLocation(1823, 30);
				 identifiers.Add((first!=null?first.Text:null)); 
				DebugLocation(1823, 64);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:64: ( COMMA follow= Identifier )*
				try { DebugEnterSubRule(84);
				while (true)
				{
					int alt84=2;
					try { DebugEnterDecision(84, decisionCanBacktrack[84]);
					int LA84_0 = input.LA(1);

					if ((LA84_0==COMMA))
					{
						alt84=1;
					}


					} finally { DebugExitDecision(84); }
					switch ( alt84 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1823:66: COMMA follow= Identifier
						{
						DebugLocation(1823, 66);
						COMMA181=(IToken)Match(input,COMMA,Follow._COMMA_in_formalParameterList6675); 
						COMMA181_tree = (object)adaptor.Create(COMMA181);
						adaptor.AddChild(root_0, COMMA181_tree);

						DebugLocation(1823, 78);
						follow=(IToken)Match(input,Identifier,Follow._Identifier_in_formalParameterList6679); 
						follow_tree = (object)adaptor.Create(follow);
						adaptor.AddChild(root_0, follow_tree);

						DebugLocation(1823, 91);
						 identifiers.Add((follow!=null?follow.Text:null)); 

						}
						break;

					default:
						goto loop84;
					}
				}

				loop84:
					;

				} finally { DebugExitSubRule(84); }


				}
				break;

			}
			} finally { DebugExitSubRule(85); }

			DebugLocation(1823, 132);
			RPAREN182=(IToken)Match(input,RPAREN,Follow._RPAREN_in_formalParameterList6690); 
			RPAREN182_tree = (object)adaptor.Create(RPAREN182);
			adaptor.AddChild(root_0, RPAREN182_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("formalParameterList", 81);
			LeaveRule("formalParameterList", 81);
			Leave_formalParameterList();
		}
		DebugLocation(1825, 1);
		} finally { DebugExitRule(GrammarFileName, "formalParameterList"); }
		return retval;

	}
	// $ANTLR end "formalParameterList"

	public class functionBody_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionBody();
	partial void Leave_functionBody();

	// $ANTLR start "functionBody"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1827:1: functionBody returns [Statement value] : lb= LBRACE ( sourceElement )* RBRACE ;
	[GrammarRule("functionBody")]
	private ES3Parser.functionBody_return functionBody()
	{
		Enter_functionBody();
		EnterRule("functionBody", 82);
		TraceIn("functionBody", 82);
		ES3Parser.functionBody_return retval = new ES3Parser.functionBody_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken lb=null;
		IToken RBRACE184=null;
		ES3Parser.sourceElement_return sourceElement183 = default(ES3Parser.sourceElement_return);

		object lb_tree=null;
		object RBRACE184_tree=null;


		BlockStatement block = new BlockStatement();
		retval.value = block;

		try { DebugEnterRule(GrammarFileName, "functionBody");
		DebugLocation(1827, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1832:2: (lb= LBRACE ( sourceElement )* RBRACE )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1832:4: lb= LBRACE ( sourceElement )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1832, 6);
			lb=(IToken)Match(input,LBRACE,Follow._LBRACE_in_functionBody6713); 
			lb_tree = (object)adaptor.Create(lb);
			adaptor.AddChild(root_0, lb_tree);

			DebugLocation(1832, 14);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1832:14: ( sourceElement )*
			try { DebugEnterSubRule(86);
			while (true)
			{
				int alt86=2;
				try { DebugEnterDecision(86, decisionCanBacktrack[86]);
				int LA86_0 = input.LA(1);

				if ((LA86_0==ADD||LA86_0==BREAK||LA86_0==CONTINUE||LA86_0==DEC||LA86_0==DELETE||LA86_0==DO||LA86_0==DecimalLiteral||LA86_0==FALSE||LA86_0==FOR||LA86_0==FUNCTION||(LA86_0>=HexIntegerLiteral && LA86_0<=IF)||LA86_0==INC||LA86_0==INV||LA86_0==Identifier||(LA86_0>=LBRACE && LA86_0<=LBRACK)||LA86_0==LPAREN||(LA86_0>=NEW && LA86_0<=NOT)||LA86_0==NULL||LA86_0==OctalIntegerLiteral||LA86_0==RETURN||LA86_0==RegularExpressionLiteral||LA86_0==SEMIC||LA86_0==SUB||LA86_0==SWITCH||LA86_0==StringLiteral||(LA86_0>=THIS && LA86_0<=THROW)||(LA86_0>=TRUE && LA86_0<=TYPEOF)||(LA86_0>=VAR && LA86_0<=VOID)||(LA86_0>=WHILE && LA86_0<=WITH)))
				{
					alt86=1;
				}


				} finally { DebugExitDecision(86); }
				switch ( alt86 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1832:15: sourceElement
					{
					DebugLocation(1832, 15);
					PushFollow(Follow._sourceElement_in_functionBody6716);
					sourceElement183=sourceElement();
					PopFollow();

					adaptor.AddChild(root_0, sourceElement183.Tree);
					DebugLocation(1832, 29);
					 block.Statements.AddLast((sourceElement183!=null?sourceElement183.value:default(Statement))); 

					}
					break;

				default:
					goto loop86;
				}
			}

			loop86:
				;

			} finally { DebugExitSubRule(86); }

			DebugLocation(1832, 84);
			RBRACE184=(IToken)Match(input,RBRACE,Follow._RBRACE_in_functionBody6723); 
			RBRACE184_tree = (object)adaptor.Create(RBRACE184);
			adaptor.AddChild(root_0, RBRACE184_tree);


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionBody", 82);
			LeaveRule("functionBody", 82);
			Leave_functionBody();
		}
		DebugLocation(1834, 1);
		} finally { DebugExitRule(GrammarFileName, "functionBody"); }
		return retval;

	}
	// $ANTLR end "functionBody"

	public class program_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Program value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_program();
	partial void Leave_program();

	// $ANTLR start "program"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1840:1: program returns [Program value] : (follow= sourceElement )* ;
	[GrammarRule("program")]
	public ES3Parser.program_return program()
	{
		Enter_program();
		EnterRule("program", 83);
		TraceIn("program", 83);
		ES3Parser.program_return retval = new ES3Parser.program_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.sourceElement_return follow = default(ES3Parser.sourceElement_return);



		script = input.ToString().Split('\n');
		Program program = new Program();

		try { DebugEnterRule(GrammarFileName, "program");
		DebugLocation(1840, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1845:2: ( (follow= sourceElement )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1845:4: (follow= sourceElement )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(1845, 4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1845:4: (follow= sourceElement )*
			try { DebugEnterSubRule(87);
			while (true)
			{
				int alt87=2;
				try { DebugEnterDecision(87, decisionCanBacktrack[87]);
				int LA87_0 = input.LA(1);

				if ((LA87_0==ADD||LA87_0==BREAK||LA87_0==CONTINUE||LA87_0==DEC||LA87_0==DELETE||LA87_0==DO||LA87_0==DecimalLiteral||LA87_0==FALSE||LA87_0==FOR||LA87_0==FUNCTION||(LA87_0>=HexIntegerLiteral && LA87_0<=IF)||LA87_0==INC||LA87_0==INV||LA87_0==Identifier||(LA87_0>=LBRACE && LA87_0<=LBRACK)||LA87_0==LPAREN||(LA87_0>=NEW && LA87_0<=NOT)||LA87_0==NULL||LA87_0==OctalIntegerLiteral||LA87_0==RETURN||LA87_0==RegularExpressionLiteral||LA87_0==SEMIC||LA87_0==SUB||LA87_0==SWITCH||LA87_0==StringLiteral||(LA87_0>=THIS && LA87_0<=THROW)||(LA87_0>=TRUE && LA87_0<=TYPEOF)||(LA87_0>=VAR && LA87_0<=VOID)||(LA87_0>=WHILE && LA87_0<=WITH)))
				{
					alt87=1;
				}


				} finally { DebugExitDecision(87); }
				switch ( alt87 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1845:5: follow= sourceElement
					{
					DebugLocation(1845, 11);
					PushFollow(Follow._sourceElement_in_program6752);
					follow=sourceElement();
					PopFollow();

					adaptor.AddChild(root_0, follow.Tree);
					DebugLocation(1845, 26);
					 program.Statements.AddLast(follow.value); 

					}
					break;

				default:
					goto loop87;
				}
			}

			loop87:
				;

			} finally { DebugExitSubRule(87); }

			DebugLocation(1845, 74);
			 retval.value = program; 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("program", 83);
			LeaveRule("program", 83);
			Leave_program();
		}
		DebugLocation(1846, 1);
		} finally { DebugExitRule(GrammarFileName, "program"); }
		return retval;

	}
	// $ANTLR end "program"

	public class sourceElement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public Statement value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_sourceElement();
	partial void Leave_sourceElement();

	// $ANTLR start "sourceElement"
	// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1853:1: sourceElement returns [Statement value] options {k=1; } : ({...}?func= functionDeclaration |stat= statement );
	[GrammarRule("sourceElement")]
	private ES3Parser.sourceElement_return sourceElement()
	{
		Enter_sourceElement();
		EnterRule("sourceElement", 84);
		TraceIn("sourceElement", 84);
		ES3Parser.sourceElement_return retval = new ES3Parser.sourceElement_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		ES3Parser.functionDeclaration_return func = default(ES3Parser.functionDeclaration_return);
		ES3Parser.statement_return stat = default(ES3Parser.statement_return);


		try { DebugEnterRule(GrammarFileName, "sourceElement");
		DebugLocation(1853, 1);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1859:2: ({...}?func= functionDeclaration |stat= statement )
			int alt88=2;
			try { DebugEnterDecision(88, decisionCanBacktrack[88]);
			try
			{
				alt88 = dfa88.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(88); }
			switch (alt88)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1859:4: {...}?func= functionDeclaration
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1859, 4);
				if (!(( input.LA(1) == FUNCTION )))
				{
					throw new FailedPredicateException(input, "sourceElement", " input.LA(1) == FUNCTION ");
				}
				DebugLocation(1859, 37);
				PushFollow(Follow._functionDeclaration_in_sourceElement6793);
				func=functionDeclaration();
				PopFollow();

				adaptor.AddChild(root_0, func.Tree);
				DebugLocation(1859, 58);
				 retval.value = func.value; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1860:4: stat= statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(1860, 8);
				PushFollow(Follow._statement_in_sourceElement6802);
				stat=statement();
				PopFollow();

				adaptor.AddChild(root_0, stat.Tree);
				DebugLocation(1860, 19);
				 retval.value = stat.value; 

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("sourceElement", 84);
			LeaveRule("sourceElement", 84);
			Leave_sourceElement();
		}
		DebugLocation(1861, 1);
		} finally { DebugExitRule(GrammarFileName, "sourceElement"); }
		return retval;

	}
	// $ANTLR end "sourceElement"
	#endregion Rules


	#region DFA
	DFA57 dfa57;
	DFA58 dfa58;
	DFA88 dfa88;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa57 = new DFA57( this, SpecialStateTransition57 );
		dfa58 = new DFA58( this );
		dfa88 = new DFA88( this, SpecialStateTransition88 );
	}

	private class DFA57 : DFA
	{
		private const string DFA57_eotS =
			"\x28\xFFFF";
		private const string DFA57_eofS =
			"\x28\xFFFF";
		private const string DFA57_minS =
			"\x1\x5\x2\x0\x25\xFFFF";
		private const string DFA57_maxS =
			"\x1\xA6\x2\x0\x25\xFFFF";
		private const string DFA57_acceptS =
			"\x3\xFFFF\x1\x3\x22\xFFFF\x1\x1\x1\x2";
		private const string DFA57_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x25\xFFFF}>";
		private static readonly string[] DFA57_transitionS =
			{
				"\x1\x3\x8\xFFFF\x1\x3\xE\xFFFF\x1\x3\x3\xFFFF\x1\x3\x1\xFFFF\x1\x3\x2"+
				"\xFFFF\x1\x3\x5\xFFFF\x1\x3\x9\xFFFF\x1\x3\x4\xFFFF\x1\x3\x2\xFFFF\x1"+
				"\x2\x5\xFFFF\x2\x3\x3\xFFFF\x1\x3\x3\xFFFF\x1\x3\x1\xFFFF\x1\x3\x5\xFFFF"+
				"\x1\x1\x1\x3\x3\xFFFF\x1\x3\xE\xFFFF\x2\x3\x1\xFFFF\x1\x3\x5\xFFFF\x1"+
				"\x3\xC\xFFFF\x1\x3\x3\xFFFF\x1\x3\x1\xFFFF\x1\x3\xA\xFFFF\x1\x3\x2\xFFFF"+
				"\x1\x3\x2\xFFFF\x1\x3\x1\xFFFF\x2\x3\x2\xFFFF\x3\x3\x2\xFFFF\x2\x3\x2"+
				"\xFFFF\x2\x3",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA57_eot = DFA.UnpackEncodedString(DFA57_eotS);
		private static readonly short[] DFA57_eof = DFA.UnpackEncodedString(DFA57_eofS);
		private static readonly char[] DFA57_min = DFA.UnpackEncodedStringToUnsignedChars(DFA57_minS);
		private static readonly char[] DFA57_max = DFA.UnpackEncodedStringToUnsignedChars(DFA57_maxS);
		private static readonly short[] DFA57_accept = DFA.UnpackEncodedString(DFA57_acceptS);
		private static readonly short[] DFA57_special = DFA.UnpackEncodedString(DFA57_specialS);
		private static readonly short[][] DFA57_transition;

		static DFA57()
		{
			int numStates = DFA57_transitionS.Length;
			DFA57_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA57_transition[i] = DFA.UnpackEncodedString(DFA57_transitionS[i]);
			}
		}

		public DFA57( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 57;
			this.eot = DFA57_eot;
			this.eof = DFA57_eof;
			this.min = DFA57_min;
			this.max = DFA57_max;
			this.accept = DFA57_accept;
			this.special = DFA57_special;
			this.transition = DFA57_transition;
		}

		public override string Description { get { return "1405:1: statement returns [Statement value] options {k=1; } : ({...}? block |{...}?func= functionDeclaration | statementTail );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition57(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA57_1 = input.LA(1);


				int index57_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (( input.LA(1) == LBRACE )) ) {s = 38;}

				else if ( (true) ) {s = 3;}


				input.Seek(index57_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA57_2 = input.LA(1);


				int index57_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (( input.LA(1) == FUNCTION )) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index57_2);
				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 57, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA58 : DFA
	{
		private const string DFA58_eotS =
			"\xF\xFFFF";
		private const string DFA58_eofS =
			"\x4\xFFFF\x1\x3\xA\xFFFF";
		private const string DFA58_minS =
			"\x1\x5\x3\xFFFF\x1\x5\xA\xFFFF";
		private const string DFA58_maxS =
			"\x1\xA6\x3\xFFFF\x1\xA9\xA\xFFFF";
		private const string DFA58_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\x1\x3\x1\xFFFF\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1"+
			"\x9\x1\xB\x1\xC\x1\xD\x1\xA";
		private const string DFA58_specialS =
			"\xF\xFFFF}>";
		private static readonly string[] DFA58_transitionS =
			{
				"\x1\x3\x8\xFFFF\x1\x8\xE\xFFFF\x1\x7\x3\xFFFF\x1\x3\x1\xFFFF\x1\x3\x2"+
				"\xFFFF\x1\x6\x5\xFFFF\x1\x3\x9\xFFFF\x1\x3\x4\xFFFF\x1\x6\x2\xFFFF\x1"+
				"\x3\x5\xFFFF\x1\x3\x1\x5\x3\xFFFF\x1\x3\x3\xFFFF\x1\x3\x1\xFFFF\x1\x4"+
				"\x5\xFFFF\x2\x3\x3\xFFFF\x1\x3\xE\xFFFF\x2\x3\x1\xFFFF\x1\x3\x5\xFFFF"+
				"\x1\x3\xC\xFFFF\x1\x9\x3\xFFFF\x1\x3\x1\xFFFF\x1\x2\xA\xFFFF\x1\x3\x2"+
				"\xFFFF\x1\xB\x2\xFFFF\x1\x3\x1\xFFFF\x1\x3\x1\xC\x2\xFFFF\x1\x3\x1\xD"+
				"\x1\x3\x2\xFFFF\x1\x1\x1\x3\x2\xFFFF\x1\x6\x1\xA",
				"",
				"",
				"",
				"\x4\x3\x2\xFFFF\x1\x3\xE\xFFFF\x1\xE\x1\x3\x5\xFFFF\x1\x3\x2\xFFFF\x2"+
				"\x3\x1\xFFFF\x1\x3\x7\xFFFF\x2\x3\xF\xFFFF\x2\x3\x6\xFFFF\x3\x3\x9\xFFFF"+
				"\x3\x3\x2\xFFFF\x2\x3\x1\xFFFF\x2\x3\x1\xFFFF\x5\x3\x4\xFFFF\x1\x3\x2"+
				"\xFFFF\x1\x3\x2\xFFFF\x2\x3\xC\xFFFF\x2\x3\x6\xFFFF\x4\x3\x1\xFFFF\x4"+
				"\x3\x3\xFFFF\x2\x3\x16\xFFFF\x2\x3",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA58_eot = DFA.UnpackEncodedString(DFA58_eotS);
		private static readonly short[] DFA58_eof = DFA.UnpackEncodedString(DFA58_eofS);
		private static readonly char[] DFA58_min = DFA.UnpackEncodedStringToUnsignedChars(DFA58_minS);
		private static readonly char[] DFA58_max = DFA.UnpackEncodedStringToUnsignedChars(DFA58_maxS);
		private static readonly short[] DFA58_accept = DFA.UnpackEncodedString(DFA58_acceptS);
		private static readonly short[] DFA58_special = DFA.UnpackEncodedString(DFA58_specialS);
		private static readonly short[][] DFA58_transition;

		static DFA58()
		{
			int numStates = DFA58_transitionS.Length;
			DFA58_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA58_transition[i] = DFA.UnpackEncodedString(DFA58_transitionS[i]);
			}
		}

		public DFA58( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 58;
			this.eot = DFA58_eot;
			this.eof = DFA58_eof;
			this.min = DFA58_min;
			this.max = DFA58_max;
			this.accept = DFA58_accept;
			this.special = DFA58_special;
			this.transition = DFA58_transition;
		}

		public override string Description { get { return "1416:1: statementTail returns [Statement value] : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA88 : DFA
	{
		private const string DFA88_eotS =
			"\x27\xFFFF";
		private const string DFA88_eofS =
			"\x27\xFFFF";
		private const string DFA88_minS =
			"\x1\x5\x1\x0\x25\xFFFF";
		private const string DFA88_maxS =
			"\x1\xA6\x1\x0\x25\xFFFF";
		private const string DFA88_acceptS =
			"\x2\xFFFF\x1\x2\x23\xFFFF\x1\x1";
		private const string DFA88_specialS =
			"\x1\xFFFF\x1\x0\x25\xFFFF}>";
		private static readonly string[] DFA88_transitionS =
			{
				"\x1\x2\x8\xFFFF\x1\x2\xE\xFFFF\x1\x2\x3\xFFFF\x1\x2\x1\xFFFF\x1\x2\x2"+
				"\xFFFF\x1\x2\x5\xFFFF\x1\x2\x9\xFFFF\x1\x2\x4\xFFFF\x1\x2\x2\xFFFF\x1"+
				"\x1\x5\xFFFF\x2\x2\x3\xFFFF\x1\x2\x3\xFFFF\x1\x2\x1\xFFFF\x1\x2\x5\xFFFF"+
				"\x2\x2\x3\xFFFF\x1\x2\xE\xFFFF\x2\x2\x1\xFFFF\x1\x2\x5\xFFFF\x1\x2\xC"+
				"\xFFFF\x1\x2\x3\xFFFF\x1\x2\x1\xFFFF\x1\x2\xA\xFFFF\x1\x2\x2\xFFFF\x1"+
				"\x2\x2\xFFFF\x1\x2\x1\xFFFF\x2\x2\x2\xFFFF\x3\x2\x2\xFFFF\x2\x2\x2\xFFFF"+
				"\x2\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA88_eot = DFA.UnpackEncodedString(DFA88_eotS);
		private static readonly short[] DFA88_eof = DFA.UnpackEncodedString(DFA88_eofS);
		private static readonly char[] DFA88_min = DFA.UnpackEncodedStringToUnsignedChars(DFA88_minS);
		private static readonly char[] DFA88_max = DFA.UnpackEncodedStringToUnsignedChars(DFA88_maxS);
		private static readonly short[] DFA88_accept = DFA.UnpackEncodedString(DFA88_acceptS);
		private static readonly short[] DFA88_special = DFA.UnpackEncodedString(DFA88_specialS);
		private static readonly short[][] DFA88_transition;

		static DFA88()
		{
			int numStates = DFA88_transitionS.Length;
			DFA88_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA88_transition[i] = DFA.UnpackEncodedString(DFA88_transitionS[i]);
			}
		}

		public DFA88( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 88;
			this.eot = DFA88_eot;
			this.eof = DFA88_eof;
			this.min = DFA88_min;
			this.max = DFA88_max;
			this.accept = DFA88_accept;
			this.special = DFA88_special;
			this.transition = DFA88_transition;
		}

		public override string Description { get { return "1853:1: sourceElement returns [Statement value] options {k=1; } : ({...}?func= functionDeclaration |stat= statement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition88(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA88_1 = input.LA(1);


				int index88_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (( input.LA(1) == FUNCTION )) ) {s = 38;}

				else if ( (true) ) {s = 2;}


				input.Seek(index88_1);
				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 88, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}

	#endregion DFA

	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _reservedWord_in_token1748 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_token1753 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _punctuator_in_token1758 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _numericLiteral_in_token1763 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _StringLiteral_in_token1768 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _keyword_in_reservedWord1781 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _futureReservedWord_in_reservedWord1786 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NULL_in_reservedWord1791 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _booleanLiteral_in_reservedWord1796 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_keyword1810 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_futureReservedWord1945 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_punctuator2225 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NULL_in_literal2483 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _booleanLiteral_in_literal2492 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _numericLiteral_in_literal2501 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _StringLiteral_in_literal2510 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _RegularExpressionLiteral_in_literal2520 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TRUE_in_booleanLiteral2537 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FALSE_in_booleanLiteral2544 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DecimalLiteral_in_numericLiteral2755 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _OctalIntegerLiteral_in_numericLiteral2764 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _HexIntegerLiteral_in_numericLiteral2773 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _THIS_in_primaryExpression3175 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_primaryExpression3184 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _literal_in_primaryExpression3193 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _arrayLiteral_in_primaryExpression3202 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _objectLiteral_in_primaryExpression3211 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LPAREN_in_primaryExpression3220 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_primaryExpression3224 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_primaryExpression3227 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LBRACK_in_arrayLiteral3253 = new BitSet(new ulong[]{0x4040100A08000020UL,0x400416000460A210UL,0x451410008UL});
		public static readonly BitSet _arrayItem_in_arrayLiteral3259 = new BitSet(new ulong[]{0x8000000UL,0x4000000000000000UL});
		public static readonly BitSet _COMMA_in_arrayLiteral3265 = new BitSet(new ulong[]{0x4040100A08000020UL,0x400416000460A210UL,0x451410008UL});
		public static readonly BitSet _arrayItem_in_arrayLiteral3269 = new BitSet(new ulong[]{0x8000000UL,0x4000000000000000UL});
		public static readonly BitSet _RBRACK_in_arrayLiteral3279 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _assignmentExpression_in_arrayItem3300 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LBRACE_in_objectLiteral3341 = new BitSet(new ulong[]{0x100000000000UL,0x2004000000008010UL,0x400000UL});
		public static readonly BitSet _propertyAssignment_in_objectLiteral3347 = new BitSet(new ulong[]{0x8000000UL,0x2000000000000000UL});
		public static readonly BitSet _COMMA_in_objectLiteral3354 = new BitSet(new ulong[]{0x100000000000UL,0x4000000008010UL,0x400000UL});
		public static readonly BitSet _propertyAssignment_in_objectLiteral3358 = new BitSet(new ulong[]{0x8000000UL,0x2000000000000000UL});
		public static readonly BitSet _RBRACE_in_objectLiteral3368 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _accessor_in_propertyAssignment3391 = new BitSet(new ulong[]{0x100000000000UL,0x4000000008010UL,0x400000UL});
		public static readonly BitSet _propertyName_in_propertyAssignment3399 = new BitSet(new ulong[]{0x0UL,0x4200000UL});
		public static readonly BitSet _formalParameterList_in_propertyAssignment3406 = new BitSet(new ulong[]{0x0UL,0x4200000UL});
		public static readonly BitSet _functionBody_in_propertyAssignment3414 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _propertyName_in_propertyAssignment3424 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_propertyAssignment3428 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_propertyAssignment3432 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_accessor3452 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_propertyName3474 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _StringLiteral_in_propertyName3483 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _numericLiteral_in_propertyName3492 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _primaryExpression_in_memberExpression3518 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _functionExpression_in_memberExpression3527 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _newExpression_in_memberExpression3536 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NEW_in_newExpression3553 = new BitSet(new ulong[]{0x4040100000000000UL,0x4120004608010UL,0x11400008UL});
		public static readonly BitSet _memberExpression_in_newExpression3558 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LPAREN_in_arguments3581 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410009UL});
		public static readonly BitSet _assignmentExpression_in_arguments3587 = new BitSet(new ulong[]{0x8000000UL,0x0UL,0x1UL});
		public static readonly BitSet _COMMA_in_arguments3593 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_arguments3597 = new BitSet(new ulong[]{0x8000000UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_arguments3606 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LBRACE_in_generics3628 = new BitSet(new ulong[]{0x4040100A00000020UL,0x200416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_generics3634 = new BitSet(new ulong[]{0x8000000UL,0x2000000000000000UL});
		public static readonly BitSet _COMMA_in_generics3640 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_generics3644 = new BitSet(new ulong[]{0x8000000UL,0x2000000000000000UL});
		public static readonly BitSet _RBRACE_in_generics3653 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _memberExpression_in_leftHandSideExpression3689 = new BitSet(new ulong[]{0x8000000002UL,0x4600000UL});
		public static readonly BitSet _generics_in_leftHandSideExpression3705 = new BitSet(new ulong[]{0x0UL,0x4200000UL});
		public static readonly BitSet _arguments_in_leftHandSideExpression3714 = new BitSet(new ulong[]{0x8000000002UL,0x4600000UL});
		public static readonly BitSet _LBRACK_in_leftHandSideExpression3725 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_leftHandSideExpression3729 = new BitSet(new ulong[]{0x0UL,0x4000000000000000UL});
		public static readonly BitSet _RBRACK_in_leftHandSideExpression3731 = new BitSet(new ulong[]{0x8000000002UL,0x4600000UL});
		public static readonly BitSet _DOT_in_leftHandSideExpression3744 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _Identifier_in_leftHandSideExpression3748 = new BitSet(new ulong[]{0x8000000002UL,0x4600000UL});
		public static readonly BitSet _leftHandSideExpression_in_postfixExpression3782 = new BitSet(new ulong[]{0x200000002UL,0x200UL});
		public static readonly BitSet _postfixOperator_in_postfixExpression3790 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _INC_in_postfixOperator3813 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DEC_in_postfixOperator3822 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _postfixExpression_in_unaryExpression3845 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _unaryOperator_in_unaryExpression3854 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression3859 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DELETE_in_unaryOperator3877 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _VOID_in_unaryOperator3884 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TYPEOF_in_unaryOperator3891 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _INC_in_unaryOperator3898 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DEC_in_unaryOperator3905 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ADD_in_unaryOperator3914 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _SUB_in_unaryOperator3923 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _INV_in_unaryOperator3930 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NOT_in_unaryOperator3937 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression3965 = new BitSet(new ulong[]{0x1000000002UL,0x280000000UL});
		public static readonly BitSet _MUL_in_multiplicativeExpression3976 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _DIV_in_multiplicativeExpression3985 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _MOD_in_multiplicativeExpression3993 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression4004 = new BitSet(new ulong[]{0x1000000002UL,0x280000000UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression4034 = new BitSet(new ulong[]{0x22UL,0x0UL,0x10000UL});
		public static readonly BitSet _ADD_in_additiveExpression4045 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _SUB_in_additiveExpression4053 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression4064 = new BitSet(new ulong[]{0x22UL,0x0UL,0x10000UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression4095 = new BitSet(new ulong[]{0x2UL,0x0UL,0xA40UL});
		public static readonly BitSet _SHL_in_shiftExpression4106 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _SHR_in_shiftExpression4114 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _SHU_in_shiftExpression4122 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression4133 = new BitSet(new ulong[]{0x2UL,0x0UL,0xA40UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression4164 = new BitSet(new ulong[]{0x2UL,0x30000503UL});
		public static readonly BitSet _LT_in_relationalExpression4175 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _GT_in_relationalExpression4183 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _LTE_in_relationalExpression4191 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _GTE_in_relationalExpression4199 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _INSTANCEOF_in_relationalExpression4207 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _IN_in_relationalExpression4215 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression4226 = new BitSet(new ulong[]{0x2UL,0x30000503UL});
		public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4252 = new BitSet(new ulong[]{0x2UL,0x30000403UL});
		public static readonly BitSet _LT_in_relationalExpressionNoIn4263 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _GT_in_relationalExpressionNoIn4271 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _LTE_in_relationalExpressionNoIn4279 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _GTE_in_relationalExpressionNoIn4287 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _INSTANCEOF_in_relationalExpressionNoIn4295 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4307 = new BitSet(new ulong[]{0x2UL,0x30000403UL});
		public static readonly BitSet _relationalExpression_in_equalityExpression4338 = new BitSet(new ulong[]{0x1000000000002UL,0x90000000000UL,0x10UL});
		public static readonly BitSet _EQ_in_equalityExpression4349 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _NEQ_in_equalityExpression4357 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _SAME_in_equalityExpression4365 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _NSAME_in_equalityExpression4373 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _relationalExpression_in_equalityExpression4384 = new BitSet(new ulong[]{0x1000000000002UL,0x90000000000UL,0x10UL});
		public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4410 = new BitSet(new ulong[]{0x1000000000002UL,0x90000000000UL,0x10UL});
		public static readonly BitSet _EQ_in_equalityExpressionNoIn4421 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _NEQ_in_equalityExpressionNoIn4429 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _SAME_in_equalityExpressionNoIn4437 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _NSAME_in_equalityExpressionNoIn4445 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4456 = new BitSet(new ulong[]{0x1000000000002UL,0x90000000000UL,0x10UL});
		public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4483 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _AND_in_bitwiseANDExpression4489 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4494 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _AND_in_bitwiseANDExpressionNoIn4521 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4549 = new BitSet(new ulong[]{0x2UL,0x0UL,0x10000000000UL});
		public static readonly BitSet _XOR_in_bitwiseXORExpression4555 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4560 = new BitSet(new ulong[]{0x2UL,0x0UL,0x10000000000UL});
		public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583 = new BitSet(new ulong[]{0x2UL,0x0UL,0x10000000000UL});
		public static readonly BitSet _XOR_in_bitwiseXORExpressionNoIn4589 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594 = new BitSet(new ulong[]{0x2UL,0x0UL,0x10000000000UL});
		public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4616 = new BitSet(new ulong[]{0x2UL,0x400000000000UL});
		public static readonly BitSet _OR_in_bitwiseORExpression4622 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4627 = new BitSet(new ulong[]{0x2UL,0x400000000000UL});
		public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649 = new BitSet(new ulong[]{0x2UL,0x400000000000UL});
		public static readonly BitSet _OR_in_bitwiseORExpressionNoIn4655 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660 = new BitSet(new ulong[]{0x2UL,0x400000000000UL});
		public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4686 = new BitSet(new ulong[]{0x2UL,0x100000UL});
		public static readonly BitSet _LAND_in_logicalANDExpression4692 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4697 = new BitSet(new ulong[]{0x2UL,0x100000UL});
		public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718 = new BitSet(new ulong[]{0x2UL,0x100000UL});
		public static readonly BitSet _LAND_in_logicalANDExpressionNoIn4724 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729 = new BitSet(new ulong[]{0x2UL,0x100000UL});
		public static readonly BitSet _logicalANDExpression_in_logicalORExpression4751 = new BitSet(new ulong[]{0x2UL,0x2000000UL});
		public static readonly BitSet _LOR_in_logicalORExpression4757 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _logicalANDExpression_in_logicalORExpression4762 = new BitSet(new ulong[]{0x2UL,0x2000000UL});
		public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784 = new BitSet(new ulong[]{0x2UL,0x2000000UL});
		public static readonly BitSet _LOR_in_logicalORExpressionNoIn4790 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795 = new BitSet(new ulong[]{0x2UL,0x2000000UL});
		public static readonly BitSet _logicalORExpression_in_conditionalExpression4822 = new BitSet(new ulong[]{0x2UL,0x1000000000000000UL});
		public static readonly BitSet _QUE_in_conditionalExpression4828 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_conditionalExpression4833 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_conditionalExpression4835 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_conditionalExpression4840 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logicalORExpressionNoIn_in_conditionalExpressionNoIn4861 = new BitSet(new ulong[]{0x2UL,0x1000000000000000UL});
		public static readonly BitSet _QUE_in_conditionalExpressionNoIn4867 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4872 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_conditionalExpressionNoIn4874 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4879 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditionalExpression_in_assignmentExpression4912 = new BitSet(new ulong[]{0x2000000942UL,0x800500000000UL,0x20000021480UL});
		public static readonly BitSet _assignmentOperator_in_assignmentExpression4924 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_assignmentExpression4931 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_assignmentOperator4946 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditionalExpressionNoIn_in_assignmentExpressionNoIn5026 = new BitSet(new ulong[]{0x2000000942UL,0x800500000000UL,0x20000021480UL});
		public static readonly BitSet _assignmentOperator_in_assignmentExpressionNoIn5038 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_assignmentExpressionNoIn5045 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _assignmentExpression_in_expression5077 = new BitSet(new ulong[]{0x8000002UL});
		public static readonly BitSet _COMMA_in_expression5083 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_expression5089 = new BitSet(new ulong[]{0x8000002UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5117 = new BitSet(new ulong[]{0x8000002UL});
		public static readonly BitSet _COMMA_in_expressionNoIn5123 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5129 = new BitSet(new ulong[]{0x8000002UL});
		public static readonly BitSet _SEMIC_in_semic5163 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _EOF_in_semic5168 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _RBRACE_in_semic5173 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _EOL_in_semic5180 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _MultiLineComment_in_semic5184 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _block_in_statement5218 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _functionDeclaration_in_statement5229 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statementTail_in_statement5236 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _variableStatement_in_statementTail5259 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _emptyStatement_in_statementTail5266 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expressionStatement_in_statementTail5273 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ifStatement_in_statementTail5280 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _iterationStatement_in_statementTail5287 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _continueStatement_in_statementTail5294 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _breakStatement_in_statementTail5301 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _returnStatement_in_statementTail5308 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _withStatement_in_statementTail5315 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _labelledStatement_in_statementTail5322 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _switchStatement_in_statementTail5329 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _throwStatement_in_statementTail5336 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _tryStatement_in_statementTail5343 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LBRACE_in_block5373 = new BitSet(new ulong[]{0x4840104A20004020UL,0xA00416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_block5376 = new BitSet(new ulong[]{0x4840104A20004020UL,0xA00416000460A230UL,0x6673490028UL});
		public static readonly BitSet _RBRACE_in_block5382 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _VAR_in_variableStatement5408 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _variableDeclaration_in_variableStatement5412 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _COMMA_in_variableStatement5418 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _variableDeclaration_in_variableStatement5424 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_variableStatement5432 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_variableDeclaration5456 = new BitSet(new ulong[]{0x802UL});
		public static readonly BitSet _ASSIGN_in_variableDeclaration5462 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpression_in_variableDeclaration5467 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_variableDeclarationNoIn5495 = new BitSet(new ulong[]{0x802UL});
		public static readonly BitSet _ASSIGN_in_variableDeclarationNoIn5501 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_variableDeclarationNoIn5506 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _SEMIC_in_emptyStatement5531 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expression_in_expressionStatement5556 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_expressionStatement5558 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IF_in_ifStatement5587 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_ifStatement5589 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_ifStatement5591 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_ifStatement5595 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_ifStatement5599 = new BitSet(new ulong[]{0x200000000002UL});
		public static readonly BitSet _ELSE_in_ifStatement5607 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_ifStatement5611 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _doStatement_in_iterationStatement5641 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _whileStatement_in_iterationStatement5650 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forStatement_in_iterationStatement5660 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DO_in_doStatement5679 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_doStatement5681 = new BitSet(new ulong[]{0x0UL,0x0UL,0x2000000000UL});
		public static readonly BitSet _WHILE_in_doStatement5683 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_doStatement5685 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_doStatement5687 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_doStatement5689 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_doStatement5691 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WHILE_in_whileStatement5711 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_whileStatement5714 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_whileStatement5717 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_whileStatement5719 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_whileStatement5722 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FOR_in_forStatement5741 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_forStatement5744 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x651410028UL});
		public static readonly BitSet _forControl_in_forStatement5749 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_forStatement5754 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_forStatement5759 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forControlVar_in_forControl5778 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forControlExpression_in_forControl5787 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forControlSemic_in_forControl5796 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _VAR_in_forControlVar5819 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _variableDeclarationNoIn_in_forControlVar5823 = new BitSet(new ulong[]{0x8000000UL,0x100UL,0x20UL});
		public static readonly BitSet _IN_in_forControlVar5837 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_forControlVar5841 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _COMMA_in_forControlVar5866 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _variableDeclarationNoIn_in_forControlVar5872 = new BitSet(new ulong[]{0x8000000UL,0x0UL,0x20UL});
		public static readonly BitSet _SEMIC_in_forControlVar5883 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410028UL});
		public static readonly BitSet _expression_in_forControlVar5889 = new BitSet(new ulong[]{0x0UL,0x0UL,0x20UL});
		public static readonly BitSet _SEMIC_in_forControlVar5897 = new BitSet(new ulong[]{0x4040100A00000022UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_forControlVar5902 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expressionNoIn_in_forControlExpression5941 = new BitSet(new ulong[]{0x0UL,0x100UL,0x20UL});
		public static readonly BitSet _IN_in_forControlExpression5958 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_forControlExpression5962 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _SEMIC_in_forControlExpression5985 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410028UL});
		public static readonly BitSet _expression_in_forControlExpression5991 = new BitSet(new ulong[]{0x0UL,0x0UL,0x20UL});
		public static readonly BitSet _SEMIC_in_forControlExpression5999 = new BitSet(new ulong[]{0x4040100A00000022UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_forControlExpression6004 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _SEMIC_in_forControlSemic6040 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410028UL});
		public static readonly BitSet _expression_in_forControlSemic6046 = new BitSet(new ulong[]{0x0UL,0x0UL,0x20UL});
		public static readonly BitSet _SEMIC_in_forControlSemic6054 = new BitSet(new ulong[]{0x4040100A00000022UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_forControlSemic6059 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CONTINUE_in_continueStatement6093 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800008000UL,0x20UL});
		public static readonly BitSet _Identifier_in_continueStatement6101 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_continueStatement6108 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _BREAK_in_breakStatement6138 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800008000UL,0x20UL});
		public static readonly BitSet _Identifier_in_breakStatement6146 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_breakStatement6153 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _RETURN_in_returnStatement6183 = new BitSet(new ulong[]{0x4040900A08000020UL,0x200416080460A210UL,0x451410028UL});
		public static readonly BitSet _expression_in_returnStatement6191 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_returnStatement6197 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WITH_in_withStatement6218 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_withStatement6221 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_withStatement6226 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_withStatement6228 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_withStatement6233 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _SWITCH_in_switchStatement6260 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_switchStatement6262 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_switchStatement6264 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_switchStatement6268 = new BitSet(new ulong[]{0x0UL,0x200000UL});
		public static readonly BitSet _LBRACE_in_switchStatement6273 = new BitSet(new ulong[]{0x400200000UL,0x2000000000000000UL});
		public static readonly BitSet _defaultClause_in_switchStatement6280 = new BitSet(new ulong[]{0x400200000UL,0x2000000000000000UL});
		public static readonly BitSet _caseClause_in_switchStatement6286 = new BitSet(new ulong[]{0x400200000UL,0x2000000000000000UL});
		public static readonly BitSet _RBRACE_in_switchStatement6293 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CASE_in_caseClause6316 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_caseClause6319 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_caseClause6323 = new BitSet(new ulong[]{0x4840104A20004022UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_caseClause6327 = new BitSet(new ulong[]{0x4840104A20004022UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _DEFAULT_in_defaultClause6352 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_defaultClause6355 = new BitSet(new ulong[]{0x4840104A20004022UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_defaultClause6359 = new BitSet(new ulong[]{0x4840104A20004022UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _Identifier_in_labelledStatement6386 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _COLON_in_labelledStatement6388 = new BitSet(new ulong[]{0x4840104A20004020UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _statement_in_labelledStatement6392 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _THROW_in_throwStatement6418 = new BitSet(new ulong[]{0x4040100A00000020UL,0x416000460A210UL,0x451410008UL});
		public static readonly BitSet _expression_in_throwStatement6425 = new BitSet(new ulong[]{0x800008000000UL,0x2000000800000000UL,0x20UL});
		public static readonly BitSet _semic_in_throwStatement6429 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TRY_in_tryStatement6454 = new BitSet(new ulong[]{0x0UL,0x200000UL});
		public static readonly BitSet _block_in_tryStatement6459 = new BitSet(new ulong[]{0x200000000400000UL});
		public static readonly BitSet _catchClause_in_tryStatement6468 = new BitSet(new ulong[]{0x200000000400002UL});
		public static readonly BitSet _finallyClause_in_tryStatement6475 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _finallyClause_in_tryStatement6485 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CATCH_in_catchClause6505 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _LPAREN_in_catchClause6508 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _Identifier_in_catchClause6513 = new BitSet(new ulong[]{0x0UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_catchClause6515 = new BitSet(new ulong[]{0x0UL,0x200000UL});
		public static readonly BitSet _block_in_catchClause6518 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FINALLY_in_finallyClause6536 = new BitSet(new ulong[]{0x0UL,0x200000UL});
		public static readonly BitSet _block_in_finallyClause6539 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FUNCTION_in_functionDeclaration6571 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _Identifier_in_functionDeclaration6576 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _formalParameterList_in_functionDeclaration6586 = new BitSet(new ulong[]{0x0UL,0x4200000UL});
		public static readonly BitSet _functionBody_in_functionDeclaration6595 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FUNCTION_in_functionExpression6622 = new BitSet(new ulong[]{0x0UL,0x4008000UL});
		public static readonly BitSet _Identifier_in_functionExpression6627 = new BitSet(new ulong[]{0x0UL,0x4000000UL});
		public static readonly BitSet _formalParameterList_in_functionExpression6634 = new BitSet(new ulong[]{0x0UL,0x4200000UL});
		public static readonly BitSet _functionBody_in_functionExpression6638 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LPAREN_in_formalParameterList6663 = new BitSet(new ulong[]{0x0UL,0x8000UL,0x1UL});
		public static readonly BitSet _Identifier_in_formalParameterList6669 = new BitSet(new ulong[]{0x8000000UL,0x0UL,0x1UL});
		public static readonly BitSet _COMMA_in_formalParameterList6675 = new BitSet(new ulong[]{0x0UL,0x8000UL});
		public static readonly BitSet _Identifier_in_formalParameterList6679 = new BitSet(new ulong[]{0x8000000UL,0x0UL,0x1UL});
		public static readonly BitSet _RPAREN_in_formalParameterList6690 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LBRACE_in_functionBody6713 = new BitSet(new ulong[]{0x4840104A20004020UL,0xA00416000460A230UL,0x6673490028UL});
		public static readonly BitSet _sourceElement_in_functionBody6716 = new BitSet(new ulong[]{0x4840104A20004020UL,0xA00416000460A230UL,0x6673490028UL});
		public static readonly BitSet _RBRACE_in_functionBody6723 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _sourceElement_in_program6752 = new BitSet(new ulong[]{0x4840104A20004022UL,0x800416000460A230UL,0x6673490028UL});
		public static readonly BitSet _functionDeclaration_in_sourceElement6793 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statement_in_sourceElement6802 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
