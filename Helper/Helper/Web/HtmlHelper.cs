using System;
using System.IO;
using System.Xml;
using Sgml;

namespace Helper {
    /// <summary>
    /// html处理相关类。
    /// </summary>
    public class HtmlHelper {
        /// <summary>
        /// 把Html代码的标签补全,如 &lt;p&gt;some text 补全为 &lt;p&gt;some text&lt;/p&gt;
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlTagComplete(string input) {
            return ProcessHtml(input, true, false, 0, null);
        }

        /// <summary>
        /// 清除Html代码中的标签, 如把 &lt;p&gt;some text&lt;/p&gt; 变为 some text
        /// </summary>
        /// <param name="input"></param>
        /// <returns>清除标签后的文本</returns>
        public static string ClearHtmlTag(string input) {
            return ProcessHtml(input, true, true, 0, null);
        }

        /// <summary>
        /// 处理html代码
        /// </summary>
        /// <param name="input">等处理的字符串</param>
        /// <param name="skipHtmlNode">是否跳过html节点</param>
        /// <param name="clearTag">是否清除html tag，只输出纯文本</param>
        /// <param name="maxCount">copy的文本的字符数，如果maxCount&lt;=0，copy全部文本</param>
        /// <param name="endStr">如果只copy了部分文本，部分文本后的附加字符，如...</param>
        /// <returns>处理后的html代码</returns>
        public static string ProcessHtml(string input, bool skipHtmlNode, bool clearTag, int maxCount, string endStr) {
            if(string.IsNullOrEmpty(input)) {
                return input;
            }
            StringWriter output = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(output);
            writer.Formatting = Formatting.Indented;

            SgmlReader reader = new SgmlReader();
            reader.DocType = "HTML";
            reader.InputStream = new StringReader(input);

            WriteXml(writer, reader, true, skipHtmlNode, clearTag, maxCount, endStr);

            writer.Flush();
            writer.Close();

            reader.Close();

            return output.ToString();
        }

        /// <summary>
        /// Copies everything from the reader object to the writer instance
        /// </summary>
        /// <param name="writer">The XmlTextWriter to copy to.</param>
        /// <param name="reader">The XmlReader to read from.</param>
        /// <param name="defattr">true to copy the default attributes from the XmlReader; otherwise, false.</param>
        /// <param name="skipHtmlNode">是否跳过html节点</param>
        /// <param name="clearTag">是否清除html tag，只输出纯文本</param>
        /// <param name="maxCount">copy的文本的字符数，如果maxCount&lt;=0，copy全部文本</param>
        /// <param name="endStr">如果只copy了部分文本，部分文本后的附加字符，如...</param>
        public static void WriteXml(XmlTextWriter writer, XmlReader reader, bool defattr, bool skipHtmlNode, bool clearTag, int maxCount, string endStr) {
            if(writer == null) {
                throw new ArgumentNullException("writer");
            }
            if(reader == null) {
                throw new ArgumentNullException("reader");
            }
            int count = 0;
            bool finished = false;
            reader.Read();
            while(!finished && !reader.EOF) {
                char[] writeNodeBuffer = null;
                bool canReadValueChunk = reader.CanReadValueChunk;
                int num = (reader.NodeType == XmlNodeType.None) ? -1 : reader.Depth;
                do {
                    if(clearTag && reader.NodeType != XmlNodeType.Text) {
                        writer.WriteString(" ");
                        continue;
                    }
                    switch(reader.NodeType) {
                        case XmlNodeType.Element:
                            if(skipHtmlNode && reader.Name != null && reader.Name.ToLower() == "html") {
                                break;
                            }
                            writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                            writer.WriteAttributes(reader, defattr);
                            if(reader.IsEmptyElement) {
                                writer.WriteEndElement();
                            }
                            break;

                        case XmlNodeType.Text:
                            int num2;
                            if(!canReadValueChunk) {
                                if(maxCount > 0) {
                                    string value = reader.Value;
                                    if((count + value.Length) >= maxCount) {
                                        value = value.Substring(0, (maxCount - count));
                                        if(!String.IsNullOrEmpty(endStr)) value += endStr;
                                        finished = true;
                                    }
                                    writer.WriteString(value);
                                    count += value.Length;
                                }
                                else {
                                    writer.WriteString(reader.Value);
                                }
                                break;
                            }
                            if(writeNodeBuffer == null) {
                                writeNodeBuffer = new char[0x400];
                            }
                            while((num2 = reader.ReadValueChunk(writeNodeBuffer, 0, 0x400)) > 0) {
                                if(maxCount > 0) {
                                    if((count + num2) >= maxCount) {
                                        num2 = maxCount - count;
                                        writer.WriteChars(writeNodeBuffer, 0, num2);
                                        if(!String.IsNullOrEmpty(endStr))
                                            writer.WriteString(endStr);
                                        finished = true;
                                    }
                                    else {
                                        writer.WriteChars(writeNodeBuffer, 0, num2);
                                    }
                                    count += num2;
                                }
                                else {
                                    writer.WriteChars(writeNodeBuffer, 0, num2);
                                }
                            }
                            break;

                        case XmlNodeType.CDATA:
                            writer.WriteCData(reader.Value);
                            break;

                        case XmlNodeType.EntityReference:
                            writer.WriteEntityRef(reader.Name);
                            break;

                        case XmlNodeType.ProcessingInstruction:
                        case XmlNodeType.XmlDeclaration:
                            writer.WriteProcessingInstruction(reader.Name, reader.Value);
                            break;

                        case XmlNodeType.Comment:
                            writer.WriteComment(reader.Value);
                            break;

                        case XmlNodeType.DocumentType:
                            writer.WriteDocType(reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"), reader.Value);
                            break;

                        case XmlNodeType.Whitespace:
                        case XmlNodeType.SignificantWhitespace:
                            writer.WriteWhitespace(reader.Value);
                            break;

                        case XmlNodeType.EndElement:
                            if(skipHtmlNode && reader.Name != null && reader.Name.ToLower() == "html") {
                                break;
                            }
                            writer.WriteFullEndElement();
                            break;
                    }
                }
                while(!finished && reader.Read() && ((num < reader.Depth) || ((num == reader.Depth) && (reader.NodeType == XmlNodeType.EndElement))));
            }
        }
    }

}
