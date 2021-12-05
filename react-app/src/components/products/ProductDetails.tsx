import { observer } from 'mobx-react-lite'
import React from 'react'
import { Container, Content, Panel } from 'rsuite'

export default observer(function ProductDetails(){

    return (
        <Container>
            <Content>
                <Panel header="Produkt">
                    <h2>eloo</h2>
                    <h2>o co tu kurwa chodzi</h2>
                </Panel>
            </Content>              
        </Container>
    )
})