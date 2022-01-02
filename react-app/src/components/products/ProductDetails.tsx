import { observer } from 'mobx-react-lite';
import { Container, Content, FlexboxGrid, Form, Panel , Grid, Col , Row, Button, ButtonToolbar, Loader , InputPicker} from 'rsuite';
import { useStore } from '../../stores/store';
import { useParams } from 'react-router-dom';
import { useEffect , useState } from 'react';
import { ProductFormInitialValue } from '../../models/product';

export default observer(function ProductDetails(){
   
    const styles = {
        fontSize: 18,
        fontWeight: 'bold'
    };

    const { productStore , productCategoryStore } = useStore();
    const { getProduct , loadingProduct } = productStore;
    const { getProductCategoryDropdownItems , loadingProductCategory , productCategoryDropdownItems } = productCategoryStore;
    const { id } = useParams<string>();
    const [ product , setProduct ] = useState<ProductFormInitialValue>(new ProductFormInitialValue());
    const [ editProduct , setEditProduct ] = useState<boolean>(false);

    useEffect(() => {
        if(id){
            getProduct(id).then(product => setProduct(new ProductFormInitialValue(product)));
            getProductCategoryDropdownItems();
        }
    }, [id , getProduct])

    if (loadingProduct && loadingProductCategory) return <Loader backdrop content="ładowanie szczegółów produktu..." vertical />

    return (
        <Container>
            <Content>
                <FlexboxGrid justify="center" align="top">
                    <FlexboxGrid.Item colspan={12}>
                        <Panel bordered>
                            <Form 
                            plaintext={!editProduct}
                            formValue={product}
                            onChange={product => setProduct(new ProductFormInitialValue(product))}
                            >

                                <Form.Group style={styles}>
                                    <Form.Control controlId="name" name="name"/>
                                    <hr />
                                </Form.Group>

                                <Grid>
                                    <Row>
                                        <Col xs={24} sm={12} md={7}>

                                            <Form.Group controlId="categoryId">
                                                <Form.ControlLabel>Nazwa kategorii:</Form.ControlLabel>
                                                <Form.Control name="categoryId" accepter={InputPicker} data={productCategoryDropdownItems}/>
                                            </Form.Group>

                                            <Form.Group controlId="createdBy">
                                                <Form.ControlLabel>Utworzone przez:</Form.ControlLabel>
                                                <Form.Control name="createdBy" value={product.createdBy} plaintext={true}/>
                                            </Form.Group>

                                            <Form.Group controlId="createdBy">
                                                <Form.ControlLabel>Data utworzenia:</Form.ControlLabel>
                                                <Form.Control name="createdBy" value={product.createdBy} plaintext={true}/>
                                            </Form.Group>

                                        </Col>

                                        <Col xs={24} sm={12} md={7}>

                                            <Form.Group controlId="producerName">
                                                <Form.ControlLabel>Nazwa producenta:</Form.ControlLabel>
                                                <Form.Control name="producerName" accepter={InputPicker} data={productCategoryDropdownItems}/> 
                                            </Form.Group>

                                            <Form.Group controlId="updatedBy">
                                                <Form.ControlLabel>Edytowane przez:</Form.ControlLabel>
                                                <Form.Control name="updatedBy" plaintext={true}/>
                                            </Form.Group>

                                            <Form.Group controlId="updatedBy">
                                                <Form.ControlLabel>Edytowane przez:</Form.ControlLabel>
                                                <Form.Control name="updatedBy" plaintext={true}/>
                                            </Form.Group>

                                        </Col>
                                        
                                    </Row>
                                </Grid>
                                <br />
                                <FlexboxGrid justify="end">
                                    <ButtonToolbar>
                                        {
                                        !editProduct &&
                                            <Button color="blue" appearance="primary" onClick={() => setEditProduct(!editProduct)}>Edytuj produkt</Button>}
                                        {
                                        editProduct &&
                                        <> 
                                            <Button color="blue" appearance="primary">Zapisz produkt</Button>
                                            <Button color="blue" appearance="ghost" onClick={() => setEditProduct(!editProduct)}>Anuluj</Button> 
                                        </>
                                        }
                                    </ButtonToolbar>
                                </FlexboxGrid>
                            </Form>
                        </Panel>
                    </FlexboxGrid.Item>
                </FlexboxGrid>  
            </Content>              
        </Container>
    )
})