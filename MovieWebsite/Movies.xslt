<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="xml" indent="yes"/>

	<xsl:template match="/ | node()">
		<xsl:copy>
			<table class ="table table-striped">
				<thead class ="thead-dark">
					<tr>
						<th>Id</th>
						<th>Title</th>
						<th>Director</th>
						<th>Synopsis</th>
					</tr>
				</thead>
				<xsl:for-each select ="movies/movie">
					<tr>
						<td>
							<xsl:value-of select = "Id"/>
						</td>
						<td>
							<xsl:value-of select = "title"/>
						</td>
						<td>
							<xsl:value-of select = "director"/>
						</td>
						<td>
							<xsl:value-of select = "synopsis"/>
						</td>
					</tr>
				</xsl:for-each>
			</table>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
